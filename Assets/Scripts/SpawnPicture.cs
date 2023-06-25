using UnityEngine;

public class SpawnPicture : MonoBehaviour
{
    public GameObject pictPrefab; // ����� ������� ��� ������ (� ����������)
    public GameObject content; // ������� ������ ��������
    private RectTransform contentAreaRT; // ������ �� ������� � ������� ������� ������ ��������

    public static int imageCurNum; // ����� ��������
    private const int imageMaxNum = 66; // ������������ ���-�� �������� (�� ����� �� ����������� ����� hhtp), ��� �� ������������� �������� ��� ������� ����������.
    private const int preloadPicNumber = 2; // ���-�� ��������������� �������� (�.�. �� ��������� ������ ����������)    
    private float borderForSpawnPic; // ������� ������� ����� ���� ������
    private const float defPicSize = 510;


    // ��������� ��������� ������ �� ���������� � ��������� ��������
    private void Start()
    {
        contentAreaRT = content.GetComponent<RectTransform>();

        imageCurNum = 1;
        StarterPics();
        borderForSpawnPic = contentAreaRT.position.y;
    }

    // ������������ ��������� ������� ���� ������ �������� 
    private void Update()
    {
        GreatMorePics();
    }

    // �������� ��������� �������� ( ������� ������� ���������� �� ������) + ���-�� ���������������
    private void StarterPics()
    {
        for (int i = 0; i < (DeviceAdaptation.HowManyPicsOnStart * 2 + preloadPicNumber); i++)
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
            borderForSpawnPic += DeviceAdaptation.PicSize;

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
        contentAreaRT.sizeDelta = new Vector2(contentAreaRT.sizeDelta.x, contentAreaRT.sizeDelta.y + defPicSize);
    }
}
