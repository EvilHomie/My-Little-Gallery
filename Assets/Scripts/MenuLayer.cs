using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MenuLayer : MonoBehaviour
{
    public GameObject gameMenu;
    public Sprite[] volumeImage;
    public Slider volumeSlider;
    public GameObject volumHandle;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GameObject.FindWithTag("GameManager").GetComponent<AudioSource>();
    }
    private void Update()
    {
        audioSource.volume = volumeSlider.value ;
        ChangeVolumeHandle();
    }

    private void ChangeVolumeHandle()
    {
        if (audioSource.volume == 0)
        {
            volumHandle.GetComponent<Image>().sprite = volumeImage[0];
        }

        else if (audioSource.volume > 0 & audioSource.volume <0.5f)
        {
            volumHandle.GetComponent<Image>().sprite = volumeImage[1];
        }

        else if (audioSource.volume > 0.5f & audioSource.volume < 1)
        {
            volumHandle.GetComponent<Image>().sprite = volumeImage[2];
        }

        else if (audioSource.volume == 1)
        {
            volumHandle.GetComponent<Image>().sprite = volumeImage[3];
        }

    }

    public void Exite()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); 
#endif
    }

    public void OpenMenu()
    {
        gameMenu.SetActive(true);
    }

    public void CloseMenu()
    {
        gameMenu.SetActive(false);
    }
}
