using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

// в данном скрипте прописана логика вызова и возможностей меню
public class MenuLayer : MonoBehaviour
{
    public GameObject gameMenu; // ссылка на объект меню
    public Sprite[] volumeImage; // массив картинок для ползунка громкости
    public Slider volumeSlider; // ссылка на слайдер громкости
    public GameObject volumHandle; // ссылка на ползунок громкости
    private AudioSource audioSource; // сылка на источник аудио

    private void Start()
    {
        // нахождение объекта с источником
        audioSource = GameObject.FindWithTag("GameManager").GetComponent<AudioSource>();
    }
    private void Update()
    {
        // отслеживание состояния громкости и позунка
        audioSource.volume = volumeSlider.value ;
        ChangeVolumeHandle();
    }

    // метод визуального изменения ползунка громкости в зависимости от громкости
    private void ChangeVolumeHandle()
    {
        if (audioSource.volume == 0)
        {
            volumHandle.GetComponent<Image>().sprite = volumeImage[0];
        }

        else if (audioSource.volume > 0 & audioSource.volume <0.5f)
        {
            volumHandle.GetComponent<Image>().sprite = volumeImage[1];
        }

        else if (audioSource.volume > 0.5f & audioSource.volume < 1)
        {
            volumHandle.GetComponent<Image>().sprite = volumeImage[2];
        }

        else if (audioSource.volume == 1)
        {
            volumHandle.GetComponent<Image>().sprite = volumeImage[3];
        }
    }

    // метод выхода из приложения в зависимости от устройства
    public void Exite()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); 
#endif
    }

    // метод открытия меню
    public void OpenMenu()
    {
        gameMenu.SetActive(true);
    }

    // метод закрытия меню
    public void CloseMenu()
    {
        gameMenu.SetActive(false);
    }
}
