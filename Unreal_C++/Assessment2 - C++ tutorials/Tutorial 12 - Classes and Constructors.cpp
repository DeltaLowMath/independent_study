#include <iostream>
#include <string>
using namespace std;

class Cat
{
public:

	Cat();

	string Name;
	int Age;
	float Hunger;

	void Meow();
};

struct Dog
{
	Dog();

	int Age;
	float Health;

	void Bark();
};

Dog::Dog()
{
	cout << "A new dog is born" << endl;

	Age = 16;
	Health = 40.f;

	Bark();
}

void Dog::Bark()
{
	cout << "My age is " << Age << ".\n";
	cout << "My health is " << Health << ".\n";
}

int main()
{
	Dog dog;
	
	system("pause");
}

Cat::Cat()
{
	Name;
	Age;
	Hunger;
	Meow();
}

void Cat::Meow()
{
	if (Hunger > 40.f)
	{
		cout << "Jumps on desk and says Meow!" << endl;
	}
}

void InstantiateCats()
{
	Cat Shadow;
	Cat Ms;

	Shadow.Name = "Shadow";
	Shadow.Age = 10;
	Shadow.Hunger = 80.f;

	Ms.Name = "Miss";
	Ms.Age = 9;
	Ms.Hunger = 64.f;
}