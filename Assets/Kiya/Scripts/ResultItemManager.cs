using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultItemManager : MonoBehaviour
{
    [SerializeField] Image _background; //背景
    [SerializeField] Image[] _items = new Image[3]; //選択されたアイテム
    [SerializeField] GameObject _success; //成功時のUI
    [SerializeField] GameObject _failure; //失敗時のUI
    [SerializeField] RectTransform _titleButton; //タイトル画面へ移動するボタン
    //[SerializeField] TMP_Text _result;
    //[SerializeField] TMP_Text _message;

    void Start()
    {
        var gm = GameManagerTest.Instance;

        //お題に沿った背景を表示
        Debug.Log(gm.CurrentTheme.Name);
        _background.sprite = gm.CurrentTheme.Sprite;

        foreach (var item in gm.SelectedItems)
        {
            Debug.Log(item.Name);
        }

        //成否表示
        if (gm.Result == true)
        {
            _success.SetActive(true);
            _failure.SetActive(false);
            _titleButton.anchoredPosition = _success.GetComponent<RectTransform>().anchoredPosition;
            //_result.text = "Congratulations!";
            //_message.gameObject.SetActive(false);
        }
        else
        {
            _success.SetActive(false);
            _failure.SetActive(true);
            _titleButton.anchoredPosition = _failure.GetComponent<RectTransform>().anchoredPosition;
            //_result.text = "You faild...";
            //_message.gameObject.SetActive(true);
        }

        //選択したアイテムが3未満だったらアイテム表示枠を消す
        for (int i = 0; i < 3 - gm.SelectedItems.Count; i++)
        {
            _items[2 - i].gameObject.SetActive(false);
        }

        for (int i = 0; i < gm.SelectedItems.Count; i++)
        {
            _items[i].sprite = gm.SelectedItems[i].Sprite;
        }

        switch (gm.SelectedItems.Count)
        {
            case 0:
                Debug.Log("アイテムなし");
                break;

            case 1:
                //_items[0].rectTransform.
                break;

            case 2:
                break;

            case 3:
                break;

            default:
                Debug.LogWarning("想定外のアイテム数");
                break;
        }
    }
}
