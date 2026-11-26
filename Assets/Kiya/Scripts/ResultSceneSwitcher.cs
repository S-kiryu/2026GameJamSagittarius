using UnityEngine;
using UnityEngine.SceneManagement;


namespace Kiya.Result
{
    public class ResultSceneSwitcher : MonoBehaviour
    {
        public void SwitchScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
            //AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);
            //op.allowSceneActivation = true;
        }

        public void MoveToResultScene()
        {

        }
    }

}

