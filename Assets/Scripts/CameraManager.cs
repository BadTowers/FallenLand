// Credit to damien_oconnell from http://forum.unity3d.com/threads/39513-Click-drag-camera-movement
// for using the mouse displacement for calculating the amount of camera movement and panning code.

using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour 
{
	//
	// VARIABLES
	//

	public float turnSpeed = 4.0f;		// Speed of camera turning when mouse moves in along an axis
	public float panSpeed = 4.0f;		// Speed of the camera when being panned
	public float zoomSpeed = 4.0f;		// Speed of the camera going back and forth

	private Vector3 mouseOrigin;	// Position of cursor when mouse dragging starts
	private bool isPanning = false;		// Is the camera being panned?
	private bool isRotating = false;	// Is the camera being rotated?

	//
	// UPDATE
	//

	void Update () 
	{
		// Get the right mouse button
		if(Input.GetMouseButtonDown(1))
		{
			// Get mouse origin
			mouseOrigin = Input.mousePosition;
			isPanning = true;
		}

		// Get the middle mouse button
		if(Input.GetMouseButtonDown(2))
		{
			// Get mouse origin
			mouseOrigin = Input.mousePosition;
			isRotating = true;
		}

		// Disable movements on button release
		//if (!Input.GetMouseButton(0)) isRotating=false;
		if (!Input.GetMouseButton(1)) isPanning=false;
		if (!Input.GetMouseButton(2)) isRotating=false;

		// Rotate camera along X and Y axis
		if (isRotating && !isPanning)
		{
			Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

			transform.RotateAround(transform.position, transform.right, -pos.y * turnSpeed);
			transform.RotateAround(transform.position, Vector3.up, pos.x * turnSpeed);
		}

		// Move the camera on it's XY plane
		if (isPanning && !isRotating)
		{
			Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

			Vector3 move = new Vector3(pos.x * panSpeed, pos.y * panSpeed, 0);
			transform.Translate(move, Space.Self);
		}

		// Zoom via scrollwheel TODO: Add zoom out and zoom in limits
		if (Input.GetAxis("Mouse ScrollWheel") > 0) {
			GetComponent<Transform>().position = new Vector3 (transform.position.x, transform.position.y - .3f, transform.position.z + .2f);
		}
		else if (Input.GetAxis("Mouse ScrollWheel") < 0) {
			GetComponent<Transform>().position = new Vector3 (transform.position.x, transform.position.y + .3f, transform.position.z - .2f);
		}
	}
}