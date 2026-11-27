using UnityEngine;
using UnityEngine.SceneManagement;


namespace Kiya.Result
{
    public class ResultSceneSwitcher : MonoBehaviour
    {
        [SerializeField] private SceneLoadingScreen _loadingScreenPrefab;

        internal StageData RetryStage { get; set; }

        public void SwitchScene(string sceneName)
        {
            LoadScene(sceneName, openStageSelect: false);
        }

        public void OpenStageSelect()
        {
            LoadScene("SceneTitle", openStageSelect: true);
        }

        private void LoadScene(string sceneName, bool openStageSelect)
        {
            bool showLoadingScreen = _loadingScreenPrefab != null && (sceneName == "InGame" || sceneName == "SceneTitle");
            if (showLoadingScreen && !SceneLoadingScreen.TryLoad(sceneName, _loadingScreenPrefab))
            {
                return;
            }

            AudioManager audioManager = AudioManager.Instance;
            if (audioManager != null)
            {
                audioManager.PlaySE("Click");
            }

            if (sceneName == "InGame")
            {
                InGameRound.SelectNextStage(RetryStage);
            }

            if (openStageSelect)
            {
                SceneTitleManager.OpenStageSelectOnNextLoad();
            }

            if (!showLoadingScreen)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }

}

