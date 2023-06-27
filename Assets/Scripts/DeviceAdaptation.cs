using System;
using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class DeviceAdaptation : MonoBehaviour
{
    [SerializeField] private GameObject content; // ссылка на область спавна картинок
    private GridLayoutGroup contentGLG;
    private RectTransform contentRT;

    public static Vector2 ScreenCenter { get; private set; }
    public int ImageCount { get; set; } = 0;

    public int ColumnsAmount { get; private set; }
    public int RowsAmount { get; private set; }
    public float BorderStep { get; private set; }

    private const int frameRate = 60; // значение частоты обновления приложения
    public float UIScale { get; private set; }
    private float UIW;
    private float UIH;
    private float cellSize;
    private float curCellSize;


    private readonly int preloadRowAmount = 1;

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;
        //Application.targetFrameRate = frameRate;
        contentGLG = content.GetComponent<GridLayoutGroup>();
        contentRT = content.GetComponent<RectTransform>();

        ScreenCenter = new Vector2(Screen.width / 2, Screen.height / 2);

        GetStartPar();
                
    }

    private void Update()
    {
        BorderEqualRows();
    }

    void GetStartPar()
    {
        int startColumnsAmount;
        int startRowsAmount;

        UIW = Screen.width;
        UIH = Screen.height;
        UIScale = (float)Math.Sqrt((UIW / 1080f) * (UIH / 2160));
        cellSize = contentGLG.cellSize.x;
        curCellSize = cellSize * UIScale;
        contentRT.sizeDelta = new Vector2(UIW / UIScale, contentRT.sizeDelta.y);

        startColumnsAmount = (int)Math.Truncate(UIW / curCellSize);
        startRowsAmount = (int)Math.Truncate(UIH / curCellSize);

        ColumnsAmount = startColumnsAmount;
        RowsAmount = startRowsAmount + preloadRowAmount;

        CalcAndAplySpaceSize(ColumnsAmount);
    }

    public IEnumerator UpdateGLG()
    {
        
        yield return new WaitForEndOfFrame();
        UIW = Screen.width;
        UIH = Screen.height;

        ColumRowsCounter();

        contentRT.sizeDelta = new Vector2(UIW / UIScale, BorderStep * RowsAmount);
        CalcAndAplySpaceSize(ColumnsAmount);
        StartCoroutine(UpdateGLG());
    }

    private void ColumRowsCounter()
    {
        ColumnsAmount = (int)Math.Truncate(UIW / curCellSize);
        RowsAmount = (int)Math.Ceiling((float)ImageCount / ColumnsAmount);
    }

    private void CalcAndAplySpaceSize(float columAmout)
    {
        float totalFreeSpace = contentRT.sizeDelta.x % cellSize;
        float spacingAmount = columAmout + 1f;
        float spaceSize = totalFreeSpace / spacingAmount;

        BorderStep = cellSize + (int)Math.Round(spaceSize);

        contentGLG.spacing = new Vector2(spaceSize, spaceSize);
        contentGLG.padding.top = (int)Math.Round(spaceSize);
    }

    private void BorderEqualRows()
    {
        contentRT.sizeDelta = new Vector2(contentRT.sizeDelta.x, BorderStep * RowsAmount);
    }
}

