using TMPro;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip clickSound;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GameObject.FindWithTag("GameManager").GetComponent<AudioSource>();
    }
    public void ClickSound()
    {
        audioSource.PlayOneShot(clickSound);
    }
}





