using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PictureAtach : MonoBehaviour
{
    private string URL = "http://data.ikppbb.com/test-task-unity-data/pics/" + Picture—reator.counterImage + ".jpg";

    private void Awake()
    {
        StartCoroutine(LoadImage());
    }

    IEnumerator LoadImage()
    {
        UnityWebRequest request= UnityWebRequestTexture.GetTexture(URL);
        
        yield return request.SendWebRequest();
        

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
