using UnityEngine;
using UnityEngine.SceneManagement;

public class YesButton : MonoBehaviour
{
    public string gameSceneName = "GameScene";

    private AsyncOperation _sceneLoad;

    public void ConfirmStage()
    {
        if (_sceneLoad != null)
        {
            return;
        }

        Debug.Log("シーンを移行");
        _sceneLoad = SceneManager.LoadSceneAsync(gameSceneName);
    }
}
