using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace FallenLand
{
	public class UIManager : MonoBehaviourPunCallbacks
	{
		private List<GameObject> Menus;

		protected void SetActiveMenu(GameObject go)
		{
			if (go != null)
			{
				go.SetActive(true);
			}
			foreach (GameObject other in Menus)
			{
				if (!other.Equals(go))
				{
					other.SetActive(false);
				}
			}
		}

		protected void AddToMenuList(GameObject go)
		{
			Check();
			Menus.Add(go);
		}

		private void Check()
		{
			if (Menus == null)
			{
				Menus = new List<GameObject>();
			}
		}
	}
}
