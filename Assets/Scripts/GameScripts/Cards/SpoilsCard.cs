using System.Collections.Generic;
using System.Text;

namespace FallenLand
{
	public class SpoilsCard : PartyCard
	{
		private List<SpoilsTypes> Types;
		private int SellValue;
		private int CarryWeight;
		private List<SpoilsCard> Attachments;
		private List<SpoilsCard> EquippedSpoils;
		private bool IsStartingCard;
		private UnityEngine.Sprite CardImage;

		public SpoilsCard(string title) : base(title)
		{
			initVariables();
		}

		public static object DeserializeSpoilsCard(byte[] data)
		{
			string str = Encoding.ASCII.GetString(data);
			SpoilsCard result = new SpoilsCard(str);
			return result;
		}

		public static byte[] SerializeSpoilsCard(object customType)
		{
			SpoilsCard spoilsCard = (SpoilsCard)customType;
			return Encoding.ASCII.GetBytes(spoilsCard.GetTitle());
		}

		public void SetSpoilsTypes(List<SpoilsTypes> types)
		{
			Types = types;
		}

		public void SetSpoilsTypes(params SpoilsTypes[] types)
		{
			Types = new List<SpoilsTypes>();
			foreach (SpoilsTypes item in types)
			{
				Types.Add(item);
			}
		}

		public void AddSpoilsType(SpoilsTypes type)
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

		public void SetIsStartingCard(bool isStarting)
		{
			IsStartingCard = isStarting;
		}

		public bool GetIsStartingCard()
		{
			return IsStartingCard;
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

		public bool GetIsRelic()
		{
			bool isRelic = false;
			if (Types.Contains(SpoilsTypes.Relic))
			{
				isRelic = true;
			}
			return isRelic;
		}

		public UnityEngine.Sprite GetCardImage()
		{
			if (CardImage == null)
			{
				string fileName = "Cards/SpoilsCards/SpoilsCard" + GetId().ToString();
				CardImage = UnityEngine.Resources.Load<UnityEngine.Sprite>(fileName);
			}
			return CardImage;
		}

		public SpoilsCard DeepCopy()
		{
			SpoilsCard newCard = new SpoilsCard(this.GetTitle());
			newCard.SetTitleSubString(this.GetTitleSubString());
			newCard.SetSpoilsTypes(this.Types);
			newCard.SetCarryWeight(this.CarryWeight);
			newCard.SetSellValue(this.SellValue);
			newCard.SetBaseSkills(this.GetBaseSkills());
			newCard.SetId(this.GetId());
			newCard.SetQuote(this.GetQuote());
			newCard.SetIsStartingCard(this.IsStartingCard);

			return newCard;
		}

		public void DeepSet(SpoilsCard cardToCopyFrom)
		{
			SetTitle(cardToCopyFrom.GetTitle());
			SetTitleSubString(cardToCopyFrom.GetTitleSubString());
			SetSpoilsTypes(cardToCopyFrom.Types);
			SetCarryWeight(cardToCopyFrom.CarryWeight);
			SetSellValue(cardToCopyFrom.SellValue);
			SetBaseSkills(cardToCopyFrom.GetBaseSkills());
			SetId(cardToCopyFrom.GetId());
			SetQuote(cardToCopyFrom.GetQuote());
			SetIsStartingCard(cardToCopyFrom.IsStartingCard);
		}

		private void initVariables()
		{
			Types = new List<SpoilsTypes>();
			Attachments = new List<SpoilsCard>();
			EquippedSpoils = new List<SpoilsCard>();

			SellValue = 0;
			CarryWeight = 0;
			IsStartingCard = false;
		}
	}
}
