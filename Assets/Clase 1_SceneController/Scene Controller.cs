using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    #region Singleton
    private static SceneController _instance;
    public static SceneController Instance { get { return _instance; } }

    private void Awake()
    {
        if (!_instance)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion

    [SerializeField] private string _loadingSceneName = "LoadingScene";
    private string _nextScene;

    public void CallScene(string sceneName)
    {
        _nextScene = sceneName;
        SceneManager.LoadScene(_loadingSceneName);
    }

    public void AutoCallNextScene(LoadingScene loading)
    {
        StartCoroutine(LoadAsyncScene(loading));
    }

    private IEnumerator LoadAsyncScene(LoadingScene loading)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(_nextScene);
        while (!async.isDone)
        {
            loading.UpdateUI(async.progress); //Le paso el progreso de la operación asincrónica (ni idea si se escribe así)
            yield return new WaitForFixedUpdate();
        }
    }
}
