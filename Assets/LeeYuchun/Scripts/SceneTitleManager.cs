using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTitleManager : MonoBehaviour
{
    [SerializeField] private Transform titleElementsContainer;
    [SerializeField] private Transform manualPanel;
    [SerializeField] private Transform creditPanel;

    public void Start()
    {
        ToggleManual(false);
        ToggleCreadit(false);
    }

    public void OnClickStart()
    {
        // TODO: 正式なシーンのパスを入り替え
        SceneManager.LoadScene("LeeYuchun/Scenes/TestScene_StageSelect");
    }

    public void OnClickCredit()
    {
        Debug.Log("Credit");
    }

    public void OnClickManual() {
        Debug.Log("Manual");
    }

    public void OnClickClose()
    {
        Application.Quit();
    }

    private void ToggleManual(bool visible)
    {
        manualPanel.gameObject.SetActive(visible);
        titleElementsContainer.gameObject.SetActive(!visible);
    }

    private void ToggleCreadit(bool visible)
    {
        creditPanel.gameObject.SetActive(visible);
        titleElementsContainer.gameObject.SetActive(!visible);
    }
}
