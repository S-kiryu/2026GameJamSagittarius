using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// インゲーム機能を実行するクラス
/// </summary>
public class InGameRound : MonoBehaviour
{
    [Header("インゲームの機能設定")]
    [SerializeField] private Timer _timer;
    [SerializeField] private ItemClickHistory _selection;
    [SerializeField] private StageData _theme;
    [SerializeField] private ItemCreatior _itemCreator;
    [SerializeField] private Button _readyButton;

    [Header("テキスト関連")]
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private TMP_Text _themeText;

    [Header("背景とシーン移行先")]
    [SerializeField] private Image _background;
    [SerializeField] private string _GameResult;

    private static StageData _nextStage;
    private bool _finished;

    /// <summary>
    /// ステージのデータを受け取る
    /// </summary>
    /// <param name="stage">渡したいステージ</param>
    internal static void SelectNextStage(StageData stage)
    {
        _nextStage = stage;
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    private static void ResetStageSelection()
    {
        _nextStage = null;
    }

    private void Start()
    {
        if (_nextStage != null)
        {
            _theme = _nextStage;
            _nextStage = null;
        }

        _readyButton.interactable = false;
        _itemCreator.GenerateItems(_theme.ItemImages);
        _readyButton.onClick.AddListener(Submit);
        _timer.StartCountdown();
        _themeText.SetText(_theme.ThemeName);
        UpdateTimerText();
    }

    private void Update()
    {
        if (_finished)
        {
            return;
        }

        UpdateTimerText();

        if (_timer.RemainingSeconds <= 0f)
        {
            Finish(false);
            return;
        }

        _readyButton.interactable =
            _selection.SelectedItems.Count == ItemClickHistory.MaxSelectionCount;
    }

    /// <summary>
    /// 選択されている数がMaxSelectionCountに満たしているかどうか
    /// </summary>
    private void Submit()
    {
        if (_finished)
        {
            return;
        }

        if (_timer.RemainingSeconds <= 0f)
        {
            Finish(false);
            return;
        }

        if (_selection.SelectedItems.Count != ItemClickHistory.MaxSelectionCount)
        {
            return;
        }

        Finish(HasCorrectSelection());
    }

    /// <summary>
    /// 正しい選択かどうか
    /// </summary>
    /// <returns>正しかったらtrue</returns>
    private bool HasCorrectSelection()
    {
        var remainingAnswers = new List<Sprite>(_theme.CorrectImages);

        if (remainingAnswers.Count != ItemClickHistory.MaxSelectionCount ||
            remainingAnswers.Contains(null))
        {
            return false;
        }

        foreach (PicItem item in _selection.SelectedItems)
        {
            if (!remainingAnswers.Remove(item.ItemSprite))
            {
                return false;
            }
        }

        return remainingAnswers.Count == 0;
    }

    /// <summary>
    /// 選択を終えたときの処理
    /// </summary>
    /// <param name="isSuccess"></param>
    private void Finish(bool isSuccess)
    {
        _finished = true;
        _selection.InputLocked = true;
        _readyButton.interactable = false;
        _timer.StopCountdown();
        UpdateTimerText();
        StageResult.Save(isSuccess, _selection.SelectedItems, _background != null ? _background.sprite : null, _theme, _timer.GetClearTime());
        SceneManager.LoadScene(_GameResult);
    }

    /// <summary>
    /// タイマーのレイアウトを決める
    /// </summary>
    private void UpdateTimerText()
    {
        _timerText.SetText("{0}", Mathf.CeilToInt(_timer.RemainingSeconds));
    }

    private void OnDestroy()
    {
        if (_readyButton != null)
        {
            _readyButton.onClick.RemoveListener(Submit);
        }
    }
}
