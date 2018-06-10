using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player {

	private List<SpoilsCard> activeSpoils;
	private List<SpoilsCard> auctionHouse; //Spoils in their town (inactive)
	private List<ActionCard> actionCards;
	private List<CharacterCard> activeCharacters;
    private List<CharacterCard> townRoster; //Characters in their town (inactive)
    private Faction faction;
    private List<TownTech> townTechs;
    private int salvage;



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

	public List<SpoilsCard> getActiveSpoilsCards(){
		return this.activeSpoils;
	}

	public SpoilsCard getActiveSpoilsCard(int ID){
		return this.activeSpoils[ID];
	}

	public void setFaction(Faction f){
		this.faction = f;
	}

	public Faction getFaction(){
		return this.faction;
	}
}
