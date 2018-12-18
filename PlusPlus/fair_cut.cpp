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

const int N = 3001;

struct sNode {
	int pos;
	int left;
	LL acc;

	sNode(int pos, int left, LL acc) {
		this->pos = pos;
		this->left = left;
		this->acc = acc;
	}
};

bool operator < (sNode a, sNode b) {
	if (a.pos < b.pos) {
		return true;
	}

	if (a.pos == b.pos && a.left < b.left) {
		return true;
	}

	if (a.pos == b.pos && a.left == b.left && a.acc < b.acc) {
		return true;
	}

	return false;
}

int n, k;

LL a[N];
map <sNode, LL> result;

LL calc(int pos, int left, int s1 = 1, int s2 = 0, LL acc = 0)
{
	if (pos == n && left > 0) {
		return -1;
	}

	sNode key = sNode(pos, left, acc);

	if (result.find(key) != result.end()) {
		return result[key];
	}

	LL buf1 = calc(pos + 1, left, s1 + 1, s2, acc + (s1 + 1) * (a[pos] - a[pos - 1]));
}

void smain() {
	cin >> n >> k;
	forn(i, n) {
		cin >> a[i];
	}

	sort(a, a + n);
}
