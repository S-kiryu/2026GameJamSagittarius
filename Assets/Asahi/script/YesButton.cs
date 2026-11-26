using UnityEngine;
using UnityEngine.SceneManagement;

public class YesButton : MonoBehaviour
{
    public string gameSceneName = "GameScene";

    public void ConfirmStage()
    {
        Debug.Log("シーンを移行");
        SceneManager.LoadScene(gameSceneName);
    }
}