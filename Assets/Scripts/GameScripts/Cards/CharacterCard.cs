using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace FallenLand
{
    public class CharacterCard : PartyCard
    {

        private int MaxHp;
        private int PsychResistance;
        private int CarryCapacity;
        private int CurrentPsychRemaning;
        private int CurrentHp;
        private int AmountOfPhysicalDamage;
        private int AmountOfInfectedDamage;
        private int AmountOfRadiationDamage;
        //specialAbilities. What bonuses the character card gets. TDC cost 3 less. Auto pass certain encounters. etc TODO
        private List<SpoilsCard> EquippedSpoils;
        private bool HasFirstStrike;
        private bool IsMaster;
        private Sprite CardImage;
        private Sprite CardPortrait;
        private LinkCommon CharacterLink;

        public CharacterCard(string title) : base(title)
        {
            EquippedSpoils = new List<SpoilsCard>();
            HasFirstStrike = false;
            IsMaster = false;
            CurrentPsychRemaning = 3;
            CharacterLink = null;
        }

        public static object DeserializeCharacterCard(byte[] data)
        {
            string str = Encoding.ASCII.GetString(data);
            CharacterCard result = new CharacterCard(str);
            return result;
        }

        public static byte[] SerializeCharacterCard(object customType)
        {
            CharacterCard characterCard = (CharacterCard)customType;
            return Encoding.ASCII.GetBytes(characterCard.GetTitle());
        }

        public void ClearAllSpoils()
        {
            EquippedSpoils = new List<SpoilsCard>();
        }

        public void SetCharacterLink(LinkCommon link)
        {
            CharacterLink = link;
        }

        public LinkCommon GetCharacterLink()
        {
            return CharacterLink;
        }

        public void SetMaxHp(int maxHp)
        {
            if (maxHp > 0)
            {
                MaxHp = maxHp;
                CurrentHp = MaxHp;
            }
        }

        public int GetMaxHp()
        {
            return MaxHp;
        }

        public int GetHpRemaining()
        {
            return CurrentHp;
        }

        public int GetMaxPhysicalHp()
        {
            return CurrentHp + AmountOfPhysicalDamage;
        }

        public int GetMaxInfectedHp()
        {
            return CurrentHp + AmountOfInfectedDamage;
        }

        public int GetMaxRadiationHp()
        {
            return CurrentHp + AmountOfRadiationDamage;
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

        public void AddPsychResistance(int amount)
        {
            if (amount > 0)
            {
                PsychResistance += amount;
            }
        }

        public void SubtractPsychResistance(int amount)
        {
            if (amount > 0)
            {
                PsychResistance -= amount;
            }

            if (PsychResistance < 1)
            {
                PsychResistance = 1;
            }
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

        public void AddCarryCapacity(int amount)
        {
            if (amount > 0)
            {
                CarryCapacity += amount;
            }
        }

        public void SubtractCarryCapacity(int amount)
        {
            if (amount > 0)
            {
                CarryCapacity -= amount;
            }
            if (CarryCapacity < 0)
            {
                CarryCapacity = 0;
            }
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

        public void SetHasFirstStrike(bool hasFirstStrike)
        {
            HasFirstStrike = hasFirstStrike;
        }

        public bool GetHasFirstStrike()
        {
            return HasFirstStrike;
        }

        public void SetIsMaster(bool isMaster)
        {
            IsMaster = isMaster;
        }

        public bool GetIsMaster()
        {
            return IsMaster;
        }

        public int GetPsychRemaning()
        {
            return CurrentPsychRemaning;
        }

        public void SetPsychRemaining(int remaining)
        {
            if (remaining < 0)
            {
                remaining = 0;
            }
            else if (remaining > 3)
            {
                remaining = 3;
            }
            CurrentPsychRemaning = remaining;
        }

        public Sprite GetCardImage()
        {
            if (CardImage == null)
            {
                string fileName = "Cards/CharacterCards/CharacterCard" + GetId().ToString();
                CardImage = Resources.Load<Sprite>(fileName);
            }
            return CardImage;
        }

        public Sprite GetCardPortrait()
        {
            if (CardPortrait == null)
            {
                string fileName = "Cards/CharacterPortraits/CharacterPortrait" + GetId().ToString();
                CardPortrait = Resources.Load<Sprite>(fileName);
            }
            return CardPortrait;
        }

        public void AddInfectedDamage(int amountOfDamage)
        {
            AmountOfInfectedDamage += amountOfDamage;
            CurrentHp -= amountOfDamage;
        }

        public void RemoveInfectedDamage(int amountOfHeal)
        {
            AmountOfInfectedDamage -= amountOfHeal;
            CurrentHp += amountOfHeal;
        }

        public int GetAmountOfInfectedDamage()
        {
            return AmountOfInfectedDamage;
        }

        public void AddPhysicalDamage(int amountOfDamage)
        {
            AmountOfPhysicalDamage += amountOfDamage;
            CurrentHp -= amountOfDamage;
        }

        public void RemovePhysicalDamage(int amountOfHeal)
        {
            AmountOfPhysicalDamage -= amountOfHeal;
            CurrentHp += amountOfHeal;
        }

        public void AddRadiationDamage(int amountOfDamage)
        {
            AmountOfRadiationDamage += amountOfDamage;
            CurrentHp -= amountOfDamage;
        }

        public void RemoveRadiationDamage(int amountOfHeal)
        {
            AmountOfRadiationDamage -= amountOfHeal;
            CurrentHp += amountOfHeal;
        }

        public int GetAmountOfRadiationDamage()
        {
            return AmountOfRadiationDamage;
        }

        public void GainSkillAmount(Skills skill, int amount)
        {
            AddSkillAmount(skill, amount);
        }

        public void LoseSkillAmount(Skills skill, int amount)
        {
            RemoveSkillAmount(skill, amount);
        }
    }
}

