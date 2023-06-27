using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DeviceAdaptation : MonoBehaviour
{
    [SerializeField] private GameObject content; // ������ �� ������ ������ ��������
    private GridLayoutGroup contentGLG; // ������ �� ������� ������
    private RectTransform contentRT; // ������ �� ��������� ������� � ������� ������� ������

    public Vector2 ScreenCenter { get; private set; } // ���������� ������ ������
    public int ImageCount { get; set; } = 0; // ������� ��������� ��������
    public int ColumnsAmount { get; private set; } // ���-�� �������
    public int RowsAmount { get; private set; } // ���-�� �����
    public float BorderStep { get; private set; } // ������ ���� ���������� ������� (����� ����� ������� �������� � �������)
    public float CellSize { get; private set; } // ����������� ������ �������� 

    private const int frameRate = 60; // �������� ������� ���������� ����������
    public float UIScale { get; private set; } // ���������� ��������� ����������� � ����������� �� ����������� ����������
    private float UIW; // ������ ����������
    private float UIH; // ������ ����������

    private float curCellSize; // ������������� ������ ��������


    private readonly int preloadRowAmount = 1; // ���������� ��������������� ����� ��� ������ ����

    private void Awake()
    {
        //��������� ������ �� ����������
        contentGLG = content.GetComponent<GridLayoutGroup>();
        contentRT = content.GetComponent<RectTransform>();

        Screen.orientation = ScreenOrientation.AutoRotation; // ��������� ������������ ������
        Application.targetFrameRate = frameRate; // ��� ��� 

        GetStartPar();
    }

    private void Update()
    {
        BorderEqualRows();
    }

    void GetStartPar() // ��������� ��������� ����������
    {
        int startColumnsAmount; // ���-�� ��������� �������
        int startRowsAmount; // ���-�� ��������� �����

        UIW = Screen.width;
        UIH = Screen.height;
        UIScale = (float)Math.Sqrt((UIW / 1080f) * (UIH / 2160));
        CellSize = contentGLG.cellSize.x;
        curCellSize = CellSize * UIScale;
        contentRT.sizeDelta = new Vector2(UIW / UIScale, contentRT.sizeDelta.y);

        startColumnsAmount = (int)Math.Truncate(UIW / curCellSize);
        startRowsAmount = (int)Math.Truncate(UIH / curCellSize);

        ColumnsAmount = startColumnsAmount;
        RowsAmount = startRowsAmount + preloadRowAmount;

        CalcAndAplySpaceSize(ColumnsAmount);
    }

    public IEnumerator UpdateGLG() // ���������� ���������� ������� ������ � ����������� 
    {

        yield return new WaitForEndOfFrame();

        UIW = Screen.width;
        UIH = Screen.height;
        ScreenCenter = new Vector2(UIW / 2, UIH / 2);

        ColumRowsCounter();

        contentRT.sizeDelta = new Vector2(UIW / UIScale, BorderStep * RowsAmount);
        CalcAndAplySpaceSize(ColumnsAmount);
        StartCoroutine(UpdateGLG());
    }

    private void ColumRowsCounter() // ����������� ���-�� ����� � �������
    {
        ColumnsAmount = (int)Math.Truncate(UIW / curCellSize);
        RowsAmount = (int)Math.Ceiling((float)ImageCount / ColumnsAmount);
    }

    private void CalcAndAplySpaceSize(float columAmout) // ������ ������� ����� ���������� � ���������� ���������� ������
    {
        float totalFreeSpace = contentRT.sizeDelta.x % CellSize;
        float spacingAmount = columAmout + 1f;
        float spaceSize = totalFreeSpace / spacingAmount;

        BorderStep = CellSize + (int)Math.Round(spaceSize);

        contentGLG.spacing = new Vector2(spaceSize, spaceSize);
        contentGLG.padding.top = (int)Math.Round(spaceSize);
    }

    private void BorderEqualRows() // ����� ���������� ������ ������� ������ � ����������� �� ���-�� ����� 
    {
        contentRT.sizeDelta = new Vector2(contentRT.sizeDelta.x, BorderStep * RowsAmount);
    }
}

