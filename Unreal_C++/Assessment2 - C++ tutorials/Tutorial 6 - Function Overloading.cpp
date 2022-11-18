#include <iostream>
#include <string>
using namespace std;

void Print(string str);
void Print(int i);
void Print(string str1, string str2);
void Print(int i, string str);

int main()
{
	int myInt = 4;
	string myStr = "Ranger";
	string mySecondStr = "Moon";

	Print(myStr);
	Print(mySecondStr);
	Print(myInt);
	Print(myInt, myStr);
	Print(myStr, mySecondStr);

	system("pause");
}

void Print(string str)
{
	cout << str << endl;
}

void Print(int i)
{
	cout << i << endl;
}

void Print(string str1, string str2)
{
	cout << "String 1: " << str1 << endl;
	cout << "String 2: " << str2 << endl;
}

void Print(int i, string str)
{
	cout << "Integer value: " << i << endl;
	cout << "String value: " << str << endl;
}