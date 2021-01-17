using System.Collections.Generic;
namespace FallenLand
{
	public class ShuffleNetworking
	{
		private readonly byte DeckToShuffle;

		public ShuffleNetworking(byte deckToShuffle)
		{
			DeckToShuffle = deckToShuffle;
		}

		public static object DeserializeShuffle(byte[] data)
		{
            byte deckToShuffle = data[0];

			ShuffleNetworking result = new ShuffleNetworking(deckToShuffle);

			return result;
		}

		public static byte[] SerializeShuffle(object customType)
		{
			ShuffleNetworking shuffle = (ShuffleNetworking)customType;

			List<byte> byteListFinal = new List<byte>
			{
				shuffle.GetDeckToShuffle()
			};

			return byteListFinal.ToArray();
		}

		public byte GetDeckToShuffle()
		{
			return DeckToShuffle;
		}
	}
}
