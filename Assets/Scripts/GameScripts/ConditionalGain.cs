
using System.Collections.Generic;

namespace FallenLand
{
    public class ConditionalGain
    {
        private List<Dictionary<Gains, int>> Rewards; //Everything in a dictionary is awarded if chosen, each list entry is a choice (so you can take dictionary 1's rewards or dictionary 2's rewards, for example
        private List<List<Times>> WhenRewardCanBeGained; //each outer list is AND'ed together, each inner list item is OR'ed together
        private Uses NumberOfTimesThisRewardCanBeClaimed;
        private bool DiscardAfterClaimingReward;
        private List<Dictionary<Gains, int>> D6Options;

        public ConditionalGain()
        {
            Rewards = new List<Dictionary<Gains, int>>();
            WhenRewardCanBeGained = new List<List<Times>>();
            DiscardAfterClaimingReward = false;
            D6Options = new List<Dictionary<Gains, int>>();
        }

        //If only one choice added, then it's just given if conditions are met
        public void AddRewardChoice(Dictionary<Gains, int> choice)
        {
            Rewards.Add(choice);
        }

        public List<Dictionary<Gains, int>> GetRewardChoices()
        {
            return Rewards;
        }

        public void SetWhenRewardCanBeGained(params List<Times>[] times)
        {
            WhenRewardCanBeGained = new List<List<Times>>();
            foreach (List<Times> curTimeList in times)
            {
                if (curTimeList != null)
                {
                    WhenRewardCanBeGained.Add(curTimeList);
                }
            }
        }

        public void SetWhenRewardCanBeGained(Times time)
        {
            WhenRewardCanBeGained = new List<List<Times>>
            {
                new List<Times>() { time }
            };
        }

        public void AddWhenRewardCanBeGained(List<Times> times)
        {
            WhenRewardCanBeGained.Add(times);
        }

        public void SetNumberOfTimesThisRewardCanBeClaimed(Uses use)
        {
            NumberOfTimesThisRewardCanBeClaimed = use;
        }

        public Uses GetNumberOfTimesThisRewardCanBeClaimed()
        {
            return NumberOfTimesThisRewardCanBeClaimed;
        }

        public void SetDiscardAfterClaimingReward(bool discardAfterClaimingReward)
        {
            DiscardAfterClaimingReward = discardAfterClaimingReward;
        }

        public bool GetDiscardAfterClaimingReward()
        {
            return DiscardAfterClaimingReward;
        }

        public void AddD6Option(Dictionary<Gains, int> gains)
        {
            D6Options.Add(gains);
        }
    }
}
