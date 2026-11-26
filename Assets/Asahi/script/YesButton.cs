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

        StageDetailPanel detailPanel = GetComponentInParent<StageDetailPanel>();
        StageData stage = detailPanel != null ? detailPanel.SelectedStage : null;
        if (detailPanel != null && stage == null)
        {
            return;
        }

        Debug.Log("シーンを移行");
        _sceneLoad = SceneManager.LoadSceneAsync(gameSceneName);
        if (_sceneLoad != null)
        {
            InGameRound.SelectNextStage(stage);
        }
    }
}
