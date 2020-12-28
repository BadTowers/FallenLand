
namespace FallenLand
{
	public class Dice
	{
        readonly System.Random RandomGen;

		public Dice()
		{
			RandomGen = new System.Random(System.Guid.NewGuid().GetHashCode());
		}

		public int RollDice(int numberOfSides)
		{
			return RandomGen.Next(1, numberOfSides + 1);
		}
	}
}
