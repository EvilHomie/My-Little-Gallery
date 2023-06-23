using System;
using UnityEngine;


public class DeviceAdaptation : MonoBehaviour
{
    private float uIScale; // коэфициент изменения интерфейса в зависимости от действительного разрешения
    private readonly float defResWidth = 1080f; // стандартая ширина экрана
    public static float PicSize { get; private set; } = 510f;  // стандартный размер картинки при разрешении  2160 х 1080 (размера объекта с картинкой + отступ)
    public static double HowManyPicsOnScreen { get; private set; } // кол-во картинок помещающихся на экране при старте
    private readonly int frameRate = 60; // значение частоты обновления приложения

    private void Awake()
    {
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
