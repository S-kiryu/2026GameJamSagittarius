using UnityEngine;
using UnityEngine.SceneManagement;


namespace Kiya.Result
{
    public class ResultSceneSwitcher : MonoBehaviour
    {
        internal StageData RetryStage { get; set; }

        public void SwitchScene(string sceneName)
        {
            if (sceneName == "InGame")
            {
                InGameRound.SelectNextStage(RetryStage);
            }

            SceneManager.LoadScene(sceneName);
        }

        public void MoveToResultScene()
        {

        }
    }

}

