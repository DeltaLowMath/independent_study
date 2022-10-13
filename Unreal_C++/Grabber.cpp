// Fill out your copyright notice in the Description page of Project Settings.


#include "Grabber.h"

#include "Engine/World.h"
#include "DrawDebugHelpers.h"
#include "PhysicsEngine/PhysicsHandleComponent.h"

// Sets default values for this component's properties
UGrabber::UGrabber()
{
	// Set this component to be initialized when the game starts, and to be ticked every frame.  You can turn these features
	// off to improve performance if you don't need them.
	PrimaryComponentTick.bCanEverTick = true;
}


// Called when the game starts
void UGrabber::BeginPlay()
{
	Super::BeginPlay();
}


// Called every frame
void UGrabber::TickComponent(float DeltaTime, ELevelTick TickType, FActorComponentTickFunction* ThisTickFunction)
{
	Super::TickComponent(DeltaTime, TickType, ThisTickFunction);

	UPhysicsHandleComponent *PhysicsHandle = GetPhysicsHandle();
	if (PhysicsHandle == nullptr)
	{
		return;
	}
	
	if (PhysicsHandle->GetGrabbedComponent() !=nullptr)
	{
		FVector TargetLocation = GetComponentLocation() + GetForwardVector() * HoldDistance;
		PhysicsHandle->SetTargetLocationAndRotation(TargetLocation, GetComponentRotation());
	}
}

void UGrabber::Grab() 
{
	UPhysicsHandleComponent *PhysicsHandle = GetPhysicsHandle();
	if (PhysicsHandle == nullptr)
	{
		return;
	}

	FHitResult Grabbable;
	bool CanReach = GetGrabbableInReach(Grabbable);
	if (CanReach) 
	{
		UPrimitiveComponent* HitComponent = Grabbable.GetComponent();
		HitComponent->WakeAllRigidBodies();
		Grabbable.GetActor()->Tags.Add("Held");
		PhysicsHandle->GrabComponentAtLocationWithRotation(
			HitComponent,
			NAME_None,
			Grabbable.ImpactPoint,
			GetComponentRotation()
		);
	}
	UE_LOG(LogTemp, Display, TEXT("Grabbed Grabbable"));
}

void UGrabber::Release() 
{
	UPhysicsHandleComponent* PhysicsHandle = GetPhysicsHandle();
	if (PhysicsHandle == nullptr)
	{
		return;
	}

	if (PhysicsHandle->GetGrabbedComponent() !=nullptr)
	{
		AActor* HeldActor = PhysicsHandle->GetGrabbedComponent()->GetOwner();
		HeldActor->Tags.Remove("Held");
		PhysicsHandle->GetGrabbedComponent()->WakeAllRigidBodies();
		PhysicsHandle->ReleaseComponent();
	}
	UE_LOG(LogTemp, Display, TEXT("Released Grabbable"));
}

UPhysicsHandleComponent* UGrabber::GetPhysicsHandle() const
{
	UPhysicsHandleComponent* Result = GetOwner()->FindComponentByClass<UPhysicsHandleComponent>();
	if (Result == nullptr)
	{
		UE_LOG(LogTemp, Error, TEXT("Grabber Requires a UPhysicsHandleComponent."));
	}
	return Result;
}

bool UGrabber::GetGrabbableInReach(FHitResult& OutGrabbable) const
{
	FVector Start = GetComponentLocation();
	FVector End = Start + GetForwardVector() * MaxGrabDistance;
	DrawDebugLine(GetWorld(), Start, End, FColor::Red);
	DrawDebugSphere(GetWorld(), End, 10, 16, FColor::Red, false, 10);

	FCollisionShape SenseTouch = FCollisionShape::MakeSphere(GrabRadius);
	return GetWorld()->SweepSingleByChannel(
		OutGrabbable,
		Start, End,
		FQuat::Identity,
		ECC_GameTraceChannel2,
		SenseTouch
	);
}

void UGrabber::DebugReach()
{
	FHitResult Grabbable;
	bool CanReach = GetGrabbableInReach(Grabbable);
	if (CanReach)
	{
		DrawDebugSphere(GetWorld(), Grabbable.Location, 8, 16, FColor::Green, false, 10);
		DrawDebugSphere(GetWorld(), Grabbable.ImpactPoint, 8, 16, FColor::Blue, false, 10);
		AActor* HitActor = Grabbable.GetActor();
		UE_LOG(LogTemp, Display, TEXT("Hit actor: %s"), *HitActor->GetActorNameOrLabel());
	}
	else 
	{
		UE_LOG(LogTemp, Display, TEXT("No actor hit."));
	}
	FRotator CameraRotation = GetComponentRotation();
	FString RotationString = CameraRotation.ToCompactString();
	UE_LOG(LogTemp, Display, TEXT("Grabber Rotation: %s"), *RotationString);
}