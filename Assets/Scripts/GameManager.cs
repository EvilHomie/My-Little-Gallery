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
        NativeControll();
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
    void NativeControll()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menu.activeSelf)
            {
                menu.SetActive(false);
            }

            else { Application.Quit(); }
        }        
    }

    // ����� �������� ����
    public void OpenMenu()
    {
        menu.SetActive(true);
    }

    // ����� �������� ����
    public void CloseMenu()
    {
        menu.SetActive(false);
    }
}
