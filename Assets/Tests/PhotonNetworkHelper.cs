using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace FallenLand
{
	public class PhotonNetworkHelper : MonoBehaviourPunCallbacks
	{
		private bool ConnectedToMaster;
		private bool ConnectedToRoom;

		#region PublicAPI
		public bool GetConnectedToMaster()
		{
			return ConnectedToMaster;
		}

		public bool GetConnectedToRoom()
		{
			return ConnectedToRoom;
		}

		public void ConnectToMaster()
		{
			PhotonNetwork.ConnectUsingSettings();
		}

		public void CreateTestRoom()
		{
			RoomOptions roomOptions = new RoomOptions
			{
				MaxPlayers = 5,
				PublishUserId = true
			};
			PhotonNetwork.CreateRoom("TestRoomName", roomOptions);
		}

		public void LeaveRoom()
		{
			PhotonNetwork.LeaveRoom();
		}

		public void DisconnectFromMaster()
		{
			PhotonNetwork.Disconnect();
		}
		#endregion

		#region PunCallbacks
		public override void OnConnectedToMaster()
		{
			ConnectedToMaster = true;
		}

		public override void OnJoinedRoom()
		{
			ConnectedToRoom = true;
		}

		public override void OnLeftRoom()
		{
			ConnectedToRoom = false;
		}

		public override void OnDisconnected(DisconnectCause cause)
		{
			ConnectedToMaster = false;
		}
		#endregion
	}
}