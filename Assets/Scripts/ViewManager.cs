using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ViewManager : MonoBehaviour
{
    public static Texture chosenPic; // контейнер для картинки которая выбрана для просмотра

    public RawImage picture; // ссылка на объект где будет изображение

    private void Start()
    {
        picture.texture = chosenPic; // применение изображение к объекту       
    }

    // метод для кнопки "вернуться в галлерею"
    public void ReturnToGallery()
    {
        LoadingSceneManager.loadingSceneName = "Gallery";
        SceneManager.LoadScene("LoadScreen");
    }
}
