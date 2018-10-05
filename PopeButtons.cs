using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopeButtons : MonoBehaviour {

    Button TipsButton;
    Button HealButton;
    Button ObjectsButton;
    Button ByePopeButton;
    //DialogueLists dialogue;
    public NPCConversation pope;

	// Use this for initialization
	void Start () {
        TipsButton = GameObject.Find("TipsButton").GetComponent<Button>();
        HealButton = GameObject.Find("HealButton").GetComponent<Button>();
        ObjectsButton = GameObject.Find("ObjectsButton").GetComponent<Button>();
        ByePopeButton = GameObject.Find("ByePopeButton").GetComponent<Button>();
        TipsButton.onClick.AddListener(() => pope.StartButtonConversation("Tips"));
        HealButton.onClick.AddListener(() => pope.StartButtonConversation("Heal"));
        ObjectsButton.onClick.AddListener(() => pope.StartButtonConversation("Objects"));
        ByePopeButton.onClick.AddListener(() => pope.StartButtonConversation("ByePope"));
        //dialogue = GameObject.Find("Gameplay").GetComponent<DialogueLists>();
        TipsButton.gameObject.SetActive(false);
        HealButton.gameObject.SetActive(false);
        ObjectsButton.gameObject.SetActive(false);
        ByePopeButton.gameObject.SetActive(false);
        pope = GameObject.Find("Pope").GetComponent<NPCConversation>();

    }

    public void SetPopeButtonsActive()
    {
        TipsButton.gameObject.SetActive(true);
        HealButton.gameObject.SetActive(true);
        ObjectsButton.gameObject.SetActive(true);
        ByePopeButton.gameObject.SetActive(true);
    }

    public void SetPopeButtonsInactive()
    {
        TipsButton.gameObject.SetActive(false);
        HealButton.gameObject.SetActive(false);
        ObjectsButton.gameObject.SetActive(false);
        ByePopeButton.gameObject.SetActive(false);
    }
}
