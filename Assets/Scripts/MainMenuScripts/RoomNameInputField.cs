using UnityEngine;
using UnityEngine.UI;

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
    }

    public string GetRoomName()
    {
        return RoomName;
    }
}