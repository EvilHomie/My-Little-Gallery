using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gallery;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject loadingLayer;
    [SerializeField] private GameObject titleMenu;

    
    private void Update()
    {
        //ChangeScreenOrientationMethod();

        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    NativeControll(SceneManager.GetActiveScene().name, MenuLayerManager.MenuIsActive);
        //}
    }

    // метод по изменению ориентации экрана в зависимотси от сцены
    void ChangeScreenOrientationMethod()
    {
        if (SceneManager.GetActiveScene().name == "View")
        Screen.orientation = ScreenOrientation.AutoRotation;
        else { Screen.orientation = ScreenOrientation.Portrait; }
    }

    // метод для кнопки "открыть галлерею"
    public void OpenGallery()
    {
        titleMenu.SetActive(false);
        gallery.SetActive(true);
        loadingLayer.SetActive(true);

    }

    // метод для кнопки "Выйти" 
    public void Exite()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); 
#endif
    }

    // метод по отслеживанию нативных кнопок в устройстве и действия в зависимости от происходящего на экране
    void NativeControll(string sceneName, bool menuIsActive)
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

        }
            if (sceneName == "View")
        {
            //LoadingLayer.loadingSceneName = "Gallery";
            SceneManager.LoadScene("LoadScreen");
        }

        if (sceneName == "Gallery")
        {
            if (menuIsActive)
            {
                menu.GetComponent<MenuLayerManager>().CloseMenu();
            }
            else { Application.Quit(); }
        }

        if (sceneName == "MainMenu")
        {
            Application.Quit();
        }
    }
}
