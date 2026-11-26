using UnityEngine;
using UnityEngine.SceneManagement;

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
