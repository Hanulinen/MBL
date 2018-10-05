using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class Save_manager : MonoBehaviour
{
    [SerializeField]
    GameObject Yola, Bobo, Gru, Fenris, Catherine, Therion, Dialogues, areyousure, Savingpanel, player;
    [SerializeField]
    Button save1, save2, save3, save4, save5, savecancel, sure_yes, sure_no;

    //constructs
    public Save_progress save;
    public Loading load;

    //saved values
    public float currentHealth;
    int slot_int;
    public int lovelevel_Yola;
    public int nextlevel_Yola;
    public int hatelevel_Yola;
    public bool hate_Yola;
    public int lovelevel_Bobo;
    public int nextlevel_Bobo;
    public int hatelevel_Bobo;
    public bool hate_Bobo;
    public int lovelevel_Gru;
    public int nextlevel_Gru;
    public int hatelevel_Gru;
    public bool hate_Gru;
    public int lovelevel_Fenris;
    public int nextlevel_Fenris;
    public int hatelevel_Fenris;
    public bool hate_Fenris;
    public int lovelevel_Catherine;
    public int nextlevel_Catherine;
    public int hatelevel_Catherine;
    public bool hate_Catherine;
    public int lovelevel_Therion;
    public int nextlevel_Therion;
    public int hatelevel_Therion;
    public bool hate_Therion;
    public int YolaQ;
    public int BoboQ;
    public int GruQ;
    public int FenrisQ;
    public int CatherineQ;
    public int TherionQ;
    public int YolaF;
    public int BoboF;
    public int GruF;
    public int FenrisF;
    public int CatherineF;
    public int TherionF;
    public int YolaQUEST;
    public int BoboQUEST;
    public int GruQUEST;
    public int FenrisQUEST;
    public int CatherineQUEST;
    public int TherionQUEST;
    public bool YolaQuestOngoing;
    public bool BoboQuestOngoing;
    public bool GruQuestOngoing;
    public bool FenrisQuestOngoing;
    public bool CatherineQuestOngoing;
    public bool TherionQuestOngoing;
    public int howManyMonstersHateYou;
    public int howManyObjectsOfLove;
    public bool tutorialPlayed;


    void Start()
    {
        save = new Save_progress();
        load = new Loading();
        onLoad();
        save1.onClick.AddListener(() => yousure(1));
        save2.onClick.AddListener(() => yousure(2));
        save3.onClick.AddListener(() => yousure(3));
        save4.onClick.AddListener(() => yousure(4));
        save5.onClick.AddListener(() => yousure(5));
        sure_yes.onClick.AddListener(() => onSave(slot_int));
        sure_no.onClick.AddListener(() => onSaveCancel());
        Savingpanel.SetActive(false);
    }


    void yousure(int my_slot)
    {
        switch (my_slot)
        {
            case 1:
                if (System.IO.File.Exists(Application.persistentDataPath + "/save1.json"))
                {
                    areyousure.SetActive(true);
                    slot_int = 1;
                }
                else
                {
                    onSave(1);
                    Savingpanel.SetActive(false);
                }
                break;
            case 2:
                if (System.IO.File.Exists(Application.persistentDataPath + "/save2.json"))
                {
                    areyousure.SetActive(true);
                    slot_int = 2;
                }
                else
                {
                    onSave(2);
                    Savingpanel.SetActive(false);
                }
                break;
            case 3:
                if (System.IO.File.Exists(Application.persistentDataPath + "/save3.json"))
                {
                    areyousure.SetActive(true);
                    slot_int = 3;
                }
                else
                {
                    onSave(3);
                    Savingpanel.SetActive(false);
                }
                break;
            case 4:
                if (System.IO.File.Exists(Application.persistentDataPath + "/save4.json"))
                {
                    areyousure.SetActive(true);
                    slot_int = 4;
                }
                else
                {
                    onSave(4);
                    Savingpanel.SetActive(false);
                }
                break;
            case 5:
                if (System.IO.File.Exists(Application.persistentDataPath + "/save5.json"))
                {
                    areyousure.SetActive(true);
                    slot_int = 5;
                }
                else
                {
                    onSave(5);
                    Savingpanel.SetActive(false);
                }
                break;
        }
    }

    void onSaveCancel()
    {
        areyousure.SetActive(false);
    }

    public void onSave(int slot)
    {
        DateTime theTime = DateTime.Now;
        string datetime = theTime.ToString("yyyy-MM-dd - HH:mm:ss ");
        save.date = datetime;

        save.currentHealth = player.GetComponent<PlayerHealth>().currentHealth;
        save.lovelevel_Yola = Yola.GetComponent<NPCConversation>().lovelevel;
        save.nextlevel_Yola = Yola.GetComponent<NPCConversation>().nextlevel;
        save.hatelevel_Yola = Yola.GetComponent<NPCConversation>().hatelevel;
        save.hate_Yola = Yola.GetComponent<NPCConversation>().hate;
        save.lovelevel_Bobo = Bobo.GetComponent<NPCConversation>().lovelevel;
        save.nextlevel_Bobo = Bobo.GetComponent<NPCConversation>().nextlevel;
        save.hatelevel_Bobo = Bobo.GetComponent<NPCConversation>().hatelevel;
        save.hate_Bobo = Bobo.GetComponent<NPCConversation>().hate;
        save.lovelevel_Gru = Gru.GetComponent<NPCConversation>().lovelevel;
        save.nextlevel_Gru = Gru.GetComponent<NPCConversation>().nextlevel;
        save.hatelevel_Gru = Gru.GetComponent<NPCConversation>().hatelevel;
        save.hate_Gru = Gru.GetComponent<NPCConversation>().hate;
        save.lovelevel_Fenris = Fenris.GetComponent<NPCConversation>().lovelevel;
        save.nextlevel_Fenris = Fenris.GetComponent<NPCConversation>().nextlevel;
        save.hatelevel_Fenris = Fenris.GetComponent<NPCConversation>().hatelevel;
        save.hate_Fenris = Fenris.GetComponent<NPCConversation>().hate;
        save.lovelevel_Catherine = Catherine.GetComponent<NPCConversation>().lovelevel;
        save.nextlevel_Catherine = Catherine.GetComponent<NPCConversation>().nextlevel;
        save.hatelevel_Catherine = Catherine.GetComponent<NPCConversation>().hatelevel;
        save.hate_Catherine = Catherine.GetComponent<NPCConversation>().hate;
        save.lovelevel_Therion = Therion.GetComponent<NPCConversation>().lovelevel;
        save.nextlevel_Therion = Therion.GetComponent<NPCConversation>().nextlevel;
        save.hatelevel_Therion = Therion.GetComponent<NPCConversation>().hatelevel;
        save.hate_Therion = Therion.GetComponent<NPCConversation>().hate;
        save.YolaQ = Dialogues.GetComponent<DialogueLists>().YolaQ;
        save.BoboQ = Dialogues.GetComponent<DialogueLists>().BoboQ;
        save.GruQ = Dialogues.GetComponent<DialogueLists>().GruQ;
        save.FenrisQ = Dialogues.GetComponent<DialogueLists>().FenrisQ;
        save.CatherineQ = Dialogues.GetComponent<DialogueLists>().CatherineQ;
        save.TherionQ = Dialogues.GetComponent<DialogueLists>().TherionQ;
        save.YolaF = Dialogues.GetComponent<DialogueLists>().YolaF;
        save.BoboF = Dialogues.GetComponent<DialogueLists>().BoboF;
        save.GruF = Dialogues.GetComponent<DialogueLists>().GruF;
        save.FenrisF = Dialogues.GetComponent<DialogueLists>().FenrisF;
        save.CatherineF = Dialogues.GetComponent<DialogueLists>().CatherineF;
        save.TherionF = Dialogues.GetComponent<DialogueLists>().TherionF;
        save.YolaQUEST = Dialogues.GetComponent<DialogueLists>().YolaQUEST;
        save.BoboQUEST = Dialogues.GetComponent<DialogueLists>().BoboQUEST;
        save.GruQUEST = Dialogues.GetComponent<DialogueLists>().GruQUEST;
        save.FenrisQUEST = Dialogues.GetComponent<DialogueLists>().FenrisQUEST;
        save.CatherineQUEST = Dialogues.GetComponent<DialogueLists>().CatherineQUEST;
        save.TherionQUEST = Dialogues.GetComponent<DialogueLists>().TherionQUEST;
        save.YolaQuestOngoing = Dialogues.GetComponent<DialogueLists>().YolaQuestOngoing;
        save.BoboQuestOngoing = Dialogues.GetComponent<DialogueLists>().BoboQuestOngoing;
        save.GruQuestOngoing = Dialogues.GetComponent<DialogueLists>().GruQuestOngoing;
        save.FenrisQuestOngoing = Dialogues.GetComponent<DialogueLists>().FenrisQuestOngoing;
        save.CatherineQuestOngoing = Dialogues.GetComponent<DialogueLists>().CatherineQuestOngoing;
        save.TherionQuestOngoing = Dialogues.GetComponent<DialogueLists>().TherionQuestOngoing;
        save.howManyMonstersHateYou = Dialogues.GetComponent<DialogueLists>().howManyMonstersHateYou;
        save.howManyObjectsOfLove = Dialogues.GetComponent<DialogueLists>().howManyObjectsOfLove;
        save.tutorialPlayed = Dialogues.GetComponent<DialogueLists>().tutorialPlayed;

        string jsonData = JsonUtility.ToJson(save, true);

        switch (slot)
        {
            case 1:
                File.WriteAllText(Application.persistentDataPath + "/save1.json", jsonData);
                break;
            case 2:
                File.WriteAllText(Application.persistentDataPath + "/save2.json", jsonData);
                break;
            case 3:
                File.WriteAllText(Application.persistentDataPath + "/save3.json", jsonData);
                break;
            case 4:
                File.WriteAllText(Application.persistentDataPath + "/save4.json", jsonData);
                break;
            case 5:
                File.WriteAllText(Application.persistentDataPath + "/save5.json", jsonData);
                break;
            case 6:
                File.WriteAllText(Application.persistentDataPath + "/saveDay.json", jsonData);
                break;
            default:
                break;
        }
        areyousure.SetActive(false);
        Savingpanel.SetActive(false);
    }

    void onLoad()
    {
        load = JsonUtility.FromJson<Loading>(File.ReadAllText(Application.persistentDataPath + "/load.json"));
        
        switch (load.load)
        {
            case 1:
                save = JsonUtility.FromJson<Save_progress>(File.ReadAllText(Application.persistentDataPath + "/save1.json"));
                break;
            case 2:
                save = JsonUtility.FromJson<Save_progress>(File.ReadAllText(Application.persistentDataPath + "/save2.json"));
                break;
            case 3:
                save = JsonUtility.FromJson<Save_progress>(File.ReadAllText(Application.persistentDataPath + "/save3.json"));
                break;
            case 4:
                save = JsonUtility.FromJson<Save_progress>(File.ReadAllText(Application.persistentDataPath + "/save4.json"));
                break;
            case 5:
                save = JsonUtility.FromJson<Save_progress>(File.ReadAllText(Application.persistentDataPath + "/save5.json"));
                break;
            case 6:
                save = JsonUtility.FromJson<Save_progress>(File.ReadAllText(Application.persistentDataPath + "/saveDay.json"));
                break;
            default:
                break;
        }
        
        if (load.load != 0)
        {
            player.GetComponent<PlayerHealth>().currentHealth = save.currentHealth;
            Yola.GetComponent<NPCConversation>().lovelevel = save.lovelevel_Yola;
            Yola.GetComponent<NPCConversation>().nextlevel = save.nextlevel_Yola;
            Yola.GetComponent<NPCConversation>().hatelevel = save.hatelevel_Yola;
            Yola.GetComponent<NPCConversation>().hate = save.hate_Yola;
            Bobo.GetComponent<NPCConversation>().lovelevel = save.lovelevel_Bobo;
            Bobo.GetComponent<NPCConversation>().nextlevel = save.nextlevel_Bobo;
            Bobo.GetComponent<NPCConversation>().hatelevel = save.hatelevel_Bobo;
            Bobo.GetComponent<NPCConversation>().hate = save.hate_Bobo;
            Gru.GetComponent<NPCConversation>().lovelevel = save.lovelevel_Gru;
            Gru.GetComponent<NPCConversation>().nextlevel = save.nextlevel_Gru;
            Gru.GetComponent<NPCConversation>().hatelevel = save.hatelevel_Gru;
            Gru.GetComponent<NPCConversation>().hate = save.hate_Gru;
            Fenris.GetComponent<NPCConversation>().lovelevel = save.lovelevel_Fenris;
            Fenris.GetComponent<NPCConversation>().nextlevel = save.nextlevel_Fenris;
            Fenris.GetComponent<NPCConversation>().hatelevel = save.hatelevel_Fenris;
            Fenris.GetComponent<NPCConversation>().hate = save.hate_Fenris;
            Catherine.GetComponent<NPCConversation>().lovelevel = save.lovelevel_Catherine;
            Catherine.GetComponent<NPCConversation>().nextlevel = save.nextlevel_Catherine;
            Catherine.GetComponent<NPCConversation>().hatelevel = save.hatelevel_Catherine;
            Catherine.GetComponent<NPCConversation>().hate = save.hate_Catherine;
            Therion.GetComponent<NPCConversation>().lovelevel = save.lovelevel_Therion;
            Therion.GetComponent<NPCConversation>().nextlevel = save.nextlevel_Therion;
            Therion.GetComponent<NPCConversation>().hatelevel = save.hatelevel_Therion;
            Therion.GetComponent<NPCConversation>().hate = save.hate_Therion;
            Dialogues.GetComponent<DialogueLists>().YolaQ = save.YolaQ;
            Dialogues.GetComponent<DialogueLists>().BoboQ = save.BoboQ;
            Dialogues.GetComponent<DialogueLists>().GruQ = save.GruQ;
            Dialogues.GetComponent<DialogueLists>().FenrisQ = save.FenrisQ;
            Dialogues.GetComponent<DialogueLists>().CatherineQ = save.CatherineQ;
            Dialogues.GetComponent<DialogueLists>().TherionQ = save.TherionQ;
            Dialogues.GetComponent<DialogueLists>().YolaF = save.YolaF;
            Dialogues.GetComponent<DialogueLists>().BoboF = save.BoboF;
            Dialogues.GetComponent<DialogueLists>().GruF = save.GruF;
            Dialogues.GetComponent<DialogueLists>().FenrisF = save.FenrisF;
            Dialogues.GetComponent<DialogueLists>().CatherineF = save.CatherineF;
            Dialogues.GetComponent<DialogueLists>().TherionF = save.TherionF;
            Dialogues.GetComponent<DialogueLists>().YolaQUEST = save.YolaQUEST;
            Dialogues.GetComponent<DialogueLists>().BoboQUEST = save.BoboQUEST;
            Dialogues.GetComponent<DialogueLists>().GruQUEST = save.GruQUEST;
            Dialogues.GetComponent<DialogueLists>().FenrisQUEST = save.FenrisQUEST;
            Dialogues.GetComponent<DialogueLists>().CatherineQUEST = save.CatherineQUEST;
            Dialogues.GetComponent<DialogueLists>().TherionQUEST = save.TherionQUEST;
            Dialogues.GetComponent<DialogueLists>().YolaQuestOngoing = save.YolaQuestOngoing;
            Dialogues.GetComponent<DialogueLists>().BoboQuestOngoing = save.BoboQuestOngoing;
            Dialogues.GetComponent<DialogueLists>().GruQuestOngoing = save.GruQuestOngoing;
            Dialogues.GetComponent<DialogueLists>().FenrisQuestOngoing = save.FenrisQuestOngoing;
            Dialogues.GetComponent<DialogueLists>().CatherineQuestOngoing = save.CatherineQuestOngoing;
            Dialogues.GetComponent<DialogueLists>().TherionQuestOngoing = save.TherionQuestOngoing;
            Dialogues.GetComponent<DialogueLists>().howManyMonstersHateYou = save.howManyMonstersHateYou;
            Dialogues.GetComponent<DialogueLists>().howManyObjectsOfLove = save.howManyObjectsOfLove;
            Dialogues.GetComponent<DialogueLists>().tutorialPlayed = save.tutorialPlayed;
        }
    }
}
