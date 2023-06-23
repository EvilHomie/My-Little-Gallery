using System;
using UnityEngine;


public class DeviceAdaptation : MonoBehaviour
{
    private float uIScale; // ���������� ��������� ���������� � ����������� �� ��������������� ����������
    private float defResWidth = 1080f; // ���������� ������ ������
    public static float picSize { get; private set; } = 510f;  // ����������� ������ �������� ��� ����������  2160 � 1080 (������� ������� � ��������� + ������)
    public static double picNumberOnScreen { get; private set; } // ���-�� �������� ������������ �� ������ ��� ������

    private void Start()
    {
        DeviceAddaptation();
    }
    // ��������� �������� � ����������� �� ���������� ������
    private void DeviceAddaptation()
    {
        uIScale = Screen.width / defResWidth;
        picSize *= uIScale;

        picNumberOnScreen = Math.Truncate(Screen.height / picSize);
    }    
}
