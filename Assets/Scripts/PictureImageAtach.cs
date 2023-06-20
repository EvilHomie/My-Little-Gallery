using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PictureImageAtach : MonoBehaviour
{
    private string URL = "http://data.ikppbb.com/test-task-unity-data/pics/" + Picture—reator.counterImage + ".jpg";

    public float downloadProgress { get; private set; }

    private void Awake()
    {
        StartCoroutine(LoadImage());
    }

    IEnumerator LoadImage()
    {
        UnityWebRequest request= UnityWebRequestTexture.GetTexture(URL);
        request.SendWebRequest();

        while (!request.isDone)
        {
            //Debug.Log("Progress: " + request.downloadProgress * 100f + "%");
            downloadProgress = request.downloadProgress;
            yield return null;
        }



        if (request.result == UnityWebRequest.Result.ConnectionError ||
            request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            Texture texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            gameObject.GetComponent<RawImage>().texture = texture;
        }
    }


}
