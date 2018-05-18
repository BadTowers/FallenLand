using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perk {
	//A perk has times it can be used
	private List<Times> whenUsable;
	//A perk has a certain number of uses
	private List<Uses> uses;
	//A perk has gains given as a result of using it
	private Dictionary<Gains, int> staticGains; //Passive type gains that are always active
	private Dictionary<Gains, int> conditionalGains; //List of different conditional ability choices the player has
	//A perk has a title
	private string perkTitle;
	//A perk has a text description
	private string perkDescription;


	//Constructor
	public Perk(string title){
		this.whenUsable = new List<Times>();
		this.uses = new List<Uses>();
		this.staticGains = new Dictionary<Gains, int>();
		this.conditionalGains = new Dictionary<Gains, int>();
		this.perkTitle = title;
	}

	public void setTimes(List<Times> t){
		this.whenUsable = t;
	}

	public void addTime(Times t){
		this.whenUsable.Add(t);
	}

	public List<Times> getTimes(){
		return this.whenUsable;
	}

	public void setUses(List<Uses> u){
		this.uses = u;
	}

	public void addUses(Uses u){
		this.uses.Add(u);
	}

	public List<Uses> getUses(){
		return this.uses;
	}

	public void setStaticGains(List<Gains> g){
		this.staticGains = g;
	}

	public void addStaticGains(Gains g){
		this.staticGains.Add(g);
	}

	public List<Gains> getStaticGains(){
		return this.staticGains;
	}

	public void setConditionalGains(List<Gains> g){
		this.conditionalGains = g;
	}

	public void addConditionalGains(Gains g){
		this.conditionalGains.Add(g);
	}

	public List<Gains> getConditionalGains(){
		return this.conditionalGains;
	}

	public void setPerkTitle(string title){
		this.perkTitle = title;
	}

	public string getPerkTitle(){
		return this.perkTitle;
	}

	public void setPerkDescription(string desc){
		this.perkDescription = desc;
	}

	public string getPerkDescription(){
		return this.perkDescription;
	}
}
