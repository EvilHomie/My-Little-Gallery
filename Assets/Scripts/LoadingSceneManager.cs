using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneManager : MonoBehaviour
{
    public Slider loadBar; // ползунок загрузки
    public TextMeshProUGUI loadProgressText; // текст с процентами загрузки

    public static string loadingSceneName; // имя сцены которую нужно загрузить
    private readonly float duration = 2; // продолжительность показа сцены загрузки

    private void Start()
    {
        //StartCoroutine(LoadSceneAsync(loadingSceneName));
        StartCoroutine(LoadSceneAsyncWithTimer(loadingSceneName));
    }

    // метод отслеживающий фактическое состояние готовности следующей сцены (использовать если нужно действительно отслеживать состояние готовности сцены)
    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            Debug.Log(progress);
            loadBar.value = progress;
            loadProgressText.text = progress * 100f + "%";

            yield return null;
        }
    }


    // метод отслеживающий фиктивное (т.е. грузится по времени равное переменной duration) состояние готовности следующей сцены
    IEnumerator LoadSceneAsyncWithTimer(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        float time = 0f;

        while (time < duration)
        {
            loadBar.value = time / duration;
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();

            if (time >= duration)
            {
                operation.allowSceneActivation = true;
            }
        }

    }

}
