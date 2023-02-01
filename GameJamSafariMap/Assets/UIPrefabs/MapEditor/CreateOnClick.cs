using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateOnClick : MonoBehaviour, IPointerDownHandler
{
    
    private RectTransform RectTransform;

    private void Awake()
    {
        RectTransform = GetComponent<RectTransform>();
    }
    public GameObject Copy;
    public void OnPointerDown(PointerEventData evenData)
    {
        Debug.Log($"Copied");
        GameObject copy=Instantiate(Copy,transform.position,Quaternion.identity);

        copy.GetComponent<DragDrop>().RectTransform.anchoredPosition = RectTransform.anchoredPosition+new Vector2(960,540);
        copy.GetComponent<DragDrop>().RectTransform.anchorMin = RectTransform.anchorMin;
        copy.GetComponent<DragDrop>().RectTransform.anchorMax = RectTransform.anchorMax;
        copy.GetComponent<DragDrop>().RectTransform.sizeDelta = RectTransform.sizeDelta;
        copy.GetComponent<DragDrop>().RectTransform.pivot = RectTransform.pivot;


        GameObject canvas =  GameObject.Find("Canvas");
        copy.transform.SetParent(canvas.transform);
    }
}
