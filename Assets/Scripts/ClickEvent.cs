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
    private bool onFullScreen = false;
    private bool translateDone = false;
    private Vector2 defPos;
    private Vector2 posInCentre;
    private float animSpeed = 1f;

    private float scaleOnFullScreen = 2.2f;

    private void OnEnable()
    {
        
        PicClickArea.onClick.AddListener(Clicked); // добавление свойства делающее картинку кликабельной
        parentForView = GameObject.FindWithTag("Viewport");
        deffParent = transform.parent.gameObject;
        posInCentre = DeviceAdaptation.ScreenCenter;



    }
    private void Update()
    {
        DefPosTracking();
    }


    // метод вызова сцены "ѕросморт" через сцену загрузки с передачей данных кака€ картинка была выбрана
    void Clicked()
    {
        if ((gameObject.GetComponent<RawImage>().texture != null) & !onFullScreen)
        {            
            StartCoroutine(TransformToCenter());
        }
        else if ((gameObject.GetComponent<RawImage>().texture != null) & onFullScreen)
        {
            StartCoroutine(ReturnFromCenter());
        }
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
            ReScaleImage(Math.Abs(LerpTCalc(startDistance, defPos) -1));
            yield return null;
        }

        ChangeParent(deffParent.transform, 0);
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
        } else { translateDone = false; }
    }


    void ReScaleImage(float t)
    {
        Vector3 defScale = new (1,1,1);
        Vector3 fullScreenScale = defScale * scaleOnFullScreen;

        gameObject.transform.localScale = Vector3.Lerp(defScale, fullScreenScale, t);

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
