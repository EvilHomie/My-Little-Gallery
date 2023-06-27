using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class GridLayoutGroupAdaptation : MonoBehaviour
{
    private GridLayoutGroup gLG;

    private double UIScale;
    private float UIW;
    private float UIH;

    private float cellSize;
    private double cellNumberW;
    private double cellNumberH;

    private float freeSpace;
    private float spaceSize;

    private void Start()
    {
        gLG = gameObject.GetComponent<GridLayoutGroup>();
        GetParam();
        SetParam();
    }   
    void GetParam()
    {
        UIW = Screen.width;
        UIH = Screen.height;
        UIScale = Math.Sqrt((UIW / 1080f) * (UIH / 2160));

        cellSize = gLG.cellSize.x * (float)UIScale;
        cellNumberW = Math.Truncate(UIW / cellSize);
        cellNumberH = Math.Truncate(UIH / cellSize);

        freeSpace = UIW % cellSize / (float)UIScale;   
        spaceSize = freeSpace / (float)cellNumberW + 1;
    }
    void SetParam()
    {
        gLG.spacing = new Vector2(spaceSize, spaceSize);
        gLG.padding.top = (int)Math.Round(spaceSize);
    }
}
