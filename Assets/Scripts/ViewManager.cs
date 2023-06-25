using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ViewManager : MonoBehaviour
{
    public static Texture chosenPic; // ��������� ��� �������� ������� ������� ��� ���������

    public GameObject picture; // ������ �� ������ ��� ����� �����������

    private Vector2 picSize; // ������ �������� �������� ������ � ������ ������������ ����������


    private void Start()
    {
        picSize = new Vector2(Screen.width, Screen.width) / (float)DeviceAdaptation.ScaleUI; // ���������� ������� ��� ��������

        picture.GetComponent<RawImage>().texture = chosenPic; // ���������� ����������� � �������

        picture.GetComponent<RectTransform>().sizeDelta = picSize; // ���������� �������
    }


    // ����� ��� ������ "��������� � ��������"
    public void ReturnToGallery()
    {
        LoadingSceneManager.loadingSceneName = "Gallery";
        SceneManager.LoadScene("LoadScreen");
    }
}
