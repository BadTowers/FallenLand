using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexInformation : MonoBehaviour, HexInterface {

	public int x;
	public int y;
	private bool city;
	private bool rad;
	private bool mountain;
	private bool plains;
	private bool randomNumber;
	private bool water;
	private bool factionBase;
	private Faction factionName;

	public HexInformation()
	{

	}

	public bool isCity()
	{
		return city;
	}

	public bool isRad()
	{
		return rad;
	}
		
	public bool isMountain()
	{
		return mountain;
	}

	public bool isPlains()
	{
		return plains;
	}

	public bool isRandomNumber()
	{
		return randomNumber;
	}

	public bool isWater()
	{
		return water;
	}

	public bool isFactionBase()
	{
		return factionBase;
	}

	public Faction getFactionBase()
	{
		//TODO
		return new Faction();
	}
}
