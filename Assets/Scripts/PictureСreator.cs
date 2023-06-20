using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PictureСreator : MonoBehaviour
{
    public GameObject pictPrefab;
    public GameObject content;
    private RectTransform contentAreaSize;
    public RectTransform UIScale;

    public static int counterImage = 1;
    private double initialPicNumber;
    private int preloadPicNumber = 3;
    private float picPlaceSize = 510; // for Height 2160
    private float greatBorder = 2160;
    private bool startPicLoaded = false;

    private void Start()
    {
        picPlaceSize *= UIScale.localScale.y;
        initialPicNumber = Math.Truncate(Screen.height / picPlaceSize);

        contentAreaSize = content.GetComponent<RectTransform>();  
        
        StartPic();
    }
    void Update()
    {        
        if (contentAreaSize.position.y > greatBorder)
        {
            CreatePic();
            CreatePic();
            greatBorder += 510;
            Debug.Log(greatBorder);
        }
    }

    void StartPic()
    {
        for (int i = 1; i < (initialPicNumber * 2 + preloadPicNumber); i++)
        {
            CreatePic();
        }
        startPicLoaded = true;
    }


    void CreatePic()
    {
        Instantiate(pictPrefab, content.transform);
        counterImage++;

        if (counterImage % 2 == 0)
        {
            ChangeSizeContentArea();
        }        
    }

    void ChangeSizeContentArea ()
    {
            contentAreaSize.sizeDelta = new Vector2(contentAreaSize.sizeDelta.x, contentAreaSize.sizeDelta.y + 510f);       
    }
}
