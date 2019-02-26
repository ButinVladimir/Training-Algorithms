//#pragma comment(linker, "/STACK:64000000")
//#include <stdlib.h>
//#include <fstream>
//#include <iostream>
//#include <vector>
//#include <stack>
//#include <stdlib.h>
//#include <stdio.h>
//#include <cstring>
//#include <map>
//#include <set>
//#include <string>
//#include <deque>
//#include <algorithm>
//#define _USE_MATH_DEFINES
//#include <math.h>
//#include <assert.h>
//
//using namespace std;
//
//#define forn(i,n) for (int i=0;i<n;i++)
//#define rforn(i,n) for (int i=n-1;i>=0;i--)
//#define mp make_pair
//#define __int64 long long
//#define LL long long
//#define ULL unsigned long long
//
//void smain();
//
//int main() {
//	ios_base::sync_with_stdio(false);
//#ifdef _DEBUG
//	freopen("input.txt", "r", stdin);
//	//freopen("output.txt", "w", stdout);
//#endif
//
//	smain();
//
//	return 0;
//}
//
//struct sEdge {
//	int left;
//	int right;
//	int num;
//	int next;
//};
//
//bool operator < (sEdge a, sEdge b) {
//	if (a.left != b.left) {
//		return a.left < b.left;
//	}
//
//	if (a.right != b.right) {
//		return a.right < b.right;
//	}
//
//	return a.num < b.num;
//}
//
//struct sState {
//	int top;
//	int bottom;
//	bool started;
//};
//
//bool operator < (sState a, sState b) {
//	if (a.top != b.top) {
//		return a.top < b.top;
//	}
//
//	if (a.bottom != b.bottom) {
//		return a.bottom < b.bottom;
//	}
//
//	return a.started < b.started;
//}
//
//int n;
//vector <sEdge> edges;
//map<sState, int> result;
//
//int Solve(int top, int bottom, bool started) {
//	if (top == n || bottom == n) {
//		return 0;
//	}
//
//	if (edges[top].left > edges[bottom].right) {
//		return Solve(top, top, true);
//	}
//
//	if (edges[top].right > edges[bottom].right || edges[top].right == edges[bottom].right && edges[top].left < edges[bottom].left) {
//		return Solve(bottom, top, started);
//	}
//
//	sState state;
//	state.top = top;
//	state.bottom = bottom;
//	state.started = started;
//
//	if (result.find(state) != result.end()) {
//		return result[state];
//	}
//
//	int buffer;
//	if (top == bottom) {
//		buffer = 1 + Solve(top + 1, bottom, false);
//	}
//	else {
//		buffer = 1 + Solve(edges[top].next, bottom, false);
//		if (started) {
//			buffer++;
//		}
//	}
//
//	buffer = max(buffer, Solve(top + 1, bottom, started));
//	result[state] = buffer;
//
//	return buffer;
//}
//
//void smain() {
//	int tests;
//	cin >> tests;
//	forn(test, tests) {
//		cin >> n;
//		edges.resize(n);
//
//		forn(i, n) {
//			cin >> edges[i].left >> edges[i].right;
//			edges[i].num = i;
//		}
//
//		sort(edges.begin(), edges.end());
//
//		for (int i = 0;i < n;i++) {
//			edges[i].next = i + 1;
//
//			while (edges[i].next < n && edges[i].right >= edges[edges[i].next].left) {
//				edges[i].next++;
//			}
//		}
//
//		result.clear();
//		cout << Solve(0, 0, true) << endl;
//	}
//}
//
