using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageDownloader : MonoBehaviour
{
    // URL картинки в момент создания объекта
    private string URL = "http://data.ikppbb.com/test-task-unity-data/pics/" + SpawnPicture.imageCurNum + ".jpg";

    public float DownloadProgress { get; private set; } // прогресс загрузки картинки

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
            //Debug.Log("Progress: " + request.downloadProgress * 100f + "%");
            DownloadProgress = request.downloadProgress;
            yield return null;
        }

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(request.error);
            StartCoroutine(LoadImage());
        }
        else
        {
            Texture texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            transform.Find("Image").GetComponent<RawImage>().texture = texture;
            transform.Find("Image").GetComponent<RawImage>().color= Color.white;
        }

        yield break;
    }
}
