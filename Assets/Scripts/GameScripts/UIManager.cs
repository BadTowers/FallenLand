using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace FallenLand
{
	public class UIManager : MonoBehaviourPunCallbacks
	{

		private List<GameObject> menus;

		protected void setActiveMenu(GameObject go)
		{
			if (go != null)
			{
				go.SetActive(true);
			}
			foreach (GameObject other in menus)
			{
				if (!other.Equals(go))
				{
					other.SetActive(false);
				}
			}
		}

		protected void addToMenuList(GameObject go)
		{
			check();
			menus.Add(go);
		}

		private void check()
		{
			if (menus == null)
			{
				menus = new List<GameObject>();
			}
		}
	}
}
