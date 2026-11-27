using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public sealed class StageButtonPanel : MonoBehaviour
{
    [SerializeField] private StageButton _stageButtonPrefab;
    [SerializeField] private StageData[] _stages = Array.Empty<StageData>();
    [SerializeField] private StageDetailPanel _detailPanel;
    [SerializeField] private GameObject _backButton;

    private void Awake()
    {
        if (_stageButtonPrefab == null || _detailPanel == null)
        {
            Debug.LogError("StageButton Prefab と StageDetailPanel を設定してください。", this);
            return;
        }

        foreach (StageData stage in _stages)
        {
            if (stage == null)
            {
                continue;
            }

            StageButton button = Instantiate(_stageButtonPrefab, transform, false);
            button.Initialize(stage, _detailPanel, _backButton);
            button.gameObject.SetActive(true);
        }
    }
}
