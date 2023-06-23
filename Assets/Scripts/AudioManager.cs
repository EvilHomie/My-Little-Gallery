using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip clickSound;
    private AudioSource audioSource;

    [SerializeField] private Sprite[] volumeImage; // массив картинок для ползунка громкости
    [SerializeField] private Slider volumeSlider; // ссылка на слайдер громкости
    [SerializeField] private GameObject volumHandle; // ссылка на ползунок громкости

    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        volumeSlider.value = audioSource.volume;
    }

    private void Update()
    {
        // отслеживание состояния громкости и ползунка
        audioSource.volume = volumeSlider.value;
        ChangeVolumeHandle(audioSource.volume);
    }
    public void PlayClickSound()
    {
        audioSource.PlayOneShot(clickSound);
    }

    // метод визуального изменения ползунка громкости в зависимости от громкости
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





