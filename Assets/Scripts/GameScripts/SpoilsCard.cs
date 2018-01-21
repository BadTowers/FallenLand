using System.Collections;
using System.Collections.Generic;

public class SpoilsCard : PartyCard {

	private List<SpoilsTypes> types; //The list of all spoils types the card qualifies as
	private int sellValue; //The value of the card when sold to the bank
	private int carryWeight; //The weight of the item
	private List<List<Gains>> activeGains; //List of different active ability choices the player has
	private List<Gains> passiveGains;
	private List<Restrictions> restrictions;
	private List<List<Times>> whenUsable; //List of lists denoting different use times for different active choices
	private Uses uses; 

	private void initLists(){
		types = new List<SpoilsTypes>();
		activeGains = new List<List<Gains>>();
		passiveGains = new List<Gains>();
		restrictions = new List<Restrictions>();
		whenUsable = new List<List<Times>>();
	}

	public SpoilsCard(string title) : base(title) {
		initLists();
	}

	public SpoilsCard(string title, List<SpoilsTypes> types) : base(title) {
		initLists();
		this.types = types;
	}

	public SpoilsCard(string title, params SpoilsTypes[] types) : base(title) {
		initLists();
		foreach(SpoilsTypes item in types) {
			this.types.Add(item);
		}
	}

	public void setTypes(List<SpoilsTypes> types) {
		this.types = types;
	}

	public void setTypes(params SpoilsTypes[] types){
		foreach(SpoilsTypes item in types) {
			this.types.Add(item);
		}
	}

	public List<SpoilsTypes> getTypes() {
		return this.types;
	}

	public void setSellValue(int value) {
		this.sellValue = value;
	}

	public int getSellValue() {
		return this.sellValue;
	}

	public void setCarryWeight(int weight){
		this.carryWeight = weight;
	}

	public int getCarryWeight() {
		return this.carryWeight;
	}

	public void setUses(Uses use){
		this.uses = use;
	}

	public Uses getUses(){
		return this.uses;
	}

	public void setRestrictions(params Restrictions[] restrictions){
		foreach(Restrictions curRestriction in restrictions) {
			this.restrictions.Add(curRestriction);
		}
	}

	public void setRestrictions(List<Restrictions> restrictions){
		this.restrictions = restrictions;
	}

	public List<Restrictions> getRestrictions(){
		return this.restrictions;
	}

	public void setPassiveGains(params Gains[] gains){
		foreach(Gains gain in gains) {
			passiveGains.Add(gain);
		}
	}

	public void setPassiveGains(List<Gains> gains){
		this.passiveGains = gains;
	}

	public List<Gains> getPassiveGains(){
		return this.passiveGains;
	}

	public void setWhenUsable(List<List<Times>> when){
		this.whenUsable = when;
	}

	public List<List<Times>> getWhenUsable(){
		return this.whenUsable;
	}

	public void setActiveGains(List<List<Gains>> gains){
		this.activeGains = gains;
	}

	public List<List<Gains>> getActiveGains(){
		return this.activeGains;
	}
}
