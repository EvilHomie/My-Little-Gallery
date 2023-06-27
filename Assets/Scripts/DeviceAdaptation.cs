using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DeviceAdaptation : MonoBehaviour
{
    [SerializeField] private GameObject content; // ссылка на объект спавна картинок
    private GridLayoutGroup contentGLG; // ссылка на область спавна
    private RectTransform contentRT; // ссылка на параметры размера и позиции области спавна

    public Vector2 ScreenCenter { get; private set; } // координаты центра экрана
    public int ImageCount { get; set; } = 0; // счетчик созданных картинок
    public int ColumnsAmount { get; private set; } // кол-во колонок
    public int RowsAmount { get; private set; } // кол-во строк
    public float BorderStep { get; private set; } // размер шага увеличения границы (равен сумме размера картинки и отступа)
    public float CellSize { get; private set; } // стандартный размер картинки 

    private const int frameRate = 60; // значение частоты обновления приложения
    public float UIScale { get; private set; } // коэфициент изменения интерсфейса в зависимости от дейстующего разрешения
    private float UIW; // ширина интерфейса
    private float UIH; // высота интерфейса

    private float curCellSize; // действительны размер картинки


    private readonly int preloadRowAmount = 1; // количество предзагруженных строк при старте игры

    private void Awake()
    {
        //получение ссылок на компоненты
        contentGLG = content.GetComponent<GridLayoutGroup>();
        contentRT = content.GetComponent<RectTransform>();

        Screen.orientation = ScreenOrientation.AutoRotation; // включение автоповорота экрана
        Application.targetFrameRate = frameRate; // лок фпс 

        GetStartPar();
    }

    private void Update()
    {
        BorderEqualRows();
    }

    void GetStartPar() // получение стартовых параметров
    {
        int startColumnsAmount; // кол-во стартовых колонок
        int startRowsAmount; // кол-во стартовых строк

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

    public IEnumerator UpdateGLG() // обновление параметров области спавна в зависимости 
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

    private void ColumRowsCounter() // калькулятор кол-ва строк и колонок
    {
        ColumnsAmount = (int)Math.Truncate(UIW / curCellSize);
        RowsAmount = (int)Math.Ceiling((float)ImageCount / ColumnsAmount);
    }

    private void CalcAndAplySpaceSize(float columAmout) // расчет зазоров между картинками и применение полученных данных
    {
        float totalFreeSpace = contentRT.sizeDelta.x % CellSize;
        float spacingAmount = columAmout + 1f;
        float spaceSize = totalFreeSpace / spacingAmount;

        BorderStep = CellSize + (int)Math.Round(spaceSize);

        contentGLG.spacing = new Vector2(spaceSize, spaceSize);
        contentGLG.padding.top = (int)Math.Round(spaceSize);
    }

    private void BorderEqualRows() // метод изменяющий размер области спавна в зависимости от кол-ва строк 
    {
        contentRT.sizeDelta = new Vector2(contentRT.sizeDelta.x, BorderStep * RowsAmount);
    }
}

