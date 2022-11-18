#include <iostream>
#include <string>
using namespace std;

void intPointer();
void arrayPointer();
void structPointer();

int main()
{
	structPointer();

	system("pause");
}

void structPointer()
{
	struct Container
	{
		string Name;

		int X;
		int Y;
		int Z;
	};

	Container container1 = { "mountain", 2, 5, 6 };

	Container* PtrToContained = &container1;

	cout << "container1 ref(name) = " << (*PtrToContained).Name << endl;
	cout << "container1 ref(X) = " << (*PtrToContained).X << endl;
	cout << "container1 ref(Y) = " << (*PtrToContained).Y << endl;
	cout << "container1 ref(Z) = " << (*PtrToContained).Z << endl;

	cout << "container1 ref(name) = " << PtrToContained->Name << endl;
	cout << "container1 ref(X) = " << PtrToContained->X << endl;
	cout << "container1 ref(Y) = " << PtrToContained->Y << endl;
	cout << "container1 ref(Z) = " << PtrToContained->Z << endl;
}

void arrayPointer()
{
	int numbers[] = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

	int* NumPtr = numbers;

	cout << "NumPtr pointing to the first element of numbers array = " << *NumPtr << endl;

	NumPtr++;

	cout << "NumPtr pointing to the second element of numbers array = " << *NumPtr << endl;

	NumPtr++;

	cout << "NumPtr pointing to the third element of numbers array = " << *NumPtr << endl;

	NumPtr += 5;

	cout << "NumPtr pointing to the eighth element of numbers array = " << *NumPtr << endl;
}

void intPointer()
{
	int a = 100;
	int* aPtr;
	aPtr = &a;

	cout << "aPtr = " << *aPtr << endl;

	int b = 50;
	aPtr = &b;

	cout << "aPtr rereferenced = " << *aPtr << endl;

	int c = 1000;
	int* cPtr = &c;

	cout << "cPtr = " << *cPtr << endl;
}