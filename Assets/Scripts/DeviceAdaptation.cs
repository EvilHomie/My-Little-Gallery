using System;
using UnityEngine;


public class DeviceAdaptation : MonoBehaviour
{
    private float uIScale; // ���������� ��������� ���������� � ����������� �� ��������������� ����������
    private readonly float defResWidth = 1080f; // ���������� ������ ������
    public static float PicSize { get; private set; } = 510f;  // ����������� ������ �������� ��� ����������  2160 � 1080 (������� ������� � ��������� + ������)
    public static double HowManyPicsOnScreen { get; private set; } // ���-�� �������� ������������ �� ������ ��� ������
    private readonly int frameRate = 60; // �������� ������� ���������� ����������

    private void Awake()
    {
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
