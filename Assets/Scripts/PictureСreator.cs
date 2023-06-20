using System;
using UnityEngine;

public class PictureСreator : MonoBehaviour
{
    public GameObject pictPrefab;
    public GameObject content;
    private RectTransform contentAreaRT;

    public static int counterImage = 1;

    private int preloadPicNumber = 4;
    private float picDefPlaceSize = 510f; // for Height 2160
    private float borderForSpawnPic;
    private float uIScale;
    private float defResWidth = 1080f;

    private void Start()
    {
        contentAreaRT = content.GetComponent<RectTransform>();

        DeviceAddaptation();

        borderForSpawnPic = contentAreaRT.position.y;

        CreateMorePic();
        StartPic();
    }
    void Update()
    {
        GreatMorePics();
    }

    void GreatMorePics()
    {
        if (contentAreaRT.position.y > borderForSpawnPic)
        {
            CreateMorePic();
            CreateMorePic();
            borderForSpawnPic += picDefPlaceSize;
            Debug.Log(borderForSpawnPic);
        }
    }
    void DeviceAddaptation()
    {
        uIScale = Screen.width / defResWidth;
        picDefPlaceSize *= uIScale;
    }

    void StartPic()
    {
        double picNumber = Math.Truncate(Screen.height / picDefPlaceSize);
        Debug.Log(picNumber);

        for (int i = 1; i < (picNumber * 2 + preloadPicNumber); i++)
        {
            CreateMorePic();
        }
    }


    void CreateMorePic()
    {
        Instantiate(pictPrefab, content.transform);
        counterImage++;

        if (counterImage % 2 == 0)
        {
            ChangeSizeContentArea();
        }
    }

    void ChangeSizeContentArea()
    {
        contentAreaRT.sizeDelta = new Vector2(contentAreaRT.sizeDelta.x, contentAreaRT.sizeDelta.y + picDefPlaceSize);
    }
}
