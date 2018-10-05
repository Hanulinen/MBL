using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class Load_menu : MonoBehaviour
{
    [SerializeField]
    Button Load1, Load2, Load3, Load4, Load5, LoadCancel;
    public Loading load;
    [SerializeField]
    AudioSource menuSource;
    [SerializeField]
    AudioClip[] menuSound;
    [SerializeField]
    GameObject Loadpanel;

    void Start()
    {
        load = new Loading();
        LoadCancel.onClick.AddListener(() => onCancel());

        if (System.IO.File.Exists(Application.persistentDataPath + "/save1.json"))
        {
            Load1.onClick.AddListener(() => Load(1));
        }
        if (System.IO.File.Exists(Application.persistentDataPath + "/save2.json"))
        {
            Load2.onClick.AddListener(() => Load(2));
        }
        if (System.IO.File.Exists(Application.persistentDataPath + "/save3.json"))
        {
            Load3.onClick.AddListener(() => Load(3));
        }
        if (System.IO.File.Exists(Application.persistentDataPath + "/save4.json"))
        {
            Load4.onClick.AddListener(() => Load(4));
        }
        if (System.IO.File.Exists(Application.persistentDataPath + "/save5.json"))
        {
            Load5.onClick.AddListener(() => Load(5));
        }
    }

    void Load(int load_num)
    {
        load.load = load_num;
        string jsonData = JsonUtility.ToJson(load, true);
        File.WriteAllText(Application.persistentDataPath + "/load.json", jsonData);
        menuSource.PlayOneShot(menuSound[0], 1.0f);
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }

    void onCancel()
    {
        Loadpanel.SetActive(false);
    }
}