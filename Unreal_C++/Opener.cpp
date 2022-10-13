
#include "Opener.h"

#include "Math/UnrealMathUtility.h"

UOpener::UOpener()
{
	PrimaryComponentTick.bCanEverTick = true;
}

void UOpener::BeginPlay()
{
	Super::BeginPlay();

	OriginalLocation = GetOwner()->GetActorLocation();
}

void UOpener::TickComponent(float DeltaTime, ELevelTick TickType, FActorComponentTickFunction* ThisTickFunction)
{
	Super::TickComponent(DeltaTime, TickType, ThisTickFunction);

	if (ShouldOpen)
	{
		FVector CurrentLocation = GetOwner()->GetActorLocation();
		FVector TargetLocation = OriginalLocation + MoveDistance;
		float MoveSpeed = FVector::Distance(OriginalLocation, TargetLocation) / MoveTimeSeconds;

		FVector NewLocation = FMath::VInterpConstantTo(CurrentLocation, TargetLocation, DeltaTime, MoveSpeed);
		GetOwner()->SetActorLocation(NewLocation);
	}
}

void UOpener::SetShouldOpen(bool NewShouldOpen)
{
	ShouldOpen = NewShouldOpen;
}