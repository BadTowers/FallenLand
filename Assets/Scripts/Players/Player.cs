using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour {

	private List<SpoilsCard> activeSpoils;
	private List<SpoilsCard> auctionHouse;
	private List<ActionCard> actionCards;
	private List<CharacterCard> townRoster;
	private List<CharacterCard> activeCharacters;


	public Player(){
		initLists();
	}

	private void initLists(){
		activeSpoils = new List<SpoilsCard>();
		auctionHouse = new List<SpoilsCard>();
		actionCards = new List<ActionCard>();
		townRoster = new List<CharacterCard>();
		activeCharacters = new List<CharacterCard>();
	}
}
