using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

/// <summary>
/// ステージ単体の機能
/// </summary>
[RequireComponent(typeof(Button))]
public class StageButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private StageData _stageData;
    [FormerlySerializedAs("detailPanel")]
    [SerializeField] private StageDetailPanel _detailPanel;

    private Vector3 _originalScale;
    private Button _button;
    private GameObject _backButton;

    internal void Initialize(StageData stage, StageDetailPanel detailPanel, GameObject backButton)
    {
        _stageData = stage;
        _detailPanel = detailPanel;
        _backButton = backButton;
    }

    private void Awake()
    {
        _originalScale = transform.localScale;
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SelectStage);
    }

    private void Start()
    {
        if (_stageData == null)
        {
            gameObject.SetActive(false);
            return;
        }

        Sprite thumbnail = _stageData.ResultBackgroundImage;
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
        if (_stageData == null || _detailPanel == null)
        {
            return;
        }

        if (_backButton != null)
        {
            _backButton.SetActive(false);
        }

        _detailPanel.ShowStage(_stageData);
    }

    private void OnDestroy()
    {
        if (_button != null)
        {
            _button.onClick.RemoveListener(SelectStage);
        }
    }
}
