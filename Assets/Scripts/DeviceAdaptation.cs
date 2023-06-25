using System;
using UnityEngine;


public class DeviceAdaptation : MonoBehaviour
{
    public static float UIScaleWidth { get; private set; } // ���������� ��������� ���������� �� ������
    public static float UIScaleHeight { get; private set; } // ���������� ��������� ���������� �� ������
    public static double ScaleUI { get; private set; } // ���������� ��������� ���������� �������
    public static float PicSize { get; private set; } = 510f;  // ����������� ������ �������� ��� ����������  2160 � 1080 (������� ������� � ��������� + ������)
    public static double HowManyPicsOnStart { get; private set; } // ���-�� �������� ������������ �� ������ ��� ������

    private const float defResWidth = 1080f; // ���������� ������ ������
    private const float defResHeight = 2160f; // ���������� ������ ������


    private readonly int frameRate = 60; // �������� ������� ���������� ����������

    private void Awake()
    {
        Application.targetFrameRate = frameRate;
        DeviceAddaptation();
    }

    // ��������� �������� � ����������� �� ���������� ������
    private void DeviceAddaptation()
    {
        UIScaleWidth = Screen.width / defResWidth;
        UIScaleHeight = Screen.height / defResHeight;
        ScaleUI = Math.Sqrt(UIScaleHeight * UIScaleWidth);

        PicSize *= UIScaleWidth;

        HowManyPicsOnStart = Math.Truncate(Screen.height / PicSize);
    }
}
