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

const int N = 52;
const int K = 1001;
const char dc[4] = { 'U', 'D', 'L', 'R' };
const int dx[4] = { -1, 1, 0, 0 };
const int dy[4] = { 0, 0, -1, 1 };

int n, m, k;
string field[N];
int ops[N][N][K];


void smain() {
	cin >> n >> m >> k;

	forn(i, n) {
		cin >> field[i];
		forn(j, m) {
			forn(q, k + 1) {
				ops[i][j][q] = -1;
			}
		}
	}

	ops[0][0][0] = 0;
	int nx, ny, no;

	forn(time, k) {
		forn(i, n) {
			forn(j, m) {
				if (ops[i][j][time] == -1 || field[i][j] == '*') {
					continue;
				}

				forn(q, 4) {
					nx = i + dx[q];
					ny = j + dy[q];
					no = ops[i][j][time] + (field[i][j] != dc[q] ? 1 : 0);

					if (nx >= 0 && nx < n && ny >= 0 && ny < m
						&& (ops[nx][ny][time + 1] == -1 || ops[nx][ny][time + 1] > no)) {
						ops[nx][ny][time + 1] = no;
					}
				}
			}
		}
	}

	int result = -1;
	forn(i, n) {
		forn(j, m) {
			if (field[i][j] != '*') {
				continue;
			}

			forn(time, k + 1) {
				if (ops[i][j][time] != -1 && (result == -1 || result > ops[i][j][time])) {
					result = ops[i][j][time];
				}
			}
		}
	}

	cout << result;
}

