using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadManager : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider loadBar;
    public TextMeshProUGUI loadProgressText;

    private GameObject[] pics;
    private float averageprogress = 0;

    private void Start()
    {
        pics = GameObject.FindGameObjectsWithTag("Pic");
    }

    private void Update()
    {
        DownloadProgressCalc();
        MenuDisabler();
    }

    void DownloadProgressCalc()
    {
        float progressSumm = 0;

        for (int i = 0; i < pics.Length; i++)
        {
            progressSumm += pics[i].GetComponent<PictureImageAtach>().downloadProgress;
        }

        averageprogress = progressSumm / pics.Length;
        loadBar.value = averageprogress;

        loadProgressText.text = $"{Math.Truncate(progressSumm / pics.Length * 100)}";
        Debug.Log(averageprogress);
    }

    void MenuDisabler()
    {
        if (averageprogress >= 1)
        {
            loadingScreen.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
