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

int n;
LL a[400000];
LL prefix[400000];

inline LL sum(int l, int r) {
	return prefix[r] - ((l > 0) ? prefix[l - 1] : 0);
}

int solve(int l, int r) {
	if (l == r) {
		return 0;
	}

	int step = r - l + 1;
	int nextPos;
	int pos = l - 1;
	LL d;
	while (step > 0) {
		nextPos = pos + step;
		if (nextPos >= r) {
			step /= 2;
			continue;
		}

		d = sum(l, nextPos) - sum(nextPos + 1, r);
		if (d > 0) {
			step /= 2;
		}
		else {
			pos = nextPos;
			if (d == 0) {
				break;
			}
		}
	}

	if (pos >= l) {
		d = sum(l, pos) - sum(pos + 1, r);

		if (d == 0) {
			return 1 + max(solve(l, pos), solve(pos + 1, r));
		}
	}

	return 0;
}

void smain() {
	int tests;
	cin >> tests;
	forn(test, tests) {
		int nn;
		cin >> nn;

		n = 0;
		LL v;
		forn(i, nn) {
			cin >> v;
			if (v != 0) {
				a[n] = v;
				prefix[n] = v;
				if (n > 0) {
					prefix[n] += prefix[n - 1];
				}
				n++;
			}
		}

		if (n == 0) {
			cout << nn - 1 << endl;

			continue;
		}

		cout << solve(0, n - 1) << endl;
	}
}

