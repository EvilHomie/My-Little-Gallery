using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

// � ������ ������� ��������� ������ ������ � ������������ ����
public class MenuLayerManager : MonoBehaviour
{
    public GameObject gameMenu; // ������ �� ������ ����
    public Sprite[] volumeImage; // ������ �������� ��� �������� ���������
    public Slider volumeSlider; // ������ �� ������� ���������
    public GameObject volumHandle; // ������ �� �������� ���������
    private AudioSource audioSource; // ����� �� �������� �����

    public static bool menuIsActive { get; private set; }

    private void Start()
    {
        // ���������� ������� � ����������
        audioSource = GameObject.FindWithTag("GameManager").GetComponent<AudioSource>();
        volumeSlider.value = audioSource.volume;
    }
    private void Update()
    {
        // ������������ ��������� ��������� � ��������
        audioSource.volume = volumeSlider.value ;
        ChangeVolumeHandle(audioSource.volume);
    }

    // ����� ����������� ��������� �������� ��������� � ����������� �� ���������
    private void ChangeVolumeHandle(float volume)
    {
        switch (volume)
        {
            case 0:
                volumHandle.GetComponent<Image>().sprite = volumeImage[0];
                break;

            case > 0 and < 0.5f:
                volumHandle.GetComponent<Image>().sprite = volumeImage[1];
                break;

            case > 0.5f and < 1:
                volumHandle.GetComponent<Image>().sprite = volumeImage[2];
                break;

            case 1:
                volumHandle.GetComponent<Image>().sprite = volumeImage[3];
                break;
        }
    }

    // ����� ������ �� ���������� � ����������� �� ����������
    public void Exite()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); 
#endif
    }

    // ����� �������� ����
    public void OpenMenu()
    {
        gameMenu.SetActive(true);
        menuIsActive = true;
    }

    // ����� �������� ����
    public void CloseMenu()
    {
        gameMenu.SetActive(false);
        menuIsActive = false;
    }
}
