#pragma once
#ifdef FUNCTIONS_EXPORTS
#define FUNCTIONS_API __declspec(dllexport)
#else
#define FUNCTIONS_API __declspec(dllimport)
#endif


extern "C" FUNCTIONS_API  double __stdcall Max(double a, double b);

extern "C" FUNCTIONS_API double __stdcall Abs(double a);

extern "C" FUNCTIONS_API int __stdcall Floor(double a);

extern "C" FUNCTIONS_API double __cdecl Pow(double a, int b);

extern "C" FUNCTIONS_API double __cdecl Percentage(double a, double b);

extern "C" FUNCTIONS_API int __cdecl Fact(int a);
