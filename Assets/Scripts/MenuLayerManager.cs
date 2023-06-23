using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

// в данном скрипте прописана логика вызова и возможностей меню
public class MenuLayerManager : MonoBehaviour
{
    public static bool MenuIsActive { get; private set; }

    // метод открытия меню
    public void OpenMenu()
    {
        gameObject.SetActive(true);
        MenuIsActive = true;
    }

    // метод закрытия меню
    public void CloseMenu()
    {
        gameObject.SetActive(false);
        MenuIsActive = false;
    }
}
