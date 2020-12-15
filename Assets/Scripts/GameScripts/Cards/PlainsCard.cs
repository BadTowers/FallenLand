
namespace FallenLand
{
	public class PlainsCard : EncounterCard
	{
		public PlainsCard(string title) : base(title)
		{

		}

		public static PlainsCard FindCardInDeckByTitle(string title, System.Collections.Generic.List<PlainsCard> deck)
		{
			PlainsCard card = null;
			for (int i = 0; i < deck.Count; i++)
			{
				if (deck[i].GetTitle() == title)
				{
					card = deck[i];
					break;
				}
			}

			return card;
		}
	}
}
