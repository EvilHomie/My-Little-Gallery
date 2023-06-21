using System;
using UnityEngine;

public class SpawnPicture : MonoBehaviour
{
    public GameObject pictPrefab; // ����� ������� ��� ������ (� ����������)
    public GameObject content; // ������� ������ ��������
    private RectTransform contentAreaRT; // ������ �� ������� � ������� ������� ������ ��������

    public static int imageCurNum = 1; // ��������� ����� ��������
    private int imageMaxNum = 66; // ������������ ���-�� �������� (�� ����� �� ����������� ����� hhtp), ��� �� ������������� �������� ��� ������� ����������.

    private int preloadPicNumber = 2; // ���-�� ��������������� �������� (�.�. �� ��������� ������ ����������)
    private float picSize = 510f; // ����������� ������ �������� ��� ����������  2160 � 1080 (������� ������� � ��������� + ������)
    private float borderForSpawnPic; // ������� ������� ����� ���� ������
    private float uIScale; // ���������� ��������� ���������� � ����������� �� ��������������� ����������
    private float defResWidth = 1080f; // ���������� ������ ������

    // ��������� ��������� ������ �� ���������� � ��������� ��������
    private void Start()
    {
        contentAreaRT = content.GetComponent<RectTransform>();

        borderForSpawnPic = contentAreaRT.position.y;

        DeviceAddaptation();
        StarterPics();
    }

    // ������������ ��������� ������� ���� ������ �������� 
    private void Update()
    {
        GreatMorePics();
    }

    // ��������� �������� � ����������� �� ���������� ������
    private void DeviceAddaptation()
    {
        uIScale = Screen.width / defResWidth;
        picSize *= uIScale;
    }

    // �������� ��������� �������� ( ������� ������� ���������� �� ������) + ���-�� ���������������
    private void StarterPics()
    {
        double picNumber = Math.Truncate(Screen.height / picSize);

        for (int i = 0; i < (picNumber * 2 + preloadPicNumber); i++)
        {
            GreatPic();
        }
    }

    // �������� �������������� �������� ���� ���� ������ ���������� ���������� � �� ���������� ������������ ����� ��������
    private void GreatMorePics()
    {
        if (contentAreaRT.position.y > borderForSpawnPic & imageCurNum <= imageMaxNum)
        {
            GreatPic();
            GreatPic();
            borderForSpawnPic += picSize;
            
        }
    }

    //����� ������ �������� � ���������� ������� ������� ������ ���� ���� ������� � ��������� ������� ( � ������ ������� ���-�� �������� = 2)
    private void GreatPic()
    {
        Instantiate(pictPrefab, content.transform);
        imageCurNum++;

        if (imageCurNum % 2 == 0)
        {
            ResizeContentArea();
        }
    }

    // ����� ���������� ������� ������
    private void ResizeContentArea()
    {
        contentAreaRT.sizeDelta = new Vector2(contentAreaRT.sizeDelta.x, contentAreaRT.sizeDelta.y + picSize);
    }
}
