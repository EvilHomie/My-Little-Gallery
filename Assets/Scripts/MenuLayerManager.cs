using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

// � ������ ������� ��������� ������ ������ � ������������ ����
public class MenuLayerManager : MonoBehaviour
{
    public static bool MenuIsActive { get; private set; }

    // ����� �������� ����
    public void OpenMenu()
    {
        gameObject.SetActive(true);
        MenuIsActive = true;
    }

    // ����� �������� ����
    public void CloseMenu()
    {
        gameObject.SetActive(false);
        MenuIsActive = false;
    }
}
