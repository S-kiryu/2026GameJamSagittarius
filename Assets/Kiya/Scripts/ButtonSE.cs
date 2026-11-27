using UnityEngine;

public class ButtonSE : MonoBehaviour
{
    public void PlaySE(string clipName)
    {
        AudioManager.Instance.PlaySE(clipName);
    }
}
