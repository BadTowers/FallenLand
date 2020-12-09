using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FallenLand
{
    public class CardClickHandler : MonoBehaviour, IPointerClickHandler, IPointerExitHandler
    {
        private bool IsClicked;
        private float PreHoverScrollSensitivity;
        private const float ZoomedScale = 2.5f;
        private Vector2 ImageSize = new Vector2(75, 100);
        private Vector3 PreClickLocation = new Vector3(-1, -1, -1);
        private GameObject HoveredOverPanel;
        private GameUIManager UiManager;
        private int SiblingOrder;
        private CardMovementHandler MovementHandler;

        void Start()
        {
            PreHoverScrollSensitivity = GameObject.Find("AuctionHouseScrollView").GetComponent<ScrollRect>().scrollSensitivity;
            UiManager = GameObject.Find("UIManager").GetComponentInChildren<GameUIManager>();
            MovementHandler = gameObject.transform.GetComponentInParent<CardMovementHandler>();
        }

        void Update()
        {
        }

        public bool GetIsClicked()
        {
            return IsClicked;
        }

        public Vector3 GetPreClickLocation()
        {
            return PreClickLocation;
        }
        
        public void OnPointerExit(PointerEventData eventData)
        {
            if (!MovementHandler.GetIsDragging() && IsClicked)
            {
                makeSmall();
                IsClicked = false;
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            //if (eventData.button == PointerEventData.InputButton.Left)
            //{
            //    Debug.Log("Mouse click");
            //    Debug.Log(transform.localPosition);
            //    if (!MovementHandler.GetIsDragging())
            //    {
            //        if (!IsClicked)
            //        {
            //            IsClicked = true;
            //            PreClickLocation = transform.position;
            //            makeLarge();
            //        }
            //        else
            //        {
            //            makeSmall();
            //            IsClicked = false;
            //        }
            //    }
            //}
        }

        #region HelperFunctions
        private void makeSmall()
        {
            this.GetComponentInParent<Image>().rectTransform.sizeDelta = new Vector2(ImageSize.x, ImageSize.y);
            transform.position = PreClickLocation;
            transform.SetSiblingIndex(SiblingOrder);
        }

        private void makeLarge()
        {
            this.GetComponentInParent<Image>().rectTransform.sizeDelta = new Vector2(ImageSize.x * ZoomedScale, ImageSize.y * ZoomedScale);
            float newX = getNewX();
            float newY = getNewY();
            transform.localPosition = new Vector3(newX, newY, transform.localPosition.z);
            SiblingOrder = transform.GetSiblingIndex();
            transform.SetAsLastSibling(); //move to the front (on parent)
        }

        private float getNewX()
        {
            float newX = transform.localPosition.x;
            if (transform.localPosition.x < 140)
            {
                newX = 140;
            }
            else if (transform.localPosition.x > 405)
            {
                newX = 405;
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
        #endregion
    }
}
