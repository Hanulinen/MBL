using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public Loading load;
    public Save_progress save;
    [SerializeField]
    Text Text1, Text2, Text3, Text4, Text5, Text6, Text7, Text8, Text9, Text10;
    [SerializeField]
    GameObject pauseMenu, optionsMenu, returnMenu, saveMenu, loadMenu;
    [SerializeField]
    Button returnMenuB, returnCancelB, returnyesB;
    [SerializeField]
    GameObject settings;
    public AudioSource menuSource;
    public AudioClip[] menuSound;
    static PauseMenu instance;
    static int MainMenu = 0;
    public static bool paused;

    public static PauseMenu Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PauseMenu>();
            }
            return instance;
        }
    }


    void Start()
    {
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(false);
        paused = false;
        returnMenuB.onClick.AddListener(() => ReturnToMainMenu());
        returnCancelB.onClick.AddListener(() => onReturncancel());
        returnyesB.onClick.AddListener(() => onReturnyes());
    }

    void Update()
    {
        
        if (Input.GetButtonDown("Pause"))
        {
            if (!paused)
            {
                Pause();
            }
            else if (!optionsMenu.activeInHierarchy)
            {
                
                if (!loadMenu.activeSelf && !saveMenu.activeSelf && !optionsMenu.activeSelf)
                {
                    Resume();
                }
                if (saveMenu.activeSelf)
                {
                    saveMenu.SetActive(false);
                    menuSource.PlayOneShot(menuSound[0], 1f);
                }
                if (loadMenu.activeSelf)
                {
                    loadMenu.SetActive(false);
                    menuSource.PlayOneShot(menuSound[0], 1f);
                }
                
            }
           
        }
    }


    public void Pause()
    {
        menuSource.PlayOneShot(menuSound[0], 1f);
        paused = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);

    }

    public void Resume()
    {
        menuSource.PlayOneShot(menuSound[0], 1f);
        paused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    void ReturnToMainMenu()
    {
        menuSource.PlayOneShot(menuSound[0], 1f);
        returnMenu.SetActive(true);
    }

    void onReturncancel()
    {
        returnMenu.SetActive(false);
    }

    void onReturnyes()
    {
        SceneManager.LoadScene(MainMenu);
    }

    public void OnSaveMenu()
    {
        if (System.IO.File.Exists(Application.persistentDataPath + "/save1.json"))
        {
            save = JsonUtility.FromJson<Save_progress>(File.ReadAllText(Application.persistentDataPath + "/save1.json"));
            Text1.text = "Save 1 ( " + save.date + ")";
        }
        if (System.IO.File.Exists(Application.persistentDataPath + "/save2.json"))
        {
            save = JsonUtility.FromJson<Save_progress>(File.ReadAllText(Application.persistentDataPath + "/save2.json"));
            Text2.text = "Save 2 ( " + save.date + ")";
        }
        if (System.IO.File.Exists(Application.persistentDataPath + "/save3.json"))
        {
            save = JsonUtility.FromJson<Save_progress>(File.ReadAllText(Application.persistentDataPath + "/save3.json"));
            Text3.text = "Save 3 ( " + save.date + ")";
        }
        if (System.IO.File.Exists(Application.persistentDataPath + "/save4.json"))
        {
            save = JsonUtility.FromJson<Save_progress>(File.ReadAllText(Application.persistentDataPath + "/save4.json"));
            Text4.text = "Save 4 ( " + save.date + ")";
        }
        if (System.IO.File.Exists(Application.persistentDataPath + "/save5.json"))
        {
            save = JsonUtility.FromJson<Save_progress>(File.ReadAllText(Application.persistentDataPath + "/save5.json"));
            Text5.text = "Save 5 ( " + save.date + ")";
        }

        menuSource.PlayOneShot(menuSound[0], 1f);
        saveMenu.SetActive(true);
    }

    public void OnLoadMenu()
    {
        if (System.IO.File.Exists(Application.persistentDataPath + "/save1.json"))
        {
            save = JsonUtility.FromJson<Save_progress>(File.ReadAllText(Application.persistentDataPath + "/save1.json"));
            Text6.text = "Save 1 ( " + save.date + ")";
        }
        if (System.IO.File.Exists(Application.persistentDataPath + "/save2.json"))
        {
            save = JsonUtility.FromJson<Save_progress>(File.ReadAllText(Application.persistentDataPath + "/save2.json"));
            Text7.text = "Save 2 ( " + save.date + ")";
        }
        if (System.IO.File.Exists(Application.persistentDataPath + "/save3.json"))
        {
            save = JsonUtility.FromJson<Save_progress>(File.ReadAllText(Application.persistentDataPath + "/save3.json"));
            Text8.text = "Save 3 ( " + save.date + ")";
        }
        if (System.IO.File.Exists(Application.persistentDataPath + "/save4.json"))
        {
            save = JsonUtility.FromJson<Save_progress>(File.ReadAllText(Application.persistentDataPath + "/save4.json"));
            Text9.text = "Save 4 ( " + save.date + ")";
        }
        if (System.IO.File.Exists(Application.persistentDataPath + "/save5.json"))
        {
            save = JsonUtility.FromJson<Save_progress>(File.ReadAllText(Application.persistentDataPath + "/save5.json"));
            Text10.text = "Save 5 ( " + save.date + ")";
        }
        menuSource.PlayOneShot(menuSound[0], 1f);
        loadMenu.SetActive(true);
    }

    public void onSaveCancel()
    {
        menuSource.PlayOneShot(menuSound[0], 1f);
        saveMenu.SetActive(false);
    }

    public void OnOptionsMenu()
    {
        menuSource.PlayOneShot(menuSound[0], 1f);
        optionsMenu.SetActive(true);
    }

}
