using FallenLand;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FallenLand
{
    public class CardMovementHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerClickHandler, IPointerExitHandler
    {
        private bool IsDragging;
        private bool IsClicked;
        private bool IsOldParentSet;
        private bool IsHoveringOverPanel;
        private const float ZoomedScale = 2.5f;
        private Vector2 ImageSize = new Vector2(75, 100);
        private Vector3 PreHoverLocation = new Vector3(-1, -1, -1);
        private float PreHoverScrollSensitivity;
        private GameObject OldParent;
        private GameObject HoveredOverPanel;
        private GameUIManager UiManager;

        void Start()
        {
            PreHoverScrollSensitivity = GameObject.Find("AuctionHouseScrollView").GetComponent<ScrollRect>().scrollSensitivity;

            UiManager = GameObject.Find("UIManager").GetComponentInChildren<GameUIManager>();
        }

        void Update()
        {
            checkIfWeAreHoveredOverPanel();
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                Debug.Log("Dragging");
                if (!IsDragging && !IsClicked)
                {
                    PreHoverLocation = transform.position;
                    UiManager.SetCardIsDragging(true);
                }
                IsDragging = true;
                figureOutCurrentParent();
                setNewTemporaryParent();
                Canvas myCanvas = this.GetComponentInParent<Canvas>();
                RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out Vector2 pos);
                transform.position = myCanvas.transform.TransformPoint(pos);
                this.GetComponentInParent<Image>().rectTransform.sizeDelta = new Vector2(ImageSize.x, ImageSize.y);
                disableScroll();
                transform.SetAsLastSibling(); //move to the front (on parent)
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                Debug.Log("Dropped");
                UiManager.SetCardIsDragging(false);
                IsDragging = false;
                Image cardImage = this.GetComponentInParent<Image>();
                if (HoveredOverPanel != null && UiManager.CardIsAllowedToMoveHere(cardImage, HoveredOverPanel))
                {
                    Transform viewportTransform = HoveredOverPanel.transform.Find("Viewport");
                    if (viewportTransform != null)
                    {
                        Debug.Log("Dropped on scroll");
                        cardImage.rectTransform.SetParent(viewportTransform.transform.Find("Content").gameObject.transform);
                        UiManager.UpdateAfterCardWasMoved(cardImage, HoveredOverPanel);
                    }
                    else
                    {
                        cardImage.rectTransform.SetParent(HoveredOverPanel.transform);
                        UiManager.UpdateAfterCardWasMoved(cardImage, HoveredOverPanel);
                    }
                }
                else
                {
                    resetParent();
                    transform.position = PreHoverLocation;
                }
                enableScroll();
                transform.SetAsFirstSibling(); //move to the back (on parent)
                OldParent = null;
                IsOldParentSet = false;
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Debug.Log("Mouse stopped hovering");
            if (!IsDragging && IsClicked)
            {
                makeSmall();
                IsClicked = false;
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                Debug.Log("Mouse click");
                Debug.Log(transform.localPosition);
                if (!IsDragging)
                {
                    if (!IsClicked)
                    {
                        IsClicked = true;
                        PreHoverLocation = transform.position;
                        makeLarge();
                    }
                    else
                    {
                        makeSmall();
                        IsClicked = false;
                    }
                }
            }
        }

        #region HelperFunctions
        private void makeSmall()
        {
            this.GetComponentInParent<Image>().rectTransform.sizeDelta = new Vector2(ImageSize.x, ImageSize.y);
            transform.position = PreHoverLocation;
            enableScroll();
            transform.SetAsFirstSibling(); //move to the back (on parent)
        }

        private void makeLarge()
        {
            this.GetComponentInParent<Image>().rectTransform.sizeDelta = new Vector2(ImageSize.x * ZoomedScale, ImageSize.y * ZoomedScale);
            float newX = getNewX();
            float newY = getNewY();
            transform.localPosition = new Vector3(newX, newY, transform.localPosition.z);
            disableScroll();
            transform.SetAsLastSibling(); //move to the front (on parent)
        }

        private float getNewX()
        {
            float newX = transform.localPosition.x;
            if (transform.localPosition.x < 140)
            {
                newX = 140;
            }
            else if (transform.localPosition.x > 385)
            {
                newX = 385;
            }
            return newX;
        }

        private float getNewY()
        {
            float newY = transform.localPosition.y;
            if (transform.localPosition.y > -90)
            {
                newY = -90;
            }
            else if (transform.localPosition.y < -170)
            {
                newY = -170;
            }
            return newY;
        }

        private void disableScroll()
        {
            Debug.Log("disabled scrolling");
            GameObject.Find("AuctionHouseScrollView").GetComponent<ScrollRect>().scrollSensitivity = 0;
        }

        private void enableScroll()
        {
            Debug.Log("enabled scrolling");
            GameObject.Find("AuctionHouseScrollView").GetComponent<ScrollRect>().scrollSensitivity = PreHoverScrollSensitivity;
        }

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
        }

        private void checkIfWeAreHoveredOverPanel()
        {
            findPanelOfInterest();

            if (HoveredOverPanel != null)
            {
                changeHoveredPanelColor(HoveredOverPanel.name);
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
                if (result.gameObject.name.Contains("CharacterPanel") || result.gameObject.name.Contains("AuctionHouseScrollView") || result.gameObject.name.Contains("TownRosterScrollView"))
                {
                    if (HoveredOverPanel != null)
                    {
                        changeHoveredPanelColor(HoveredOverPanel.name);
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

        private void changeHoveredPanelColor(string name)
        {
            Color color;

            if (IsHoveringOverPanel && UiManager.CardIsAllowedToMoveHere(this.GetComponentInChildren<Image>(), HoveredOverPanel))
            {
                color = new Color(88f / 255f, 121f / 255f, 214f / 255f, 1f);
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
