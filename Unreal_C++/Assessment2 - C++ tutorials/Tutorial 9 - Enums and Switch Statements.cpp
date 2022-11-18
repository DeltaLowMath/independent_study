#include <iostream>
#include <string>
using namespace std;

enum PlayerStatus
{
	PS_Crawling,
	PS_Crouching,
	PS_Standing,
	PS_Walking,
	PS_Running
};

const float RunSpeed = 32.0f;
const float WalkSpeed = 16.0f;
const float CrouchSpeed = 8.0f;
const float CrawlSpeed = 4.0f;

void UpdateMovementSpeedIf(PlayerStatus P_Status, float& speed);
void UpdateMovementSpeedSwitch(PlayerStatus P_Status, float& speed);
void SwitchOnInt(int i);

int main()
{
	float MovementSpeed;
	PlayerStatus status = PS_Walking;

	UpdateMovementSpeedSwitch(status, MovementSpeed);
	
	cout << "MovementSpeed = " << MovementSpeed << endl;

	int integer = 404;
	SwitchOnInt(integer);


	system("pause");
}

void SwitchOnInt(int i)
{
	switch (i)
	{
	case 0:
		cout << "Your number was zero. \n";
			break;
	case 1:
		cout << "Your number was one. \n";
			break;
	case 2:
		cout << "Your number was two. \n";
			break;
	case 3:
		cout << "Your number was three. \n";
			break;
	default:
		cout << "Your number was not zero, nor one, two or three. \n";
			break;
	}
}

void UpdateMovementSpeedSwitch(PlayerStatus P_Status, float& speed)
{
	switch (P_Status)
	{
	case PS_Running:
		speed = RunSpeed;
		break;
	case PS_Walking:
		speed = WalkSpeed;
		break;
	case PS_Crouching:
		speed = CrouchSpeed;
		break;
	case PS_Crawling:
		speed = CrawlSpeed;
		break;
	}
}

void UpdateMovementSpeedIf(PlayerStatus P_Status, float& speed)
{
	if (P_Status == PS_Running)
	{
		speed = RunSpeed;
	}
	else if (P_Status == PS_Walking)
	{
		speed = WalkSpeed;
	}
	else if (P_Status == PS_Crouching)
	{
		speed = CrouchSpeed;
	}
	else if (P_Status == PS_Crawling)
	{
		speed = CrawlSpeed;
	}
}