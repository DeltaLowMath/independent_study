#include <iostream>
using namespace std;

int main()
{
	for (int i = 0; i <= 10; i++)
	{
		for (int j = 0; j <= 10; j++)
		{
			for (int k = 0; k <= 10; k++)
			{
				cout << "i = " << i << " ( k of " << k << " (j = " << j << "))" << endl;
			}
		}
	}

	system("pause");
}

void AllTheWhile()
{
	int count = 0;

	double NumberPi = 3.1459;
	double NumberE = 2.81643212851256;
	bool Condition = true;

	while (count <= 10)
	{
		cout << count << endl;
		count++;
	}

	do
	{
		cout << "Pi by E by Count = " << NumberPi + NumberE * count << endl;

		count++;
		if (count <= 100)
		{
			Condition = true;
		}
		else
		{
			Condition = false;
		}
	} while (Condition);
}