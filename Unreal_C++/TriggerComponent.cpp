
#include "TriggerComponent.h"

UTriggerComponent::UTriggerComponent()
{
	PrimaryComponentTick.bCanEverTick = true;

	UE_LOG(LogTemp, Display, TEXT("Trigger Componenet is Constructing"));
}

void UTriggerComponent::BeginPlay()
{
	Super::BeginPlay();

	UE_LOG(LogTemp, Display, TEXT("Trigger Componenet Alive"));
}

void UTriggerComponent::TickComponent(float DeltaTime, ELevelTick TickType, FActorComponentTickFunction* ThisTickFunction)
{
	Super::TickComponent(DeltaTime, TickType, ThisTickFunction);

	AActor* Actor = GetAcceptableActor();
	if (Actor != nullptr)
	{
		UPrimitiveComponent* Component = Cast<UPrimitiveComponent>(Actor->GetRootComponent());
		if (Component != nullptr)
		{
			Component->SetSimulatePhysics(false);
		}
		Actor->AttachToComponent(this, FAttachmentTransformRules::KeepWorldTransform);
		Opener->SetShouldOpen(true);
	}
	else
	{
		Opener->SetShouldOpen(false);
	}
}

void UTriggerComponent::SetOpener(UOpener* NewOpener)
{
	Opener = NewOpener;
}

AActor* UTriggerComponent::GetAcceptableActor() const
{
	TArray<AActor*> Actors;
	GetOverlappingActors(Actors);
	for (AActor* Actor : Actors)
	{
		bool HasAcceptedTag = Actor->ActorHasTag(AcceptedTag);
		bool IsHeld = Actor->ActorHasTag("Held");
		if (HasAcceptedTag && !IsHeld)
		{
			return Actor;
		}
	}
	return nullptr;
}