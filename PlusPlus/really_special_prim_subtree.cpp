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

struct sRib {
	int from;
	int to;
	int len;
	int num;

	sRib(int from, int to, int len, int num) {
		this->from = from;
		this->to = to;
		this->len = len;
		this->num = num;
	}
};

bool operator < (sRib a, sRib b) {
	if (a.len != b.len) {
		return a.len < b.len;
	}

	return a.num < b.num;
}

void smain() {
	int n;
	cin >> n;
	int m;
	cin >> m;
	int from, to, len;

	vector<vector<sRib>> ribs(n);
	forn(i, m) {
		cin >> from >> to >> len;
		from--;
		to--;
		ribs[from].push_back(sRib(from, to, len, i));
		ribs[to].push_back(sRib(to, from, len, i));
	}

	int r;
	cin >> r;
	r--;

	vector<bool> visited(n);
	set<sRib> queue;
	for (auto it = ribs[r].begin(); it != ribs[r].end(); it++) {
		queue.insert(*it);
	}
	visited[r] = true;
	int result = 0;

	while (queue.size() > 0) { 
		sRib minRib = *queue.begin();
		queue.erase(queue.begin());

		if (!visited[minRib.to]) {
			visited[minRib.to] = true;
			result += minRib.len;

			for (auto it = ribs[minRib.to].begin(); it != ribs[minRib.to].end(); it++) {
				queue.insert(*it);
			}
		}
	}

	cout << result;
}
