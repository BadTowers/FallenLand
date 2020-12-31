using System.Collections.Generic;

namespace FallenLand
{
	public class ResourceNetworking
	{
		private readonly int OwnerIndex;
		private readonly Coordinates ResourceLocation;
		private readonly int CaptorIndex;

		public ResourceNetworking(int ownerIndex, Coordinates resourceLocation, int captorIndex)
		{
			OwnerIndex = ownerIndex;
			ResourceLocation = resourceLocation;
			CaptorIndex = captorIndex;
		}

		public static object DeserializeResource(byte[] data)
		{
			int ownerIndex = data[0];
			int xLocation = data[1];
			int yLocation = data[2];
			int captorIndex = data[3];

			ResourceNetworking result = new ResourceNetworking(ownerIndex, new Coordinates(xLocation, yLocation), captorIndex);

			return result;
		}

		public static byte[] SerializeResource(object customType)
		{
			ResourceNetworking encounterStatus = (ResourceNetworking)customType;
			Coordinates location = encounterStatus.GetResourceLocation();

			List<byte> byteListFinal = new List<byte>
			{
				(byte)encounterStatus.GetOwnerIndex(),
				(byte)location.GetX(),
				(byte)location.GetY(),
				(byte)encounterStatus.GetCaptorIndex(),
			};

			return byteListFinal.ToArray();
		}

		public int GetOwnerIndex()
		{
			return OwnerIndex;
		}

		public int GetCaptorIndex()
		{
			return CaptorIndex;
		}

		public Coordinates GetResourceLocation()
		{
			return ResourceLocation;
		}
	}
}
