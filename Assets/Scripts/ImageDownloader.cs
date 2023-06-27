using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageDownloader : MonoBehaviour
{
    [SerializeField] private GameObject errorLayer;
    [SerializeField] private Button errorClickArea;

    // URL картинки в момент создания объекта
    private string URL = "http://data.ikppbb.com/test-task-unity-data/pics/" + SpawnPicture.ImageCurNum + ".jpg";

    public float DownloadProgress { get; private set; } // прогресс загрузки картинки
    public bool ErrorDownloading { get; private set; } = false;

    private void Awake()
    {
        // вызов корутины при создании объекта
        StartCoroutine(LoadImage());
    }

    // метод загрузки и применения картинки к объекту
    IEnumerator LoadImage()
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(URL);
        request.SendWebRequest();

        while (!request.isDone)
        {
            DownloadProgress = request.downloadProgress;
            yield return null;
        }

        if (request.result != UnityWebRequest.Result.Success)
        {
            errorLayer.SetActive(true);
            ErrorDownloading = true;
            errorClickArea.onClick.AddListener(RestartLoading);
        }
        else
        {
            Texture texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            transform.Find("Image").GetComponent<RawImage>().texture = texture;
            transform.Find("Image").GetComponent<RawImage>().color = Color.white;
            errorClickArea.onClick.RemoveAllListeners();
        }
        yield break;
    }

    // метод по перезапуску корутины в случае ошибки загрузки
    public void RestartLoading()
    {        
        errorClickArea.onClick.RemoveAllListeners();
        StartCoroutine(LoadImage());
        errorLayer.SetActive(false);
    }
}
