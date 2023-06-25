using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PicLoadProgressPanel : MonoBehaviour
{
    public GameObject loadingScreen; // ������ �� ���� �������� �����������
    public Slider loadBar; // ������ �� �������� � ���������� �������� �����������
    private ImageDownloader imageDownloaderScript; // ������ �� ������ ��� ���������� �������� � ���������� �����������

    private void Awake()
    {
        imageDownloaderScript = gameObject.GetComponent<ImageDownloader>();
        StartCoroutine(DownloadProgressCalc());
    }


    // ����� �� ������������ ��������� �������� ����������� � ����������� ��������� �� ��������
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
