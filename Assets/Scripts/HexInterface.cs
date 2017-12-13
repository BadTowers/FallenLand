﻿using UnityEngine;
using System.Collections;

public interface HexInterface {

	bool isCity();
	void setIsCity(bool city);

	bool isRad();
	void setIsRad(bool rad);

	bool isMountain();
	void setIsMountain(bool mountain);

	bool isPlains();
	void setIsPlains(bool plains);

	bool isRandomNumber();
	void setIsRandomNumber(bool rand);

	bool isWater();
	void setIsWater(bool water);

	bool isFactionBase();
	void setIsFactionBase(bool b);

	bool isResource();
	void setIsResource(bool resource);

	Factions getFaction();
	void setFaction(Factions f);

	bool isVisible();
	void setIsVisible( bool vis);
}
