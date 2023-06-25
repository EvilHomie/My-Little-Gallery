using System;
using UnityEngine;


public class DeviceAdaptation : MonoBehaviour
{
    public static float PicSize { get; private set; } = 510f;  // стандартный размер картинки при разрешении  2160 х 1080 (размера объекта с картинкой + отступ)
    public static double HowManyPicsOnScreen { get; private set; } // кол-во картинок помещающихся на экране при старте
    public static Vector2 ScreenCenter { get; private set; }


    private float uIScale; // коэфициент изменения интерфейса в зависимости от действительного разрешения
    private const float defResWidth = 1080f; // стандартая ширина экрана
    private const int frameRate = 60; // значение частоты обновления приложения



    private void Awake()
    {
        ScreenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        //Application.targetFrameRate = frameRate;
        DeviceAddaptation();
    }
    // адаптация размеров в зависимости от разрешения экрана
    private void DeviceAddaptation()
    {
        uIScale = Screen.width / defResWidth;
        PicSize *= uIScale;

        HowManyPicsOnScreen = Math.Truncate(Screen.height / PicSize);
    }
}
