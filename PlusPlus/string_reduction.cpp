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

struct sState {
	int letter;
	int from;
	int to;

	sState(int l, int f, int t) {
		this->letter = l;
		this->from = f;
		this->to = t;
	}
};

bool operator < (sState a, sState b) {
	if (a.letter != b.letter) {
		return a.letter < b.letter;
	}

	if (a.from != b.from) {
		return a.from < b.from;
	}

	return a.to < b.to;
}

set<sState> queue;

const int MAX_LETTERS = 3;
const int MAX_LENGTH = 100;

bool visited[MAX_LETTERS][MAX_LENGTH][MAX_LENGTH];
vector<int> starts[MAX_LETTERS][MAX_LENGTH];
vector<int> finishes[MAX_LETTERS][MAX_LENGTH];
int dp[MAX_LENGTH + 1];

void smain() {
	int tests;
	cin >> tests;
	forn(test, tests) {
		forn(i, MAX_LETTERS) {
			forn(j, MAX_LENGTH) {
				forn(k, MAX_LENGTH) {
					visited[i][j][k] = 0;
				}

				starts[i][j].clear();
				finishes[i][j].clear();
			}
		}
		forn(i, MAX_LENGTH) {
			dp[i] = 0;
		}

		queue.clear();

		string s;
		cin >> s;
		forn(i, s.length()) {
			visited[s[i] - 'a'][i][i] = true;
			queue.insert(sState(s[i] - 'a', i, i));
			starts[s[i] - 'a'][i].push_back(i);
			finishes[s[i] - 'a'][i].push_back(i);
		}

		int start;
		int finish;
		int new_letter;
		while (!queue.empty()) {
			sState state = *queue.begin();
			queue.erase(queue.begin());

			forn(i, MAX_LETTERS) {
				if (i == state.letter) {
					continue;
				}
				new_letter = 3 - i - state.letter;

				if (state.from > 0) {
					finish = state.to;

					forn(j, starts[i][state.from - 1].size()) {
						start = starts[i][state.from - 1][j];

						if (!visited[new_letter][start][finish]) {
							visited[new_letter][start][finish] = true;
							queue.insert(sState(new_letter, start, finish));
							starts[new_letter][finish].push_back(start);
							finishes[new_letter][start].push_back(finish);
						}
					}
				}

				if (state.to < s.length() - 1) {
					start = state.from;

					forn(j, finishes[i][state.to + 1].size()) {
						finish = finishes[i][state.to + 1][j];

						if (!visited[new_letter][start][finish]) {
							visited[new_letter][start][finish] = true;
							queue.insert(sState(new_letter, start, finish));
							starts[new_letter][finish].push_back(start);
							finishes[new_letter][start].push_back(finish);
						}
					}
				}
			}
		}

		dp[s.length()] = 0;
		rforn(i, s.length()) {
			dp[i] = dp[i + 1] + 1;

			forn(k, MAX_LETTERS) {
				for (int j = i;j < s.length();j++) {
					if (visited[k][i][j]) {
						dp[i] = min(dp[i], 1 + dp[j + 1]);
					}
				}
			}
		}

		cout << dp[0] << endl;
	}
}

