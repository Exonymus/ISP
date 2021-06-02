using System;

namespace Lab7
{
    class Converter : IComparable, IEquatable<Converter>
    {
        private int _num;
        private int _denom;
        private readonly bool changed = false;

        public Converter(int _num, int _denom)
        {
            if (!changed)
            {
                int devide = GreatDivisor(_num, _denom);
                this._denom = _denom / devide;
                this._num = _num / devide;
                changed = true;
            }
            else
            {
                this._denom = _denom;
                this._num = _num;
            }
        }

        public int GreatDivisor(int _num, int _denom)
        {
            if (_num % _denom == 0)
                return _denom;

            if (_denom % _num == 0)
                return _num;

            if (_num > _denom)
                return GreatDivisor(_num % _denom, _denom);

            return GreatDivisor(_num, _denom % _num);
        }

        public static Converter operator +(Converter num1, Converter num2)
        {
            int num = num1._num * num2._denom + num2._num * num1._denom;
            int denom = num1._denom * num2._denom;

            Converter result = new Converter(num, denom);

            return result;
        }

        public static Converter operator -(Converter num1, Converter num2)
        {
            num2._num = (-num2._num);
            Converter temp = num1 + num2;
            num2._num = (-num2._num);

            return temp;
        }

        public static Converter operator *(Converter num1, Converter num2)
        {
            int num = num1._num * num2._num;
            int denom = num1._denom * num2._denom;

            Converter result = new Converter(num, denom);

            return result;
        }

        public static Converter operator /(Converter num1, Converter num2)
        {
            int num = num1._num * num2._denom;
            int denom = num1._denom * num2._num;

            Converter result = new Converter(num, denom);

            return result;
        }

        public static bool operator <(Converter num1, Converter num2)
        {
            if (!num1.changed && !num2.changed)
            {
                num1._num *= num2._denom;
                num2._num *= num1._denom;
                num1._denom *= num2._denom;
                num2._denom = num1._denom;
                return num1._num < num2._num;
            }

            return num1._num < num2._num;

        }

        public static bool operator >(Converter num1, Converter num2)
        {
            if (!num1.changed && !num2.changed)
            {
                num1._num *= num2._denom;
                num2._num *= num1._denom;
                num1._denom *= num2._denom;
                num2._denom = num1._denom;
            }

            return num1._num > num2._num;
        }

        public override string ToString()
        {
            string res = $"{_num}/{_denom}";

            return res;
        }

        public double ToDouble()
        {
            double value = (double)_num / _denom;

            return value;
        }

        public int CompareTo(object obj)
        {
            Converter another = obj as Converter;

            if (another.ToDouble() - (double)_num / _denom < 2e-10)
                return 1;

            if ((double)_num / _denom - another.ToDouble() < 2e-10)
                return -1;

            return 0;
        }

        public bool Equals(Converter other)
        {
            if (other == null)
                return false;
            
            return _num * other._denom == other._num * _denom;
        }

        public static bool ToConverter(string conv, out Converter obj)
        {

            obj = null;
            string[] parts = conv.Split('/');

            if (parts.Length == 2 && Int32.TryParse(parts[0], out int part1) && Int32.TryParse(parts[1], out int part2) && part1 != 0 && part2 > 0)
            {
                obj = new Converter(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]));
                return true;
            }
            else if (parts.Length == 1)
            {
                parts = conv.Split(',');
                if (parts.Length == 2 && Int32.TryParse(parts[0], out part1))
                {
                    for (int i = 0; i < parts[1].Length; i++)
                    {
                        if (parts[0][0] == '-')
                        {
                            part1 = part1 * 10 - (int)Char.GetNumericValue(parts[1][i]);
                        }
                        else
                        {
                            part1 = part1 * 10 + (int)Char.GetNumericValue(parts[1][i]);
                        }
                    }
                    obj = new Converter(part1, (int)Math.Pow(10, parts[1].Length));
                    return true;
                }
                else if (parts.Length == 1 && Int32.TryParse(parts[0], out part1))
                {
                    obj = new Converter(part1, 1);
                    return true;
                }
            }

            return false;
        }

        public static explicit operator double(Converter value)
        {
            return value._num / (double)value._denom;
        }

        public static implicit operator int(Converter value)
        {
            return value._num / value._denom;
        }

    }
}