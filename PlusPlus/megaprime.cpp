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

const int primesNumber = 4;
const int primesDigits[] = { 2, 3, 5, 7, };

bool BuildCurrentNumber(int position, int currentNumbers[], int startNumbers[], bool greater = false)
{
	if (position == -1)
	{
		return true;
	}

	if (greater)
	{
		currentNumbers[position] = 0;
		return BuildCurrentNumber(position - 1, currentNumbers, startNumbers, true);
	}

	forn(i, primesNumber)
	{
		currentNumbers[position] = i;

		if (primesDigits[i] == startNumbers[position])
		{
			if (BuildCurrentNumber(position - 1, currentNumbers, startNumbers, false))
			{
				return true;
			}
		}

		if (primesDigits[i] > startNumbers[position])
		{
			return BuildCurrentNumber(position - 1, currentNumbers, startNumbers, true);
		}
	}

	return false;
}

inline LL ConvertNumber(int currentNumbers[], int currentL)
{
	LL result = 0;
	rforn(i, currentL + 1)
	{
		result = result * 10 + primesDigits[currentNumbers[i]];
	}

	return result;
}

inline void Increment(int currentNumbers[], int & currentL)
{
	int position = 0;
	currentNumbers[0]++;

	while (position <= currentL && currentNumbers[position] == primesNumber)
	{
		currentNumbers[position] = 0;
		currentNumbers[position + 1]++;
		position++;
	}

	if (position > currentL)
	{
		currentL++;
		currentNumbers[position] = 0;
	}
}

const LL maxPrime = 32000000;
const LL maxPrimes = 2000000;
bool isComposite[maxPrime + 1] = { 0 };
LL primesSieve[maxPrimes];

void smain() {
	LL start, finish;
	cin >> start >> finish;

	int startL = 0;
	int startNumbers[16];
	LL startB = start;

	while (startB)
	{
		startNumbers[startL++] = startB % 10;
		startB /= 10;
	}
	startNumbers[startL] = 0;

	int currentNumbers[16];
	int currentL = startL - 1;

	if (!BuildCurrentNumber(currentL, currentNumbers, startNumbers))
	{
		currentL++;
		BuildCurrentNumber(currentL, currentNumbers, startNumbers);
	}


	LL currentPrime = 0;
	for (LL i = 2;i <= maxPrime;i++)
	{
		if (!isComposite[i])
		{
			primesSieve[currentPrime++] = i;

			if (currentPrime == 0)
			{
				cout << i;
			}
		}

		for (LL j = 0; j < currentPrime && primesSieve[j] * i <= maxPrime; j++)
		{
			isComposite[primesSieve[j] * i] = true;
		}
	}



	LL currentNumber = ConvertNumber(currentNumbers, currentL);
	LL result = 0;
	bool isCurrentPrime;

	while (currentNumber <= finish)
	{
		isCurrentPrime = true;

		for (LL j=0; j < currentPrime && primesSieve[j] * primesSieve[j] <= currentNumber; j++)
		{
			if (currentNumber % primesSieve[j] == 0)
			{
				isCurrentPrime = false;
				break;
			}
		}

		if (isCurrentPrime)
		{
			result++;
		}

		Increment(currentNumbers, currentL);
		currentNumber = ConvertNumber(currentNumbers, currentL);
	}

	cout << result;
}
