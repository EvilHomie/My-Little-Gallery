using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ViewManager : MonoBehaviour
{
    public static Texture chosenPic; // контейнер для картинки которая выбрана для просмотра

    public GameObject picture; // ссылка на объект где будет изображение

    private Vector2 picSize; // размер картинки согласно экрану с учетом скалирования интерфейса


    private void Start()
    {
        picSize = new Vector2(Screen.width, Screen.width) / (float)DeviceAdaptation.ScaleUI; // вычесление размера для картинки

        picture.GetComponent<RawImage>().texture = chosenPic; // применение изображение к объекту

        picture.GetComponent<RectTransform>().sizeDelta = picSize; // применение размера
    }


    // метод для кнопки "вернуться в галлерею"
    public void ReturnToGallery()
    {
        LoadingSceneManager.loadingSceneName = "Gallery";
        SceneManager.LoadScene("LoadScreen");
    }
}
