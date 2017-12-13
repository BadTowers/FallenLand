using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour, HexInterface{
	public int x;
	public int y;
	private bool city;
	private bool rad;
	private bool mountain;
	private bool plains;
	private bool randomNumber;
	private bool water;
	private bool resource;
	private bool factionBase;
	private Factions faction;
	private bool visible;

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

	public Factions getFaction()
	{
		return this.faction;
	}

	public void setFaction(Factions f)
	{
		this.faction = f;
	}

	public bool isVisible()
	{
		return this.visible;
	}

	public void setIsVisible(bool vis)
	{
		this.visible = vis;
	}
}
