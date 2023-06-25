using System;
using UnityEngine;


public class DeviceAdaptation : MonoBehaviour
{
    public static float UIScaleWidth { get; private set; } // коэфициент изменения интерфейса по ширине
    public static float UIScaleHeight { get; private set; } // коэфициент изменения интерфейса по высоте
    public static double ScaleUI { get; private set; } // коэфициент изменения интерфейса средний
    public static float PicSize { get; private set; } = 510f;  // стандартный размер картинки при разрешении  2160 х 1080 (размера объекта с картинкой + отступ)
    public static double HowManyPicsOnStart { get; private set; } // кол-во картинок помещающихся на экране при старте

    private const float defResWidth = 1080f; // стандартая ширина экрана
    private const float defResHeight = 2160f; // стандартая высота экрана


    private readonly int frameRate = 60; // значение частоты обновления приложения

    private void Awake()
    {
        Application.targetFrameRate = frameRate;
        DeviceAddaptation();
    }

    // адаптация размеров в зависимости от разрешения экрана
    private void DeviceAddaptation()
    {
        UIScaleWidth = Screen.width / defResWidth;
        UIScaleHeight = Screen.height / defResHeight;
        ScaleUI = Math.Sqrt(UIScaleHeight * UIScaleWidth);

        PicSize *= UIScaleWidth;

        HowManyPicsOnStart = Math.Truncate(Screen.height / PicSize);
    }
}
