using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// ステージ単体の機能
/// </summary>
[RequireComponent(typeof(Button))]
public class StageButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private StageData _stageData;
    [SerializeField] private StageDetailPanel detailPanel;

    private Vector3 _originalScale;
    private Button _button;

    private void Awake()
    {
        if (_stageData == null)
        {
            gameObject.SetActive(false);
            return;
        }

        _originalScale = transform.localScale;
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SelectStage);

        Sprite thumbnail = _stageData.SelectImage;
        if (thumbnail != null && _button.image != null)
        {
            _button.image.type = Image.Type.Simple;
            _button.image.preserveAspect = true;
            _button.image.sprite = thumbnail;
        }

        TMP_Text label = GetComponentInChildren<TMP_Text>();
        if (label != null)
        {
            label.SetText(_stageData.ThemeName);
            label.enabled = thumbnail == null;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = _originalScale * 1.3f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = _originalScale;
    }

    private void SelectStage()
    {
        detailPanel.ShowStage(_stageData);
    }

    private void OnDestroy()
    {
        if (_button != null)
        {
            _button.onClick.RemoveListener(SelectStage);
        }
    }
}
