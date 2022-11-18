#include <iostream>
#include <string>
using namespace std;

class Creature
{
public:
	Creature();

	void SetName(string name);
	
	string GetName();
	float GetHealth();

	void TakeDamage(float damage);

private:
	string Name;
	float Health;

protected:
	int NumberOfLimbs;

};

class Goblin : public Creature
{
public:
	Goblin();
	int GetLimbNum();
};

int main()
{
	Creature Igoth;
	Igoth.SetName("Igoth");

	cout << Igoth.GetName() << endl;
	cout << "Health: " << Igoth.GetHealth() << endl;

	cout << "Igoth will now take 35 damage!" << endl;
	Igoth.TakeDamage(35.0);

	cout << endl;

	Goblin Ral;
	cout << Ral.GetName() << endl;
	cout << "Limbs: " << Ral.GetLimbNum() << endl;

	system("pause");
}

Creature::Creature()
{
	Health = 100.f;
	cout << "A creature has spawned!\n";
}

void Creature::SetName(string name)
{
	Name = name;
}

string Creature::GetName()
{
	return Name;
}

float Creature::GetHealth()
{
	return Health;
}

void Creature::TakeDamage(float damage)
{
	float TotalHealth;
	TotalHealth = Health - damage;

	if (TotalHealth <= 0.f)
	{
		cout << GetName() << " has died!\n";
	}
	else
	{
		Health -= damage;
	}

	cout << "Health: " << Health << endl;
}

Goblin::Goblin()
{
	NumberOfLimbs = 5;
	SetName("Ral");
}

int Goblin::GetLimbNum()
{
	return NumberOfLimbs;
}