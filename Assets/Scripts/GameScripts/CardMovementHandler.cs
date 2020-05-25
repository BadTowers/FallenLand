using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardMovementHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerClickHandler, IPointerExitHandler
{
    private bool IsDragging;
    private bool IsClicked;
    private const float ZoomedScale = 2.5f;
    private Vector2 ImageSize = new Vector2(75, 100);
    private Vector3 PreHoverLocation = new Vector3(-1, -1, -1);
    private float PreHoverScrollSensitivity;

    void Start()
    {
        PreHoverScrollSensitivity = GameObject.Find("AuctionHouseScrollView").GetComponent<ScrollRect>().scrollSensitivity;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("Dragging");
            if (!IsDragging && !IsClicked)
            {
                PreHoverLocation = transform.position;
            }
            IsDragging = true;
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
            transform.position = PreHoverLocation;
            enableScroll();
            transform.SetAsFirstSibling(); //move to the back (on parent)
            IsDragging = false;
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
        transform.position = new Vector3(newX, newY, transform.position.z);
        disableScroll();
        transform.SetAsLastSibling(); //move to the front (on parent)
    }

    private float getNewX()
    {
        float newX = transform.position.x;
        if (transform.position.x < 268)
        {
            newX = 268;
        }
        else if (transform.position.x > 729)
        {
            newX = 729;
        }
        return newX;
    }

    private float getNewY()
    {
        float newY = transform.position.y;
        if (transform.position.y > 360)
        {
            newY = 360;
        }
        else if (transform.position.y < 205)
        {
            newY = 205;
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
}
