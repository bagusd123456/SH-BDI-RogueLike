using Doozy.Runtime.UIManager.Components;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource BGMSource;
    public AudioSource SFXSource;
    public AudioSource hover;
    public AudioSource click;
    public AudioClip sound;
    public AudioListener listener;

    [Space]

    [Range(0f, 1f)]
    public float _masterVolume;
    [Range(0f, 1f)]
    public float _BGMVolume;
    [Range(0f, 1f)]
    public float _SFXVolume;

    [Space]
    public AudioClip mainMenuClip;
    public AudioClip navClip;
    public AudioClip[] levelBGM;

    public static SoundManager Instance { get; private set; }

    public List<SoundData> soundData = new List<SoundData>();
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;

        DontDestroyOnLoad(this);
        listener = FindObjectOfType<AudioListener>();
        LoadData();
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayBGM(mainMenuClip);

        UIButton[] buttonList = FindObjectsOfType<UIButton>();
        foreach (var item in buttonList)
        {
            item.AddBehaviour(Doozy.Runtime.UIManager.UIBehaviour.Name.PointerEnter).Event.AddListener(() => hover.Play());
            item.AddBehaviour(Doozy.Runtime.UIManager.UIBehaviour.Name.PointerClick).Event.AddListener(() => click.Play());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (listener == null)
            listener = FindObjectOfType<AudioListener>();
        AudioListener.volume = _masterVolume;
        BGMSource.volume = _BGMVolume;
        SFXSource.volume = _SFXVolume;
    }

    public void PlayBGM(AudioClip clip)
    {
        BGMSource.clip = clip;
        BGMSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void LoadData()
    {
        AudioListener.pause = PlayerPrefs.GetInt("masterSetting") != 0;
        BGMSource.enabled = PlayerPrefs.GetInt("bgmSetting") != 0;
        SFXSource.enabled = PlayerPrefs.GetInt("sfxSetting") != 0;

        _masterVolume = PlayerPrefs.GetFloat("masterVolume");
        _BGMVolume = PlayerPrefs.GetFloat("BGMVolume");
        _SFXVolume = PlayerPrefs.GetFloat("SFXVolume");
    }

    public void SaveData()
    {
        bool master = !AudioListener.pause;
        PlayerPrefs.SetInt("masterSetting", master ? 1 : 0);

        bool bgm = BGMSource.enabled;
        PlayerPrefs.SetInt("bgmSetting", bgm ? 1 : 0);

        bool sfx = SFXSource.enabled;
        PlayerPrefs.SetInt("sfxSetting", sfx ? 1 : 0);


        float masterVolume = _masterVolume;
        PlayerPrefs.SetFloat("masterVolume", masterVolume);

        float bgmVolume = _BGMVolume;
        PlayerPrefs.SetFloat("BGMVolume", bgmVolume);

        float sfxVolume = _SFXVolume;
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
    }

    private void OnApplicationQuit()
    {
        
    }
}

[System.Serializable]
public class SoundData
{
    public bool toggle;
    public float volume;
}
