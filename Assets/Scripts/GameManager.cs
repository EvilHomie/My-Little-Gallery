using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    

    private void Start()
    {
        DontDestroyOnLoad();
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
    }

    void ChangeScreenOrientationMethod()
    {
        if (SceneManager.GetActiveScene().name == "View")
        Screen.orientation = ScreenOrientation.AutoRotation;
        else { Screen.orientation = ScreenOrientation.Portrait; }
    }

    public void OpenLoadScreen()
    {
        LoadingSceneManager.loadingSceneName = "Gallery";
        SceneManager.LoadScene("LoadScreen");
    }

    public void Exite()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); 
#endif
    }

    
}
