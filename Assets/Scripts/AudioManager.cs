using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip clickSound;
    private AudioSource audioSource;

    [SerializeField] private Sprite[] volumeImage; // ������ �������� ��� �������� ���������
    [SerializeField] private Slider volumeSlider; // ������ �� ������� ���������
    [SerializeField] private GameObject volumHandle; // ������ �� �������� ���������

    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        volumeSlider.value = audioSource.volume;
    }

    private void Update()
    {
        // ������������ ��������� ��������� � ��������
        audioSource.volume = volumeSlider.value;
        ChangeVolumeHandle(audioSource.volume);
    }
    public void PlayClickSound()
    {
        audioSource.PlayOneShot(clickSound);
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
}





