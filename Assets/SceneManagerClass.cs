using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerClass : MonoBehaviour
{
    public float progress;
    public void LoadScene(string sceneName){
        StartCoroutine(LoadSceneGame(sceneName));
    }
    IEnumerator LoadSceneGame(string sceneName){
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        async.allowSceneActivation = false;
        while(!async.isDone){
            progress = Mathf.Clamp01(async.progress / 0.9f);
            if(progress == 1f){
                async.allowSceneActivation = true;
            }
        yield return null;
        }
    }
}
