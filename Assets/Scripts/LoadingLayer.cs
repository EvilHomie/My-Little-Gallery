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
    public List<bool> downloadIsDone;

    private void OnEnable()
    {
        picArray = GameObject.FindGameObjectsWithTag("Picture");
        StartCoroutine(CallcMethod());
    }


    // ����� ������������� ����������� ��������� ���������� ����� (�������� ��� �� ��������� �������� ���������)
    IEnumerator CallcMethod()
    {
        while (downloadIsDone.Count != picArray.Length)
        {
            StartPicsDownloadProgress();
            yield return null;
        }
        gameObject.SetActive(false);
        yield break;
    }

    void StartPicsDownloadProgress()
    {
        float everageDownload = 0;
        float downloadProgressSumm = 0;
        downloadIsDone.Clear();

        foreach (GameObject pic in picArray)
        {
            downloadProgressSumm += pic.GetComponent<ImageDownloader>().DownloadProgress;
            everageDownload = downloadProgressSumm / picArray.Length;
            
            if(pic.transform.Find("Image").GetComponent<RawImage>().texture != null)
            {
                downloadIsDone.Add(true);
            }
        }
        loadBar.value = everageDownload;
        loadProgressText.text = $"{Math.Round(everageDownload * 100)}%";
    }
}
