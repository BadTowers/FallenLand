// Credit to damien_oconnell from http://forum.unity3d.com/threads/39513-Click-drag-camera-movement
// for using the mouse displacement for calculating the amount of camera movement and panning code.

using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour 
{
	public float rotateSpeed;	// Speed of camera turning when mouse moves in along an axis
	public float panSpeed;		// Speed of the camera when being panned
	public float zoomSpeed;		// Speed of the camera going back and forth
	public float minZoomFOV;
	public float maxZoomFOV;
	private bool isPanning = false;		// Is the camera being panned?
	private bool isRotating = false;	// Is the camera being rotated?

	//For panning
	private Vector3 oldLocation = new Vector3(-1, -1, -1);
	private Vector3 newLocation = new Vector3 (-1, -1, -1);

	//For rotating
	private float x;
	private float y;
	private Vector3 rotateValue;

	void Update () 
	{
		// Get the right mouse button
		if(Input.GetMouseButtonDown(1))
		{
			isRotating = true;
		}

		// Get the middle mouse button
		if(Input.GetMouseButtonDown(2))
		{
			isPanning = true;
		}

		// Disable movements on button release
		if (!Input.GetMouseButton(1)) {
			isRotating = false;
		}
		if (!Input.GetMouseButton(2)) {
			isPanning = false;
			oldLocation = new Vector3(-1, -1, -1);
			newLocation = new Vector3(-1, -1, -1);
		}

		// Rotate camera along X and Y axis
		if (isRotating && !isPanning)
		{
			x = Input.GetAxis("Mouse X");
			y = Input.GetAxis("Mouse Y");
			rotateValue = new Vector3(y, x * -1, 0); //Create the rotation vector
			transform.eulerAngles = transform.eulerAngles - (rotateValue * rotateSpeed * MapCreation.scale); //Adjust for rotating speed
			//This chunk of code restrict the rotation angles in the LEFT/RIGHT directions
			float newRotY = transform.eulerAngles.y;
			if (transform.eulerAngles.y > 50 && transform.eulerAngles.y < 310) { // If the y is outside of the allowed range
				//If it's closer to 310 than it is to 50
				if (Mathf.Abs (310 - transform.eulerAngles.y) < Mathf.Abs (50 - transform.eulerAngles.y)) {
					newRotY = 310;
				} else { //Else, it's closer to 50 than 310
					newRotY = 50;
				}
			}
			//This chunk of code restricts the rotation angles in the UP/DOWN directions
			float newRotX = Mathf.Clamp(transform.eulerAngles.x, 20, 80);
			//Set the new rotation, res
			transform.eulerAngles = new Vector3(newRotX, newRotY, transform.eulerAngles.z); //Clamp the rotational x value range
		}

		// Pan the camera on its XZ plane
		if (isPanning && !isRotating)
		{
			//Update the mouse location from one frame ago.
			oldLocation = newLocation;

			//Update the mouse location from this frame
			newLocation = Input.mousePosition;

			//If old location is -1, then this is the first pan frame, so return.
			if (oldLocation.x == -1) {
				return;
			}

			Vector3 movement = Vector3.zero;
			movement.x = oldLocation.x - newLocation.x; //Set side to side move equal to the left/right move of mouse
			movement.z = oldLocation.y - newLocation.y; //Set front to back move (z plane) equal to the up/down move of the mouse
			movement.x *= panSpeed; // Pan speed only has to be reduced in the Left/Right direction, not the Up/Down
			movement = Camera.main.transform.TransformDirection(movement); //Account for camera facing different direction than default
			movement.y = 0; //Don't change in the y direction
			transform.Translate(movement * Time.deltaTime * MapCreation.scale, Space.World); //Update the camera
			//Ensure we are still in the the map bounds
			float newPanX = transform.position.x;
			float newPanZ = transform.position.z;
			newPanX = Mathf.Clamp(newPanX, -1 * MapCreation.scale, 25 * MapCreation.scale);
			newPanZ = Mathf.Clamp(newPanZ, -5 * MapCreation.scale, 14 * MapCreation.scale);
			//Update the camera if we went over the bounds
			transform.position = new Vector3 (newPanX, transform.position.y, newPanZ);
		}

		// Zoom via scrollwheel TODO: Add zoom out and zoom in limits
		if (Input.GetAxis("Mouse ScrollWheel") > 0) {
			//GetComponent<Transform>().position = new Vector3 (transform.position.x, transform.position.y - .3f, transform.position.z + .2f);
			ZoomIn();
		}
		else if (Input.GetAxis("Mouse ScrollWheel") < 0) {
			//GetComponent<Transform>().position = new Vector3 (transform.position.x, transform.position.y + .3f, transform.position.z - .2f);
			ZoomOut();
		}
	}

	private void ZoomIn()
	{
		Camera.main.fieldOfView -= zoomSpeed;
		if (Camera.main.fieldOfView < minZoomFOV)
		{
			Camera.main.fieldOfView = minZoomFOV;
		}
	}

	private void ZoomOut()
	{
		Camera.main.fieldOfView += zoomSpeed;
		if (Camera.main.fieldOfView > maxZoomFOV)
		{
			Camera.main.fieldOfView = maxZoomFOV;
		}
	}
}