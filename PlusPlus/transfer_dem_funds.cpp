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
#include <stack>

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

// All global declarations go here
const double C_PRECISION = 0;

int c_n;
vector<pair <int, double> > c_ribs[10000];
int c_sparse_table[40][20000];
int c_path[20000];
int c_path_position;
double c_prob[10000];
int c_path_length[10000];
int c_left_position[10000];
int c_pred[10000];
int c_pos[10000];

void c_dfs(int position)
{
	forn(i, c_n)
	{
		c_pred[i] = -1;
		c_pos[i] = 0;
	}

	stack<int> st;
	st.push(position);
	int current, to;

	while (!st.empty())
	{
		current = st.top();
		if (c_pos[current] == 0)
		{
			c_left_position[current] = c_path_position;
		}

		if (c_pos[current] == c_ribs[current].size())
		{
			c_path[c_path_position++] = current;
			st.pop();
			continue;
		}

		to = c_ribs[current][c_pos[current]].first;
		if (to == c_pred[current])
		{
			c_pos[current]++;
			continue;
		}

		c_path[c_path_position++] = current;

		c_path_length[to] = c_path_length[current] + 1;
		c_prob[to] = c_prob[current] + c_ribs[current][c_pos[current]].second;
		c_pred[to] = current;
		c_pos[current]++;

		st.push(to);
	}
}

void c_build()
{
	c_path_position = 0;
	c_path_length[0] = 0;
	c_prob[0] = 0;
}

void c_make_table()
{
	forn(i, c_path_position)
	{
		c_sparse_table[0][i] = c_path[i];
	}

	int p = 1;
	int length = 1;
	int max_length = 2 * c_n - 1;
	int to;

	while (length * 2 <= max_length)
	{
		forn(i, max_length)
		{
			c_sparse_table[p][i] = c_sparse_table[p - 1][i];

			to = i + length;
			if (to < max_length && c_path_length[c_sparse_table[p - 1][to]] < c_path_length[c_sparse_table[p - 1][i]])
			{
				c_sparse_table[p][i] = c_sparse_table[p - 1][to];
			}
		}

		p++;
		length *= 2;
	}
}

void c_add_rib(int a, int b, double v)
{
	a--;
	b--;
	v = log10(v) - 2;
	c_ribs[a].push_back(mp(b, v));
	c_ribs[b].push_back(mp(a, v));
}

void c_prepare()
{
	c_build();
	c_dfs(0);
	c_make_table();
}

bool c_answer(char * s)
{
	int a, b;
	double v;

	sscanf(s, "%d,%d,%lf", &a, &b, &v);
	a--;
	b--;

	int la = c_left_position[a];
	int lb = c_left_position[b];
	if (la > lb)
	{
		swap(la, lb);
	}

	int max_length = lb - la + 1;
	int length = 1;
	int p = 0;

	while (length <= max_length)
	{
		length *= 2;
		p++;
	}

	p--;
	length /= 2;

	int c = c_sparse_table[p][la];
	int d = c_sparse_table[p][lb - length + 1];

	if (c_path_length[d] < c_path_length[c])
	{
		c = d;
	}

	return (c_prob[a] + c_prob[b] - 2 * c_prob[c] - v) >= C_PRECISION;
}

void smain() {
	scanf("%d", &c_n);

	int a, b;
	double v;
	forn(i, c_n - 1)
	{
		scanf("%d,%d,%lf", &a, &b, &v);
		c_add_rib(a, b, v);
	}

	c_prepare();

	char s[1000];
	while (true)
	{
		scanf("%s", s);
		if (!strcmp(s, "END"))
		{
			break;
		}

		cout << (c_answer(s) ? "YES\n" : "NO\n");
	}
}
