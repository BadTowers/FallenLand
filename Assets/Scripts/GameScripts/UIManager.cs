using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

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
				foreach (GameObject other in menus)
				{
					if (!other.Equals(go))
					{
						other.SetActive(false);
					}
				}
			}
			else
			{
				foreach (GameObject other in menus)
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
