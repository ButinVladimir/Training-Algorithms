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

LL m;

struct sNode
{
	LL value;
	sNode *left, *right;
};

LL get_value(sNode * node)
{
	return node ? node->value : m;
}

void update_value(sNode * node)
{
	if (node)
	{
		node->value = min(get_value(node->left), get_value(node->right));
	}
}

void add(sNode * &node, LL segment_left, LL segment_right, LL value)
{
	if (segment_left > segment_right)
	{
		return;
	}

	if (!node)
	{
		node = new sNode();
		node->left = 0;
		node->right = 0;
	}

	if (segment_left == segment_right)
	{
		node->value = value;
	}
	else
	{
		LL m = (segment_left + segment_right) / 2;
		if (value <= m)
		{
			add(node->left, segment_left, m, value);
		}
		else
		{
			add(node->right, m+1, segment_right, value);
		}

		update_value(node);
	}
}

LL get(sNode * node, LL segment_left, LL segment_right, LL left, LL right)
{
	if (!node || segment_left > right || segment_right < left)
	{
		return m;
	}

	if (segment_left >= left && segment_right <= right)
	{
		return node->value;
	}

	LL m = (segment_left + segment_right) / 2;

	return min(get(node->left, segment_left, m, left, right), get(node->right, m + 1, segment_right, left, right));
}

void smain() {
	int n;
	int q;
	LL a, sum, result, val;
	cin >> q;

	forn(test, q)
	{
		cin >> n >> m;
		sum = 0;
		result = 0;
		sNode * root = new sNode();

		forn(i, n)
		{
			cin >> a;
			sum = (sum + a) % m;
			result = max(result, sum);

			val = sum + m - get(root, 0, m, sum + 1, m);
			result = max(result, val);

			add(root, 0, m, sum);
		}

		cout << result << '\n';
	}
}
