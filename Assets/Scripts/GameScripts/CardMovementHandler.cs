using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FallenLand
{
    public class CardMovementHandler : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        private bool IsDragging;
        private bool IsOldParentSet;
        private bool IsHoveringOverPanel;
        private Vector2 ImageSize = new Vector2(75, 100);
        private Vector3 PreDragLocation = new Vector3(-1, -1, -1);
        private float PreHoverScrollSensitivity;
        private GameObject OldParent;
        private GameObject HoveredOverPanel;
        private GameUIManager UiManager;
        private int SiblingOrder;
        private CardClickHandler ClickHandler;

        void Start()
        {
            PreHoverScrollSensitivity = GameObject.Find("AuctionHouseScrollView").GetComponent<ScrollRect>().scrollSensitivity;
            UiManager = GameObject.Find("UIManager").GetComponentInChildren<GameUIManager>();
            ClickHandler = gameObject.transform.GetComponentInParent<CardClickHandler>();
        }

        void Update()
        {
            checkIfWeAreHoveredOverPanel();
        }

        public bool GetIsDragging()
        {
            return IsDragging;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                Debug.Log("Dragging");
                if (!IsDragging)
                {
                    UiManager.SetCardIsDragging(true);
                    SiblingOrder = transform.GetSiblingIndex();
                    PreDragLocation = transform.position;
                }
                IsDragging = true;
                figureOutCurrentParent();
                setNewTemporaryParent();
                Canvas myCanvas = this.GetComponentInParent<Canvas>();
                RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out Vector2 pos);
                transform.position = myCanvas.transform.TransformPoint(pos);
                this.GetComponentInParent<Image>().rectTransform.sizeDelta = new Vector2(ImageSize.x, ImageSize.y);
                transform.SetAsLastSibling(); //move to the front (on parent)
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                UiManager.SetCardIsDragging(false);
                IsDragging = false;
                Image cardImage = this.GetComponentInParent<Image>();
                if (HoveredOverPanel != null && UiManager.CardIsAllowedToMoveHere(cardImage, HoveredOverPanel))
                {
                    Transform viewportTransform = HoveredOverPanel.transform.Find("Viewport");
                    cardImage.rectTransform.SetParent(viewportTransform.transform.Find("Content").gameObject.transform);
                    UiManager.UpdateAfterCardWasMoved(cardImage, HoveredOverPanel);
                }
                else
                {
                    resetParent();
                    transform.position = PreDragLocation;
                }
                OldParent = null;
                IsOldParentSet = false;
                if (HoveredOverPanel != null)
                {
                    changeHoveredPanelColor();
                    HoveredOverPanel = null;
                }
            }
        }

        #region HelperFunctions

        private void figureOutCurrentParent()
        {
            if (this.GetComponentInParent<Image>().rectTransform.parent != null && !IsOldParentSet)
            {
                Debug.Log("Figured out old parent for " + this.GetComponentInParent<Image>().name);
                OldParent = this.GetComponentInParent<Image>().rectTransform.parent.gameObject;
                IsOldParentSet = true;
            }
        }

        private void setNewTemporaryParent()
        {
            Debug.Log("Set new temporary parent for " + this.GetComponentInParent<Image>().name);
            this.GetComponentInParent<Image>().rectTransform.SetParent(GameObject.Find("CharacterAndSpoilsAssigningPanel").transform);
        }

        private void resetParent()
        {
            Debug.Log("Reset parent for " + this.GetComponentInParent<Image>().name);
            this.GetComponentInParent<Image>().rectTransform.SetParent(OldParent.transform);
            transform.SetSiblingIndex(SiblingOrder);
        }

        private void checkIfWeAreHoveredOverPanel()
        {
            findPanelOfInterest();

            if (HoveredOverPanel != null)
            {
                changeHoveredPanelColor();
                if (!IsHoveringOverPanel)
                {
                    HoveredOverPanel = null;
                }
            }
        }

        private void findPanelOfInterest()
        {
            IsHoveringOverPanel = false;
            PointerEventData pointer = new PointerEventData(EventSystem.current);
            pointer.position = Input.mousePosition;

            List<RaycastResult> raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointer, raycastResults);

            foreach (RaycastResult result in raycastResults)
            {
                if (result.gameObject.name.Contains("CharacterSlotScrollView") || 
                    result.gameObject.name.Contains("AuctionHouseScrollView") || 
                    result.gameObject.name.Contains("TownRosterScrollView") ||
                    result.gameObject.name.Contains("VehicleSlotScrollView"))
                {
                    if (HoveredOverPanel != null)
                    {
                        changeHoveredPanelColor();
                    }
                    if (IsDragging)
                    {
                        HoveredOverPanel = result.gameObject;
                        IsHoveringOverPanel = true;
                    }
                    break;
                }
            }
        }

        private void changeHoveredPanelColor()
        {
            Color color;

            if (IsHoveringOverPanel && IsDragging)
            {
                if (UiManager.CardIsAllowedToMoveHere(this.GetComponentInChildren<Image>(), HoveredOverPanel))
                {
                    color = new Color(88f / 255f, 121f / 255f, 214f / 255f, 0.5f);
                }
                else
                {
                    color = new Color(166f / 255f, 0f, 0f, 0.5f);
                }
            }
            else
            {
                color = new Color(0f, 0f, 0f, 0f);
            }

            HoveredOverPanel.gameObject.GetComponent<Image>().color = color;
        }
        #endregion
    }
}
