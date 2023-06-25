using System;
using UnityEngine;


public class DeviceAdaptation : MonoBehaviour
{
    public static float PicSize { get; private set; } = 510f;  // ����������� ������ �������� ��� ����������  2160 � 1080 (������� ������� � ��������� + ������)
    public static double HowManyPicsOnScreen { get; private set; } // ���-�� �������� ������������ �� ������ ��� ������
    public static Vector2 ScreenCenter { get; private set; }


    private float uIScale; // ���������� ��������� ���������� � ����������� �� ��������������� ����������
    private const float defResWidth = 1080f; // ���������� ������ ������
    private const int frameRate = 60; // �������� ������� ���������� ����������



    private void Awake()
    {
        ScreenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        //Application.targetFrameRate = frameRate;
        DeviceAddaptation();
    }
    // ��������� �������� � ����������� �� ���������� ������
    private void DeviceAddaptation()
    {
        uIScale = Screen.width / defResWidth;
        PicSize *= uIScale;

        HowManyPicsOnScreen = Math.Truncate(Screen.height / PicSize);
    }
}
