using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour {

	private string title;

	public Card(string title){
		this.title = title;
	}

	public string getTitle(){
		return title;
	}

}
