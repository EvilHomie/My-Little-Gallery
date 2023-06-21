using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GalleryManager : MonoBehaviour
{
    public void OpenLoadScreen()
    {
        LoadingScene.loadingSceneName = "View";
        SceneManager.LoadScene("LoadScreen");
    }
}
