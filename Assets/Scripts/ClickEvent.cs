using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickEvent : MonoBehaviour
{
    public Button clickArea; // кликабельна€ область у картинки

    private void Awake()
    {
        clickArea.onClick.AddListener(OpenPicOnFullScreen); // добавление свойства делающее картинку кликабельной
    }

    // метод вызова сцены "ѕросморт" через сцену загрузки с передачей данных кака€ картинка была выбрана
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
