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

const LL MOD = 1000000000 + 7;
const LL MAX = 314159;

char a[200000];
char b[200000];
int al, bl;

void smain() {
	cin >> a >> b;
	al = strlen(a);
	bl = strlen(b);

	reverse(a, a + al);
	reverse(b, b + bl);
	while (al < bl) {
		a[al] = '0';
		al++;
	}

	while (bl < al) {
		b[bl] = '0';
		bl++;
	}

	LL result = 0;
	LL pwr = 1;
	LL bc = 0;

	for (int i = 0;i < bl;i++) {
		if (b[i] == '1') {
			bc = (bc + pwr) % MOD;
		}
		pwr = (pwr * 2) % MOD;
	}

	LL bz = 0;
	LL bo = 0;
	pwr = 1;
	for (int i = 0;i < al;i++) {
		if (i < bl) {
			if (b[i] == '1') {
				bo = (bo + 1) % MOD;
			}
			else {
				bz = (bz + 1) % MOD;
			}
		}

		if (a[i] == '0') {
			result = (result + (pwr * bo) % MOD) % MOD;
		}
		else {
			result = (result + (pwr * bz) % MOD) % MOD;
			result = (result + (pwr * (MAX - i)) % MOD) % MOD;
		}

		pwr = (pwr * 2) % MOD;
	}

	LL bbc = 0;
	for (int i = bl - 1;i > 0;i--) {
		if (b[i] == '1') {
			bbc = (bbc + 1) % MOD;
		}

		result = (result + (pwr * bbc) % MOD) % MOD;
		bbc = (bbc * 2) % MOD;
	}

	for (int i = al;i <= MAX;i++) {
		result = (result + (bc * pwr) % MOD) % MOD;
		pwr = (pwr * 2) % MOD;
	}

	cout << result;
}
