#pragma comment(linker, "/STACK:64000000")
#include <stdlib.h>
#include <fstream>
#include <iostream>
#include <vector>
#include <stdlib.h>
#include <stdio.h>
#include <cstring>
#include <map>
#include <set>
#include <string>
#include <deque>
#include <algorithm>
#define _USE_MATH_DEFINES
#include <math.h>
#include <assert.h>

using namespace std;

#define forn(i,n) for (int i=0;i<n;i++)
#define rforn(i,n) for (int i=n-1;i>=0;i--)
#define mp make_pair
#define __int64 long long
#define LL long long

void smain();

int main() {
	ios_base::sync_with_stdio(false);
#ifdef _DEBUG
	freopen("input.txt", "r", stdin);
	//freopen("output.txt", "w", stdout);
#endif

	smain();

	return 0;
}

struct Number
{
	string s;
	int l;
} numbers[200000];

bool operator < (Number a, Number b)
{
	if (a.l < b.l)
	{
		return true;
	}

	if (a.l > b.l)
	{
		return false;
	}

	forn(i, a.l)
	{
		if (a.s[i] < b.s[i])
		{
			return true;
		}

		if (a.s[i] > b.s[i])
		{
			return false;
		}
	}

	return false;
}

void smain() {
	int n;
	cin >> n;

	forn(i, n)
	{
		cin >> numbers[i].s;
		numbers[i].l = numbers[i].s.length();
	}

	sort(numbers, numbers + n);

	forn(i, n)
	{
		cout << numbers[i].s << '\n';
	}
}
