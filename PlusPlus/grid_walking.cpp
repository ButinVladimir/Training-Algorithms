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

const int MAX_M = 301;
const LL MOD = 1000000000 + 7;

LL c[MAX_M][MAX_M];
int n, m;
vector<int> d;
vector<int> x;
LL dp[10][MAX_M][MAX_M];
LL answer[10][MAX_M];

void smain() {
	forn(i, MAX_M) {
		c[i][0] = 1;
	}

	for (int i = 1;i < MAX_M;i++) {
		for (int j = 1;j <= i;j++) {
			c[i][j] = (c[i - 1][j - 1] + c[i - 1][j]) % MOD;
		}
	}

	int tests;
	cin >> tests;
	forn(test, tests) {
		cin >> n >> m;
		d.resize(n);
		x.resize(n);

		forn(i, n) {
			cin >> x[i];
		}

		forn(i, n) {
			cin >> d[i];
		}

		forn(i, n) {
			for (int j = 1; j <= d[i];j++) {
				dp[i][j][0] = 1;
			}

			for (int k = 1; k <= m;k++) {
				for (int j = 1;j <= d[i];j++) {
					dp[i][j][k] = 0;

					if (j > 1) {
						dp[i][j][k] = (dp[i][j][k] + dp[i][j - 1][k - 1]) % MOD;
					}

					if (j < d[i]) {
						dp[i][j][k] = (dp[i][j][k] + dp[i][j + 1][k - 1]) % MOD;
					}
				}
			}
		}

		rforn(i, n) {
			for (int j = 0; j <= m;j++) {
				answer[i][j] = 0;

				if (i == n - 1) {
					answer[i][j] = dp[i][x[i]][j];
				}
				else {
					for (int k = 0;k <= j;k++) {
						answer[i][j] = (answer[i][j] + c[j][k] * answer[i + 1][j - k] % MOD * dp[i][x[i]][k] % MOD) % MOD;
					}
				}
			}
		}

		cout << answer[0][m] << endl;
	}
}
