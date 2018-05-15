using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player {

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

	public void addSpoilsCard(SpoilsCard sc){
		this.activeSpoils.Add(sc);
	}

	public void addCharacterCard(CharacterCard cc){
		this.activeCharacters.Add(cc);
	}

	public void addActionCard(ActionCard ac){
		this.actionCards.Add(ac);
	}
}
