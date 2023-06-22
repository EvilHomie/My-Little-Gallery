using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PicLoadProgressPanel : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider loadBar;
    private ImageDownloader imageDownloaderScript;

    

    private void Awake()
    {
        imageDownloaderScript = gameObject.GetComponent<ImageDownloader>();
    }

    private void Update()
    {
        DownloadProgressCalc();
    }

    private void DownloadProgressCalc()
    {    
        if (transform.Find("Image").GetComponent<RawImage>().texture == null)
        {
            loadBar.value = imageDownloaderScript.DownloadProgress;
        }
        else
        {
            loadingScreen.SetActive(false);
        }
    }
}
