using System.Collections.Generic;

namespace FallenLand
{
	public class MissionLocationNetworking
	{
		private readonly int MissionNumber;
		private readonly int RandomNumberLocation;

		public MissionLocationNetworking(int missionNumber, int randomNumberLocation)
		{
			MissionNumber = missionNumber;
			RandomNumberLocation = randomNumberLocation;
		}

		public static object DeserializeMissionLocation(byte[] data)
		{
            int missionNumber = data[0]; //grab mission number
			int randomLocationNumber = data[1]; //grab location next
			MissionLocationNetworking result = new MissionLocationNetworking(missionNumber, randomLocationNumber);
			return result;
		}

		public static byte[] SerializeMissionLocation(object customType)
		{
			MissionLocationNetworking missionLocationInfo = (MissionLocationNetworking)customType;
			UnityEngine.Debug.Log("Serialization: mission number is " + missionLocationInfo.GetMissionNumber());
            List<byte> byteListFinal = new List<byte>
            {
                (byte)missionLocationInfo.GetMissionNumber(), //pack mission number first
				(byte)missionLocationInfo.GetRandomLocationNumber() //pack mission location next
			};
            UnityEngine.Debug.Log("Serialization for mission location: size is " + byteListFinal.Count);

			return byteListFinal.ToArray();
		}

		public int GetMissionNumber()
		{
			return MissionNumber;
		}

		public int GetRandomLocationNumber()
		{
			return RandomNumberLocation;
		}
	}
}
