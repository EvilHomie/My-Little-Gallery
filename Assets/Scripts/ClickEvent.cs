using System;
using System.Collections;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class ClickEvent : MonoBehaviour
{
    [SerializeField] private Button PicClickArea; // кликабельна€ область у картинки
    private GameObject parentForView;
    private GameObject deffParent;
    private GridLayoutGroup contentGLG;
    private bool onFullScreen = false;
    private bool translateDone = false;
    private Vector2 defPos;
    private Vector2 posInCentre;
    private readonly float animSpeed = 1f;

    private float scaleOnFullScreen;
    private double UIScale;
    private float UIW;
    private float UIH;

    private void OnEnable()
    {
        //Screen.orientation = ScreenOrientation.AutoRotation;

        PicClickArea.onClick.AddListener(Clicked); // добавление свойства делающее картинку кликабельной
        parentForView = GameObject.FindWithTag("Viewport");
        deffParent = transform.parent.gameObject;
        //posInCentre = DeviceAdaptation.ScreenCenter;
        contentGLG = GameObject.FindWithTag("Content").GetComponent<GridLayoutGroup>();

        scaleOnFullScreen = Screen.width / contentGLG.cellSize.x;

        GridLayoutGroupAdaptation();

        //Debug.Log("Enabled");

    }
    private void Update()
    {
        DefPosTracking();
    }

    void GridLayoutGroupAdaptation()
    {
        UIW = Screen.width;
        UIH = Screen.height;

        UIScale = Math.Sqrt((UIW / 1080f) * (UIH / 2160));



    }


    // метод вызова сцены "ѕросморт" через сцену загрузки с передачей данных кака€ картинка была выбрана
    void Clicked()
    {
        Debug.Log("Click");
        //if ((gameObject.GetComponent<RawImage>().texture != null) & !onFullScreen)
        //{
        //    StartCoroutine(TransformToCenter());
        //}
        //else if ((gameObject.GetComponent<RawImage>().texture != null) & onFullScreen)
        //{
        //    StartCoroutine(ReturnFromCenter());
        //}
    }

    IEnumerator TransformToCenter()
    {
        translateDone = false;
        float startDistance = Vector2.Distance(transform.position, posInCentre);
        ChangeParent(parentForView.transform, 1);

        while (!translateDone)
        {
            Translate(transform.position, posInCentre);
            ReScaleImage(LerpTCalc(startDistance, posInCentre));
            yield return null;
        }
        Screen.orientation = ScreenOrientation.AutoRotation;
        onFullScreen = true;
        yield break;
    }

    IEnumerator ReturnFromCenter()
    {
        translateDone = false;
        float startDistance = Vector2.Distance(transform.position, defPos);

        while (!translateDone)
        {
            Translate(transform.position, defPos);
            ReScaleImage(Math.Abs(LerpTCalc(startDistance, defPos) - 1));
            yield return null;
        }

        ChangeParent(deffParent.transform, 0);
        Screen.orientation = ScreenOrientation.Portrait;
        onFullScreen = false;
        yield break;
    }

    void DefPosTracking()
    {
        defPos = deffParent.transform.position;
    }

    void Translate(Vector2 from, Vector2 to)
    {
        transform.position = Vector2.MoveTowards(from, to, animSpeed);

        if (from == to)
        {
            translateDone = true;
        }
        else { translateDone = false; }
    }


    void ReScaleImage(float t)
    {
        Vector3 defScale = new(1, 1, 1);
        Vector3 fullScreenScale = defScale * scaleOnFullScreen;

        gameObject.transform.localScale = Vector3.Lerp(defScale, fullScreenScale, t);

        //Vector2 defSize = gameObject.GetComponent<RectTransform>().sizeDelta;
        //Vector2 maxSize = new(Screen.width * 0.5f, Screen.width * 0.5f);
        //gameObject.GetComponent<RectTransform>().sizeDelta = Vector2.Lerp(defSize, maxSize, t);

    }

    void ChangeParent(Transform newParent, int indexInParent)
    {
        transform.SetParent(newParent);
        transform.SetSiblingIndex(indexInParent);
    }

    float LerpTCalc(float startDistance, Vector2 endPoint)
    {

        float curentDistance = Vector2.Distance(transform.position, endPoint);
        float lerpT = Math.Abs(curentDistance / startDistance - 1);
        Debug.Log(lerpT);
        return lerpT;
    }
}
