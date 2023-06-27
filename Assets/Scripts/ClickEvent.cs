using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ClickEvent : MonoBehaviour
{
    [SerializeField] private Button PicClickArea; // ������������ ������� � ��������
    private DeviceAdaptation dAScript; // ������ �� ����� � ������� �� ����������
    private GameObject parentForView; // ������ � ������� ����� ����������� �����
    private GameObject deffParent; // ������ � ������ ��������� �������� �� ���������
    private bool onFullScreen = false; // ���������� �� �������
    private bool translateDone = true; // �������� �� ������� �������������� ��� ���������
    private Vector2 defPos; // ��������� ������� ��������
    private readonly float animSpeed = 20; // �������� � ������� ���������� �������������� � ������������ ��������

    private float scaleOnFullScreen; // ���������� ��������� ��� ��������������

    private void OnEnable()
    {
        //��������� ������ �� �������
        dAScript = GameObject.FindWithTag("GameManager").GetComponent<DeviceAdaptation>();
        parentForView = GameObject.FindWithTag("Viewport");

        PicClickArea.onClick.AddListener(Clicked); // ���������� �������� �������� �������� ������������        
        deffParent = transform.parent.gameObject; // ������������ ��������� �������
    }
    private void Update()
    {
        ScaleFullScreenCalc();
        DefPosTracking();
    }

    void ScaleFullScreenCalc() // ��������� scaleOnFullScreen � ����������� �� ���������� ����������
    {
        if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
        {
            scaleOnFullScreen = Screen.width / dAScript.CellSize / dAScript.UIScale;
        }
        else { scaleOnFullScreen = Screen.height / dAScript.CellSize / dAScript.UIScale; }
    }

    void Clicked() // ��� ���������� ��� ����� 
    {
        // ������ ������ ��������� �������� �� ���� �����
        if ((gameObject.GetComponent<RawImage>().texture != null) & !onFullScreen)
        {
            StartCoroutine(TransformToCenter());
        }
        // ������ ������ ����������� �������� � ���������� ���������
        else if ((gameObject.GetComponent<RawImage>().texture != null) & onFullScreen)
        {
            StartCoroutine(ReturnFromCenter());
        }
    }

    IEnumerator TransformToCenter() // ������� �������������� �������� �� ���� �����
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

    IEnumerator ReturnFromCenter() // ������� ������������ �������� 
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

    void DefPosTracking() // ������������ ��������� ��������� ������� ��������
    {
        defPos = deffParent.transform.position;
    }

    void Translate(Vector2 from, Vector2 to) // ����� ����������� ��������
    {
        transform.position = Vector2.MoveTowards(from, to, animSpeed);

        if (from == to)
        {
            translateDone = true;
        }
        else { translateDone = false; }
    }

    void ReScaleImage(float t) //����� ��������� ������� ��������
    {
        Vector3 defScale = new(1, 1, 1);
        Vector3 fullScreenScale = defScale * scaleOnFullScreen;

        gameObject.transform.localScale = Vector3.Lerp(defScale, fullScreenScale, t);
    }

    void ChangeParent(Transform newParent, int indexInParent) // ����� ������������ "���������"
    {
        transform.SetParent(newParent);
        transform.SetSiblingIndex(indexInParent);
    }

    float LerpTCalc(float startDistance, Vector2 endPoint) // ������������ ��������� ����������� �������� � ������ � �������
    {
        float curentDistance = Vector2.Distance(transform.position, endPoint);
        float lerpT = Math.Abs(curentDistance / startDistance - 1);
        return lerpT;
    }
}
