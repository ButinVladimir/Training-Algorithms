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

map<LL, LL> result;
vector<LL> s;

LL solve(LL value) {
	auto it = result.find(value);
	if (it != result.end()) {
		return it->second;
	}

	LL buffer = 0;
	forn(i, s.size()) {
		if (value != s[i] && value % s[i] == 0) {
			buffer = max(buffer, 1 + solve(s[i]) * (value / s[i]));
		}
	}

	result[value] = buffer;

	return buffer;
}

void smain() {
	int tests;
	cin >> tests;
	forn(test, tests) {
		result.clear();

		LL n;
		cin >> n;

		int m;
		cin >> m;
		s.resize(m);
		forn(i, m) {
			cin >> s[i];
		}

		cout << solve(n) << endl;
	}
}

