using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneManager : MonoBehaviour
{
    public Slider loadBar; // �������� ��������
    public TextMeshProUGUI loadProgressText; // ����� � ���������� ��������

    public static string loadingSceneName; // ��� ����� ������� ����� ���������
    private readonly float duration = 2; // ����������������� ������ ����� ��������

    private void Start()
    {
        //StartCoroutine(LoadSceneAsync(loadingSceneName));
        StartCoroutine(LoadSceneAsyncWithTimer(loadingSceneName));
    }

    // ����� ������������� ����������� ��������� ���������� ��������� ����� (������������ ���� ����� ������������� ����������� ��������� ���������� �����)
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


    // ����� ������������� ��������� (�.�. �������� �� ������� ������ ���������� duration) ��������� ���������� ��������� �����
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
