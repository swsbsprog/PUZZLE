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
            images[i].sprite = sprites[i];
        }
    }


    public Texture2D targetImage;
    public int xCount = 2;
    public int yCount = 3;

    //public Rect rect;
    public List<Sprite> resultSprite;
    public int width;
    public int height;
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
                resultSprite.Add(Sprite.Create(targetImage, rect, new Vector2(0.5f, 0.5f)));
            }
        }
    }
}
