﻿using System.Collections.Generic;


public class Faction {

	//A faction has a name
	private string facName;
	//A faction has perks
	private List<Perk> perks;
	//A faction has a starting base location
	private Coordinates baseCoordinates;
	//A faction has a starting base name (city, state)
	private string baseLocationString;
	//A faction has lore
	private string facLore;
	//A faction has starting town techs
	private List<TownTech> startingTownTechs;
	//A faction has an ID
	private int ID;



	//Constructor
	public Faction(string name, Coordinates c){
		this.facName = name;
		this.baseCoordinates = c;
		perks = new List<Perk>();
        startingTownTechs = new List<TownTech>();
	}


	public void setName(string n){
		this.facName = n;
	}

	public string getName(){
		return this.facName;
	}

	public void setPerks(List<Perk> p){
		this.perks = p;
	}

	public void addPerk(Perk p){
		this.perks.Add(p);
	}

	public List<Perk> getPerks(){
		return this.perks;
	}

	public void setBaseLocation(Coordinates c){
		this.baseCoordinates = c;
	}

	public Coordinates getBaseLocation(){
		return this.baseCoordinates;
	}

	public void setBaseLocationString(string s){
		this.baseLocationString = s;
	}

	public string getBaseLocationString(){
		return this.baseLocationString;
	}

	public void setLore(string lore){
		this.facLore = lore;
	}

	public string getLore(){
		return this.facLore;
	}

	public void setStartingTownTechs(List<TownTech> t){
		this.startingTownTechs = t;
	}

	public void addStartingTownTech(TownTech t){
		this.startingTownTechs.Add(t);
	}

	public List<TownTech> getStartingTownTechs(){
		return this.startingTownTechs;
	}

	public void setID(int id){
		this.ID = id;
	}

	public int getID(){
		return this.ID;
	}

}
