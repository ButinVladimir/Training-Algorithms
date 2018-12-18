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
	int to;
	LL len;

	sRib(int to, LL len) {
		this->to = to;
		this->len = len;
	}
};

struct sEvent {
	LL value;
	int pos;
	int mask;

	sEvent(LL value, int pos, int mask) {
		this->value = value;
		this->pos = pos;
		this->mask = mask;
	}
};

bool operator < (sEvent a, sEvent b) {
	if (a.value != b.value) {
		return a.value < b.value;
	}

	if (a.pos != b.pos) {
		return a.pos < b.pos;
	}

	return a.mask < b.mask;
}

int n, m, k;
LL dist[1000][1024];
int masks[1000];
vector<sRib> ribs[1000];

void smain() {
	int kl, kv;

	cin >> n >> m >> k;
	LL full_mask = (1 << k) - 1;

	forn(i, n) {
		cin >> kl;
		forn(j, kl) {
			cin >> kv;

			masks[i] |= 1 << (kv - 1);
		}
	}

	int a, b;
	LL v;
	forn(i, m) {
		cin >> a >> b >> v;
		a--;
		b--;
		ribs[a].push_back(sRib(b, v));
		ribs[b].push_back(sRib(a, v));
	}

	forn(i, n) {
		forn(j, 1024) {
			dist[i][j] = -1;
		}
	}

	set<sEvent> queue;
	dist[0][masks[0]] = 0;
	queue.insert(sEvent(0, 0, masks[0]));

	int to;
	int nm;
	int nv;
	while (!queue.empty()) {
		sEvent evt = *queue.begin();
		queue.erase(queue.begin());

		forn(i, ribs[evt.pos].size()) {
			to = ribs[evt.pos][i].to;
			nm = evt.mask | masks[to];
			nv = evt.value + ribs[evt.pos][i].len;

			if (dist[to][nm] == -1 || dist[to][nm] > nv) {
				if (dist[to][nm] > nv) {
					queue.erase(sEvent(dist[to][nm], to, nm));
				}

				dist[to][nm] = nv;
				queue.insert(sEvent(nv, to, nm));
			}
		}
	}

	LL result = dist[n - 1][full_mask];
	for (int msk = 0; msk <= full_mask; msk++) {
		for (int submask = msk; submask > 0; submask = msk & (submask - 1)) {
			if (dist[n - 1][msk] != -1 && dist[n - 1][full_mask ^ submask] != -1) {
				result = min(result, max(dist[n - 1][msk], dist[n - 1][full_mask ^ submask]));
			}
		}

		if (dist[n - 1][msk] != -1) {
			result = min(result, max(dist[n - 1][msk], dist[n - 1][full_mask]));
		}
	}

	cout << result;
}
