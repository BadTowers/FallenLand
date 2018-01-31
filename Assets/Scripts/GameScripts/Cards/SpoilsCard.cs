using System.Collections;
using System.Collections.Generic;

public class SpoilsCard : PartyCard {

	private List<SpoilsTypes> types; //The list of all spoils types the card qualifies as
	private int sellValue; //The value of the card when sold to the bank
	private int carryWeight; //The weight of the item
	private List<Dictionary<Gains, int>> conditionalGains; //List of different conditional ability choices the player has
	private Dictionary<Gains, int> staticGains; //Passive type gains that are always active
	private List<List<Restrictions>> restrictions; //What the card has to be attached to, what it can't combine with, etc
	private List<List<Times>> whenUsable; //List of lists denoting different use times for different active choices
	private List<Uses> uses; 
	private List<bool> discards; //If you discard the card after using a conditional gain 
	private List<SpoilsCard> d6; //D6 options can be viewed as 6 individual spoils cards, each with one active ability representing the D6 option
	private List<SpoilsCard> d10; //D10 options can be viewed as 10 individual spoils cards, each with one active ability.
	private bool isTemp; //Denotes if it's a temporary D6 spoils or a normal spoils from the deck
	private Times whenTempEnd; //Marks when the temp gain expires (such as after a certain phase, after a turn, etc)
	private List<SpoilsCard> attachments; //Spoils cards attached to this spoils card
	private bool placeOnTopOfDiscard; //Is true if it goes on top (Default), false if it goes on bottom

	private void initLists(){
		types = new List<SpoilsTypes>();
		conditionalGains = new List<Dictionary<Gains, int>>();
		staticGains = new Dictionary<Gains, int>();
		restrictions = new List<List<Restrictions>>();
		whenUsable = new List<List<Times>>();
		uses = new List<Uses>();
		discards = new List<bool>();
		d6 = new List<SpoilsCard>();
		d10 = new List<SpoilsCard>();
		attachments = new List<SpoilsCard>();

		sellValue = 0;
		carryWeight = 0;
		isTemp = false;
		whenTempEnd = Times.Never;
		placeOnTopOfDiscard = true; //all cards default to going on the top of the discard pile
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

	public void setStaticGains(Dictionary<Gains, int> gains){
		this.staticGains = gains;
	}

	public Dictionary<Gains, int> getStaticGains(){
		return this.staticGains;
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

	public void setConditionalGains(List<Dictionary<Gains, int>> gains){
		this.conditionalGains = gains;
	}

	public void setConditionalGains(params Dictionary<Gains,int>[] gains){
		this.conditionalGains = new List<Dictionary<Gains, int>>();
		foreach(Dictionary<Gains,int> item in gains) {
			this.conditionalGains.Add(item);
		}
	}

	public void addConditionalGain(Gains gain, int value){
		this.conditionalGains.Add(new Dictionary<Gains, int>{ { gain, value } });
	}

	public void addConditionalGain(Dictionary<Gains, int> gain){
		this.conditionalGains.Add(gain);
	}

	public List<Dictionary<Gains, int>> getConditionalGains(){
		return this.conditionalGains;
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

	public void setD10Options(List<SpoilsCard> d10){
		this.d10 = d10;
	}

	public void setD10Options(params SpoilsCard[] d10){
		this.d10 = new List<SpoilsCard>();
		foreach(SpoilsCard item in d10) {
			this.d10.Add(item);
		}
	}

	public void addD10Option(SpoilsCard card){
		this.d10.Add(card);
	}

	public List<SpoilsCard> getD10Options(){
		return this.d10;
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

	public void setDiscardToTop(bool b){
		this.placeOnTopOfDiscard = b;
	}

	public bool getDiscardToTop(){
		return this.placeOnTopOfDiscard;
	}
}
