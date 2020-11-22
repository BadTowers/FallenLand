// Credit to damien_oconnell from http://forum.unity3d.com/threads/39513-Click-drag-camera-movement
// for using the mouse displacement for calculating the amount of camera movement and panning code.

using UnityEngine;

namespace FallenLand
{
	public class CameraManager : MonoBehaviour
	{
        public const float PanSpeed = MapCreation.MAP_SCALE;
        public const float ZoomSpeed = 4f;
        public const float MinZoom = 10f;
        public const float MaxZoom = 50f;

        private GameObject PauseMenu;
        private GameObject CharacterSpoilsOverlay;
        private bool IsPanning = false;
        private bool CameraMovementIsAllowed = false;
        private Vector3 oldMouseLocation = new Vector3(-1, -1, -1);
        private Vector3 newMouseLocation = new Vector3(-1, -1, -1);

        #region UnityFunctions
        void Awake()
        {
            PauseMenu = GameObject.Find("PauseMenu");
            CharacterSpoilsOverlay = GameObject.Find("CharacterAndSpoilsAssigningPanel");
        }

        void Start()
        {
            //Center the camera
            Camera.main.transform.position = new Vector3(12 * MapCreation.MAP_SCALE, MinZoom, 5 * MapCreation.MAP_SCALE);
        }

        void Update()
        {
            updateIsAllowedToPan();

            // Get the right mouse button
            if (Input.GetMouseButtonDown(1) && CameraMovementIsAllowed)
            {
                IsPanning = true;
            }

            // Disable movements on button release
            if (IsPanning && !Input.GetMouseButton(1))
            {
                IsPanning = false;
                oldMouseLocation = new Vector3(-1, -1, -1);
                newMouseLocation = new Vector3(-1, -1, -1);
            }

            // Pan the camera on its XZ plane
            if (IsPanning)
            {
                //Update the mouse location from one frame ago.
                oldMouseLocation = newMouseLocation;

                //Update the mouse location from this frame
                newMouseLocation = Input.mousePosition;

                //If old location is -1, then this is the first pan frame, so return.
                if (oldMouseLocation.x == -1)
                {
                    return;
                }

                Vector3 movement = Vector3.zero;
                movement.x = oldMouseLocation.x - newMouseLocation.x; //Set side to side move equal to the left/right move of mouse
                movement.z = oldMouseLocation.y - newMouseLocation.y; //Set front to back move (z plane) equal to the up/down move of the mouse
                movement *= PanSpeed * (transform.position.y / MinZoom); //Scale for PanSpeed and how zoomed in or out we are
                transform.Translate(movement * Time.deltaTime, Space.World); //Update the camera

                //Ensure we are still in the the map bounds
                float newPanX = transform.position.x;
                float newPanZ = transform.position.z;
                newPanX = Mathf.Clamp(newPanX, -1 * MapCreation.MAP_SCALE, 27 * MapCreation.MAP_SCALE);
                newPanZ = Mathf.Clamp(newPanZ, -1 * MapCreation.MAP_SCALE, 16 * MapCreation.MAP_SCALE);
                //Update the camera if we went over the bounds
                transform.position = new Vector3(newPanX, transform.position.y, newPanZ);
            }

            // Zoom via scrollwheel
            if (Input.GetAxis("Mouse ScrollWheel") > 0 && CameraMovementIsAllowed)
            {
                zoomIn();
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0 && CameraMovementIsAllowed)
            {
                zoomOut();
            }
        }
        #endregion

        #region HelperFunctions
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

        private void updateIsAllowedToPan()
        {
            if (!PauseMenu.activeSelf && !CharacterSpoilsOverlay.activeSelf)
            {
                CameraMovementIsAllowed = true;
            }
            else
            {
                CameraMovementIsAllowed = false;
            }
        }
        #endregion
    }
}