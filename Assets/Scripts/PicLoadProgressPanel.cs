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
    }

    private void Update()
    {
        DownloadProgressCalc();
    }

    // метод по отслеживанию прогресса загрузки изображения и отображение состояния на ползунке
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
