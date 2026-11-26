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
        ToggleCredit(false);
    }

    public void OnClickStartButton()
    {
        // TODO: 正式なシーンのパスを入り替え
        SceneManager.LoadScene("LeeYuchun/Scenes/TestScene_StageSelect");
    }

    public void OnClickManualButton()
    {
        ToggleManual(true);
    }

    public void OnClickCreditButton()
    {
        ToggleCredit(true);
    }

    public void OnClickClosePanelButton()
    {
        ToggleManual(false);
        ToggleCredit(false);
    }

    public void OnClickCloseGameButton()
    {
        Application.Quit();
    }

    private void ToggleManual(bool visible)
    {
        manualPanel.gameObject.SetActive(visible);
        titleElementsContainer.gameObject.SetActive(!visible);
    }

    private void ToggleCredit(bool visible)
    {
        creditPanel.gameObject.SetActive(visible);
        titleElementsContainer.gameObject.SetActive(!visible);
    }
}
