#include <iostream>
using namespace std;

int main() 
{
	int a = 22;
	int b(22);

	if (a > b) 
	{
		cout << "a is greater than b." << endl;
	}
	else if (a < b)
	{
		cout << "a is less than b." << endl;
	}
	else
	{
		cout << "a is equal to b." << endl;
	}

	system("pause");
}