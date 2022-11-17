using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Doozy.Runtime.UIManager.Containers;
using Doozy.Runtime.UIManager.Components;

public class UI_InGameController : MonoBehaviour
{
    public UIContainer pauseMenu;
    public UIContainer optionMenu;
    public CinemachineVirtualCamera _cmInGame;
    public CinemachineVirtualCamera _cmPauseGame;

    public UIToggle masterSource;
    public UIToggle BGMSource;
    public UIToggle SFXSource;

    public UISlider _masterVolume;
    public UISlider _BGMVolume;
    public UISlider _SFXVolume;

    private void Awake()
    {
        LoadUI();
    }
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.BGMSource.clip = SoundManager.Instance.levelBGM[0];
        SoundManager.Instance.BGMSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!optionMenu.gameObject.activeInHierarchy)
                if (!pauseMenu.gameObject.activeInHierarchy)
                    PauseGame();
                else
                    ResumeGame();
            else
                OptionMenu();

        }
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

    public void PauseGame()
    {
        pauseMenu.Show();
        Time.timeScale = 0;
        _cmInGame.gameObject.SetActive(false);
        _cmPauseGame.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        pauseMenu.Hide();
        Time.timeScale = 1;
        _cmInGame.gameObject.SetActive(true);
        _cmPauseGame.gameObject.SetActive(false);
    }

    public void OptionMenu()
    {
        if (!optionMenu.gameObject.activeInHierarchy)
            optionMenu.Show();
        else
            optionMenu.Hide();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
