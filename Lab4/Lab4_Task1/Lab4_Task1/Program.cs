using System;
using System.Runtime.InteropServices;

namespace Lab4_Task1
{
    class Program
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEM_INFO
        {
            public ushort processorArchitecture;
            public ushort processorLevel;
            public ushort processorRevision;
            public uint numberOfProcessors;
            public uint pageSize;
            public uint processorType;
            ushort reserved;
            public IntPtr minimumApplicationAddress;
            public IntPtr maximumApplicationAddress;
            public IntPtr activeProcessorMask;
            public uint allocationGranularity;
            
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void GetSystemInfo(out SYSTEM_INFO Info);

        public static void PrintProcessorArchitecture(ushort wProcessorArchitecture)
        {
            Console.Write("Архитектура процессорра: ");
            switch (wProcessorArchitecture)
            {
                case 0:
                    Console.WriteLine("Intel x86");
                    break;
                case 6:
                    Console.WriteLine("Intel x64 (на базе Intel Itanium)");
                    break;
                case 9:
                    Console.WriteLine("(AMD или Intel) x64");
                    break;
                case 5:
                    Console.WriteLine("ARM");
                    break;
                case 12:
                    Console.WriteLine("ARM64");
                    break;
                default:
                    Console.WriteLine("Неизвестна");
                    break;
            }
        }

        public static void PrintSystemInfo()
        {
            SYSTEM_INFO info;
            GetSystemInfo(out info);

            PrintProcessorArchitecture(info.processorArchitecture);
            Console.WriteLine("Объем страницы: {0} KB", info.pageSize / 1024);
            Console.WriteLine("Гранулярность распределения: {0}", info.allocationGranularity);
            Console.WriteLine("Тип процессора: {0}", info.processorType);
            Console.WriteLine("Уровень процессора: {0}", info.processorLevel);
            Console.WriteLine("Ревизия процессора: {0}", info.processorRevision);
            Console.WriteLine("Кол-во логических процессоров в данной группе: {0}", info.numberOfProcessors);

        }

        public static void Main(string[] args)
        {
            Console.WriteLine("\tОсновные характеристики системы:");

            PrintPhysicallyInstalledSystemMemory();

            PrintSystemInfo();

            PrintGlobalMemoryStatus();
            PrintDiskFreeSpace("C:\\");
            PrintDiskFreeSpace("D:\\");

            PrintSystemPowerStatus();


        }

        [StructLayout(LayoutKind.Sequential)]
        public struct LPSYSTEM_POWER_STATUS
        {
            public byte ACLineStatus;
            public byte BatteryFlag;
            public byte BatteryLifePercent;
            public byte SystemStatusFlag;
            public int BatteryLifeTime;
            public int BatteryFullLifeTime;
        }

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetSystemPowerStatus(out LPSYSTEM_POWER_STATUS lpSystemPowerStatus);

        static void PrintSystemPowerStatus()
        {
            LPSYSTEM_POWER_STATUS lpSystemPowerStatus;
            GetSystemPowerStatus(out lpSystemPowerStatus);
            PrintACLineStatus(lpSystemPowerStatus.ACLineStatus);
            PrintBatteryFlag(lpSystemPowerStatus.BatteryFlag);
            PrintBatteryLifePercent(lpSystemPowerStatus.BatteryLifePercent);
            SystemStatusFlag(lpSystemPowerStatus.SystemStatusFlag);
            PrintLifeTime(lpSystemPowerStatus.BatteryLifeTime, "Время жизни батареи:");
            PrintLifeTime(lpSystemPowerStatus.BatteryFullLifeTime, "Времени до конца зарядки:");
        }

        static void PrintACLineStatus(byte ACLineStatus)
        {
            Console.Write("\nСтатус зарядного устройства: ");
            switch (ACLineStatus)
            {
                case 0:
                    Console.WriteLine("Не подключено");
                    break;
                case 1:
                    Console.WriteLine("Подключено");
                    break;
            }
        }

        static void PrintBatteryFlag(byte BatteryFlag)
        {
            Console.WriteLine(BatteryFlag);
            Console.Write("Состояние Батареи: ");
            switch (BatteryFlag)
            {
                case 0:
                    Console.WriteLine("Нормальное (Уровень заряда в пределах от 33% до 65%)");
                    break;
                case 1:
                    Console.WriteLine("Хорошее (Уровень заряда > 66%)");
                    break;
                case 2:
                    Console.WriteLine("Нуждается в зарядке (Уровень заряда < 33%)");
                    break;
                case 4:
                    Console.WriteLine("Нуждается в срочной зарядке (Уровень заряда < 5%)");
                    break;
                case 8:
                    Console.WriteLine("Батарея устройства на зарядке");
                    break;
                case 128:
                    Console.WriteLine("Батарея устройства отсуствует");
                    break;
                case 255:
                    Console.WriteLine("Неизвестен");
                    break;
            }
        }

        static void PrintBatteryLifePercent(byte BatteryLifePercent)
        {
            Console.Write("Заряд Батареи: ");
            if (BatteryLifePercent == 255)
                Console.WriteLine("Статус неизвестен");
            else
                Console.WriteLine(BatteryLifePercent + "%");
        }

        
        static void SystemStatusFlag(byte SystemStatusFlag)
        {
            Console.Write("Режим энергосбережения: ");
            if (SystemStatusFlag == 0)
                Console.WriteLine("Отключен");
            else
                Console.WriteLine("Включен");
        }

        static void PrintLifeTime(long LifeTime, string Action)
        {
            if (LifeTime == -1)
                Console.WriteLine(Action + " Время зарядки неизвестно, или устройство не подключено к зарядке");
            else
                Console.WriteLine(Action + " Оставшееся время работы: {0}h {1}m", LifeTime / 3600, LifeTime / 60 % 60);
        }

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetPhysicallyInstalledSystemMemory(out ulong TotalMemoryInKilobytes);

        static void PrintPhysicallyInstalledSystemMemory()
        {
            ulong memoryInKilobytes;
            GetPhysicallyInstalledSystemMemory(out memoryInKilobytes);
            Console.WriteLine(memoryInKilobytes / 1024 / 1024 + " GB RAM установленно.\n");
        }

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetDiskFreeSpaceEx(string lpDirectoryName,
                                              out ulong lpFreeBytesAvailable,
                                              out ulong lpTotalNumberOfBytes,
                                              out ulong lpTotalNumberOfFreeBytes);

        static void PrintDiskFreeSpace(string lpDirectoryName)
        {
            Console.WriteLine("\nИнформация о диске: {0}", lpDirectoryName);

            ulong FreeBytesAvailable;
            ulong TotalNumberOfBytes;
            ulong TotalNumberOfFreeBytes;

            GetDiskFreeSpaceEx(lpDirectoryName, out FreeBytesAvailable,
                                                out TotalNumberOfBytes,
                                                out TotalNumberOfFreeBytes);

            Console.WriteLine("Свободно: {0} GB", FreeBytesAvailable / 1024 / 1024 / 1024);
            Console.WriteLine("Всего: {0} GB", TotalNumberOfBytes / 1024 / 1024 / 1024);
            Console.WriteLine("Всего памяти свободно: {0} GB", TotalNumberOfFreeBytes / 1024 / 1024 / 1024);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MEMORYSTATUSEX
        {
            public uint dwLength;
            public uint dwMemoryLoad;
            public ulong ullTotalPhys;
            public ulong ullAvailPhys;
            public ulong ullTotalPageFile;
            public ulong ullAvailPageFile;
            public ulong ullTotalVirtual;
            public ulong ullAvailVirtual;
            public ulong ullAvailExtendedVirtual;
        }

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern void GlobalMemoryStatusEx(out MEMORYSTATUSEX lpBuffer);

        public static void PrintGlobalMemoryStatus()
        {
            MEMORYSTATUSEX memStatus;
            memStatus.dwLength = (uint)Marshal.SizeOf(typeof(MEMORYSTATUSEX));
            GlobalMemoryStatusEx(out memStatus);

            Console.WriteLine("\nИспользуется {0}% памяти.",
                               memStatus.dwMemoryLoad);
            Console.WriteLine("Установленно {0} MB физической памяти.",
                               memStatus.ullTotalPhys / 1024 / 1024);
            Console.WriteLine("Свободно: {0} МВ физической памяти.\n",
                               memStatus.ullAvailPhys / 1024);
            Console.WriteLine("Всего: {0} KB страничного файла.",
                               memStatus.ullTotalPageFile / 1024);
            Console.WriteLine("Свободно: {0} KB страничного файла.\n",
                               memStatus.ullAvailPageFile / 1024);
            Console.WriteLine("Установленно {0} KB виртуальной памяти.",
                               memStatus.ullTotalVirtual / 1024);
            Console.WriteLine("Свободно: {0} KB виртуальной памяти.\n",
                               memStatus.ullAvailVirtual / 1024);
            Console.WriteLine("Свободно: {0} KB расширенной памяти.",
                               memStatus.ullAvailExtendedVirtual / 1024);
        }
    }
}
