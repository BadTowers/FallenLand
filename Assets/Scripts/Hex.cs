using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour, HexInterface{
	private Coordinates coords;
	private bool city;
	private bool rad;
	private bool mountain;
	private bool plains;
	private bool randomNumber;
	private bool water;
	private bool resource;
	private bool factionBase;
	private Factions.name faction = Factions.name.NULL;
	private bool valid;

	//CONSTRUCTORS
	public Hex()
	{

	}
	public Hex(Coordinates coords)
	{
		this.coords = coords;
	}
	public Hex(int x, int y)
	{
		this.coords = new Coordinates (x, y);
	}

	public void setCoordinates(Coordinates coords)
	{
		this.coords = coords;
	}

	public void setCoordinates(int x, int y)
	{
		this.coords = new Coordinates (x, y);
	}

	public Coordinates getCoordinates()
	{
		return this.coords;
	}

	public bool isCity()
	{
		return city;
	}

	public void setIsCity(bool city)
	{
		this.city = city;
	}

	public bool isRad()
	{
		return rad;
	}

	public void setIsRad(bool rad)
	{
		this.rad = rad;
	}
		
	public bool isMountain()
	{
		return mountain;
	}

	public void setIsMountain(bool mountain)
	{
		this.mountain = mountain;
	}

	public bool isPlains()
	{
		return plains;
	}

	public void setIsPlains(bool plains)
	{
		this.plains = plains;
	}

	public bool isRandomNumber()
	{
		return randomNumber;
	}

	public void setIsRandomNumber(bool rn)
	{
		this.randomNumber = rn;
	}

	public bool isWater()
	{
		return water;
	}

	public void setIsWater(bool water)
	{
		this.water = water;
	}

	public bool isResource()
	{
		return this.resource;
	}

	public void setIsResource(bool resource)
	{
		this.resource = resource;
	}

	public bool isFactionBase()
	{
		return factionBase;
	}

	public void setIsFactionBase(bool fb)
	{
		this.factionBase = fb;
	}

	public Factions.name getFaction()
	{
		return this.faction;
	}

	public void setFaction(Factions.name f)
	{
		this.faction = f;
	}

	public bool isHexInGame()
	{
		return this.valid;
	}

	public void setIsHexInGame(bool valid)
	{
		this.valid = valid;
	}
}
