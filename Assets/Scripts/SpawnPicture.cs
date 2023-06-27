using System;
using UnityEngine;

public class SpawnPicture : MonoBehaviour
{
    [SerializeField] private DeviceAdaptation dAScript;
    [SerializeField] private GameObject pictPrefab; // ����� ������� ��� ������ (� ����������)
    [SerializeField] private GameObject content; // ������� ������ ��������

    private RectTransform contentRT;

    public static int ImageCurNum { get; private set; } = 0;// ����� ��������
    private readonly int imageMaxNum = 66; // ������������ ���-�� �������� (�� ����� �� ����������� ����� hhtp), ��� �� ������������� �������� ��� ������� ����������.

    // ��������� ��������� ������ �� ���������� � ��������� ��������
    private void OnEnable()
    {
        contentRT = content.GetComponent<RectTransform>();
        
        StarterPics();
    }

    // ������������ ��������� ������� ���� ������ �������� 
    private void Update()
    {
        GreatMorePics();

        if (ImageCurNum % dAScript.ColumnsAmount != 0)
        {
            GreatPic(1);
        }        
    }

    // �������� ��������� �������� ( ������� ������� ���������� �� ������) + ���-�� ���������������
    private void StarterPics()
    {
        GreatPic(dAScript.RowsAmount * dAScript.ColumnsAmount);
        StartCoroutine(dAScript.UpdateGLG());
    }

    // �������� �������������� �������� ���� ���� ������ ���������� ���������� � �� ���������� ������������ ����� ��������
    private void GreatMorePics()
    {
        float contentSize = dAScript.BorderStep * dAScript.RowsAmount * (float)dAScript.UIScale;

        if ((contentSize - contentRT.position.y)  < dAScript.BorderStep * (float)dAScript.UIScale & ImageCurNum <= imageMaxNum)
        {            
            GreatPic(dAScript.ColumnsAmount);
        }
    }

    //����� ������ �������� � ���������� ������� ������� ������ ���� ���� ������� � ��������� ������� ( � ������ ������� ���-�� �������� = 2)
    private void GreatPic(int number)
    {
        for (int i = 0; i < number & ImageCurNum != imageMaxNum; i++)
        {
            ImageCurNum++;
            Instantiate(pictPrefab, content.transform);
            dAScript.ImageCount++;
        }
    }
}
