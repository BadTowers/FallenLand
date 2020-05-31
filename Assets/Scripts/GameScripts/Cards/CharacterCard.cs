using System.Collections.Generic;

namespace FallenLand
{
    public class CharacterCard : PartyCard
    {

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
    }
}

