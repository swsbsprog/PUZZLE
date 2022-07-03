using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SnapPiece : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData data)
    {
        if (data.pointerDrag != null)
        {
            Debug.Log("Dropped object was: " + data.pointerDrag);
            data.pointerDrag.transform.position = transform.position;

            // 제대로된 위치에 드랍 되었다면 번쩍이게 하자
            if(IsRightPosition(data.pointerDrag))
            {
                SetBlink(data.pointerDrag);
            }
        }
    }

    private bool IsRightPosition(GameObject pointerDrag)
    {
        return pointerDrag.name == name;
    }

    private void SetBlink(GameObject pointerDrag)
    {
        // 방식1, 코루틴으로
        StartCoroutine(SetBlinkCo(pointerDrag));    // 함수로 실행하는 방식 <- 추천
        //StartCoroutine("SetBlinkCo", pointerDrag);  // 이름으로 실행하는 방식

        // 방식2, 애니메이터
    }

    private IEnumerator SetBlinkCo(GameObject pointerDrag)
    {
        pointerDrag.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        pointerDrag.GetComponent<Image>().color = Color.white;
    }
}
