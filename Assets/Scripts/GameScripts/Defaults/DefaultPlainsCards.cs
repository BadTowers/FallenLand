using System.Collections.Generic;
using UnityEngine;

namespace FallenLand
{
	public class DefaultPlainsCards
	{
		private List<PlainsCard> PlainsCards;

		public DefaultPlainsCards()
		{
			PlainsCards = new List<PlainsCard>();

			PlainsCard curCard;
			int curID = 0;

			Debug.Log("Instantiating plains cards...");

			/****************************************************************************************************************************************************************/
			curCard = new PlainsCard("A Helping Hand");
			curCard.SetSalvageReward(2);
			curCard.SetDescriptionText("Ahead, the pictureesque farm house is indeed in poor condition, yet may provide ample shelter against the insurgent rainstorm. " +
				"A grizzled old farmer steps out of the shadows of the porch and confronts you with an antique shotgun. After a barrage of questions and seemingly correct answers, Mac warms " +
				"up to you and invites you to sample his stash of the very finest pre-war whiskies. After a few drinks to warm you pu, Mac offers you a deal. \"I'll let you folks weather out " +
				"the storm here, if y'all help me fix my tractor. With Ol' Betsy, life's still worth living'.\" He prattles on about his tractor for what seems an eternity, mentioning a more " +
				"substantial reward if you are successful.");
            curCard.SetSkillChecks(new Dictionary<Skills, int>
			{
				[Skills.Mechanical] = 4,
				[Skills.Technical] = 3
			});
			curCard.SetArePartySkillCheck(new List<bool>
			{
				true,
				true
			});
			curCard.SetMakePsychCheckAfterEncounter(false);
			curCard.SetSuccessHeaderText("Draw the next Relic Spoils card, discarding all others. You may place your party on the nearest Mission chip and attempt it at no cost in weeks.");
			curCard.SetSuccessDescriptionText("Mac is filled with joy and smiling as he gives you the reward.");
			//curCard.AddRewardGain();
			curCard.SetFailureHeaderText("All Party members automatically suffer 1 point of Psychological Damage.");
			curCard.SetFailureDescriptionText("Inconsolable at the los of Ol' Betsy, a heartbroken Mac ushers you out. As you pass the rusted mailbox at the end of the drive, a lone gunshot " +
				"echoes from within the house.");
			curCard.SetId(curID);
			curID++;
			PlainsCards.Add(curCard); //Add the card to the list of all cards
		}

		public List<PlainsCard> GetPlainsCards()
		{
			return PlainsCards;
		}
	}
}
