using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Piece : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
   
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetAsLastSibling();  //드래그 하고 있는걸 가장 위에 보이게 하자 -> sibling index조정
        //print("Begin:" +eventData);
        GetComponent<Image>().raycastTarget = false;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<Image>().raycastTarget = true;
    }
    public Vector3 screenPoint;
    public Vector3 worldPoint;
    public void OnDrag(PointerEventData eventData)
    {
        print("Drag" + eventData);
        transform.position = eventData.position; // overay일때 작동


        // screen space camera일때 사용.
        //screenPoint = eventData.position; // eventData.position : ScreenPosition

        //worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);
        //worldPoint.z = 0;
        //transform.position = worldPoint;
    }
}
