using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sceneloading : MonoBehaviour
{
    public Image progressbar;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAsyncOperation());
    }

    IEnumerator LoadAsyncOperation()
    {
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(3);

        while ( gameLevel.progress < 1)
        {
            progressbar.fillAmount = gameLevel.progress;
            yield return new WaitForEndOfFrame();

        }

    }
    
}
