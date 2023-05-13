using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField]
    private Image _loadingBar;

    void Start()
    {
        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation loading = SceneManager.LoadSceneAsync("Main");

        loading.allowSceneActivation = false;

        while (!loading.isDone)
        {
            _loadingBar.fillAmount = loading.progress;

            if (loading.progress >= 0.9f)
            {
                loading.allowSceneActivation = true;
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
