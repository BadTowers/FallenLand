using System.Collections.Generic;
using System.Text;

namespace FallenLand
{
    public class CharacterCard : PartyCard
    {

        private int MaxHp;
        private int PsychResistance;
        private int CarryCapacity;
        private int CurrentPsychRemaning;
        private int CurrentHp;
        //link. This would map some spoils card to some bonuses. ex) any two wheeled vehicle -> +1 movement and +6 carrying capacity TODO
        //specialAbilities. What bonuses the character card gets. TDC cost 3 less. Auto pass certain encounters. etc TODO
        private List<SpoilsCard> EquippedSpoils;
        private bool HasFirstStrike;
        ConditionalGain Link;
        private bool IsMaster;

        public CharacterCard(string title) : base(title)
        {
            EquippedSpoils = new List<SpoilsCard>();
            HasFirstStrike = false;
            IsMaster = false;
            CurrentPsychRemaning = 3;
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

        public void SetHpRemaining(int hpRemaining)
        {
            if (hpRemaining < 0)
            {
                hpRemaining = 0;
            }
            else if (hpRemaining > MaxHp)
            {
                hpRemaining = MaxHp;
            }
            CurrentHp = hpRemaining;
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

        public void SetLink(ConditionalGain link)
        {
            Link = link;
        }

        public ConditionalGain GetLink()
        {
            return Link;
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
    }
}

