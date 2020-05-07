using System.Collections.Generic;

public class Faction
{
	private string FactionName;
	private List<Perk> Perks;
	private Coordinates StartingBaseLocation;
	private string StartingBaseName;
	private string FactionLore;
	private List<TownTech> StartingTownTechs;
	private int Id;

	public Faction(string name, Coordinates location)
	{
		FactionName = name;
		StartingBaseLocation = location;
		Perks = new List<Perk>();
        StartingTownTechs = new List<TownTech>();
	}

	public void SetName(string name)
	{
		FactionName = name;
	}

	public string GetName()
	{
		return FactionName;
	}

	public void SetPerks(List<Perk> perks)
	{
		if (perks != null)
		{
			Perks = perks;
		}
	}

	public void AddPerk(Perk perk)
	{
		if (perk != null)
		{
			Perks.Add(perk);
		}
	}

	public List<Perk> GetPerks()
	{
		return Perks;
	}

	public void SetBaseLocation(Coordinates location)
	{
		if (location != null)
		{
			StartingBaseLocation = location;
		}
	}

	public Coordinates GetBaseLocation()
	{
		return StartingBaseLocation;
	}

	public void SetBaseLocationString(string locationString)
	{
		StartingBaseName = locationString;
	}

	public string GetBaseLocationString()
	{
		return StartingBaseName;
	}

	public void SetLore(string lore)
	{
		FactionLore = lore;
	}

	public string GetLore()
	{
		return FactionLore;
	}

	public void SetStartingTownTechs(List<TownTech> townTechs)
	{
		if (townTechs != null)
		{
			StartingTownTechs = townTechs;
		}
	}

	public void AddStartingTownTech(TownTech townTech)
	{
		StartingTownTechs.Add(townTech);
	}

	public List<TownTech> GetStartingTownTechs()
	{
		return StartingTownTechs;
	}

	public void SetId(int id)
	{
		Id = id;
	}

	public int GetId()
	{
		return Id;
	}

}
