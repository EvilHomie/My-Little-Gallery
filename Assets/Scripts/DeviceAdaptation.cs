using System;
using UnityEngine;


public class DeviceAdaptation : MonoBehaviour
{
    private float uIScale; // коэфициент изменения интерфейса в зависимости от действительного разрешения
    private float defResWidth = 1080f; // стандартая ширина экрана
    public static float picSize { get; private set; } = 510f;  // стандартный размер картинки при разрешении  2160 х 1080 (размера объекта с картинкой + отступ)
    public static double picNumberOnScreen { get; private set; } // кол-во картинок помещающихся на экране при старте

    private void Start()
    {
        DeviceAddaptation();
    }
    // адаптация размеров в зависимости от разрешения экрана
    private void DeviceAddaptation()
    {
        uIScale = Screen.width / defResWidth;
        picSize *= uIScale;

        picNumberOnScreen = Math.Truncate(Screen.height / picSize);
    }    
}
