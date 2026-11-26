using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneSwitcher : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }

    public void MoveToIngameScene(string sceneName)
    {
        Debug.Log("Game Start");
        //SceneManager.LoadScene(sceneName);
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
}
