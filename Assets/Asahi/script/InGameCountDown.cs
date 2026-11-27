using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// ゲーム開始前のカウントダウン
/// </summary>
public class InGameCountDown : MonoBehaviour
{
    [SerializeField] private TMP_Text _countDownText;
    [SerializeField] private Timer _timer;
    [SerializeField] private Image _countDownBackGround;

    /// <summary>
    /// カウントダウン
    /// </summary>
    /// <returns></returns>
    public IEnumerator StartCountDown()
    {
        _countDownBackGround.gameObject.SetActive(true);
        _countDownText.gameObject.SetActive(true);

        for(int i = 3;  i >= 1; i--)
        {
            _countDownText.SetText("{0}", i);
            yield return new WaitForSeconds(1f);
        }

        _countDownText.SetText("START");
        yield return new WaitForSeconds(1f);

        _countDownText.gameObject.SetActive(false);
        _countDownBackGround.gameObject.SetActive(false);

        //タイマー開始
        _timer.StartCountdown();
    }
}
