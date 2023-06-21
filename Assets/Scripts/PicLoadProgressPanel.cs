using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PicLoadProgressPanel : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider loadBar;
    public TextMeshProUGUI loadProgressText;
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

            loadProgressText.text = $"{Math.Truncate(imageDownloaderScript.DownloadProgress * 100)}";
        }
        else
        {
            loadingScreen.SetActive(false);
        }
    }
}
