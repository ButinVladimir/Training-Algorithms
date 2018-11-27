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

const int N = 100000;

LL values[N];
vector<int> ribs[N];
LL sum[N];
multiset<LL> part_sums;
LL result;

void update_result(LL value) {
	if (value >= 0 && (result == -1 || result > value)) {
		result = value;
	}
}

void calc_sum(int current, int from = -1) {
	int to;
	sum[current] = values[current];

	forn(i, ribs[current].size()) {
		to = ribs[current][i];
		if (to == from) {
			continue;
		}

		calc_sum(to, current);
		sum[current] += sum[to];
	}
}

void visit_nested_trees(int current, int from = -1) {
	part_sums.insert(sum[current]);

	int to;
	LL a, b;

	a = sum[current];
	b = sum[0] - 2 * a;
	if (a > 0 && b >= 0) {
		if (part_sums.find(a * 2) != part_sums.end()) {
			update_result(a - b);
		}

		if (part_sums.find(a + b) != part_sums.end()) {
			update_result(a - b);
		}
	}

	b = sum[current];
	a = (sum[0] - b) / 2;
	if (a > 0 && b >= 0 && 2 * a + b == sum[0] && part_sums.find(a + b) != part_sums.end()) {
		update_result(a - b);
	}

	forn(i, ribs[current].size()) {
		to = ribs[current][i];
		if (to == from) {
			continue;
		}

		visit_nested_trees(to, current);
	}

	part_sums.erase(part_sums.find(sum[current]));
}

void visit_adjacent_trees(int current, int from = -1) {
	int to;
	LL a, b;

	a = sum[current];
	b = sum[0] - 2 * a;

	if (a > 0 && b >= 0) {
		if (part_sums.find(a) != part_sums.end()) {
			update_result(a - b);
		}

		if (part_sums.find(b) != part_sums.end()) {
			update_result(a - b);
		}
	}

	b = sum[current];
	a = (sum[0] - b) / 2;
	if (a > 0 && b >= 0 && 2 * a + b == sum[0] && part_sums.find(a) != part_sums.end()) {
		update_result(a - b);
	}

	forn(i, ribs[current].size()) {
		to = ribs[current][i];
		if (to == from) {
			continue;
		}

		visit_adjacent_trees(to, current);
	}

	part_sums.insert(sum[current]);
}

void smain() {
	int tests;
	cin >> tests;

	forn(test, tests) {
		int n, a, b;
		cin >> n;

		forn(i, n) {
			cin >> values[i];
			ribs[i].clear();
			sum[i] = 0;
		}

		forn(i, n - 1) {
			cin >> a >> b;
			a--;
			b--;
			ribs[a].push_back(b);
			ribs[b].push_back(a);
		}

		part_sums.clear();
		result = -1;

		calc_sum(0);
		visit_nested_trees(0);
		part_sums.clear();
		visit_adjacent_trees(0);

		cout << result << endl;
	}
}
