using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickEvent : MonoBehaviour
{
    public Button clickArea;

    private void Awake()
    {
        clickArea.onClick.AddListener(loadViewScene);
    }

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
