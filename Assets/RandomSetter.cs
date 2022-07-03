using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSetter : MonoBehaviour
{
    public Image[] allChildImage;
    [ContextMenu("�̹��� ������ ��ġ�� ��ġ")]
    void SetRandomPosition()
    {
        allChildImage = transform.GetComponentsInChildren<Image>();
         
        foreach(var image in allChildImage)
        {
            if (image.transform == transform)
                continue;

            image.transform.position = new Vector3(
                Random.Range(0, Camera.main.pixelWidth), // x
                Random.Range(0, Camera.main.pixelHeight), // y
                0
                ); 
        }
    }
}
