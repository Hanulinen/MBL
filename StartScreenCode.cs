using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class StartScreenCode : MonoBehaviour
{

    [SerializeField]
    Button StartButton, LoadButton, OptionsButton, CreditsButton, CreditsCancel, ControlsButton, ControlsCancel;
    [SerializeField]
    Button Load1, Load2, Load3, Load4, Load5, LoadCancel, Quit;
    [SerializeField]
    Text Text1, Text2, Text3, Text4, Text5;
    [SerializeField]
    AudioSource mainMenuSource;
    [SerializeField]
    AudioSource mainMenuMusicSource;
    [SerializeField]
    AudioClip[] mainMenuSound;
    [SerializeField]
    GameObject options, loading_panel,creditsPanel, controlsPanel;
    public Loading load;
    public Save_progress save;

    void Start()
    {
        load = new Loading();
        mainMenuSource.Stop();
        mainMenuMusicSource.Stop();
        mainMenuMusicSource.Play();
        StartButton.onClick.AddListener(() => StartButtonPressed());
        LoadButton.onClick.AddListener(() => LoadButtonPressed());
        OptionsButton.onClick.AddListener(() => OptionsButtonPressed());
        CreditsButton.onClick.AddListener(() => CreditsButtonPressed());
        CreditsCancel.onClick.AddListener(() => CreditsCancelButtonPressed());
        ControlsButton.onClick.AddListener(() => ControlsButtonPressed());
        ControlsCancel.onClick.AddListener(() => ControlsCancelButtonPressed());
        LoadCancel.onClick.AddListener(() => LoadCancelPressed());
        Quit.onClick.AddListener(() => onQuit());

        if (System.IO.File.Exists(Application.persistentDataPath + "/save1.json"))
        {
            Load1.onClick.AddListener(() => Load(1));
            save = JsonUtility.FromJson<Save_progress>(File.ReadAllText(Application.persistentDataPath + "/save1.json"));
            Text1.text = "Save 1 ( " + save.date + ")";
        }
        if (System.IO.File.Exists(Application.persistentDataPath + "/save2.json"))
        {
            Load2.onClick.AddListener(() => Load(2));
            save = JsonUtility.FromJson<Save_progress>(File.ReadAllText(Application.persistentDataPath + "/save2.json"));
            Text2.text = "Save 2 ( " + save.date + ")";
        }
        if (System.IO.File.Exists(Application.persistentDataPath + "/save3.json"))
        {
            Load3.onClick.AddListener(() => Load(3));
            save = JsonUtility.FromJson<Save_progress>(File.ReadAllText(Application.persistentDataPath + "/save3.json"));
            Text3.text = "Save 3 ( " + save.date + ")";
        }
        if (System.IO.File.Exists(Application.persistentDataPath + "/save4.json"))
        {
            Load4.onClick.AddListener(() => Load(4));
            save = JsonUtility.FromJson<Save_progress>(File.ReadAllText(Application.persistentDataPath + "/save4.json"));
            Text4.text = "Save 4 ( " + save.date + ")";
        }
        if (System.IO.File.Exists(Application.persistentDataPath + "/save5.json"))
        {
            Load5.onClick.AddListener(() => Load(5));
            save = JsonUtility.FromJson<Save_progress>(File.ReadAllText(Application.persistentDataPath + "/save5.json"));
            Text5.text = "Save 5 ( " + save.date + ")";
        }
    }

    void CreditsButtonPressed()
    {
        mainMenuSource.PlayOneShot(mainMenuSound[0], 1.0f);
        creditsPanel.SetActive(true);
    }

    void CreditsCancelButtonPressed()
    {
        mainMenuSource.PlayOneShot(mainMenuSound[0], 1.0f);
        creditsPanel.SetActive(false);
    }

    void ControlsButtonPressed()
    {
        mainMenuSource.PlayOneShot(mainMenuSound[0], 1.0f);
        controlsPanel.SetActive(true);
    }

    void ControlsCancelButtonPressed()
    {
        mainMenuSource.PlayOneShot(mainMenuSound[0], 1.0f);
        controlsPanel.SetActive(false);
    }

    void LoadCancelPressed()
    {
        mainMenuSource.PlayOneShot(mainMenuSound[0], 1.0f);
        loading_panel.SetActive(false);
    }

    void OptionsButtonPressed()
    {
        mainMenuSource.PlayOneShot(mainMenuSound[0], 1.0f);
        options.SetActive(true);
    }

    void LoadButtonPressed()
    {
        mainMenuSource.PlayOneShot(mainMenuSound[0], 1.0f);
        loading_panel.SetActive(true);
    }
    void Load(int load_num)
    {
        load.load = load_num;
        string jsonData = JsonUtility.ToJson(load, true);
        File.WriteAllText(Application.persistentDataPath + "/load.json", jsonData);
        mainMenuSource.PlayOneShot(mainMenuSound[0], 1.0f);
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    void StartButtonPressed()
    {
        load.load = 0;
        string jsonData = JsonUtility.ToJson(load, true);
        File.WriteAllText(Application.persistentDataPath + "/load.json", jsonData);
        mainMenuSource.PlayOneShot(mainMenuSound[0], 1.0f);
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    void onQuit()
    {
        Application.Quit();
    }
}