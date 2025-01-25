using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DradAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    
    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;

    public void OnBeginDrag(PointerEventData eventData)
    {
        rectTransform = GetComponent<RectTransform>(); 
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();  

        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0.6f; 
            canvasGroup.blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 1f; 
            canvasGroup.blocksRaycasts = true; 
        }
    }
}



