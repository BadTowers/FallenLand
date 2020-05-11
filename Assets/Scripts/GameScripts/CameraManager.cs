// Credit to damien_oconnell from http://forum.unity3d.com/threads/39513-Click-drag-camera-movement
// for using the mouse displacement for calculating the amount of camera movement and panning code.

using UnityEngine;
using System.Collections;

namespace FallenLand
{
	public class CameraManager : MonoBehaviour
	{
		public float PanSpeed;
		public float ZoomSpeed;
		public float MinZoom;
		public float MaxZoom;
		private bool isPanning = false;

		//For panning
		private Vector3 oldLocation = new Vector3(-1, -1, -1);
		private Vector3 newLocation = new Vector3(-1, -1, -1);

		void Start()
		{
			//Center the camera
			Camera.main.transform.position = new Vector3(12 * MapCreation.scale, MinZoom, 5 * MapCreation.scale);
		}

		void Update()
		{
			// Get the right mouse button
			if (Input.GetMouseButtonDown(1))
			{
				isPanning = true;
			}

			// Disable movements on button release
			if (!Input.GetMouseButton(1))
			{
				isPanning = false;
				oldLocation = new Vector3(-1, -1, -1);
				newLocation = new Vector3(-1, -1, -1);
			}

			// Pan the camera on its XZ plane
			if (isPanning)
			{
				//Update the mouse location from one frame ago.
				oldLocation = newLocation;

				//Update the mouse location from this frame
				newLocation = Input.mousePosition;

				//If old location is -1, then this is the first pan frame, so return.
				if (oldLocation.x == -1)
				{
					return;
				}

				Vector3 movement = Vector3.zero;
				movement.x = oldLocation.x - newLocation.x; //Set side to side move equal to the left/right move of mouse
				movement.z = oldLocation.y - newLocation.y; //Set front to back move (z plane) equal to the up/down move of the mouse
				movement *= PanSpeed; // Pan speed only has to be reduced in the Left/Right direction, not the Up/Down
									  //movement = Camera.main.transform.TransformDirection(movement); //Account for camera facing different direction than default
				movement.y = 0; //Don't change in the y direction
				transform.Translate(movement * Time.deltaTime * MapCreation.scale, Space.World); //Update the camera
																								 //Ensure we are still in the the map bounds
				float newPanX = transform.position.x;
				float newPanZ = transform.position.z;
				newPanX = Mathf.Clamp(newPanX, -1 * MapCreation.scale, 27 * MapCreation.scale);
				newPanZ = Mathf.Clamp(newPanZ, -1 * MapCreation.scale, 16 * MapCreation.scale);
				//Update the camera if we went over the bounds
				transform.position = new Vector3(newPanX, transform.position.y, newPanZ);
			}

			// Zoom via scrollwheel
			if (Input.GetAxis("Mouse ScrollWheel") > 0)
			{
				//GetComponent<Transform>().position = new Vector3 (transform.position.x, transform.position.y - .3f, transform.position.z + .2f);
				zoomIn();
			}
			else if (Input.GetAxis("Mouse ScrollWheel") < 0)
			{
				//GetComponent<Transform>().position = new Vector3 (transform.position.x, transform.position.y + .3f, transform.position.z - .2f);
				zoomOut();
			}
		}

		private void zoomIn()
		{
			float newY = Camera.main.transform.position.y - ZoomSpeed;
			if (newY < MinZoom)
			{
				newY = MinZoom;
			}
			Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, newY, Camera.main.transform.position.z);
		}

		private void zoomOut()
		{
			float newY = ZoomSpeed + Camera.main.transform.position.y;
			if (newY > MaxZoom)
			{
				newY = MaxZoom;
			}
			Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, newY, Camera.main.transform.position.z);
		}
	}
}