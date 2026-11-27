using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///     音楽関係を管理するクラス
/// </summary>
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [System.Serializable]
    public class SoundData
    {
        public AudioClip Clip => _clip;
        public string Name => _name;
        public float Volume => _volume;

        [SerializeField] AudioClip _clip;
        [SerializeField] string _name;
        [SerializeField, Range(0, 1)] float _volume;
    }
    [Header("プレイヤー")]
    [SerializeField] AudioSource _sePlayer;
    [SerializeField] AudioSource _bgmPlayer;

    [Header("SEリスト")]
    [SerializeField] List<SoundData> _seList;
    [Header("BGMリスト")]
    [SerializeField] List<SoundData> _bgmList;

    /// <summary>
    ///     SE再生
    /// </summary>
    /// <param name="name"></param>
    /// <param name="volume"></param>
    public void PlaySE(string name)
    {
        foreach (var se in _seList)
        {
            if (se.Name == name)
            {
                //GameObject sePlayer = new GameObject("SEPlayer");
                //sePlayer.transform.SetParent(transform);

                //var source = sePlayer.AddComponent<AudioSource>();
                _sePlayer.volume = se.Volume;
                _sePlayer.spatialBlend = 0f;
                //_sePlayer.clip = se.Clip;
                _sePlayer.PlayOneShot(se.Clip);
                //Destroy(sePlayer, se.Clip.length);
            }
        }
    }

    public float GetSELength(string name)
    {
        foreach (var se in _seList)
        {
            if (se.Name == name)
            {
                return se.Clip.length;
            }
        }

        return 0f;
    }

    /// <summary>
    ///     BGM再生(ループ)
    /// </summary>
    /// <param name="name"></param>
    public void PlayBGM(string name)
    {
        Debug.Log($"PlayBGM {name}");
        Debug.Log(_bgmPlayer.clip);
        Debug.Log(_bgmPlayer.isPlaying);

        foreach (var bgm in _bgmList)
        {
            if (bgm.Name == name)
            {
                _bgmPlayer.Stop();

                if (_bgmPlayer.clip == bgm.Clip && _bgmPlayer.isPlaying)
                    return;

                _bgmPlayer.clip = bgm.Clip;
                _bgmPlayer.loop = true;
                _bgmPlayer.volume = bgm.Volume;
                _bgmPlayer.Play();
            }
        }
    }

    /// <summary>
    ///     音楽のフェード
    /// </summary>
    /// <param name="fadeTime"></param>
    public void FadeBGM(float fadeTime, float startVolume, float targetVolume)
    {
        StartCoroutine(FadeCoroutine(fadeTime, startVolume, targetVolume));
    }

    IEnumerator FadeCoroutine(float fadeTime, float startVolume, float targetVolume)
    {
        _bgmPlayer.volume = startVolume;
        float timer = 0;

        while (timer < fadeTime)
        {
            timer += Time.deltaTime;
            _bgmPlayer.volume = Mathf.Lerp(startVolume, targetVolume, timer / fadeTime);

            yield return null;
        }

        _bgmPlayer.volume = targetVolume;

        if (targetVolume != 0)
            yield break;
        else
            Stop();

    }

    /// <summary>
    ///     BGMのストップ
    /// </summary>
    public void Stop()
    {
        _bgmPlayer.Stop();
    }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        _bgmPlayer = GetComponentInChildren<AudioSource>();
        //PlayBGM("BGM");
    }
}