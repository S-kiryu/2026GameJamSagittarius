using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Kiya.Result
{
    public class ResultItemManager : MonoBehaviour
    {
        [SerializeField] Image _background; //背景
        [SerializeField] Image[] _items = new Image[3]; //選択されたアイテム
        [SerializeField] GameObject _success; //成功時のUI
        [SerializeField] GameObject _failure; //失敗時のUI
        [SerializeField] RectTransform _titleButton; //タイトル画面へ移動するボタン

        private void Start()
        {
            if (StageResult.TryTake(out StageResult result))
            {
                ShowResult(result.IsSuccess, result.Background, result.SelectedItems.Select(item => item.ItemImage).ToArray());
                return;
            }

            GameManagerTest preview = GameManagerTest.Instance;
            if (preview != null)
            {
                ShowResult(preview.Result, preview.CurrentTheme?.Sprite, preview.SelectedItems.Select(item => item?.Sprite).ToArray());
                return;
            }

            ShowResult(null, null, Array.Empty<Sprite>());
        }

        private void ShowResult(bool? isSuccess, Sprite background, IReadOnlyList<Sprite> items)
        {
            if (background != null)
            {
                _background.sprite = background;
            }

            _success.SetActive(isSuccess == true);
            _failure.SetActive(isSuccess == false);
            if (isSuccess.HasValue)
            {
                GameObject resultPanel = isSuccess.Value ? _success : _failure;
                _titleButton.anchoredPosition = resultPanel.GetComponent<RectTransform>().anchoredPosition;
            }

            for (int i = 0; i < _items.Length; i++)
            {
                Sprite sprite = i < items.Count ? items[i] : null;
                _items[i].sprite = sprite;
                _items[i].gameObject.SetActive(sprite != null);
            }
        }
    }
}
