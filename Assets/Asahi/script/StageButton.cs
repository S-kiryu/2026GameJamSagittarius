using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StageButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    Vector3 originalScale;
    Vector3 enlargedScale;

    public Sprite stageBackground;
    public StageDetailPanel detailPanel;
    void Start()
    {
        originalScale = transform.localScale;
        enlargedScale = originalScale * 1.3f;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = enlargedScale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = originalScale;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Image image = GetComponent<Image>();
        detailPanel.showStage(stageBackground);
    }
}