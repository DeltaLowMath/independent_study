#include <iostream>
using namespace std;

class Object
{
public:
	virtual void BeginPlay();
};

class Actor : public Object
{
public:
	void BeginPlay();
};

class Pawn : public Actor
{
public:
	virtual void BeginPlay() override;
};

int main()
{
	Object* obj = new Object;
	obj->BeginPlay();

	Actor* act = new Actor;
	act->BeginPlay();

	Pawn* pwn = new Pawn;
	pwn->BeginPlay();

	delete obj;
	delete act;
	delete pwn;

	system("pause");
}

void Object::BeginPlay()
{
	cout << "Object BeginPlay() called.\n";
}

void Actor::BeginPlay()
{
	cout << "Actor BeginPlay() called.\n";
	Object::BeginPlay();
}

void Pawn::BeginPlay()
{
	cout << "Pawn BeginPlay() called.\n";
	Actor::BeginPlay();
}