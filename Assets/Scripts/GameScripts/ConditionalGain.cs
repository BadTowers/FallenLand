
using System.Collections.Generic;

namespace FallenLand
{
    public class ConditionalGain
    {
        private List<List<Reward>> RewardChoices; //Everything in a dictionary is awarded if chosen, each list entry is a choice (so you can take dictionary 1's rewards or dictionary 2's rewards, for example
        private List<List<Times>> WhenRewardCanBeGained; //each outer list is AND'ed together, each inner list item is OR'ed together
        private Uses NumberOfTimesThisRewardCanBeClaimed;
        private bool DiscardAfterClaimingReward;
        private List<List<Reward>> D6Options;
        private State StateWhenUsable;

        public ConditionalGain()
        {
            RewardChoices = new List<List<Reward>>();
            WhenRewardCanBeGained = new List<List<Times>>();
            DiscardAfterClaimingReward = false;
            D6Options = new List<List<Reward>>();
        }

        //If only one choice added, then it's just given if conditions are met
        public void AddRewardChoice(List<Reward> choice)
        {
            RewardChoices.Add(choice);
        }

        public List<List<Reward>> GetRewardChoices()
        {
            return RewardChoices;
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

        public List<List<Times>> GetWhenRewardCanBeGained()
        {
            return WhenRewardCanBeGained;
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

        public void AddD6Option(List<Reward> gains)
        {
            D6Options.Add(gains);
        }

        public void SetWhenRewardCanBeClaimed(State state)
        {
            StateWhenUsable = state;
        }

        public State GetWhenRewardCanBeClaimed()
        {
            return StateWhenUsable;
        }
    }

    public class ConditionalGainHelpers
    {
        public static void HandleConditionalGain(GameManager gameManager, ConditionalGain conditionalGain)
        {
            if (conditionalGain != null && conditionalGain.GetWhenRewardCanBeClaimed() != null && conditionalGain.GetWhenRewardCanBeClaimed().IsStateOccurring(gameManager))
            {
                List<List<Reward>> rewards = conditionalGain.GetRewardChoices();
                if (rewards.Count == 1)
                {
                    for (int rewardIndex = 0; rewardIndex < rewards[0].Count; rewardIndex++)
                    {
                        rewards[0][rewardIndex].HandleReward(gameManager);
                    }
                }
                else
                {
                    //Ask the game manager to show the user their options
                }
            }
        }
    }
}
