using System.Collections;
using System.Collections.Generic;

public class SpoilsCard : PartyCard {

	private List<SpoilsTypes> types; //The list of all spoils types the card qualifies as
	private int sellValue; //The value of the card when sold to the bank
	private int carryWeight; //The weight of the item
	private List<Dictionary<Gains, int>> activeGains; //List of different active ability choices the player has
	private List<Gains> passiveGains;
	private List<Restrictions> restrictions;
	private List<Times> whenUsable; //List of lists denoting different use times for different active choices
	private List<Uses> uses; 
	private List<bool> discards; 

	private void initLists(){
		types = new List<SpoilsTypes>();
		activeGains = new List<Dictionary<Gains, int>>();
		passiveGains = new List<Gains>();
		restrictions = new List<Restrictions>();
		whenUsable = new List<Times>();
		uses = new List<Uses>();
		discards = new List<bool>();
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

	public void setWhenUsable(List<Times> when){
		this.whenUsable = when;
	}

	public void setWhenUsable(params Times[] when){
		foreach(Times item in when) {
			this.whenUsable.Add(item);
		}
	}

	public List<List<Times>> getWhenUsable(){
		return this.whenUsable;
	}

	public void setActiveGains(List<Dictionary<Gains, int>> gains){
		this.activeGains = gains;
	}

	public void setActiveGames(params Dictionary<Gains,int>[] gains){
		foreach(Dictionary<Gains,int> item in gains) {
			this.activeGains.Add(item);
		}
	}

	public List<Dictionary<Gains, int>> getActiveGains(){
		return this.activeGains;
	}

	public void setNumberOfUses(List<Uses> uses){
		this.uses = uses;
	}

	public void setNumberOfUses(params Uses[] uses){
		foreach(Uses item in uses) {
			this.uses.Add(item);
		}
	}

	public List<Uses> getNumberOfUses(){
		return this.uses;
	}

	public void setDiscard(List<bool> discards){
		this.discards = discards;
	}

	public void setDiscard(params bool[] discards){
		foreach(bool item in discards) {
			this.discards.Add(item);
		}
	}

	public List<bool> getDiscard(){
		return this.discards;
	}
}
