using UnityEngine;
using UnityEngine.UI;

public class StageDetailPanel : MonoBehaviour
{
    public Image stageImage;

    public void showStage(Sprite sprite)
    {
        stageImage.sprite = sprite;
        gameObject.SetActive(true);
    }
    public void HidePanel()
    {
        gameObject.SetActive(false);
    }
}
