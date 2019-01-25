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

void smain() {
	map<long, long> counts;
	map<long, long> frequences;

	int n, c;
	long x;
	cin >> n;
	forn(i, n) {
		cin >> c >> x;

		switch (c) {
		case 1:
			frequences[counts[x]]--;
			counts[x]++;
			frequences[counts[x]]++;
			break;
		case 2:
			if (counts[x] > 0) {
				frequences[counts[x]]--;
				counts[x]--;
				frequences[counts[x]]++;
			}
			break;
		case 3:
			if (frequences[x] > 0) {
				cout << 1 << endl;
			}
			else {
				cout << 0 << endl;
			}
		}
	}
}
