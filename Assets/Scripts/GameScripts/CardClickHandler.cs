using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FallenLand
{
    public class CardClickHandler : MonoBehaviour, IPointerClickHandler
    {
        private GameUIManager UiManager;
        private CardMovementHandler MovementHandler;

        void Start()
        {
            UiManager = GameObject.Find("UIManager").GetComponentInChildren<GameUIManager>();
            MovementHandler = gameObject.transform.GetComponentInParent<CardMovementHandler>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                Debug.Log("Mouse click");
                if (MovementHandler == null || !MovementHandler.GetIsDragging())
                {
                    //tell ui manager to show window for this card
                    UiManager.SetCardIsClicked(gameObject.transform.GetComponentInParent<Image>().sprite);
                    UiManager.SetCardIsHorizontal(gameObject.transform.rotation.z != 0);
                }
            }
        }
    }
}
