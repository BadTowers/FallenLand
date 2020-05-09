using System.Collections.Generic;

public abstract class Player 
{
	private List<SpoilsCard> AuctionHouse;
	private List<ActionCard> ActionCardsInHand;
	private List<CharacterCard> ActiveCharacters;
    private List<CharacterCard> TownRoster;
    private Faction FactionOfPlayer;
    private List<TownTech> TownTechs;
    private int AmountOfSalvage;
	private int Id;


	public Player(Faction faction, int startingSalvage)
	{
		if (startingSalvage < 0)
		{
			startingSalvage = 0;
		}
		if (faction == null)
		{
			faction = new Faction("dummy faction", new Coordinates(Constants.INVALID_LOCATION, Constants.INVALID_LOCATION));
		}

		AmountOfSalvage = startingSalvage;
		FactionOfPlayer = faction;
		initLists();
        //TODO extract starting town techs from faction
	}

	public void AddSpoilsCardToAuctionHouse(SpoilsCard spoilsCard)
	{
		if (spoilsCard != null)
		{
			AuctionHouse.Add(spoilsCard);
		}
	}

	public void AddCharacterCardToTownRoster(CharacterCard characterCard)
	{
		if (characterCard != null)
		{
			TownRoster.Add(characterCard);
		}
	}

	public void AddActionCardToHand(ActionCard actionCard)
	{
		if (actionCard != null)
		{
			ActionCardsInHand.Add(actionCard);
		}
	}

	public List<SpoilsCard> GetAuctionHouseCards()
	{
		return AuctionHouse;
	}

	public List<ActionCard> GetActionCards()
	{
		return ActionCardsInHand;
	}

	public List<CharacterCard> GetTownRoster()
	{
		return TownRoster;
	}

	public void SetPlayerFaction(Faction faction)
	{
		if (faction != null)
		{
			FactionOfPlayer = faction;
		}
	}

	public Faction GetPlayerFaction()
	{
		return FactionOfPlayer;
	}

    public int GetSalvageAmount()
	{
        return AmountOfSalvage;
    }

    public void AddSalvageToPlayer(int salvageToAdd)
	{
		if (salvageToAdd > 0)
		{
			AmountOfSalvage += salvageToAdd;
		}
    }

    public void RemoveSalvageFromPlayer(int salvageToRemove)
	{
		if (salvageToRemove > 0)
		{
			AmountOfSalvage -= salvageToRemove;
		}
		if (AmountOfSalvage < 0)
		{
			AmountOfSalvage = 0;
		}
    }

    public List<TownTech> GetTownTechs()
	{
        return TownTechs;
    }

	public List<CharacterCard> GetActiveCharacters()
	{
		return ActiveCharacters;
	}

    public void AddTownTech(TownTech techToAdd)
	{
		if (techToAdd != null)
		{
			TownTechs.Add(techToAdd);
		}
    }


	private void initLists()
	{
		AuctionHouse = new List<SpoilsCard>();
		ActionCardsInHand = new List<ActionCard>();
		TownRoster = new List<CharacterCard>();
		ActiveCharacters = new List<CharacterCard>();
		TownTechs = new List<TownTech>();
	}
}
