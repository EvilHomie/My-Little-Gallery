using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    public Slider loadBar;
    public TextMeshProUGUI loadProgressText;

    public static string loadingSceneName;

    private void Start()
    {
        StartCoroutine(LoadSceneAsync(loadingSceneName));
    }

    IEnumerator LoadSceneAsync (string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress/ 0.9f);

            Debug.Log(progress);
            loadBar.value = progress;
            loadProgressText.text = progress * 100f + "%";

            yield return null;
        }
    }

}
