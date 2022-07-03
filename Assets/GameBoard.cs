using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBoard : MonoBehaviour
{
    //public int publicInt =1;
    //private int privateInt = 2;

    //[SerializeField]
    //private int SerializeFieldPrivateInt = 3;

    //[HideInInspector]
    //public int hideInInspectorPublicInt = 4;


    [SerializeField]
    private Sprite[] sprites;
    public Image[] images;

    [ContextMenu("이미지 배치")]   
    void SetImage()
    {
        print("SetImage");
        for (int i = 0; i < sprites.Length; i++)
        {
            images[i].sprite = sprites[i];
        }
    }
}
