using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private float _savedVolume;
    private float _savedBrightness;
    [SerializeField]
    private Slider _volumeSlider;
    [SerializeField]
    private Slider _brightnessSlider;
    [SerializeField]
    private AudioMixer _audioMixer;
    [SerializeField]
    private Image _brightness;
    [SerializeField]
    private GameObject _pauseMenu;
    private bool _paused;

    private void Start()
    {
        _brightness = GameObject.Find("BrightnessManager").transform.GetChild(0).GetChild(0).GetComponent<Image>();
        _savedVolume = PlayerPrefs.GetFloat("Volume");
        _savedBrightness = PlayerPrefs.GetFloat("Brightness");
        UpdateSliders();

        if (_brightness == null)
        {
            Debug.LogError("The BrightnessManager is NULL.");
        }
    }

    private void Update()
    {
        PauseGame();
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

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        _pauseMenu.SetActive(false);
    }

    private void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_paused == false)
            {
                _pauseMenu.SetActive(true);
                _paused = true;
            }
            else if (_paused == true)
            {
                _pauseMenu.SetActive(false);
                _paused = false;
            }
        }
    }
}
