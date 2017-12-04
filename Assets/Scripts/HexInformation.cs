using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexInformation : MonoBehaviour {

	public int x;
	public int y;

	//Default constructor
	public HexInformation()
	{

	}

	public HexInformation(int x, int y)
	{
		this.x = x;
		this.y = y;
	}
}
