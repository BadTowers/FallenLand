using UnityEngine;
using UnityEngine.UI;

namespace FallenLand
{
    [RequireComponent(typeof(InputField))]
    public class RoomNameInputField : MonoBehaviour
    {
        private string RoomName = "JeksPeen";

        void Start()
        {
            InputField inputField = this.GetComponent<InputField>();
            if (inputField != null)
            {
                inputField.text = RoomName;
            }
        }

        public void SetRoomName(string value)
        {
            RoomName = value;

            InputField inputField = this.GetComponent<InputField>();
            if (inputField != null)
            {
                inputField.text = RoomName;
            }
        }

        public string GetRoomName()
        {
            return RoomName;
        }
    }
}