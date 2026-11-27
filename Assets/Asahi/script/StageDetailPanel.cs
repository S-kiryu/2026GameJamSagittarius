using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 選択後の確認パネル
/// </summary>
public class StageDetailPanel : MonoBehaviour
{
    /// <summary>
    /// ステージのイメージ
    /// </summary>
    [SerializeField] private Image stageImage;
    [SerializeField] private TMP_Text TitleText;
    public StageData SelectedStage { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="stage"></param>
    public void ShowStage(StageData stage)
    {
        Debug.Log(stage.SelectImage);
        SelectedStage = stage;
        stageImage.sprite = stage.SelectImage;
        stageImage.preserveAspect = true;
        stageImage.enabled = stage.SelectImage != null;

        if (TitleText != null)
        {
            TitleText.SetText(stage.ThemeName);
        }

        gameObject.SetActive(true);
    }

    public void HidePanel()
    {
        SelectedStage = null;
        gameObject.SetActive(false);
    }
}
