
#include "Grabber.h"

#include "Engine/World.h"
#include "DrawDebugHelpers.h"
#include "PhysicsEngine/PhysicsHandleComponent.h"

UGrabber::UGrabber()
{
	PrimaryComponentTick.bCanEverTick = true;
}

void UGrabber::BeginPlay()
{
	Super::BeginPlay();
}

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

bool UGrabber::GetGrabbableInReach(FHitResult& OutGrabbable) const
{
	FVector Start = GetComponentLocation();
	FVector End = Start + GetForwardVector() * ReachDistance;
	FCollisionShape SenseTouch = FCollisionShape::MakeSphere(GrabRadius);

	return GetWorld()->SweepSingleByChannel(
		OutGrabbable,
		Start, End,
		FQuat::Identity,
		ECC_GameTraceChannel2,
		SenseTouch
	);
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
	FVector Start = GetComponentLocation();
	FVector End = Start + GetForwardVector() * ReachDistance;
	DrawDebugLine(GetWorld(), Start, End, FColor::Red);
	DrawDebugSphere(GetWorld(), End, 10, 16, FColor::Red, false, 10);
}

void UGrabber::DebugGrabAim()
{
	FRotator CameraRotation = GetComponentRotation();
	FString RotationLog = CameraRotation.ToCompactString();
	UE_LOG(LogTemp, Display, TEXT("Grabber Rotation: %s"), *RotationLog);
}