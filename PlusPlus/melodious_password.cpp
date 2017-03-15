#pragma comment(linker, "/STACK:64000000")
#include <stdlib.h>
#include <fstream>
#include <iostream>
#include <vector>
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

char vowels[] = { 'e', 'u', 'i', 'o', 'a' };
char consonants[] = { 'q', 'w', 'r', 't', 'p', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b', 'n', 'm' };
char result[6] = { 0 };
int vowels_length = 5;
int consonants_length = 20;

void Step(int n, bool vowel)
{
	if (n == -1)
	{
		cout << result << '\n';
		return;
	}

	char * letters = vowel ? vowels : consonants;
	int length = vowel ? vowels_length : consonants_length;

	forn(i, length)
	{
		result[n] = letters[i];
		Step(n - 1, !vowel);
	}
}

void smain() {
	int n;
	cin >> n;

	Step(n - 1, true);
	Step(n - 1, false);
}
