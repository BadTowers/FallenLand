using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using NUnit.Framework.Constraints;

namespace FallenLand
{
    [RequireComponent(typeof(InputField))]
    public class UserNameInputField : MonoBehaviour
    {
        const string playerNamePrefKey = "PlayerName";

        #region MonoBehaviour CallBacks
        void Start()
        {
            string defaultName = string.Empty;
            InputField inputField = this.GetComponent<InputField>();
            if (inputField != null)
            {
                if (PlayerPrefs.HasKey(playerNamePrefKey))
                {
                    defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                }
                inputField.text = defaultName;
            }
            PhotonNetwork.NickName = defaultName;
        }
        #endregion

        #region Public Methods
        public void SetPlayerName(string value)
        {
            InputField inputField = this.GetComponent<InputField>();
            if (!string.IsNullOrEmpty(value))
            {
                PhotonNetwork.NickName = value;

                PlayerPrefs.SetString(playerNamePrefKey, value);
                inputField.text = value;
            }
        }
        #endregion
    }
}