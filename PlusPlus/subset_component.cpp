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

const ULL maxCacheLen = 1024;

int n;
ULL d[20];
bool cache[maxCacheLen][64][64];
bool visited[64];
int queue[64];
ULL result;

void smain() {
	cin >> n;
	forn(i, n) {
		cin >> d[i];
	}

	int mx = min(maxCacheLen, 1ULL << n);
	int queue_start;
	int queue_end;
	int from;
	for (ULL mask = 0; mask < mx; mask++) {
		for (ULL i = 0; i < 64; i++) {
			if ((mask & i) == 0) {
				continue;
			}

			for (ULL j = 0; j < 64;j++)
				for (ULL k = 0; k < 64;k++)
					if ((d[i] & (1ULL << j)) > 0 && (d[i] & (1ULL << k))) {
						cache[mask][j][k] = true;
						cache[mask][k][j] = true;
					}
		}

		forn(i, 64) visited[i] = 0;
		forn(i, 64) if (!visited[i]) {
			result++;
			visited[i] = true;
			queue_start = 0;
			queue_end = 1;
			queue[0] = i;
			while (queue_start < queue_end) {
				from = queue[queue_start];
				forn(to, 64) if (cache[mask][from][to] && !visited[to]) {
					visited[to] = true;
					queue[queue_end] = to;
					queue_end++;
				}

				queue_start++;
			}
		}
	}

	cout << result;
}
