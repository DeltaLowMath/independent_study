
#pragma once

#include "CoreMinimal.h"
#include "Components/BoxComponent.h"
#include "Opener.h"
#include "TriggerComponent.generated.h"


UCLASS( ClassGroup = (Custom), meta = (BlueprintSpawnableComponent) )
class DUNGEONCRAWLER_API UTriggerComponent : public UBoxComponent
{
	GENERATED_BODY()

public:
	UTriggerComponent();

protected:
	virtual void BeginPlay() override;

public:
	virtual void TickComponent(float DeltaTime, ELevelTick TickType, FActorComponentTickFunction* ThisTickFunction) override;

	UFUNCTION(BlueprintCallable)
	void SetOpener(UOpener* Opener);

private:
	UPROPERTY(EditAnywhere)
	FName AcceptedTag;

	UOpener* Opener;

	AActor* GetAcceptableActor() const;
};