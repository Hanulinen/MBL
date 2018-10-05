using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestPageText : MonoBehaviour
{
    private static QuestPageText instance;
    public static QuestPageText Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<QuestPageText>();
            }
            return instance;
        }
    }

    DialogueLists dialogLists;
    List<Text> textBoxes = new List<Text>();

    void Awake()
    {
        dialogLists = FindObjectOfType<DialogueLists>();

        textBoxes.Add(GameObject.Find("BoboQuests").GetComponent<Text>());
        textBoxes.Add(GameObject.Find("CatherineQuests").GetComponent<Text>());
        textBoxes.Add(GameObject.Find("FenrisQuests").GetComponent<Text>());
        textBoxes.Add(GameObject.Find("GruQuests").GetComponent<Text>());
        textBoxes.Add(GameObject.Find("TherionQuests").GetComponent<Text>());
        textBoxes.Add(GameObject.Find("YolaQuests").GetComponent<Text>());

        for (int i = 0; i < textBoxes.Count; i++)
        {
            textBoxes[i].text = string.Empty;
        }
    }

    public void CheckQuests()
    {
        if (dialogLists.BoboQuestOngoing)
        {
            textBoxes[0].text = "Find : " + dialogLists.bobo_questitems[dialogLists.BoboQUEST] + " X" + dialogLists.bobo_questitems_amount[dialogLists.BoboQUEST];
        }
        else
        {
            textBoxes[0].text = string.Empty;
        }
        if (dialogLists.CatherineQuestOngoing)
        {
            textBoxes[1].text = "Find : " + dialogLists.catherine_questitems[dialogLists.CatherineQUEST] + " X" + dialogLists.catherine_questitems_amount[dialogLists.CatherineQUEST];
        }
        else
        {
            textBoxes[1].text = string.Empty;
        }
        if (dialogLists.FenrisQuestOngoing)
        {
            textBoxes[2].text = "Find : " + dialogLists.fenris_questitems[dialogLists.FenrisQUEST] + " X" + dialogLists.fenris_questitems_amount[dialogLists.FenrisQUEST];
        }
        else
        {
            textBoxes[2].text = string.Empty;
        }
        if (dialogLists.GruQuestOngoing)
        {
            textBoxes[3].text = "Find : " + dialogLists.gru_questitems[dialogLists.GruQUEST] + " X" + dialogLists.gru_questitems_amount[dialogLists.GruQUEST];
        }
        else
        {
            textBoxes[3].text = string.Empty;
        }
        if (dialogLists.TherionQuestOngoing)
        {
            textBoxes[4].text = "Find : " + dialogLists.therion_questitems[dialogLists.TherionQUEST] + " X" + dialogLists.therion_questitems_amount[dialogLists.TherionQUEST];
        }
        else
        {
            textBoxes[4].text = string.Empty;
        }
        if (dialogLists.YolaQuestOngoing)
        {
            textBoxes[5].text = "Find : " + dialogLists.yola_questitems[dialogLists.YolaQUEST] + " X" + dialogLists.yola_questitems_amount[dialogLists.YolaQUEST];
        }
        else
        {
            textBoxes[5].text = string.Empty;
        }
    }
}
