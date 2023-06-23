using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickEvent : MonoBehaviour
{
    public Button clickArea; // кликабельна€ область у картинки

    private void Awake()
    {
        clickArea.onClick.AddListener(loadViewScene); // добавление свойства делающее картинку кликабельной
    }

    // метод вызова сцены "ѕросморт" через сцену загрузки с передачей данных кака€ картинка была выбрана
    void loadViewScene()
    {
        if (transform.Find("Image").GetComponent<RawImage>().texture != null)
        {
            LoadingSceneManager.loadingSceneName = "View";
            ViewManager.chosenPic = transform.Find("Image").GetComponent<RawImage>().texture;
            SceneManager.LoadScene("LoadScreen");
            GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>().ClickSound();
        }
    }
}
