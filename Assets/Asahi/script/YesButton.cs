using UnityEngine;
using UnityEngine.SceneManagement;

public class YesButton : MonoBehaviour
{
    public string gameSceneName = "GameScene";
    [SerializeField] private SceneLoadingScreen _loadingScreenPrefab;

    private AsyncOperation _sceneLoad;

    public void ConfirmStage()
    {
        if (_sceneLoad != null)
        {
            return;
        }

        StageDetailPanel detailPanel = GetComponentInParent<StageDetailPanel>();
        StageData stage = detailPanel != null ? detailPanel.SelectedStage : null;
        if (detailPanel != null && stage == null)
        {
            return;
        }

        bool loadStarted;
        if (_loadingScreenPrefab != null)
        {
            loadStarted = SceneLoadingScreen.TryLoad(gameSceneName, _loadingScreenPrefab);
        }
        else
        {
            _sceneLoad = SceneManager.LoadSceneAsync(gameSceneName);
            loadStarted = _sceneLoad != null;
        }

        if (loadStarted)
        {
            Debug.Log("シーンを移行");
            InGameRound.SelectNextStage(stage);
        }
    }
}
