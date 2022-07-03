using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Piece : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
   
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetAsLastSibling();  //�巡�� �ϰ� �ִ°� ���� ���� ���̰� ���� -> sibling index����
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
        transform.position = eventData.position; // overay�϶� �۵�


        // screen space camera�϶� ���.
        //screenPoint = eventData.position; // eventData.position : ScreenPosition

        //worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);
        //worldPoint.z = 0;
        //transform.position = worldPoint;
    }
}
