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

struct sNode {
	int day;
	int stocks;

	sNode(int day, int stocks) {
		this->day = day;
		this->stocks = stocks;
	}
};

bool operator < (sNode a, sNode b) {
	if (a.day < b.day)
		return true;

	if (a.day == b.day && a.stocks < b.stocks) {
		return true;
	}

	return false;
}

int n;
map<sNode, LL> intermediate_results;
LL prices[50001];

LL solve(int day, int stocks) {
	if (day >= n) {
		return 0;
	}

	sNode key(day, stocks);
	if (intermediate_results.find(key) != intermediate_results.end()) {
		return intermediate_results[key];
	}

	LL result = solve(day + 1, stocks);
	result = max(result, solve(day + 1, stocks + 1) - prices[day]);
	for (int i = 1;i <= stocks;i++) {
		result = max(result, solve(day + 1, stocks - i) + prices[day] * i);
	}

	intermediate_results[key] = result;

	return result;
}

void smain() {
	int tests;
	cin >> tests;
	forn(test, tests) {
		intermediate_results.clear();
		cin >> n;

		forn(i, n) {
			cin >> prices[i];
		}

		cout << solve(0, 0) << endl;
	}
}
