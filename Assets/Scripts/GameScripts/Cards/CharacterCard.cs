using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCard : PartyCard {

	private int MaxHp;
	private int PsychResistance;
	private int CarryCapacity;
                               //link. This would map some spoils card to some bonuses. ex) any two wheeled vehicle -> +1 movement and +6 carrying capacity TODO
                               //specialAbilities. What bonuses the character card gets. TDC cost 3 less. Auto pass certain encounters. etc TODO
    private List<SpoilsCard> EquippedSpoils;

	public CharacterCard(string title) : base(title)
    {
        EquippedSpoils = new List<SpoilsCard>();
    }

	public void SetMaxHp(int maxHp)
    {
        if (maxHp > 0)
        {
            MaxHp = maxHp;
        }
	}

	public int GetMaxHp()
    {
		return MaxHp;
	}

	public void SetPsychResistance(int psychResistance)
    {
        if (psychResistance > 0)
        {
            PsychResistance = psychResistance;
        }
	}

	public int GetPsychResistance()
    {
		return PsychResistance;
	}

	public void SetCarryCapacity(int carryCapacity)
    {
        if (carryCapacity >= 0)
        {
            CarryCapacity = carryCapacity;
        }
	}

	public int GetCarryCapacity()
    {
		return CarryCapacity;
	}

    //Returns true if it can attach a card (no restrictions stopped it)
    //Returns false if the card cannot be attached (some restriction stopped it)
    //TODO maybe at some point, give access to an object that gives the reasons why a card wasn't attached
    public bool AttachSpoilsCard(SpoilsCard toAttach)
    {
        bool canBeAttached = true;

        //TODO Check restrictions here

        if (canBeAttached)
        {
            EquippedSpoils.Add(toAttach); //Equip the spoils
            //TODO: Remove the card from the player's hand
        }

        return canBeAttached;
    }

    public bool RemoveSpoilsCard(SpoilsCard toRemove)
    {
        bool canBeRemoved = true;

        //TODO check restrictions here //This may not be necessary for removal, have to check this

        if (!EquippedSpoils.Contains(toRemove))
        {
            canBeRemoved = false;
        }
        if (canBeRemoved)
        {
            EquippedSpoils.Remove(toRemove);
            //TODO: Add the card back to the player
        }

        return canBeRemoved;
    }
}

