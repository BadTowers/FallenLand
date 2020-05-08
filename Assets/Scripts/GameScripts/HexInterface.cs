using UnityEngine;
using System.Collections;

public interface HexInterface
{
	bool IsCity();
	void SetIsCity(bool isCity);

	bool IsRad();
	void SetIsRad(bool isRad);

	bool IsMountain();
	void SetIsMountain(bool isMountain);

	bool IsPlains();
	void SetIsPlains(bool isPlains);

	bool IsRandomLocation();
	void SetIsRandomLocation(bool isRandomLocation);

	bool IsWater();
	void SetIsWater(bool isWater);

	bool IsFactionBase();
	void SetIsFactionBase(bool isFactionBase);

	bool IsResource();
	void SetIsResource(bool isResource);

	Faction GetFaction();
	void SetFaction(Faction faction);

	int GetRandomLocationNumber();
	void SetRandomLocationNumber(int randomLocationNumber);

	bool IsHexInGame();
	void SetIsHexInGame(bool isValid);
}
