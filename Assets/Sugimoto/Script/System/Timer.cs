using UnityEngine;

/// <summary>
/// タイマー
/// </summary>
public class Timer : MonoBehaviour
{
    //時間
    private const float Duration = 10f;
    //終了時間
    private double _deadline;
    private float _stoppedSeconds = Duration;
    //動いているか
    private bool _isRunning;

    public float RemainingSeconds => _isRunning
        ? Mathf.Max(0f, (float)(_deadline - Time.unscaledTimeAsDouble))
        : _stoppedSeconds;

    /// <summary>
    /// タイマーのスタート
    /// </summary>
    public void StartCountdown()
    {
        _deadline = Time.unscaledTimeAsDouble + Duration;
        _isRunning = true;
    }

    public void StopCountdown()
    {
        _stoppedSeconds = RemainingSeconds;
        _isRunning = false;
    }
}