using Doozy.Runtime.UIManager.Components;
using Doozy.Runtime.UIManager.Containers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_MainMenuController : MonoBehaviour
{
    public UIContainer optionMenu;

    public UIToggle masterSource;
    public UIToggle BGMSource;
    public UIToggle SFXSource;

    public UISlider _masterVolume;
    public UISlider _BGMVolume;
    public UISlider _SFXVolume;
    // Start is called before the first frame update
    void Awake()
    {
        LoadUI();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    public void LoadUI()
    {
        SoundManager.Instance.LoadData();

        masterSource.IsOn = AudioListener.pause;
        BGMSource.IsOn = SoundManager.Instance.BGMSource.enabled;
        SFXSource.IsOn = SoundManager.Instance.SFXSource.enabled;

        _masterVolume.value = SoundManager.Instance._masterVolume;
        _BGMVolume.value = SoundManager.Instance._BGMVolume;
        _SFXVolume.value = SoundManager.Instance._SFXVolume;
    }

    public void UpdateUI()
    {
        SoundManager.Instance._masterVolume = _masterVolume.value;
        SoundManager.Instance._BGMVolume = _BGMVolume.value;
        SoundManager.Instance._SFXVolume = _SFXVolume.value;

        AudioListener.pause = !masterSource.isOn;
        SoundManager.Instance.BGMSource.enabled = BGMSource.IsOn;
        SoundManager.Instance.SFXSource.enabled = SFXSource.IsOn;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void OptionMenu()
    {
        if (!optionMenu.gameObject.activeInHierarchy)
            optionMenu.Show();
        else
        {
            optionMenu.Hide();
            SoundManager.Instance.SaveData();
        }
            
    }

    public void QuitGame()
    {
        SoundManager.Instance.SaveData();
        Application.Quit();
    }
}
