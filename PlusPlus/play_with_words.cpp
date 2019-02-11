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

const int N = 3000;
bool visited[N][N];
int dp[N][N];
string s;

int step(int left, int right)
{
	if (left > right) {
		return 0;
	}

	if (left == right) {
		return 1;
	}

	if (!visited[left][right]) {
		visited[left][right] = true;
		dp[left][right] = max(step(left, right - 1), step(left + 1, right));
		if (s[left] == s[right]) {
			dp[left][right] = max(dp[left][right], 2 + step(left + 1, right - 1));
		}
	}
	
	return dp[left][right];
}

void smain() {
	cin >> s;
	int result = 0;
	for (int i = 0;i < s.length() - 1;i++) {
		result = max(result, step(0, i) * step(i + 1, s.length() - 1));
	}

	cout << result;
}

