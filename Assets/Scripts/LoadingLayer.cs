using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingLayer : MonoBehaviour
{
    [SerializeField] private Slider loadBar; // ползунок загрузки
    [SerializeField] private TextMeshProUGUI loadProgressText; // текст с процентами загрузки
    private GameObject[] picArray;
    public List<bool> downloadIsDone;

    private void OnEnable()
    {
        picArray = GameObject.FindGameObjectsWithTag("Picture");
        StartCoroutine(CallcMethod());
    }


    // метод отслеживающий фактическое состояние готовности сцены (проверка все ли начальные картинки загружены)
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
