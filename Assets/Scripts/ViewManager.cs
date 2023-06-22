using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ViewManager : MonoBehaviour
{
    public static Texture chosenPic;

    public RawImage picture;

    private float scale;

    private void Start()
    {
        picture.texture = chosenPic;        
    }

    public void ReturnToGallery()
    {
        LoadingSceneManager.loadingSceneName = "Gallery";
        SceneManager.LoadScene("LoadScreen");
    }
}
