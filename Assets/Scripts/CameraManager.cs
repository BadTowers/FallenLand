// Credit to damien_oconnell from http://forum.unity3d.com/threads/39513-Click-drag-camera-movement
// for using the mouse displacement for calculating the amount of camera movement and panning code.

using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour 
{
	public float rotateSpeed = 4.0f;	// Speed of camera turning when mouse moves in along an axis
	public float panSpeed = 0.5f;		// Speed of the camera when being panned
	public float zoomSpeed = 4.0f;		// Speed of the camera going back and forth
	public float minZoomFOV = 20.0f;
	public float maxZoomFOV = 70.0f;
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
			rotateValue = new Vector3 (y, x * -1, 0);
			transform.eulerAngles = transform.eulerAngles - (rotateValue * rotateSpeed);
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

			//Update the camera
			transform.Translate(movement * panSpeed * Time.deltaTime, Space.World);
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