using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SettingManager : MonoBehaviour {

    public Toggle fullscreenToggle;
    public Dropdown resolutionDropdown;
    public Resolution[] resolutions;
    public Slider musicSlider;
    public Slider fxSlider;
    public GameSettings gameSettings;
    public Button applyButton;
    public Button cancelButton;
    public GameObject optionsMenu;
    public AudioSource fxSource;
    public AudioSource musicSource1;
    public AudioSource musicSource2;
    public AudioClip[] menuSound;

    void Start()
    {
        //Application.targetFrameRate = 60;
        gameSettings = new GameSettings();
        fullscreenToggle.onValueChanged.AddListener(delegate { OnFullscreenToggle(); });
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResoutionChange(); });
        musicSlider.onValueChanged.AddListener(delegate { OnMusicChange(); });
        fxSlider.onValueChanged.AddListener(delegate { OnFxChange(); });
        applyButton.onClick.AddListener(delegate { OnApplyButtonClick(); });
        cancelButton.onClick.AddListener(delegate { OnCancelButtonClick(); });
        resolutions = Screen.resolutions;
        foreach(Resolution resolution in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }
        LoadSettings();



    }

    void Update()
    {
        if (Input.GetButtonDown("Pause") && optionsMenu.activeSelf)
        {
            OnCancelButtonClick();
        }
    }

    public void OnFullscreenToggle()
    {
        gameSettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
    }

    public void OnResoutionChange()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
        gameSettings.resolution = resolutionDropdown.value;
    }

    public void OnMusicChange()
    {
        musicSource1.volume = gameSettings.music = musicSlider.value;
        musicSource2.volume = gameSettings.music = musicSlider.value;
    }

    public void OnFxChange()
    {
       fxSource.volume = gameSettings.fx = fxSlider.value;
    }

    public void SaveSettings()
    {
        string jsonData = JsonUtility.ToJson(gameSettings, true);
        File.WriteAllText(Application.persistentDataPath + "/gamesettings.json",jsonData);
    }

    public void LoadSettings()
    {
        gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));
        fullscreenToggle.isOn = gameSettings.fullscreen;
        resolutionDropdown.value = gameSettings.resolution;
        musicSlider.value = gameSettings.music;
        fxSlider.value = gameSettings.fx;
        resolutionDropdown.RefreshShownValue();
        Screen.fullScreen = gameSettings.fullscreen;
        fxSource.volume = gameSettings.fx = fxSlider.value;
        musicSource1.volume = gameSettings.music;
        musicSource2.volume = gameSettings.music;
    }

    public void OnApplyButtonClick()
    {
        SaveSettings();
        fxSource.PlayOneShot(menuSound[0], gameSettings.fx);
        optionsMenu.SetActive(false);
    }

    public void OnCancelButtonClick()
    {
        LoadSettings();
        fxSource.PlayOneShot(menuSound[0], gameSettings.fx);
        optionsMenu.SetActive(false);
    }

}
