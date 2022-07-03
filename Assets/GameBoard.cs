using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBoard : MonoBehaviour
{
    static public GameBoard instance;
    private void Awake(){instance = this; }
    private void OnDestroy() { instance = null; }
    //private void OnDestroy() => instance = null;

    public int score;
    public int MaxCount = 12;
    public Text scoreText;
    public GameObject stageClearUIgo;
    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
        if(score == MaxCount)
        {
            stageClearUIgo.SetActive(true);
        }
    }

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
            images[i].sprite = resultSprite[i];// sprites[i];
            images[i].name = resultSprite[i].name;
        }
    }


    public Texture2D targetImage;
    public int xCount = 2;
    public int yCount = 3;

    //public Rect rect;
    public List<Sprite> resultSprite;
    public int width;
    public int height;

    public Transform backPanel;
    public Transform movePanel;
    [ContextMenu("이미지 생성")]
    void CreateSprite()
    {
        resultSprite.Clear();
        width = targetImage.width / xCount;
        height = targetImage.height / yCount;
        for (int y = 0; y < yCount; y++)
        {
            for (int x = 0; x < xCount; x++)
            {
                Rect rect = new Rect();
                rect.x = x * width;
                rect.y = y * height;
                rect.width = width;
                rect.height = height;
                var sprite = Sprite.Create(targetImage, rect, new Vector2(0.5f, 0.5f));
                sprite.name = $"Y:{x}, Y:{y}";
                resultSprite.Add(sprite);
            }
        }

        // image게임 오브젝트생성.
        DestroyChild(backPanel);
        DestroyChild(movePanel);

        //backPanel//  이미지 게임오브젝트생성, SnapPiece
        //movePanel//  이미지 게임오브젝트생성, Piece
        CreateImage(backPanel, resultSprite, typeof(SnapPiece));
        CreateImage(movePanel, resultSprite, typeof(Piece));

        backPanel.GetComponent<GridLayoutGroup>().constraintCount = xCount;
        movePanel.GetComponent<RandomSetter>().SetRandomPosition();

        var pieces = movePanel.GetComponentsInChildren<Piece>();
        foreach(var item in pieces)
        {
            var animator = item.gameObject.AddComponent<Animator>();
            animator.runtimeAnimatorController = controller;
            item.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
        }   
    }
    public RuntimeAnimatorController controller;

    private void CreateImage(Transform parentPanel, List<Sprite> resultSprite, Type type)
    {
        int index = 0;
        for (int y = 0; y < yCount; y++)
        {
            for (int x = 0; x < xCount; x++)
            {
                GameObject newGo = new GameObject();
                newGo.name = $"Y:{x}, Y:{y}";
                newGo.transform.SetParent(parentPanel);
                newGo.transform.localScale = new Vector3(1, 1, 1); // new Vector3(1, 1, 1)== Vector3.one;

                Image Image = newGo.AddComponent<Image>();
                newGo.AddComponent(type);
                Image.sprite = resultSprite[index++];
            }
        }
    }

    private void DestroyChild(Transform parentTr)
    {
        var childs = parentTr.GetComponentsInChildren<Transform>();
        foreach(var item in childs)
        {
            if (item == parentTr)
                continue;

            if(Application.isPlaying)
                Destroy(item.gameObject);
            else
                DestroyImmediate(item.gameObject, true);
        }
    }
}
