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

            // ����ε� ��ġ�� ��� �Ǿ��ٸ� ��½�̰� ����
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
        // ���1, �ڷ�ƾ����
        StartCoroutine(SetBlinkCo(pointerDrag));    // �Լ��� �����ϴ� ��� <- ��õ
        //StartCoroutine("SetBlinkCo", pointerDrag);  // �̸����� �����ϴ� ���

        // ���2, �ִϸ�����
    }

    private IEnumerator SetBlinkCo(GameObject pointerDrag)
    {
        pointerDrag.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        pointerDrag.GetComponent<Image>().color = Color.white;
    }
}
