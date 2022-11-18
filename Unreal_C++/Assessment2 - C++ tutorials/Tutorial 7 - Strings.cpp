#include <iostream>
#include <string>
using namespace std;

int main()
{
	string MyString1;
	MyString1 = "My cat's name is: ";
	string FirstName1 = "Merci ";
	string LastName1 = "Beaucoup";

	string MyString2 = "My other cat's name is: ";
	string FirstName2 = "Big Sir ";
	string LastName2 = "Bear";

	MyString1 += FirstName1;
	MyString1 += LastName1;

	MyString2 += (FirstName2 + LastName2);

	cout << MyString1 << endl;
	cout << MyString2 << endl;


	char MyCString1[5] = { 'C', 'a', 't', 's', '\0' };
	char MyCString2[5] = "Dogs";

	system("pause");
}