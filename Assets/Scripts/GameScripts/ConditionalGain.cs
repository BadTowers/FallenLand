
using System.Collections.Generic;

namespace FallenLand
{
    public class ConditionalGain
    {
        private readonly List<List<Reward>> RewardChoices; //Everything in a dictionary is awarded if chosen, each list entry is a choice (so you can take dictionary 1's rewards or dictionary 2's rewards, for example
        private State StateWhenUsable;

        public ConditionalGain()
        {
            RewardChoices = new List<List<Reward>>();
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
        public static void HandleConditionalGain(GameManager gameManager, ConditionalGain conditionalGain, int playerIndex)
        {
            if (conditionalGain != null && conditionalGain.GetWhenRewardCanBeClaimed() != null && conditionalGain.GetWhenRewardCanBeClaimed().IsStateOccurring(gameManager, playerIndex, Constants.DONT_CARE))
            {
                List<List<Reward>> rewards = conditionalGain.GetRewardChoices();
                if (rewards.Count == 1)
                {
                    for (int rewardIndex = 0; rewardIndex < rewards[0].Count; rewardIndex++)
                    {
                        rewards[0][rewardIndex].HandleReward(gameManager, gameManager.GetIndexForMyPlayer());
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
