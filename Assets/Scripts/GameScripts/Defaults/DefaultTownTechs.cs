using System.Collections.Generic;

namespace FallenLand
{
	public class DefaultTownTechs
	{
		private List<TownTech> Techs;

		public DefaultTownTechs()
		{
			Techs = new List<TownTech>();

			//Vars
			TownTech curTech;

			/***************************************************/
			curTech = new TownTech("Energy Production");
			curTech.SetPurchaseCost(30);
			curTech.SetUpgradeCost(30);
			curTech.SetSellCost(25);
			curTech.SetId(1);
			Techs.Add(curTech);

			/***************************************************/
			curTech = new TownTech("Garrison");
			curTech.SetPurchaseCost(30);
			curTech.SetUpgradeCost(30);
			curTech.SetSellCost(25);
			curTech.SetId(2);
			Techs.Add(curTech);

			/***************************************************/
			curTech = new TownTech("Law and Order");
			curTech.SetPurchaseCost(40);
			curTech.SetUpgradeCost(40);
			curTech.SetSellCost(25);
			curTech.SetId(3);
			Techs.Add(curTech);

			/***************************************************/
			curTech = new TownTech("Learning Center");
			curTech.SetPurchaseCost(30);
			curTech.SetUpgradeCost(30);
			curTech.SetSellCost(25);
			curTech.SetId(4);
			Techs.Add(curTech);

			/***************************************************/
			curTech = new TownTech("Machinist Shop");
			curTech.SetPurchaseCost(30);
			curTech.SetUpgradeCost(30);
			curTech.SetSellCost(25);
			curTech.SetId(5);
			Techs.Add(curTech);

			/***************************************************/
			curTech = new TownTech("Marketplace");
			curTech.SetPurchaseCost(40);
			curTech.SetUpgradeCost(40);
			curTech.SetSellCost(25);
			curTech.SetId(6);
			Techs.Add(curTech);

			/***************************************************/
			curTech = new TownTech("Medical Center");
			curTech.SetPurchaseCost(30);
			curTech.SetUpgradeCost(30);
			curTech.SetSellCost(25);
			curTech.SetId(7);
			Techs.Add(curTech);

			/***************************************************/
			curTech = new TownTech("Communication Center");
			curTech.SetPurchaseCost(30);
			curTech.SetUpgradeCost(30);
			curTech.SetSellCost(25);
			curTech.SetId(8);
			Techs.Add(curTech);

			/***************************************************/
			curTech = new TownTech("Water and Supplies");
			curTech.SetPurchaseCost(30);
			curTech.SetUpgradeCost(30);
			curTech.SetSellCost(25);
			curTech.SetId(9);
			Techs.Add(curTech);
		}

		public List<TownTech> GetDefaultTownTechList()
		{
			return Techs;
		}

		public TownTech GetTownTechByName(string name)
		{
			TownTech toReturn = null;
			foreach (TownTech tt in Techs)
			{
				if (tt.GetTechName() == name)
				{
					toReturn = tt;
					break;
				}
			}

			return toReturn;
		}
	}
}
