using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingLayer : MonoBehaviour
{
    [SerializeField] private Slider loadBar; // �������� ��������
    [SerializeField] private TextMeshProUGUI loadProgressText; // ����� � ���������� ��������
    private GameObject[] picArray;
    public List<bool> downloadIsDoneForAll;

    private void OnEnable()
    {
        picArray = GameObject.FindGameObjectsWithTag("Picture");

        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            loadBar.gameObject.SetActive(false);
            transform.Find("Start Error").gameObject.SetActive(true);
        }
        else { StartCoroutine(CallcMethod()); }
    }


    // ����� ������������� ����������� ��������� ���������� ����� (�������� ��� �� ��������� �������� ���������)
    IEnumerator CallcMethod()
    {
        while (downloadIsDoneForAll.Count != picArray.Length)
        {
            PicsDownloadProgress();
            yield return null;
        }
        gameObject.SetActive(false);
        yield break;
    }

    void PicsDownloadProgress()
    {
        float everageDownload = 0;
        float downloadProgressSumm = 0;
        downloadIsDoneForAll.Clear();

        foreach (GameObject pic in picArray)
        {
            downloadProgressSumm += pic.GetComponent<ImageDownloader>().DownloadProgress;
            everageDownload = downloadProgressSumm / picArray.Length;

            if(pic.GetComponent<ImageDownloader>().ErrorDownloading)
            {
                downloadIsDoneForAll.Add(true);
            }
            
            if(pic.transform.Find("Image").GetComponent<RawImage>().texture != null)
            {
                downloadIsDoneForAll.Add(true);
            }
        }
        loadBar.value = everageDownload;
        loadProgressText.text = $"{Math.Round(everageDownload * 100)}%";
    }
}
