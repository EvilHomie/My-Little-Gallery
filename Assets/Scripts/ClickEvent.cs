using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickEvent : MonoBehaviour
{
    public Button clickArea; // ������������ ������� � ��������

    private void Awake()
    {
        clickArea.onClick.AddListener(OpenPicOnFullScreen); // ���������� �������� �������� �������� ������������
    }

    // ����� ������ ����� "��������" ����� ����� �������� � ��������� ������ ����� �������� ���� �������
    void OpenPicOnFullScreen()
    {
        if (transform.Find("Image").GetComponent<RawImage>().texture != null)
        {
            ViewManager.chosenPic = transform.Find("Image").GetComponent<RawImage>().texture;
            SceneManager.LoadScene("LoadScreen");
            GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>().PlayClickSound();
        }
    }
}
