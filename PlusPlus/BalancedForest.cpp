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

LL c[N];
LL sum[N];
int current_pos[N];
vector<int> to[N];
int first_tree_visited[N];
int first_tree_stack_len;
int first_subtree_root, second_subtree_root;
LL first_subtree_sum, second_subtree_sum, third_subtree_sum;
LL result;

inline void update_result(LL value) {
	if (value > 0 && (result == -1 || result > value)) {
		result = value;
	}
}

inline void compute_sum(int current, int from = -1) {
	int t;
	sum[current] = c[current];
	forn(i, to[current].size()) {
		t = to[current][i];
		if (t == from) {
			continue;
		}

		compute_sum(t, current);
		sum[current] += sum[t];
	}
}

inline void find_third_subtree() {
	third_subtree_sum = sum[0] - first_subtree_sum - second_subtree_sum;
	if (first_subtree_sum == second_subtree_sum) {
		update_result(first_subtree_sum - third_subtree_sum);
	}

	if (first_subtree_sum == third_subtree_sum) {
		update_result(first_subtree_sum - second_subtree_sum);
	}

	if (second_subtree_sum == third_subtree_sum) {
		update_result(second_subtree_sum - first_subtree_sum);
	}
}

inline void find_second_subtree(int current, int from = -1, int pos = 0, bool on_path_to_first_subtree = true) {
	int t;
	bool next_vert_on_path_to_first_subtree = false;
	for (int i = current_pos[current];i < to[current].size();i++) {
		t = to[current][i];
		if (t == from) {
			continue;
		}

		if (t == first_subtree_root) {
			continue;
		}

		second_subtree_root = t;
		second_subtree_sum = sum[t];
		next_vert_on_path_to_first_subtree = on_path_to_first_subtree && first_tree_stack_len > (pos + 1) && first_tree_visited[pos + 1] == t;
		if (next_vert_on_path_to_first_subtree) {
			second_subtree_sum -= first_subtree_sum;
		}

		find_third_subtree();
		find_second_subtree(t, current, pos + 1, next_vert_on_path_to_first_subtree);
	}
}

inline void find_first_subtree(int current, int from = -1, int pos = 0) {
	current_pos[current] = 0;
	first_tree_visited[pos] = current;

	int t;
	for (current_pos[current]; current_pos[current] < to[current].size(); current_pos[current]++) {
		t = to[current][current_pos[current]];
		if (t == from) {
			continue;
		}

		first_subtree_root = t;
		first_subtree_sum = sum[t];
		first_tree_stack_len = pos + 1;

		second_subtree_root = 0;
		second_subtree_sum = sum[0] - first_subtree_sum;
		find_third_subtree();

		find_second_subtree(0);

		find_first_subtree(t, current, pos + 1);
	}

	current_pos[current] = 0;
}

void smain() {
	int tests;
	scanf("%d", &tests);

	string command;
	forn(test, tests) {
		int n, a, b;
		scanf("%d", &n);
		forn(i, n) {
			scanf("%lld", &c[i]);
			to[i].clear();
			current_pos[i] = 0;
		}

		forn(i, n - 1) {
			scanf("%d", &a);
			scanf("%d", &b);
			a--;
			b--;

			to[a].push_back(b);
			to[b].push_back(a);
		}

		compute_sum(0);
		result = -1;
		find_first_subtree(0);
		printf("%lld\n", result);
	}
}
