using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Hex : MonoBehaviour, HexInterface
{
	private Coordinates CoordinatesInstance;
	private bool IsCityHex;
	private bool IsRadHex;
	private bool IsMountainHex;
	private bool IsPlainsHex;
	private bool IsRandomLocationHex;
	private bool IsWaterHex;
	private bool IsResourceHex;
	private bool IsFactionBaseHex;
	private Faction FactionInstance;
	private int LocationNumber;
	private bool IsValidHex;

	public Hex()
	{
		CoordinatesInstance = new Coordinates(Constants.INVALID_LOCATION, Constants.INVALID_LOCATION);
		FactionInstance = new Faction("invalid faction", new Coordinates(Constants.INVALID_LOCATION, Constants.INVALID_LOCATION));
	}

	public Hex(Coordinates coords)
	{
		if (coords != null)
		{
			CoordinatesInstance = coords;
		}
		else
		{
			CoordinatesInstance = new Coordinates(Constants.INVALID_LOCATION, Constants.INVALID_LOCATION);
		}

		FactionInstance = new Faction("invalid faction", new Coordinates(Constants.INVALID_LOCATION, Constants.INVALID_LOCATION));
	}

	public Hex(int x, int y)
	{
		setXAndYCoordinates(x, y);
		FactionInstance = new Faction("invalid faction", new Coordinates(Constants.INVALID_LOCATION, Constants.INVALID_LOCATION));
	}

	public void SetCoordinates(Coordinates coords)
	{
		if (coords != null)
		{
			CoordinatesInstance = coords;
		}
	}

	public void SetCoordinates(int x, int y)
	{
		setXAndYCoordinates(x, y);
	}

	public Coordinates GetCoordinates()
	{
		return CoordinatesInstance;
	}

	public bool IsCity()
	{
		return IsCityHex;
	}

	public void SetIsCity(bool city)
	{
		IsCityHex = city;
	}

	public bool IsRad()
	{
		return IsRadHex;
	}

	public void SetIsRad(bool rad)
	{
		IsRadHex = rad;
	}

	public bool IsMountain()
	{
		return IsMountainHex;
	}

	public void SetIsMountain(bool mountain)
	{
		IsMountainHex = mountain;
	}

	public bool IsPlains()
	{
		return IsPlainsHex;
	}

	public void SetIsPlains(bool plains)
	{
		IsPlainsHex = plains;
	}

	public bool IsRandomLocation()
	{
		return IsRandomLocationHex;
	}

	public void SetIsRandomLocation(bool isRandomLocation)
	{
		IsRandomLocationHex = isRandomLocation;
	}

	public bool IsWater()
	{
		return IsWaterHex;
	}

	public void SetIsWater(bool isWater)
	{
		IsWaterHex = isWater;
	}

	public bool IsResource()
	{
		return IsResourceHex;
	}

	public void SetIsResource(bool isResource)
	{
		IsResourceHex = isResource;
	}

	public bool IsFactionBase()
	{
		return IsFactionBaseHex;
	}

	public void SetIsFactionBase(bool isFactionBase)
	{
		IsFactionBaseHex = isFactionBase;
	}

	public Faction GetFaction()
	{
		return FactionInstance;
	}

	public void SetFaction(Faction faction)
	{
		if (faction != null)
		{
			FactionInstance = faction;
		}
	}

	public int GetRandomLocationNumber()
	{
		return LocationNumber;
	}

	public void SetRandomLocationNumber(int locationNum)
	{
		if (locationNum > 0)
		{
			LocationNumber = locationNum;
		}
	}

	public bool IsHexInGame()
	{
		return IsValidHex;
	}

	public void SetIsHexInGame(bool isValid)
	{
		IsValidHex = isValid;
	}

	private void setXAndYCoordinates(int x, int y)
	{
		if (x < Constants.INVALID_LOCATION)
		{
			x = Constants.INVALID_LOCATION;
		}
		if (y < Constants.INVALID_LOCATION)
		{
			y = Constants.INVALID_LOCATION;
		}
		CoordinatesInstance = new Coordinates(x, y);
	}
}
