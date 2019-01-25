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

const int K = 12;
const int N = 1500;

int dp[K][N][N];
char s1[2000];
char s2[2000];
int s1l, s2l, kk;

void clear() {
	for (int k = 0;k < K;k++) {
		for (int i = 0;i < N;i++) {
			for (int j = 0;j < N;j++) {
				dp[k][i][j] = 0;
			}
		}
	}
}

void fill_zero() {
	for (int i = 0;i < s1l;i++) {
		for (int j = 0;j < s2l;j++) {
			if (s1[i] == s2[j]) {
				dp[0][i][j] = 1;

				if (i >= 1 && j >= 1) {
					dp[0][i][j] += dp[0][i - 1][j - 1];
				}
			}
		}
	}
}

void fill_first() {
	int len;
	for (int i = 0;i < s1l;i++) {
		for (int j = 0;j < s2l;j++) {
			if (s1[i] == s2[j]) {
				len = dp[0][i][j];
				dp[1][i][j] = len;

				if (i >= len && j >= len) {
					dp[1][i][j]++;

					if (i > len && j > len) {
						dp[1][i][j] += dp[0][i - len - 1][j - len - 1];
					}
				}
			}
			else {
				dp[1][i][j] = 1;

				if (i >= 1 && j >= 1) {
					dp[1][i][j] += dp[0][i - 1][j - 1];
				}
			}
		}
	}
}

void fill_next() {
	int len;
	for (int k = 2;k < K;k++) {
		for (int i = 0;i < s1l;i++) {
			for (int j = 0;j < s2l;j++) {
				len = dp[k - 1][i][j];
				dp[k][i][j] = len;

				if (i >= len && j >= len) {
					dp[k][i][j] += dp[k - 1][i - len][j - len];
				}
			}
		}
	}
}

void smain() {
	int tests;
	cin >> tests;
	forn(test, tests) {
		cin >> kk >> s1 >> s2;
		s1l = strlen(s1);
		s2l = strlen(s2);

		clear();
		fill_zero();
		fill_first();
		fill_next();

		int result = 0;
		int buffer;
		int kleft;
		int kt;
		for (int i = 0;i < s1l;i++) {
			for (int j = 0;j < s2l;j++) {
				buffer = 0;
				kleft = kk;
				for (int q = K - 1;q > 0 && i >= buffer && j >= buffer; q--) {
					kt = 1 << (q - 1);
					if (kleft < kt) {
						continue;
					}

					kleft -= kt;
					buffer += dp[q][i - buffer][j - buffer];
				}

				if (i >= buffer && j >= buffer) {
					buffer += dp[0][i - buffer][j - buffer];
				}

				result = max(result, buffer);
			}
		}

		cout << result << endl;
	}
}
