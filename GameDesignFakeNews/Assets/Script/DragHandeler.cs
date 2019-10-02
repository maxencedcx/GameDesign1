using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandeler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    public static GameObject itemBeingDragged;
    Vector3 startPosition;
    Transform startParent;
    private bool isBig;

    #region IBeginDragHandler implementation

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    #endregion

    #region IDragHandler implementation

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    #endregion

    #region IEndDragHandler implementation

    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDragged = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (transform.parent == startParent)
        {
            transform.position = startPosition;
        }
    }

    #endregion

    #region IPointerClick implementation
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && isBig == false)
        {
            transform.localScale += new Vector3(1.1F, 1.1f, 1.1f);
            isBig = true;
        }
        else if (eventData.button == PointerEventData.InputButton.Right && isBig == true)
        {
            transform.localScale = new Vector3(1, 1, 1);
            isBig = false;
        }
    }
    #endregion
}
