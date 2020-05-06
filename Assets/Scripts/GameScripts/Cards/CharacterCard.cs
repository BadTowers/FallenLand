using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCard : PartyCard {

	private int hp; //The max hp the character has
	private int psychResistance; //The psych resistance the character has
	private int carryCapacity; //The carry capacity that a character has
                               //link. This would map some spoils card to some bonuses. ex) any two wheeled vehicle -> +1 movement and +6 carrying capacity TODO
                               //specialAbilities. What bonuses the character card gets. TDC cost 3 less. Auto pass certain encounters. etc TODO
    private List<SpoilsCard> equippedSpoils; //All spoils attached to the character

	public CharacterCard(string title) : base(title) {
        equippedSpoils = new List<SpoilsCard>();

    }

	public void setHP(int hp) {
		this.hp = hp;
	}

	public int getHP() {
		return this.hp;
	}

	public void setPsychResistance(int r) {
		this.psychResistance = r;
	}

	public int getPsychResistance() {
		return this.psychResistance;
	}

	public void setCarryCapacity(int c) {
		this.carryCapacity = c;
	}

	public int getCarryCapacity() {
		return this.carryCapacity;
	}

    //Returns true if it can attach a card (no restrictions stopped it)
    //Returns false if the card cannot be attached (some restriction stopped it)
    //TODO maybe at some point, give access to an object that gives the reasons why a card wasn't attached
    public bool attachSpoilsCard(SpoilsCard toAttach) {
        bool canBeAttached = true;

        //TODO Check restrictions here

        if (canBeAttached) {
            this.equippedSpoils.Add(toAttach); //Equip the spoils
            //TODO: Remove the card from the player's hand
        }

        return canBeAttached;
    }

    public bool removeSpoilsCard(SpoilsCard toRemove) {
        bool canBeRemoved = true;

        //TODO check restrictions here //This may not be necessary for removal, have to check this

        if (canBeRemoved) {
            //TODO: Remove the card from this character.
            //TODO: Add the card back to the player
        }

        return canBeRemoved;
    }
}

