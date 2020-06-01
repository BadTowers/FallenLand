﻿using System.Collections.Generic;

namespace FallenLand
{
	public class SpoilsCard : PartyCard
	{
		private List<SpoilsTypes> Types;
		private int SellValue;
		private int CarryWeight;
		private List<Dictionary<Gains, int>> ConditionalGains;
		private Dictionary<Gains, int> StaticGains;
		private List<List<Restrictions>> Restrictions;
		private List<List<Times>> TimesWhenUsable;
		private List<Uses> NumberOfUses;
		private List<bool> DiscardsAfterConditionalGains;
		private List<SpoilsCard> D6Options;
		private List<SpoilsCard> D10Options;
		private bool IsTemporary;
		private Times WhenTempGainsExpire;
		private List<SpoilsCard> Attachments;
		private bool PlaceOnTopOfDiscard;
		private List<SpoilsCard> EquippedSpoils;

		public SpoilsCard(string title) : base(title)
		{
			initVariables();
		}

		public SpoilsCard(string title, List<SpoilsTypes> types) : base(title)
		{
			initVariables();
			Types = types;
		}

		public SpoilsCard(string title, params SpoilsTypes[] types) : base(title)
		{
			initVariables();
			foreach (SpoilsTypes item in types)
			{
				Types.Add(item);
			}
		}

		public void SetTypes(List<SpoilsTypes> types)
		{
			Types = types;
		}

		public void SetTypes(params SpoilsTypes[] types)
		{
			Types = new List<SpoilsTypes>();
			foreach (SpoilsTypes item in types)
			{
				Types.Add(item);
			}
		}

		public void AddType(SpoilsTypes type)
		{
			Types.Add(type);
		}

		public List<SpoilsTypes> GetSpoilsTypes()
		{
			return Types;
		}

		public void SetSellValue(int sellValue)
		{
			if (sellValue >= 0)
			{
				SellValue = sellValue;
			}
		}

		public int GetSellValue()
		{
			return SellValue;
		}

		public void SetCarryWeight(int carryWeight)
		{
			if (carryWeight >= 0)
			{
				CarryWeight = carryWeight;
			}
		}

		public int GetCarryWeight()
		{
			return CarryWeight;
		}

		public void SetRestrictions(params List<Restrictions>[] restrictions)
		{
			Restrictions = new List<List<Restrictions>>();
			foreach (List<Restrictions> curRestriction in restrictions)
			{
				if (curRestriction != null)
				{
					Restrictions.Add(curRestriction);
				}
			}
		}

		public void SetRestrictions(List<List<Restrictions>> restrictions)
		{
			if (restrictions != null)
			{
				Restrictions = restrictions;
			}
		}

		public void AddRestriction(List<Restrictions> newRestriction)
		{
			if (newRestriction != null)
			{
				Restrictions.Add(newRestriction);
			}
		}

		public List<List<Restrictions>> GetRestrictions()
		{
			return Restrictions;
		}

		public void SetStaticGains(Dictionary<Gains, int> gains)
		{
			if (gains != null)
			{
				StaticGains = gains;
			}
		}

		public Dictionary<Gains, int> GetStaticGains()
		{
			return StaticGains;
		}

		public void SetWhenUsable(List<List<Times>> whenUsable)
		{
			if (whenUsable != null)
			{
				TimesWhenUsable = whenUsable;
			}
		}

		public void SetWhenUsable(params List<Times>[] whenUsable)
		{
			TimesWhenUsable = new List<List<Times>>();
			foreach (List<Times> curWhenUsable in whenUsable)
			{
				if (curWhenUsable != null)
				{
					TimesWhenUsable.Add(curWhenUsable);
				}
			}
		}

		public void AddWhenUsable(List<Times> time)
		{
			if (time != null)
			{
				TimesWhenUsable.Add(time);
			}
		}

		public List<List<Times>> GetWhenUsable()
		{
			return TimesWhenUsable;
		}

		public void SetConditionalGains(List<Dictionary<Gains, int>> gains)
		{
			if (gains != null)
			{
				ConditionalGains = gains;
			}
		}

		public void SetConditionalGains(params Dictionary<Gains, int>[] conditionalGains)
		{
			ConditionalGains = new List<Dictionary<Gains, int>>();
			foreach (Dictionary<Gains, int> curConditionalGain in conditionalGains)
			{
				if (curConditionalGain != null)
				{
					ConditionalGains.Add(curConditionalGain);
				}
			}
		}

		public void AddConditionalGain(Gains gain, int value)
		{
			ConditionalGains.Add(new Dictionary<Gains, int> { { gain, value } });
		}

		public void AddConditionalGain(Dictionary<Gains, int> gain)
		{
			if (gain != null)
			{
				ConditionalGains.Add(gain);
			}
		}

		public List<Dictionary<Gains, int>> GetConditionalGains()
		{
			return ConditionalGains;
		}

		public void SetNumberOfUses(List<Uses> numUses)
		{
			if (numUses != null)
			{
				NumberOfUses = numUses;
			}
		}

		public void SetNumberOfUses(params Uses[] uses)
		{
			NumberOfUses = new List<Uses>();
			foreach (Uses curNumUses in uses)
			{
				NumberOfUses.Add(curNumUses);
			}
		}

		public void AddNumberOfUses(Uses use)
		{
			NumberOfUses.Add(use);
		}

		public List<Uses> GetNumberOfUses()
		{
			return NumberOfUses;
		}

		public void SetDiscard(List<bool> discards)
		{
			if (discards != null)
			{
				DiscardsAfterConditionalGains = discards;
			}
		}

		public void SetDiscard(params bool[] discards)
		{
			DiscardsAfterConditionalGains = new List<bool>();
			foreach (bool item in discards)
			{
				DiscardsAfterConditionalGains.Add(item);
			}
		}

		public void AddDiscard(bool disc)
		{
			DiscardsAfterConditionalGains.Add(disc);
		}

		public List<bool> GetDiscard()
		{
			return DiscardsAfterConditionalGains;
		}

		public void SetD6Options(List<SpoilsCard> d6)
		{
			if (d6 != null)
			{
				D6Options = d6;
			}
		}

		public void SetD6Options(params SpoilsCard[] d6)
		{
			D6Options = new List<SpoilsCard>();
			foreach (SpoilsCard item in d6)
			{
				D6Options.Add(item);
			}
		}

		public void AddD6Option(SpoilsCard card)
		{
			D6Options.Add(card);
		}

		public List<SpoilsCard> GetD6Options()
		{
			return D6Options;
		}

		public void SetD10Options(List<SpoilsCard> d10)
		{
			if (d10 != null)
			{
				D10Options = d10;
			}
		}

		public void SetD10Options(params SpoilsCard[] d10Options)
		{
			D10Options = new List<SpoilsCard>();
			foreach (SpoilsCard curD10Option in d10Options)
			{
				D10Options.Add(curD10Option);
			}
		}

		public void AddD10Option(SpoilsCard card)
		{
			D10Options.Add(card);
		}

		public List<SpoilsCard> GetD10Options()
		{
			return D10Options;
		}

		public void SetIsTemp(bool temp)
		{
			IsTemporary = temp;
		}

		public bool GetIsTemp()
		{
			return IsTemporary;
		}

		public void SetWhenTempEnd(Times time)
		{
			WhenTempGainsExpire = time;
		}

		public Times GetWhenTempEnd()
		{
			return WhenTempGainsExpire;
		}

		public void AddAttachment(SpoilsCard attachment)
		{
			if (attachment != null)
			{
				Attachments.Add(attachment);
			}
		}

		public List<SpoilsCard> GetAttachments()
		{
			return Attachments;
		}

		public void SetDiscardToTop(bool isDiscardToTop)
		{
			PlaceOnTopOfDiscard = isDiscardToTop;
		}

		public bool GetDiscardToTop()
		{
			return PlaceOnTopOfDiscard;
		}

		public List<SpoilsCard> GetEquippedSpoils()
		{
			return EquippedSpoils;
		}

		public void AttachSpoilsCard(SpoilsCard toAttach)
		{
			if (toAttach != null)
			{
				EquippedSpoils.Add(toAttach);
			}
		}

		public void RemoveSpoilsCard(SpoilsCard toRemove)
		{
			if (EquippedSpoils.Contains(toRemove))
			{
				EquippedSpoils.Remove(toRemove);
			}
		}

		public SpoilsCard DeepCopy()
		{
			SpoilsCard newCard = new SpoilsCard(this.GetTitle());
			newCard.SetTitleSubString(this.GetTitleSubString());
			newCard.SetTypes(this.Types);
			newCard.SetCarryWeight(this.CarryWeight);
			newCard.SetSellValue(this.SellValue);
			newCard.SetBaseSkills(this.GetBaseSkills());
			newCard.SetStaticGains(this.StaticGains);
			newCard.SetConditionalGains(this.ConditionalGains);
			newCard.SetWhenUsable(this.TimesWhenUsable);
			newCard.SetNumberOfUses(this.NumberOfUses);
			newCard.SetDiscard(this.DiscardsAfterConditionalGains);
			newCard.SetRestrictions(this.Restrictions);
			newCard.SetId(this.GetId());
			newCard.SetQuote(this.GetQuote());
			newCard.SetD6Options(this.D6Options);
			newCard.SetD10Options(this.D10Options);
			newCard.SetDiscardToTop(this.PlaceOnTopOfDiscard);

			return newCard;
		}

		public void DeepSet(SpoilsCard cardToCopyFrom)
		{
			this.SetTitle(cardToCopyFrom.GetTitle());
			this.SetTitleSubString(cardToCopyFrom.GetTitleSubString());
			this.SetTypes(cardToCopyFrom.Types);
			this.SetCarryWeight(cardToCopyFrom.CarryWeight);
			this.SetSellValue(cardToCopyFrom.SellValue);
			this.SetBaseSkills(cardToCopyFrom.GetBaseSkills());
			this.SetStaticGains(cardToCopyFrom.StaticGains);
			this.SetConditionalGains(cardToCopyFrom.ConditionalGains);
			this.SetWhenUsable(cardToCopyFrom.TimesWhenUsable);
			this.SetNumberOfUses(cardToCopyFrom.NumberOfUses);
			this.SetDiscard(cardToCopyFrom.DiscardsAfterConditionalGains);
			this.SetRestrictions(cardToCopyFrom.Restrictions);
			this.SetId(cardToCopyFrom.GetId());
			this.SetQuote(cardToCopyFrom.GetQuote());
			this.SetD6Options(cardToCopyFrom.D6Options);
			this.SetD10Options(cardToCopyFrom.D10Options);
			this.SetDiscardToTop(cardToCopyFrom.PlaceOnTopOfDiscard);
		}

		private void initVariables()
		{
			Types = new List<SpoilsTypes>();
			ConditionalGains = new List<Dictionary<Gains, int>>();
			StaticGains = new Dictionary<Gains, int>();
			Restrictions = new List<List<Restrictions>>();
			TimesWhenUsable = new List<List<Times>>();
			NumberOfUses = new List<Uses>();
			DiscardsAfterConditionalGains = new List<bool>();
			D6Options = new List<SpoilsCard>();
			D10Options = new List<SpoilsCard>();
			Attachments = new List<SpoilsCard>();
			EquippedSpoils = new List<SpoilsCard>();

			SellValue = 0;
			CarryWeight = 0;
			IsTemporary = false;
			WhenTempGainsExpire = Times.Never;
			PlaceOnTopOfDiscard = true; //all cards default to going on the top of the discard pile
		}
	}
}
