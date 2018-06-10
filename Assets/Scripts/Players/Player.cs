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



	public Player(int startingSalvage){
        this.salvage = startingSalvage;
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

    public int getSalvage() {
        return this.salvage;
    }

    public void addSalvage(int salvageToAdd) {
        this.salvage += salvageToAdd;
    }

    public void subtractSalvage(int salvageToSubtract) {
        this.salvage -= salvageToSubtract;
    }

    public List<TownTech> getTownTechs() {
        return this.townTechs;
    }

    public void addTownTech(TownTech toAdd) {
        this.townTechs.Add(toAdd);
    }

    //TODO this prolly isn't right
    public void removeTownTech(TownTech toRemove) {
        this.townTechs.Remove(toRemove);
    }
}
