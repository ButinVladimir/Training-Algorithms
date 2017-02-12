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

const long EMPTY = -1;
const int LETTERS = 26;

struct sNode
{
	int *next;
	int resultSkipped;
	int resultNotSkipped;
	bool word;
} nodes[5000000];

int nodeCounter = 0;

int calc(int currentNode, int currentSum, bool isSkipped)
{
	if (currentNode == -1)
	{
		return 0;
	}

	if (nodes[currentNode].resultNotSkipped != EMPTY && !isSkipped)
	{
		return nodes[currentNode].resultNotSkipped;
	}

	if (nodes[currentNode].resultSkipped != EMPTY && isSkipped)
	{
		return nodes[currentNode].resultSkipped;
	}

	int result = 0;

	if (!nodes[currentNode].word)
	{
		
		forn(i, LETTERS)
		{
			if (nodes[currentNode].next[i] != EMPTY)
			{
				result += calc(nodes[currentNode].next[i], currentSum + 'A' + i, isSkipped);
			}
		}

		if (isSkipped)
		{
			nodes[currentNode].resultSkipped = result;
		}
		else
		{
			nodes[currentNode].resultNotSkipped = result;
		}
		
		return result;
	}

	forn(i, LETTERS)
	{
		if (nodes[currentNode].next[i] != EMPTY)
		{
			result += calc(nodes[currentNode].next[i], currentSum + 'A' + i, false);
		}
	}

	if (!isSkipped)
	{
		int takenResult = currentSum;

		forn(i, LETTERS)
		{
			if (nodes[currentNode].next[i] != EMPTY)
			{
				takenResult += calc(nodes[currentNode].next[i], currentSum + 'A' + i, true);
			}
		}

		result = max(result, takenResult);
		nodes[currentNode].resultNotSkipped = result;
	}
	else
	{
		nodes[currentNode].resultSkipped = result;
	}

	return result;
}

int next_node()
{
	nodes[nodeCounter].next = new int[LETTERS];
	nodes[nodeCounter].resultNotSkipped = EMPTY;
	nodes[nodeCounter].resultSkipped = EMPTY;
	nodes[nodeCounter].word = false;

	forn(i, LETTERS)
	{
		nodes[nodeCounter].next[i] = EMPTY;
	}

	return nodeCounter++;
}

void prefix_neighbourhood() {
	int rootNode = next_node(), currentNode;
	int n, l, letter;
	string s;
	cin >> n;

	forn(i, n)
	{
		cin >> s;
		currentNode = rootNode;
		
		l = s.length();
		forn(j, l)
		{
			letter = s[j] - 'A';
			if (nodes[currentNode].next[letter] == EMPTY)
			{
				nodes[currentNode].next[letter] = next_node();
			}

			currentNode = nodes[currentNode].next[letter];
		}

		nodes[currentNode].word = true;
	}

	cout << calc(rootNode, 0, false);
}
