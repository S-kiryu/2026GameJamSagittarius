using UnityEngine;
using System.Collections;
using TMPro;

/// <summary>
/// ゲーム開始前のカウントダウン
/// </summary>
public class InGameCountDown : MonoBehaviour
{
    [SerializeField] private TMP_Text _countDownText;
    [SerializeField] private Timer _timer;

    /// <summary>
    /// カウントダウン
    /// </summary>
    /// <returns></returns>
    public IEnumerator StartCountDown()
    {
        _countDownText.gameObject.SetActive(true);

        for(int i = 3;  i >= 1; i--)
        {
            _countDownText.SetText("{0}", i);
            yield return new WaitForSeconds(1f);
        }

        _countDownText.SetText("START");
        yield return new WaitForSeconds(1f);

        _countDownText.gameObject.SetActive(false);

        //タイマー開始
        _timer.StartCountdown();
    }
}
