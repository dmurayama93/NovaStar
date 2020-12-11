using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _optionsMenu;
    [SerializeField]
    private AudioMixer _audioMixer;
    [SerializeField]
    private AudioClip _menuMusic;
    [SerializeField]
    private Image _brightness;
    private float _savedVolume;
    private float _savedBrightness;
    [SerializeField]
    private Slider _volumeSlider;
    [SerializeField]
    private Slider _brightnessSlider;

    private void Start()
    {
        AudioManager.Instance.PlayMusic(_menuMusic, 1f);
        UpdateSliders();
    }

    public void StartGame()
    {
        //Should load in loading screen whichever integer that may correspond to
        //For proper working order you can order your scenes 0 - Mainmenu 1 -loadingscreen 2 - Maingame
        SceneManager.LoadScene(1); 
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OptionsMenuOn()
    {
        _optionsMenu.SetActive(true);
    }

    public void OptionsMenuOff()
    {
        _optionsMenu.SetActive(false);
    }

    public void SetVolume(float volume)
    {
        _audioMixer.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }

    public void SetBrightness(float brightness)
    {
        _brightness.color = new Color(255, 255, 255, brightness);
        PlayerPrefs.SetFloat("Brightness", brightness);
        PlayerPrefs.Save();
    }

    private void UpdateSliders()
    {
        _savedVolume = PlayerPrefs.GetFloat("Volume");
        _savedBrightness = PlayerPrefs.GetFloat("Brightness");

        _volumeSlider.value = _savedVolume;
        _brightnessSlider.value = _savedBrightness;

        SetBrightness(_savedBrightness);
        SetVolume(_savedVolume);
    }
}
