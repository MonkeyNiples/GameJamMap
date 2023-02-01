using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour,IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public RectTransform RectTransform;
    [SerializeField] private Canvas canvas; 
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        RectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnPointerDown(PointerEventData evenData)
    {
        Debug.Log($"Clicked on {gameObject}!");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log($"Begin draggin on {gameObject}!");
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;


    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log($"draggin on {gameObject}!");
        RectTransform.anchoredPosition += eventData.delta/canvas.scaleFactor;

    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log($"End draggin on {gameObject}!");
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1;

    }
    public void OndDrop(PointerEventData eventDate)
    {

    }
}
