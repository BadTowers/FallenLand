using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexInformation : MonoBehaviour {
	public int x;
	public int y;
	private bool city;
	private bool rad;
	private bool mountain;
	private bool plains;
	private bool randomNumber;
	private bool water;
	private bool factionBase;
	private Factions faction;

	//Empty constructor
	public HexInformation()
	{

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

	public bool isFactionBase()
	{
		return factionBase;
	}

	public void setIsFactionBase(bool fb)
	{
		this.factionBase = fb;
	}

	public void setFaction(Factions f)
	{
		this.faction = f;
	}
}
