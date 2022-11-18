#include <iostream>
using namespace std;

class Item
{
public:
	Item()
	{
		cout << "An item has been created.\n";
	}
	~Item()
	{
		cout << "An item has been destroyed.\n";
	}
};

class Critter
{
public:

	Critter()
	{
		cout << "A critter is spawned!\n";
		++CritterCount;
	}

	static void AnnounceCount()
	{
		cout << CritterCount << endl;
	}

	static int CritterCount;
};

int Critter::CritterCount = 0;

void AddToCount();
void StaticItem();
void CritterSpawner();

int main()
{
	CritterSpawner();

	system("pause");
}

void AddToCount()
{
	static int count = 0;
	count++;

	cout << count << endl;

	for (int i = 0; i < 100; i++)
	{
		AddToCount();
	}
}

void StaticItem()
{
	{
		Item item;
	}
	{
		static Item item;
	}
}

void CritterSpawner()
{
	for (int i = 0; i < 20; i++)
	{
		Critter* critter = new Critter;
		Critter::AnnounceCount();
		delete critter;
	}
}