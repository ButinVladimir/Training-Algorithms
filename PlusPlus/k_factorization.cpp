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

struct SNumber {
	LL prev;
	int dist;

	SNumber() {
		prev = -1;
		dist = 0;
	}
};

void smain() {
	LL n;
	int k;
	cin >> n >> k;

	vector<LL> a(k);
	forn(i, k) {
		cin >> a[i];
	}

	if (n == 1) {
		cout << 1;
		return;
	}

	map<LL, SNumber> numbers;
	set<LL> queue;

	queue.insert(n);

	while (!queue.empty()) {
		LL current = *queue.begin();
		queue.erase(current);
		SNumber currentNumber = numbers[current];

		forn(i, k) {
			if (current % a[i] != 0) {
				continue;
			}
			LL next = current / a[i];

			SNumber nextNumber = numbers[next];
			if (nextNumber.prev == -1
				|| nextNumber.dist > currentNumber.dist + 1
				|| (nextNumber.dist == currentNumber.dist + 1) && (nextNumber.prev > current)) {
				numbers[next].dist = currentNumber.dist + 1;
				numbers[next].prev = current;
				queue.insert(next);
			}
		}
	}

	if (numbers[1].prev == -1) {
		cout << -1;
		return;
	}

	LL val = 1;
	vector<LL> path;
	path.push_back(val);
	while (val < n) {
		val = numbers[val].prev;
		path.push_back(val);
	}

	forn(i, path.size()) {
		cout << path[i] << ' ';
	}
}
