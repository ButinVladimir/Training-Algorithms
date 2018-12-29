#pragma comment(linker, "/STACK:64000000")
#include <stdlib.h>
#include <fstream>
#include <iostream>
#include <vector>
#include <stack>
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
#define ULL unsigned long long

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

LL solve(LL v) {
	LL f;
	LL result = 0;

	for (LL i = 0;i < 50;i++) {
		f = (1LL << i);
		if (f > v) {
			break;
		}

		if ((v & f) == 0) {
			result += (1LL << i);
		}
	}

	return result;
}

void smain() {
	int tests;
	cin >> tests;
	forn(test, tests) {
		LL q;
		cin >> q;
		cout << solve(q) << endl;
	}
}
