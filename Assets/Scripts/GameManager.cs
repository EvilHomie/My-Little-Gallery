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

    // метод дл€ кнопки "открыть галлерею"
    public void OpenGallery()
    {
        titleMenu.SetActive(false);
        gallery.SetActive(true);
        loadingLayer.SetActive(true);
    }

    // метод дл€ кнопки "¬ыйти" 
    public void Exite()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); 
#endif
    }

    // метод по отслеживанию нативных кнопок в устройстве и действи€ в зависимости от происход€щего на экране
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

    // метод открыти€ меню
    public void OpenMenu()
    {
        menu.SetActive(true);
    }

    // метод закрыти€ меню
    public void CloseMenu()
    {
        menu.SetActive(false);
    }
}
