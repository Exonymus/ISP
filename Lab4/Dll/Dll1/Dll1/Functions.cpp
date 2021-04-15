#include "pch.h"
#include <utility>
#include <limits.h>
#include "Functions.h"

double __stdcall Max(double a, double b)
{
	if (a > b)
		return a;
	else
		return b;
}
int __stdcall Floor(double a)
{
	return (int) a;
}

double __stdcall Abs(double a)
{
	if (a < 0)
		return -a;
	else 
		return a;
}

double __cdecl Pow(double a, int b)
{
	if (b == 1)
		return a;
	if (!b)
		return 1;
	return a * Pow(a, --b);
}

double __cdecl Percentage(double a, double b)
{
	return a / b * 100;
}

int __cdecl Fact(int a)
{
	if (a < 0)
		return 0;
	if (a == 0)
		return 1;
	else
		return a * Fact(a - 1);
}