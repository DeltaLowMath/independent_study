#include <iostream>
using namespace std;

int main()
{
	int MyArray[6] = { 1, 28, 2, 56, 5, 12 };

	for (int i = 0; i < 6; i++)
	{
		cout << "MyArray[" << i << "] = " << MyArray[i] << endl;
	}

	system("pause");
}