using UnityEngine;

public class SpawnPicture : MonoBehaviour
{
    public GameObject pictPrefab; // ����� ������� ��� ������ (� ����������)
    public GameObject content; // ������� ������ ��������
    private RectTransform contentAreaRT; // ������ �� ������� � ������� ������� ������ ��������

    public static int imageCurNum; // ����� ��������
    private int imageMaxNum = 66; // ������������ ���-�� �������� (�� ����� �� ����������� ����� hhtp), ��� �� ������������� �������� ��� ������� ����������.
    private int preloadPicNumber = 2; // ���-�� ��������������� �������� (�.�. �� ��������� ������ ����������)    
    private float borderForSpawnPic; // ������� ������� ����� ���� ������
    

    // ��������� ��������� ������ �� ���������� � ��������� ��������
    private void Awake()
    {
        contentAreaRT = content.GetComponent<RectTransform>();

        borderForSpawnPic = contentAreaRT.position.y;

        imageCurNum = 1;

        StarterPics();
    }

    // ������������ ��������� ������� ���� ������ �������� 
    private void Update()
    {
        GreatMorePics();        
    }

    

    // �������� ��������� �������� ( ������� ������� ���������� �� ������) + ���-�� ���������������
    private void StarterPics()
    {
        for (int i = 0; i < (DeviceAdaptation.picNumberOnScreen * 2 + preloadPicNumber); i++)
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
            borderForSpawnPic += DeviceAdaptation.picSize;
            
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
        contentAreaRT.sizeDelta = new Vector2(contentAreaRT.sizeDelta.x, contentAreaRT.sizeDelta.y + DeviceAdaptation.picSize);
    }
}
