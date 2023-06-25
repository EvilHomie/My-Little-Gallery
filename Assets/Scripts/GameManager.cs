using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private static MenuLayerManager MenuLayerManagerScript; // ссылка на скрип меню (необходима для понимания активно ли меню)

    private void Awake()
    {
        DontDestroyOnLoad();

        if (GameObject.FindWithTag("MenuManager") != null)
        {
            MenuLayerManagerScript = GameObject.FindWithTag("MenuManager").GetComponent<MenuLayerManager>();
        }
    }
    void DontDestroyOnLoad()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        ChangeScreenOrientationMethod();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            NativeControll(SceneManager.GetActiveScene().name, MenuLayerManager.MenuIsActive);
        }
    }

    // метод по изменению ориентации экрана в зависимотси от сцены
    void ChangeScreenOrientationMethod()
    {
        if (SceneManager.GetActiveScene().name == "View")
            Screen.orientation = ScreenOrientation.AutoRotation;
        else { Screen.orientation = ScreenOrientation.Portrait; }
    }

    // метод для кнопки "открыть галлерею"
    public void OpenLoadScreen()
    {
        LoadingSceneManager.loadingSceneName = "Gallery";
        SceneManager.LoadScene("LoadScreen");
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
        if (sceneName == "View")
        {
            LoadingSceneManager.loadingSceneName = "Gallery";
            SceneManager.LoadScene("LoadScreen");
        }

        if (sceneName == "Gallery")
        {
            if (menuIsActive)
            {
                MenuLayerManagerScript.CloseMenu();
            }
            else { Application.Quit(); }
        }

        if (sceneName == "MainMenu")
        {
            Application.Quit();
        }
    }
}
