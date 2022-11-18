#include <iostream>
#include <string>
using namespace std;

void ChangeString(string& str);

int main()
{
	string myString = "Warlock";

	ChangeString(myString);

	cout << myString << endl;

	system("pause");
}

void ChangeString(string& str)
{
	str += "!!!";
}