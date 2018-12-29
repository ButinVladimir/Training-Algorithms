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

void pass_test()
{
	int n, m;
	cin >> n >> m;
	vector<vector<int>> ribs(n);

	int from, to;
	forn(i, m) {
		cin >> from >> to;
		from--;
		to--;
		ribs[from].emplace_back(to);
		ribs[to].emplace_back(from);
	}

	int s;
	cin >> s;
	s--;
	vector<int> dist(n, -1);
	vector<int> cnt(n, 0);
	vector<bool> visited(n, 0);
	deque<int> q;

	dist[s] = 0;
	visited[s] = true;
	q.push_back(s);

	set<pair<int, int>> aq;
	forn(i, n) {
		if (i == s) {
			continue;
		}

		aq.insert(mp(0, i));
	}

	int all_rib_count = 0;
	int cd = 1;

	while (!q.empty()) {
		while (!q.empty()) {
			all_rib_count++;
			from = q.front();
			q.pop_front();

			for (auto it = ribs[from].begin(); it != ribs[from].end();it++) {
				to = *it;
				if (visited[to]) {
					continue;
				}

				aq.erase(aq.find(mp(cnt[to], to)));
				cnt[to]++;
				aq.insert(mp(cnt[to], to));
			}
		}

		while (!aq.empty() && aq.begin()->first < all_rib_count) {
			to = aq.begin()->second;
			aq.erase(aq.begin());
			visited[to] = true;
			dist[to] = cd;
			q.push_back(to);
		}

		cd++;
	}

	forn(i, n) {
		if (i == s) {
			continue;
		}

		cout << dist[i] << ' ';
	}

	cout << endl;
}

void smain() {
	int tests;
	cin >> tests;
	forn(test, tests)
	{
		pass_test();
	}
}
