using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneContoller : MonoBehaviour
{
    public static LoadingConstant constant;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        constant = new LoadingConstant();
    }

    public static void LoadSene(string nextSceneName)
    {
        SceneManager.LoadScene(nextSceneName);
    }

    public void ChangeHomeScene()
    {
        //SceneManager.LoadScene();
        Coroutine coroutine = StartCoroutine(LoadSceneProcess(constant.homeSceneName));
        constant.currentSceneName = constant.homeSceneName;
    }

    public void ChangeGamePlayScene()
    {
        Coroutine coroutine = StartCoroutine(LoadSceneProcess(constant.gameplaySceneName));
    }

    IEnumerator LoadSceneProcess(string nextSceneName)
    {
        yield return new WaitForSeconds(constant.loadingTime);

        AsyncOperation operation = SceneManager.LoadSceneAsync(nextSceneName, LoadSceneMode.Single);
        operation.allowSceneActivation = true;

        yield return new WaitForSeconds(constant.loadingTime);

        constant.currentSceneName = nextSceneName;

    }

    // Ã¼Å©¿ë
    public void ApplicaionQuit()
    {
        Application.Quit();
    }
}

public class LoadingConstant
{ 
    public LoadingConstant() { }


    public string homeSceneName = "HomeScene";
    public string loadingSceneName = "LoadingScene";
    public string gameplaySceneName = "PlayTestScene";

    public float loadingTime = 1f;
    public string currentSceneName = "HomeScene";
}
