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

struct sRib {
	int u, v;
	long w;
	bool operator <(sRib rib) {
		if (this->w != rib.w) {
			return this->w < rib.w;
		}

		if (this->u != rib.u) {
			return this->u < rib.u;
		}

		if (this->v != rib.v) {
			return this->v < rib.v;
		}

		return false;
	}
};

struct sNode {
	sNode *left, *right;
	long value;
};

sNode * root = new sNode();
const int N = 1000000001;

vector<long> dsu_size;
vector<int> dsu_parent;

int get_parent(int v) {
	if (v != dsu_parent[v]) {
		dsu_parent[v] = get_parent(dsu_parent[v]);
	}

	return dsu_parent[v];
}

void merge(int a, int b) {
	a = get_parent(a);
	b = get_parent(b);

	if (a == b) {
		return;
	}

	if (dsu_size[a] < dsu_size[b]) {
		swap(a, b);
	}

	dsu_parent[b] = a;
	dsu_size[a] += dsu_size[b];
}

void add(sNode *& node, int node_left, int node_right, int index, long value) {
	if (index < node_left || index > node_right || node_left > node_right) {
		return;
	}
	if (node == 0) {
		node = new sNode();
	}

	node->value += value;

	if (node_left < node_right) {
		int m = (node_left + node_right) / 2;
		if (index <= m) {
			add(node->left, node_left, m, index, value);
		}
		else {
			add(node->right, m + 1, node_right, index, value);
		}
	}
}

long get(sNode * node, int node_left, int node_right, int left, int right) {
	if (node_right < left || node_left > right || node_left > node_right || node == 0) {
		return 0;
	}

	if (node_left >= left && node_right <= right) {
		return node->value;
	}

	int m = (node_left + node_right) / 2;

	return get(node->left, node_left, m, left, right) + get(node->right, m + 1, node_right, left, right);
}

void smain() {
	int n, q;
	cin >> n >> q;
	vector<sRib> ribs(n-1);
	forn(i, n - 1) {
		cin >> ribs[i].u >> ribs[i].v >> ribs[i].w;
		ribs[i].u--;
		ribs[i].v--;
	}

	long cnt;

	sort(ribs.begin(), ribs.end());
	dsu_size.resize(n);
	dsu_parent.resize(n);
	forn(i, n) {
		dsu_size[i] = 1;
		dsu_parent[i] = i;
	}

	forn(i, n - 1) {
		cnt = dsu_size[get_parent(ribs[i].u)] * dsu_size[get_parent(ribs[i].v)];
		add(root, 0, N, ribs[i].w, cnt);
		merge(ribs[i].u, ribs[i].v);
	}

	int l, r;
	forn(i, q) {
		cin >> l >> r;
		cout << get(root, 0, N, l, r) << endl;
	}
}
