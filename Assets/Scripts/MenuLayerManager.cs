using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

// в данном скрипте прописана логика вызова и возможностей меню
public class MenuLayerManager : MonoBehaviour
{
    public GameObject gameMenu; // ссылка на объект меню
    public Sprite[] volumeImage; // массив картинок для ползунка громкости
    public Slider volumeSlider; // ссылка на слайдер громкости
    public GameObject volumHandle; // ссылка на ползунок громкости
    private AudioSource audioSource; // сылка на источник аудио

    public static bool menuIsActive { get; private set; }

    private void Start()
    {
        // нахождение объекта с источником
        audioSource = GameObject.FindWithTag("GameManager").GetComponent<AudioSource>();
        volumeSlider.value = audioSource.volume;
    }
    private void Update()
    {
        // отслеживание состояния громкости и ползунка
        audioSource.volume = volumeSlider.value ;
        ChangeVolumeHandle(audioSource.volume);
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
        menuIsActive = true;
    }

    // метод закрытия меню
    public void CloseMenu()
    {
        gameMenu.SetActive(false);
        menuIsActive = false;
    }
}
