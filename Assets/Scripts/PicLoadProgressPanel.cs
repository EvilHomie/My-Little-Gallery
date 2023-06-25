using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PicLoadProgressPanel : MonoBehaviour
{
    public GameObject loadingScreen; // ссылка на окно загрузки изображения
    public Slider loadBar; // ссылка на ползунок с прогрессом загрузки изображения
    private ImageDownloader imageDownloaderScript; // ссылка на скрипт где происходит загрузка и применение изображения

    private void Awake()
    {
        imageDownloaderScript = gameObject.GetComponent<ImageDownloader>();
        StartCoroutine(DownloadProgressCalc());
    }


    // метод по отслеживанию прогресса загрузки изображения и отображение состояния на ползунке
    IEnumerator DownloadProgressCalc()
    {    
        while(transform.Find("Image").GetComponent<RawImage>().texture == null)
        {
            yield return null;
            loadBar.value = imageDownloaderScript.DownloadProgress;
        }

        loadingScreen.SetActive(false);
        
    }
}
