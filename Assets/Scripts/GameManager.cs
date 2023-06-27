using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gallery;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject loadingLayer;
    [SerializeField] private GameObject titleMenu;

    
    private void Update()
    {
        //ChangeScreenOrientationMethod();

        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    NativeControll(SceneManager.GetActiveScene().name, MenuLayerManager.MenuIsActive);
        //}
    }

    // ����� �� ��������� ���������� ������ � ����������� �� �����
    void ChangeScreenOrientationMethod()
    {
        if (SceneManager.GetActiveScene().name == "View")
        Screen.orientation = ScreenOrientation.AutoRotation;
        else { Screen.orientation = ScreenOrientation.Portrait; }
    }

    // ����� ��� ������ "������� ��������"
    public void OpenGallery()
    {
        titleMenu.SetActive(false);
        gallery.SetActive(true);
        loadingLayer.SetActive(true);

    }

    // ����� ��� ������ "�����" 
    public void Exite()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); 
#endif
    }

    // ����� �� ������������ �������� ������ � ���������� � �������� � ����������� �� ������������� �� ������
    void NativeControll(string sceneName, bool menuIsActive)
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

        }
            if (sceneName == "View")
        {
            //LoadingLayer.loadingSceneName = "Gallery";
            SceneManager.LoadScene("LoadScreen");
        }

        if (sceneName == "Gallery")
        {
            if (menuIsActive)
            {
                menu.GetComponent<MenuLayerManager>().CloseMenu();
            }
            else { Application.Quit(); }
        }

        if (sceneName == "MainMenu")
        {
            Application.Quit();
        }
    }
}
