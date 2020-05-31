using System.Text;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FallenLand
{
	public class MouseManager : MonoBehaviour
	{
		private GameObject HexInformationBackground;
		private GameObject HexInformationText;
		private string ToolTipText = "";

        #region UnityFunctions
        void Awake()
		{
			HexInformationBackground = GameObject.Find("HexInformationBackground");
			HexInformationText = GameObject.Find("HexInformationText");
		}

		void Start()
		{
			HexInformationText.SetActive(false);
			HexInformationBackground.SetActive(false);
		}

		// Update is called once per frame
		void Update()
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Get a vector called a Ray from the mouse through the world

			RaycastHit objectHitInfo; //Object the raycast hit, if any

			//Check if the ray hit any colliders
			if (Physics.Raycast(ray, out objectHitInfo))
			{
				GameObject ourHitObject = objectHitInfo.collider.transform.gameObject; //Get the object the mouse is over

				//We know here what we are mousing over
				if (ourHitObject.name != null)
				{
					mouseOverHex(ourHitObject);
				}
			}
			else
			{
				disableHexInfo();
			}
		}
        #endregion

        private void mouseOverHex(GameObject go)
		{
			//If left clicking
			if (Input.GetMouseButtonDown(0))
			{
				//If we clicked a Unity UI element
				if (EventSystem.current.IsPointerOverGameObject())
				{
					//It is, so let's not do any game click code
					Debug.Log("Clicked a game object");
					return;
				}
				Debug.Log("Clicked a hex");

				MeshRenderer mr;
				//Each hex is made of 2 hexes, and inner and an outer. Get the mesh of the inner hex.
				if (go.name == "OuterHex")
				{
					mr = go.transform.parent.Find("InnerHex").GetComponentInChildren<MeshRenderer>();
				}
				else
				{
					mr = go.GetComponentInChildren<MeshRenderer>();
				}

				toggleColor(mr);
			}
			else
			{
				string info = getHexInfoString(go.transform.GetComponentInParent<Hex>());
				enableHexInfo(info);
			}
		}

		private void toggleColor(MeshRenderer mr)
		{
			Debug.Log("toggleColor");
			if (mr.material.color == Color.white)
			{
				Debug.Log("blue");
				mr.material.color = Color.blue;
			}
			else
			{
				Debug.Log("white");
				mr.material.color = Color.white;
			}
		}

		private void enableHexInfo(string text)
		{
			ToolTipText = text;
			HexInformationText.SetActive(true);
			HexInformationBackground.SetActive(true);
		}

		private void disableHexInfo()
		{
			ToolTipText = ""; //Reset the tooltip text when you aren't mousing over something
			HexInformationText.SetActive(false);
			HexInformationBackground.SetActive(false);
		}

		private string getHexInfoString(Hex hex)
		{
			StringBuilder toReturn = new StringBuilder();
			toReturn.Append(hex.name);
			toReturn.Append(Environment.NewLine);
			if (hex.IsRad())
			{
				toReturn.Append("Rad" + Environment.NewLine);
			}
			if (hex.IsCity())
			{
				toReturn.Append("City" + Environment.NewLine);
			}
			if (hex.IsMountain())
			{
				toReturn.Append("Mountain" + Environment.NewLine);
			}
			if (hex.IsPlains())
			{
				toReturn.Append("Plains" + Environment.NewLine);
			}
			if (hex.IsRandomLocation())
			{
				toReturn.Append("R: ");
				toReturn.Append(hex.GetRandomLocationNumber());
				toReturn.Append(Environment.NewLine);
			}
			if (hex.IsResource())
			{
				toReturn.Append("Resource" + Environment.NewLine);
			}
			if (hex.IsFactionBase())
			{
				toReturn.Append("F: ");
				toReturn.Append(hex.GetFaction().GetName());
				toReturn.Append(Environment.NewLine);
			}
			if (hex.IsWater())
			{
				toReturn.Append("Water" + Environment.NewLine);
			}

			return toReturn.ToString();
		}
	}
}
