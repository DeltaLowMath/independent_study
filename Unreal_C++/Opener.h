
#pragma once

#include "CoreMinimal.h"
#include "Components/ActorComponent.h"
#include "Opener.generated.h"


UCLASS( ClassGroup=(Custom), meta=(BlueprintSpawnableComponent) )
class DUNGEONCRAWLER_API UOpener : public UActorComponent
{
	GENERATED_BODY()

public:
	UOpener();

protected:
	virtual void BeginPlay() override;

public:	
	virtual void TickComponent(float DeltaTime, ELevelTick TickType, FActorComponentTickFunction* ThisTickFunction) override;

	void SetShouldOpen(bool ShouldOpen);

private:
	UPROPERTY(EditAnywhere)
	FVector MoveDistance;

	UPROPERTY(EditAnywhere)
	float MoveTimeSeconds = 8;
	
	bool ShouldOpen = false;

	FVector OriginalLocation; 
};