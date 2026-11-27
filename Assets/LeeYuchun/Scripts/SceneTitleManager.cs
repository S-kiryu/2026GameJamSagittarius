using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTitleManager : MonoBehaviour
{
    [SerializeField] private Transform titleElementsContainer;
    [SerializeField] private Transform manualPanel;
    [SerializeField] private Transform creditPanel;
    [SerializeField] private Transform rankingPanel;

    public void Start()
    {
        ToggleManual(false);
        ToggleCredit(false);
        ToggleRanking(false);
        AudioManager.Instance.PlayBGM("Title");
    }

    public void OnClickStartButton()
    {
        // TODO: 正式なシーンのパスを入り替え
        SceneManager.LoadScene("LeeYuchun/Scenes/TestScene_StageSelect");
    }

    public void OnClickManualButton()
    {
        AudioManager.Instance.PlaySE("Click");
        ToggleManual(true);
    }

    public void OnClickCreditButton()
    {
        AudioManager.Instance.PlaySE("Click");
        ToggleCredit(true);
    }

    public void OnClickRankingButton()
    {
        AudioManager.Instance.PlaySE("Click");
        ToggleRanking(true);
    }

    public void OnClickClosePanelButton()
    {
        AudioManager.Instance.PlaySE("Click");
        ToggleManual(false);
        ToggleCredit(false);
        ToggleRanking(false);
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

    private void ToggleRanking(bool visible)
    {
        rankingPanel.gameObject.SetActive(visible);
        titleElementsContainer.gameObject.SetActive(!visible);
    }
}
