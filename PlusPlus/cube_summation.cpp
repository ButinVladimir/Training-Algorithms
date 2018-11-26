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
	freopen("output.txt", "w", stdout);
#endif

	smain();

	return 0;
}

const int N = 101;
LL fenwick[N][N][N];
LL value[N][N][N];

LL query(int x, int y, int z)
{
	LL result = 0;
	for (int i = x;i >= 0;i = (i & (i + 1)) - 1)
		for (int j = y;j >= 0;j = (j & (j + 1)) - 1)
			for (int k = z;k >= 0;k = (k & (k + 1)) - 1)
				result += fenwick[i][j][k];

	return result;
}

LL fullQuery(int x1, int y1, int z1, int x2, int y2, int z2)
{
	int dx = x1 - 1;
	int dy = y1 - 1;
	int dz = z1 - 1;
	return query(x2, y2, z2)
		- query(dx, y2, z2)
		- query(x2, dy, z2)
		- query(x2, y2, dz)
		+ query(dx, dy, z2)
		+ query(dx, y2, dz)
		+ query(x2, dy, dz)
		- query(dx, dy, dz);
}

void update(int x, int y, int z, LL w)
{
	for (int i = x;i < N;i = (i | (i + 1)))
		for (int j = y;j < N;j = (j | (j + 1)))
			for (int k = z;k < N;k = (k | (k + 1)))
				fenwick[i][j][k] += w;
}

void clear()
{
	forn(i, N)
		forn(j, N)
		forn(k, N) {
		fenwick[i][j][k] = 0;
		value[i][j][k] = 0;
	}
}

void smain() {
	int tests;
	cin >> tests;

	string command;
	forn(test, tests) {
		clear();
		int n, m;
		cin >> n >> m;
		string command;

		int x1, y1, z1, x2, y2, z2;
		long w;

		forn(i, m) {
			cin >> command;
			if (command == "UPDATE") {
				cin >> x1 >> y1 >> z1 >> w;
				update(x1, y1, z1, w - value[x1][y1][z1]);
				value[x1][y1][z1] = w;
			}
			else {
				cin >> x1 >> y1 >> z1 >> x2 >> y2 >> z2;
				cout << fullQuery(x1, y1, z1, x2, y2, z2) << endl;
			}
		}
	}
}
