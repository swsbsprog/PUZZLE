using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseTest : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        //print("Begin:" +eventData);
    }

    public Vector3 screenPoint;
    public Vector3 worldPoint;
    public void OnDrag(PointerEventData eventData)
    {
        print("Drag" + eventData);
        //transform.position = eventData.position; // overay일때 작동


        // screen space camera일때 사용.
        //screenPoint = eventData.position; // eventData.position : ScreenPosition

        //worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);
        //worldPoint.z = 0;
        //transform.position = worldPoint;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //print("End" + eventData);
    }
}
