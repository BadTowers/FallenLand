﻿using System.Collections;
using System.Collections.Generic;

public class SpoilsCard : PartyCard {

	private List<SpoilsTypes> types; //The list of all spoils types the card qualifies as
	private int sellValue; //The value of the card when sold to the bank
	private int carryWeight; //The weight of the item
	private List<Dictionary<Gains, int>> activeGains; //List of different active ability choices the player has
	private Dictionary<Gains, int> passiveGains;
	private List<List<Restrictions>> restrictions;
	private List<List<Times>> whenUsable; //List of lists denoting different use times for different active choices
	private List<Uses> uses; 
	private List<bool> discards; 
	private List<SpoilsCard> d6; //D6 options can be viewed as 6 individual spoils cards, each with one active ability representing the D6 option
	private bool isTemp;
	private Times whenTempEnd;
	private List<SpoilsCard> attachments; //Spoils cards attached to this spoils card

	private void initLists(){
		types = new List<SpoilsTypes>();
		activeGains = new List<Dictionary<Gains, int>>();
		passiveGains = new Dictionary<Gains, int>();
		restrictions = new List<List<Restrictions>>();
		whenUsable = new List<List<Times>>();
		uses = new List<Uses>();
		discards = new List<bool>();
		d6 = new List<SpoilsCard>();
		attachments = new List<SpoilsCard>();

		sellValue = 0;
		carryWeight = 0;
		isTemp = false;
		whenTempEnd = Times.Never;
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
		this.types = new List<SpoilsTypes>();
		foreach(SpoilsTypes item in types) {
			this.types.Add(item);
		}
	}

	public void addType(SpoilsTypes type){
		this.types.Add(type);
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

	public void setRestrictions(params List<Restrictions>[] restrictions){
		this.restrictions = new List<List<Restrictions>>();
		foreach(List<Restrictions> curRestriction in restrictions) {
			this.restrictions.Add(curRestriction);
		}
	}

	public void setRestrictions(List<List<Restrictions>> restrictions){
		this.restrictions = restrictions;
	}

	public void addRestriction(List<Restrictions> res){
		this.restrictions.Add(res);
	}

	public List<List<Restrictions>> getRestrictions(){
		return this.restrictions;
	}

	public void setPassiveGains(Dictionary<Gains, int> gains){
		this.passiveGains = gains;
	}

	public Dictionary<Gains, int> getPassiveGains(){
		return this.passiveGains;
	}

	public void setWhenUsable(List<List<Times>> when){
		this.whenUsable = when;
	}

	public void setWhenUsable(params List<Times>[] when){
		this.whenUsable = new List<List<Times>>();
		foreach(List<Times> item in when) {
			this.whenUsable.Add(item);
		}
	}

	public void addWhenUsable(List<Times> time){
		this.whenUsable.Add(time);
	}

	public List<List<Times>> getWhenUsable(){
		return this.whenUsable;
	}

	public void setActiveGains(List<Dictionary<Gains, int>> gains){
		this.activeGains = gains;
	}

	public void setActiveGains(params Dictionary<Gains,int>[] gains){
		this.activeGains = new List<Dictionary<Gains, int>>();
		foreach(Dictionary<Gains,int> item in gains) {
			this.activeGains.Add(item);
		}
	}

	public void addActiveGain(Gains gain, int value){
		this.activeGains.Add(new Dictionary<Gains, int>{ { gain, value } });
	}

	public void addActiveGain(Dictionary<Gains, int> gain){
		this.activeGains.Add(gain);
	}

	public List<Dictionary<Gains, int>> getActiveGains(){
		return this.activeGains;
	}

	public void setNumberOfUses(List<Uses> uses){
		this.uses = uses;
	}

	public void setNumberOfUses(params Uses[] uses){
		this.uses = new List<Uses>();
		foreach(Uses item in uses) {
			this.uses.Add(item);
		}
	}

	public void addNumberOfUses(Uses use){
		this.uses.Add(use);
	}

	public List<Uses> getNumberOfUses(){
		return this.uses;
	}

	public void setDiscard(List<bool> discards){
		this.discards = discards;
	}

	public void setDiscard(params bool[] discards){
		this.discards = new List<bool>();
		foreach(bool item in discards) {
			this.discards.Add(item);
		}
	}

	public void addDiscard(bool disc){
		this.discards.Add(disc);
	}

	public List<bool> getDiscard(){
		return this.discards;
	}

	public void setD6Options(List<SpoilsCard> d6){
		this.d6 = d6;
	}

	public void setD6Options(params SpoilsCard[] d6){
		this.d6 = new List<SpoilsCard>();
		foreach(SpoilsCard item in d6) {
			this.d6.Add(item);
		}
	}

	public void addD6Option(SpoilsCard card){
		this.d6.Add(card);
	}

	public List<SpoilsCard> getD6Options(){
		return this.d6;
	}

	public void setIsTemp(bool temp){
		this.isTemp = temp;
	}

	public bool getIsTemp(){
		return this.isTemp;
	}

	public void setWhenTempEnd(Times time){
		this.whenTempEnd = time;
	}

	public Times getWhenTempEnd(){
		return this.whenTempEnd;
	}

	public void addAttachment(SpoilsCard att){
		this.attachments.Add(att);
	}

	public List<SpoilsCard> getAttachments(){
		return this.attachments;
	}
}
