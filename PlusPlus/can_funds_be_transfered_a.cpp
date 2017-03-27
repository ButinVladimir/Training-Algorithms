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

const int MAX_N = 1000000;
const int MAX_STEPS = 40;

class csolve
{
private:
	vector<int> ribs[MAX_N];
	int pred[MAX_N];
	int tin[MAX_N];
	int tout[MAX_N];
	int pwr[MAX_N];
	int position[MAX_N];
	int steps[MAX_STEPS][MAX_N];

	bool is_in(int a, int b)
	{
		return this->tin[b] >= this->tin[a] && this->tout[b] <= this->tout[a];
	}

	int find_lca(int a, int b)
	{
		if (this->is_in(a, b))
		{
			return a;
		}

		if (this->is_in(b, a))
		{
			return b;
		}

		int next;
		rforn(i, MAX_STEPS)
		{
			next = this->steps[i][a];
			if (!this->is_in(next, b))
			{
				a = next;
			}
		}

		return this->pred[a];
	}

public:
	csolve()
	{
		for (int i = 0; i < MAX_N; i++)
		{
			this->pwr[i] = 1;
			this->position[i] = 0;
		}
	}

	void dfs()
	{
		stack<int> st;
		st.push(0);
		forn(i, MAX_STEPS)
		{
			this->steps[i][0] = 0;
		}

		this->pred[0] = 0;

		int from, to;
		int time = 0;

		while (!st.empty())
		{
			from = st.top();

			if (this->position[from] == 0)
			{
				this->tin[from] = time;
				time++;
			}

			if (this->position[from] >= ribs[from].size())
			{
				this->tout[from] = time;
				time++;

				st.pop();
				continue;
			}

			to = this->ribs[from][this->position[from]];
			this->position[from]++;

			if (to == this->pred[from])
			{
				continue;
			}

			pred[to] = from;
			this->pwr[to] = this->pwr[from] + 1;
			this->steps[0][to] = from;
			for (int i = 1; i < MAX_STEPS; i++)
			{
				this->steps[i][to] = this->steps[i - 1][this->steps[i - 1][to]];
			}

			st.push(to);
		}
	}

	void add_rib(int a, int b)
	{
		a--;
		b--;

		this->ribs[a].push_back(b);
		this->ribs[b].push_back(a);
	}

	bool check_pair(int a, int b, int prob)
	{
		a--;
		b--;
		int c = this->find_lca(a, b);

		int value = this->pwr[a] + this->pwr[b] - 2 * this->pwr[c] + 1;
		return value - prob > 0;
	}
};

void smain() {
	int n, a, b, d;
	scanf("%d", &n);

	csolve solve;
	forn(i, n - 1)
	{
		scanf("%d,%d", &a, &b);
		solve.add_rib(a, b);
	}

	solve.dfs();

	char str[1000];
	scanf("%s", str);
	while (strcmp(str, "END"))
	{
		sscanf(str, "%d,%d,%lf", &a, &b, &d);
		printf("%s", solve.check_pair(a, b, d) ? "YES\n" : "NO\n");

		scanf("%s", str);
	}
}
