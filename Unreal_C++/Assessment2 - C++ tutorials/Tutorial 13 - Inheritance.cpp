#include <iostream>
#include <string>
using namespace std;

class Animal
{
public:
	Animal();
	Animal(string name, int age, int num_limbs);

	string Name;
	int Age;
	int NumberOfLimbs;

	void Report();
};

class Dog : public Animal
{
public:
	Dog();
	Dog(string name, int age, int num_limbs);

	void Speak();
};

class Shiba : public Dog
{
public:
	Shiba();
	Shiba(string name, int age, int num_limbs);
};

int main()
{
	Animal animal;
	animal.Report();

	Animal animal_2("Cheeto", 16, 4);

	Dog dog("Spot", 5, 4);
	dog.Speak();

	Shiba shiba("Doge", 8, 4);
	shiba.Speak();

	system("pause");
}

Animal::Animal()
{
	cout << "An ANIMAL is born!" << endl;

	Name = "Default";
	Age = 8;
	NumberOfLimbs = 4;
}

//Animal::Animal(string name, int age, int num_limbs)
//{
//	Name = name;
//	Age = age;
//	NumberOfLimbs = num_limbs;
//}

Animal::Animal(string name, int age, int num_limbs) 
	: Name(name), Age(age), NumberOfLimbs(num_limbs) 
{
	Report();
}

void Animal::Report()
{
	cout << endl;
	cout << "Name: " << Name << endl;
	cout << "Age: " << Age << endl;
	cout << "NumberOfLimbds: = " << NumberOfLimbs << endl;
	cout << endl;
}

Dog::Dog()
{
	cout << "A DOG is born" << endl;
}

Dog::Dog(string name, int age, int num_limbs) : Animal(name, age, num_limbs)
{
}

void Dog::Speak()
{
	cout << "Woof!\n";
}

Shiba::Shiba(string name, int age, int num_limbs) : Dog(name, age, num_limbs)
{
}