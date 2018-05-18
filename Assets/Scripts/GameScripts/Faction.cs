using System.Collections.Generic;


public class Faction {

	//A faction has a name
	private string facName;
	//A faction has perks
	private List<Perk> perks;
	//A faction has lore
	private string facLore;
	//A faction has an ID
	private int ID;



	//Constructor
	public Faction(string name){
		this.facName = name;
		perks = new List<Perk>();
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

	public void setLore(string lore){
		this.facLore = lore;
	}

	public string getLore(){
		return this.facLore;
	}

	public void setID(int id){
		this.ID = id;
	}

	public int getID(){
		return this.ID;
	}

}
