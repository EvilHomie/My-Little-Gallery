using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ClickEvent : MonoBehaviour
{
    [SerializeField] private Button PicClickArea; // кликабельная область у картинки
    private DeviceAdaptation dAScript; // ссылка на скрип с данными об устройстве
    private GameObject parentForView; // объект в котором будет происходить обзор
    private GameObject deffParent; // объект в которм находится картинка по умолчанию
    private bool onFullScreen = false; // развернута ли картнка
    private bool translateDone = true; // завершен ли процесс разворачивания для просмотра
    private Vector2 defPos; // начальная позиция картинки
    private readonly float animSpeed = 20; // скорость с которой происходит разворачивание и сворачивание картинки

    private float scaleOnFullScreen; // коэфициент умножения при разворачивании

    private void OnEnable()
    {
        //получение ссылок на объекты
        dAScript = GameObject.FindWithTag("GameManager").GetComponent<DeviceAdaptation>();
        parentForView = GameObject.FindWithTag("Viewport");

        PicClickArea.onClick.AddListener(Clicked); // добавление свойства делающее картинку кликабельной        
        deffParent = transform.parent.gameObject; // присваивание начальной позиции
    }
    private void Update()
    {
        ScaleFullScreenCalc();
        DefPosTracking();
    }

    void ScaleFullScreenCalc() // изменение scaleOnFullScreen в зависимости от ориентации устройства
    {
        if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
        {
            scaleOnFullScreen = Screen.width / dAScript.CellSize / dAScript.UIScale;
        }
        else { scaleOnFullScreen = Screen.height / dAScript.CellSize / dAScript.UIScale; }
    }

    void Clicked() // что происходит при клике 
    {
        // запуск метода разворота картинки на весь экран
        if ((gameObject.GetComponent<RawImage>().texture != null) & !onFullScreen)
        {
            StartCoroutine(TransformToCenter());
        }
        // запуск метода возвращения картинки к начальному состоянию
        else if ((gameObject.GetComponent<RawImage>().texture != null) & onFullScreen)
        {
            StartCoroutine(ReturnFromCenter());
        }
    }

    IEnumerator TransformToCenter() // процесс разворачивания картинки на весь экран
    {
        translateDone = false;
        float startDistance = Vector2.Distance(transform.position, dAScript.ScreenCenter);
        ChangeParent(parentForView.transform, 1);
        yield return null;

        while (!translateDone)
        {
            Translate(transform.position, dAScript.ScreenCenter);
            ReScaleImage(LerpTCalc(startDistance, dAScript.ScreenCenter));
            yield return null;
        }
        onFullScreen = true;
        yield break;
    }

    IEnumerator ReturnFromCenter() // процесс сворачивания картинки 
    {
        translateDone = false;
        float startDistance = Vector2.Distance(transform.position, defPos);
        ChangeParent(deffParent.transform, 0);
        yield return null;

        while (!translateDone)
        {
            Translate(transform.position, defPos);
            ReScaleImage(Math.Abs(LerpTCalc(startDistance, defPos) - 1));
            yield return null;
        }


        onFullScreen = false;
        yield break;
    }

    void DefPosTracking() // отслеживание координат начальной позиции картинки
    {
        defPos = deffParent.transform.position;
    }

    void Translate(Vector2 from, Vector2 to) // метод перемещения картинки
    {
        transform.position = Vector2.MoveTowards(from, to, animSpeed);

        if (from == to)
        {
            translateDone = true;
        }
        else { translateDone = false; }
    }

    void ReScaleImage(float t) //метод изменения размера картинки
    {
        Vector3 defScale = new(1, 1, 1);
        Vector3 fullScreenScale = defScale * scaleOnFullScreen;

        gameObject.transform.localScale = Vector3.Lerp(defScale, fullScreenScale, t);
    }

    void ChangeParent(Transform newParent, int indexInParent) // метод переключения "родителей"
    {
        transform.SetParent(newParent);
        transform.SetSiblingIndex(indexInParent);
    }

    float LerpTCalc(float startDistance, Vector2 endPoint) // отслеживание состояния перемещения картинки к центру и обратно
    {
        float curentDistance = Vector2.Distance(transform.position, endPoint);
        float lerpT = Math.Abs(curentDistance / startDistance - 1);
        return lerpT;
    }
}
