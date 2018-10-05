using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPCConversation : MonoBehaviour {

    [SerializeField] //love level hearts
    Image heart0,heart1, heart2, heart3, heart4, heart5;
    public GameObject talktext, examinetext, giftgivingcancelbutton;
    public Button giftgivingcancelbuttonB;
    //Is true if player is next to an NPC.
    bool nextToNPC;
    //Is true if a conversation is playing.
    public bool conversationPlaying;
    bool levelupconversationplaying;              
    bool hateconversationplaying;
    //Indicates whether or not this is the first conversation with lover. Initialized to true.
    bool firstConversation;
    //Indicates wheter or not the current conversation is started by pressing a button from a buttonset. Initialized to false.
    bool buttonConversation;
    bool buttonsActive;
    bool choiceOnGoing;
    bool succesfulgift;
    public bool hate;
    //Test iterator to demonstrate changing text.
    int i;
    //There are 3 types of NPC's. Lovers, Major NPC's and Minor NPC's.
    //Depending on the type, a different type of conversation is needed.
    public int NPCType;
    //A random number that determines the dialogue spoken by the minor NPC;
    int rand;
    //Lover-NPC's have a love level variable that determines their familiarity with the main character an thus their lines;
    public int lovelevel;
    public int nextlevel;
    public int hatelevel;
    //Every NPC has a name that is used to get their own lines from the script file.
    public string NPCName;
    string who;
    //Lover's conversation buttons
    Button TalkButton;
    Button AskButton;
    Button FlirtButton;
    Button GiftButton;
    Button QuestButton;
    Button ByeButton;
    Button RumorsButton;
    Button BuyButton;

    Button ByeShopButton;
    public Button A;
    public Button B;
    public Button C;
    //Button name that is pressed
    public string pressedButtonName;
    //Text in the button.
    string myText;
    //Text being shown letter by letter.
    string currentText = "";
    //Full text to show
    string fullText;
    //Text show speed. When the text flows slower and player presses E while text is flowing
    //it gets bugged. So leave it at this speed.
    float textDelay = 0.005f;
    //Script where all the dialogue is located.
    DialogueLists dialogues;
    //Accesses the script Textbox to turn on and off the textbox
    Textbox myTextbox;
    PlayerMovement myPlayerMovement;
    //source for audio
    public AudioSource fxSource;
    public AudioClip[] achivementSounds;


    public bool GivingGift { get; set; }
    public PlayerInventory Playerinventory { get; set; }

    bool objectOfLove;

    void Awake () {

        lovelevel = 0;
        nextlevel = 0;
        hate = false;

        nextToNPC = false;
        conversationPlaying = false;
        firstConversation = true;
        buttonConversation = false;
        buttonsActive = true;
        choiceOnGoing = false;
        levelupconversationplaying = false;
        hateconversationplaying = false;
        objectOfLove = false;

        i = 1;

        myPlayerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        myTextbox = GameObject.Find("TextBox").GetComponent<Textbox>();
        dialogues = GameObject.Find("Gameplay").GetComponent<DialogueLists>();
        TalkButton = GameObject.Find("TalkButton").GetComponent<Button>();
        AskButton = GameObject.Find("AskButton").GetComponent<Button>();
        FlirtButton = GameObject.Find("FlirtButton").GetComponent<Button>();
        GiftButton = GameObject.Find("GiftButton").GetComponent<Button>();
        QuestButton = GameObject.Find("QuestButton").GetComponent<Button>();
        ByeButton = GameObject.Find("ByeButton").GetComponent<Button>();
        RumorsButton = GameObject.Find("RumorsButton").GetComponent<Button>();
        BuyButton = GameObject.Find("BuyButton").GetComponent<Button>();

        ByeShopButton = GameObject.Find("ByeShopButton").GetComponent<Button>();
        TalkButton.onClick.AddListener(() => StartButtonConversation("Talk"));
        AskButton.onClick.AddListener(() => StartButtonConversation("Ask"));
        FlirtButton.onClick.AddListener(() => StartButtonConversation("Flirt"));
        GiftButton.onClick.AddListener(() => StartButtonConversation("Gift"));
        QuestButton.onClick.AddListener(() => StartButtonConversation("Quest"));
        ByeButton.onClick.AddListener(() => StartButtonConversation("Bye"));
        RumorsButton.onClick.AddListener(() => StartButtonConversation("Rumors"));
        BuyButton.onClick.AddListener(() => StartButtonConversation("Buy"));

        ByeShopButton.onClick.AddListener(() => StartButtonConversation("ByeShop"));
        A = GameObject.Find("ChoiceA").GetComponent<Button>();
        B = GameObject.Find("ChoiceB").GetComponent<Button>();
        C = GameObject.Find("ChoiceC").GetComponent<Button>();
        A.onClick.AddListener(() => checkIfCorrect(1));
        B.onClick.AddListener(() => checkIfCorrect(2));
        C.onClick.AddListener(() => checkIfCorrect(3));
        succesfulgift = false;
        GivingGift = false;
        Playerinventory = GameObject.Find("Inventory").GetComponent<PlayerInventory>();
        giftgivingcancelbuttonB.onClick.AddListener(() => cancelgivinggift());
    }

    // Update is called once per frame
    void Update ()
    {
        if (GivingGift)
        {
            giftgivingcancelbutton.SetActive(true);
        }
        else
        {
            giftgivingcancelbutton.SetActive(false);
        }

        if (NPCType == 3)
        {
            Updatehearts(lovelevel, hate);
        }

        if (!PauseMenu.paused && !ShopInventory.Instance.IsOpen)
        {
            //Debug.Log(dialogues.howManyMonstersHateYou);
            if (A.gameObject.activeSelf)
            {
                SetLoverButtonsInactive();
            }
            if (buttonsActive)
            {
                TalkButton.gameObject.SetActive(false);
                AskButton.gameObject.SetActive(false);
                FlirtButton.gameObject.SetActive(false);
                GiftButton.gameObject.SetActive(false);
                QuestButton.gameObject.SetActive(false);
                ByeButton.gameObject.SetActive(false);
                RumorsButton.gameObject.SetActive(false);
                BuyButton.gameObject.SetActive(false);

                ByeShopButton.gameObject.SetActive(false);
                dialogues.end.Deactivate();
                buttonsActive = false;
            }
            //Increases lovelevel when conditions are met
            if (nextlevel == lovelevel + 1 && lovelevel < 5)
            {
                
                this.lovelevel++;
                this.nextlevel = 0;
                this.hatelevel = 0;
                choiceOnGoing = false;
                Debug.Log("LEVEL UP " + NPCName);
                //start level up conversation
                StartLevelUpConversation();
                SetLoverButtonsInactive();
                if (!hate)
                {
                    fxSource.PlayOneShot(achivementSounds[0], 1f);
                }
            }

            if (hatelevel == lovelevel + 1 && lovelevel < 5)
            {
                hate = true;
                choiceOnGoing = false;
                lovelevel = 0;
                hatelevel = 0;
                Debug.Log("HATELEVEL! " + NPCName);
                dialogues.howManyMonstersHateYou++;
                StartHateConversation();
                SetLoverButtonsInactive();
            }


            if (dialogues.itemID == null && pressedButtonName == "Gift")
            {
                Debug.Log("Choosing an item");
                //StopMoving();
                GiftGiving();
                Debug.Log(dialogues.itemID);
                if (Input.GetKeyDown(KeyCode.Tab) || Input.GetButtonDown("Inventory"))
                {
                    conversationPlaying = false;
                    Playerinventory.OpenCloseInventory();
                    GivingGift = false;
                    pressedButtonName = null;
                    EndConversation();
                }
            }
            else if (dialogues.itemID != null && who == gameObject.name)
            {
                conversationPlaying = false;
                Playerinventory.StartCoroutine(Playerinventory.FadeOut());
                Playerinventory.CloseToolTip();
                conversationPlaying = true;


                if (who == "Yola")
                {
                    if (dialogues.yola_giftlist.Contains(dialogues.itemID))
                    {
                        dialogues.spriteChanger.ChangingSprites(dialogues.yola_gifts_faces[lovelevel]); myText = dialogues.yola_gifts[lovelevel];
                        succesfulgift = true;

                    }
                    else if (dialogues.itemID == "Golden crown" && lovelevel == 5)
                    {
                        dialogues.spriteChanger.ChangingSprites(dialogues.yola_gifts_faces[lovelevel + 1]); myText = dialogues.yola_gifts[lovelevel + 1];
                        objectOfLove = true;
                    }
                    else
                    {
                        dialogues.spriteChanger.ChangingSprites(dialogues.yola_badgifts_faces[lovelevel]); myText = dialogues.yola_badgifts[lovelevel];
                    }
                }
                else if (who == "Gru")
                {
                    if (dialogues.gru_giftlist.Contains(dialogues.itemID))
                    {
                        dialogues.spriteChanger.ChangingSprites(dialogues.gru_gifts_faces[lovelevel]); myText = dialogues.gru_gifts[lovelevel];
                        succesfulgift = true;
                    }
                    else if (dialogues.itemID == "Severed head" && lovelevel == 5)
                    {
                        dialogues.spriteChanger.ChangingSprites(dialogues.gru_gifts_faces[lovelevel + 1]); myText = dialogues.gru_gifts[lovelevel + 1];
                        objectOfLove = true;
                    }
                    else
                    {
                        dialogues.spriteChanger.ChangingSprites(dialogues.gru_badgifts_faces[lovelevel]); myText = dialogues.gru_badgifts[lovelevel];
                    }
                }
                else if (who == "Fenris")
                {
                    if (dialogues.fenris_giftlist.Contains(dialogues.itemID))
                    {
                        dialogues.spriteChanger.ChangingSprites(dialogues.fenris_gifts_faces[lovelevel]); myText = dialogues.fenris_gifts[lovelevel];
                        succesfulgift = true;

                    }
                    else if (dialogues.itemID == "Pink collar" && lovelevel == 5)
                    {
                        dialogues.spriteChanger.ChangingSprites(dialogues.fenris_gifts_faces[lovelevel + 1]); myText = dialogues.fenris_gifts[lovelevel + 1];
                        objectOfLove = true;
                    }
                    else
                    {
                        dialogues.spriteChanger.ChangingSprites(dialogues.fenris_badgifts_faces[lovelevel]); myText = dialogues.fenris_badgifts[lovelevel];
                    }
                }
                else if (who == "Catherine")
                {
                    if (dialogues.catherine_giftlist.Contains(dialogues.itemID))
                    {
                        dialogues.spriteChanger.ChangingSprites(dialogues.catherine_gifts_faces[lovelevel]); myText = dialogues.catherine_gifts[lovelevel];
                        succesfulgift = true;

                    }
                    else if (dialogues.itemID == "Parasol" && lovelevel == 5)
                    {
                        dialogues.spriteChanger.ChangingSprites(dialogues.catherine_gifts_faces[lovelevel + 1]); myText = dialogues.catherine_gifts[lovelevel + 1];
                        objectOfLove = true;
                    }
                    else
                    {
                        dialogues.spriteChanger.ChangingSprites(dialogues.catherine_badgifts_faces[lovelevel]); myText = dialogues.catherine_badgifts[lovelevel];
                    }
                }
                else if (who == "Bobo")
                {
                    if (dialogues.bobo_giftlist.Contains(dialogues.itemID))
                    {
                        dialogues.spriteChanger.ChangingSprites(dialogues.bobo_gifts_faces[lovelevel]); myText = dialogues.bobo_gifts[lovelevel];
                        succesfulgift = true;

                    }
                    else if (dialogues.itemID == "Jetpack" && lovelevel == 5)
                    {
                        dialogues.spriteChanger.ChangingSprites(dialogues.bobo_gifts_faces[lovelevel + 1]); myText = dialogues.bobo_gifts[lovelevel + 1];
                        objectOfLove = true;
                    }
                    else
                    {
                        dialogues.spriteChanger.ChangingSprites(dialogues.bobo_badgifts_faces[lovelevel]); myText = dialogues.bobo_badgifts[lovelevel];
                    }
                }
                else if (who == "Therion")
                {
                    if (dialogues.therion_giftlist.Contains(dialogues.itemID))
                    {
                        dialogues.spriteChanger.ChangingSprites(dialogues.therion_gifts_faces[lovelevel]); myText = dialogues.therion_gifts[lovelevel];
                        succesfulgift = true;

                    }
                    else if (dialogues.itemID == "Magnificent cake" && lovelevel == 5)
                    {
                        dialogues.currentConversationLength = 2;
                        dialogues.spriteChanger.ChangingSprites(dialogues.therion_gifts_faces[lovelevel + 1]); myText = dialogues.therion_gifts[lovelevel + 1];
                        objectOfLove = true;
                    }
                    else
                    {
                        dialogues.spriteChanger.ChangingSprites(dialogues.therion_badgifts_faces[lovelevel]); myText = dialogues.therion_badgifts[lovelevel];
                    }
                }
                else
                {
                    myText = "ERROR";
                }
                typeWriter(myText);
                //////////////////
                //OBJECT OF LOVE//
                //////////////////
                if (Input.GetButtonDown("Use"))
                {
                    if (objectOfLove)
                    {
                        if (who == "Yola") { dialogues.spriteChanger.ChangingSprites(dialogues.yola_gifts_faces[lovelevel + 2]); myText = dialogues.yola_gifts[lovelevel + 2]; InventoryManager.Instance.AddItemToPlayerInventory(2, 9); }
                        else if (who == "Gru") { dialogues.spriteChanger.ChangingSprites(dialogues.gru_gifts_faces[lovelevel + 2]); myText = dialogues.gru_gifts[lovelevel + 2]; InventoryManager.Instance.AddItemToPlayerInventory(2, 8); }
                        else if (who == "Fenris") { dialogues.spriteChanger.ChangingSprites(dialogues.fenris_gifts_faces[lovelevel + 2]); myText = dialogues.fenris_gifts[lovelevel + 2]; InventoryManager.Instance.AddItemToPlayerInventory(2, 6); }
                        else if (who == "Catherine") { dialogues.spriteChanger.ChangingSprites(dialogues.catherine_gifts_faces[lovelevel + 2]); myText = dialogues.catherine_gifts[lovelevel + 2]; InventoryManager.Instance.AddItemToPlayerInventory(2, 7); }
                        else if (who == "Bobo") { dialogues.spriteChanger.ChangingSprites(dialogues.bobo_gifts_faces[lovelevel + 2]); myText = dialogues.bobo_gifts[lovelevel + 2]; InventoryManager.Instance.AddItemToPlayerInventory(2, 10); }
                        else if (who == "Therion") { dialogues.spriteChanger.ChangingSprites(dialogues.therion_gifts_faces[lovelevel + 2]); myText = dialogues.therion_gifts[lovelevel + 2]; InventoryManager.Instance.AddItemToPlayerInventory(2, 11); }
                        typeWriter(myText);
                        dialogues.itemID = null;
                        pressedButtonName = null;
                        dialogues.howManyObjectsOfLove++;
                    }
                    else if (lovelevel > 0 && lovelevel < 3 && succesfulgift && dialogues.i == 0)
                    {
                        dialogues.i++;
                        Debug.Log("3");
                        this.nextlevel++;
                        succesfulgift = false;

                    }
                    if (!objectOfLove)
                    {
                        Debug.Log("4");
                        EndConversation();
                        dialogues.itemID = null;
                    }
                }
                //dialogues.SetItemID(null);
            }
            else if (levelupconversationplaying && Input.GetButtonDown("Use") && conversationPlaying && nextToNPC || hateconversationplaying && Input.GetButtonDown("Use") && conversationPlaying && nextToNPC)
            {
                
                Debug.Log("stage 1");
                NextTextMajor();
                if (hate)
                {
                    dialogues.spriteChanger.DisableEverything();
                    dialogues.spriteChanger.leftSprite = 12;
                    EndConversation();
                }

            }

            else if (choiceOnGoing)
            {
                Debug.Log("stage 2");
                StopMoving();
                if (Input.GetButtonDown("Use"))
                {
                    EndConversation();
                    choiceOnGoing = false;
                }

            }
            //If button conversation is playing
            else if (buttonConversation && Input.GetButtonDown("Use") && conversationPlaying && nextToNPC)
            {
                Debug.Log("stage 3");
                if (objectOfLove)
                {
                    objectOfLove = false;
                    EndConversation();
                }
                else NextTextMajor();
            }
            //If conversation is playing and player presses E, the next textbox is loaded;
            else if (Input.GetButtonDown("Use") && conversationPlaying && nextToNPC)
            {
                Debug.Log("stage 4");
                if (NPCType == 1) { NextTextMinor(); }
                else { NextTextMajor(); }
            }
            //Checks every frame if player is next to an npc and E is pressed.
            else if (Input.GetButtonDown("Use") && nextToNPC && !conversationPlaying && who != null && (!InventoryManager.Instance.playerInventory.IsOpen && !InventoryManager.Instance.InvTabButtons.RelatioShipStats.activeInHierarchy && !InventoryManager.Instance.InvTabButtons.ObjectivesPage.activeInHierarchy))
            {
                Debug.Log("stage 5");
                StartConversation();
                //Textbox is set active when conversation starts.
                myTextbox.SetTextBoxActive();
                //A random interer is created to take a random line from a minor NPC's dialogue list.
                rand = Random.Range(0, 3);
                //NPC's type determines the flow of conversation;
                //Minor NPC
                if (NPCType == 1) { myText = dialogues.GetLinesMinor(NPCName, rand); }
                //Major NPC
                else if (NPCType == 2) { myText = dialogues.GetLinesMajor(NPCName, rand); }
                else if (hate) { NextTextMajor(); }
                //Lover NPC
                else { myText = dialogues.GetLinesLover(NPCName, rand, lovelevel, firstConversation); }
                typeWriter(myText);
            }

        }
    }
    //Is executed when trigger is activated.
    void OnTriggerEnter2D(Collider2D col)
    {
        talktext.SetActive(true);
        nextToNPC = true;
        who = this.gameObject.name;
        Playerinventory.SetNPCConversationInstance(who);
    }
    //Is executed when trigger is deactivated.
    void OnTriggerExit2D(Collider2D col)
    {
        talktext.SetActive(false);
        nextToNPC = false;
        who = null;
    }
    //Is executed when button (textbox) or USE button is pressed.
    void NextTextMinor()
    {
        EndConversation();
        dialogues.spriteChanger.DisableEverything();
    }
    //When talking to a major NPC/lover
    void NextTextMajor()
    {
        if (dialogues.currentConversationLength <= dialogues.i)
        {
            //Conversation is over.
            dialogues.spriteChanger.DisableEverything();
            dialogues.spriteChanger.leftSprite = 12;
            EndConversation();
        }
        else
        {
            //Next line from conversaion is shown.
            if (hateconversationplaying) { myText = dialogues.GetLinesHate(NPCName); }
            else if (hate) { myText = dialogues.GetLinesHateGreeting(NPCName); }
            else if (levelupconversationplaying) {  myText = dialogues.GetLinesLevelUp(NPCName,lovelevel); }
            else if (buttonConversation){myText = dialogues.GetLinesButton(pressedButtonName, NPCName, lovelevel);}
            else
            {
                rand = Random.Range(0, 3);
                if (NPCType == 2) { myText = dialogues.GetLinesMajor(NPCName, rand); }
                else { myText = dialogues.GetLinesLover(NPCName, rand, lovelevel, firstConversation); }

            }
            typeWriter(myText);
        }
    }
    //Is executed when conversation starts
    void StartConversation()
    {
        examinetext.SetActive(false);
        Debug.Log("Conversation started");
        conversationPlaying = true;
        StopMoving();
        if (Playerinventory.IsOpen)
        {
            Playerinventory.OpenCloseInventory();
        }
        if (who == null)
        {
            conversationPlaying = false;
            myPlayerMovement.enabled=true;
        }
    }
    //Is executed when a conversation starts via button press
    public void StartButtonConversation(string buttonName)
    {
        if (who == this.NPCName) {
            //Conversation is playing
            conversationPlaying = true;
            //Conversation started via button press is playing
            buttonConversation = true;
            //Button's name is registered
            pressedButtonName = buttonName;
            //Textbox is activated
            myTextbox.SetTextBoxActive();
            StopMoving();
            //A line of text is searched from the dialoguelists
            if (nextToNPC)
            {
                dialogues.ReturnIteratorToTheBeginning();
                myText = dialogues.GetLinesButton(pressedButtonName, NPCName, lovelevel);
                //Typewriiter writes the text flowingly
                typeWriter(myText);
            }
        }

    }
    //Checks the validity of answer
    void checkIfCorrect(int choiceNumber)
    {
        if (who != null)
        {
            EndConversation();
            StartConversation();
            myTextbox.SetTextBoxActive();
            dialogues.SetChoicesInactive();
            
            if (who == "Yola" && nextToNPC)
            {
                if (choiceNumber == dialogues.yola_correct[dialogues.YolaF])
                {
                    dialogues.spriteChanger.ChangingSprites(dialogues.yola_correct_faces[lovelevel]);
                    myText = dialogues.yola_correctanswers[lovelevel];
                    nextlevel++;
                }
                else { hatelevel++; dialogues.spriteChanger.ChangingSprites(dialogues.yola_wronganswers_faces[lovelevel]); myText = dialogues.yola_wronganswers[lovelevel]; }
            }
            else if (who == "Gru" && nextToNPC)
            {
                if (choiceNumber == dialogues.gru_correct[dialogues.GruF])
                {
                    dialogues.spriteChanger.ChangingSprites(dialogues.gru_correct_faces[lovelevel]);
                    myText = dialogues.gru_correctanswers[lovelevel];
                    nextlevel++;
                }
                else { hatelevel++; dialogues.spriteChanger.ChangingSprites(dialogues.gru_wronganswers_faces[lovelevel]); myText = dialogues.gru_wronganswers[lovelevel]; }
            }
            else if (who == "Fenris" && nextToNPC)
            {
                if (choiceNumber == dialogues.fenris_correct[dialogues.FenrisF])
                {
                    dialogues.spriteChanger.ChangingSprites(dialogues.fenris_correct_faces[lovelevel]);
                    myText = dialogues.fenris_correctanswers[lovelevel];
                    nextlevel++;
                }
                else { hatelevel++; dialogues.spriteChanger.ChangingSprites(dialogues.fenris_wronganswers_faces[lovelevel]); myText = dialogues.fenris_wronganswers[lovelevel]; }
            }
            else if (who == "Catherine" && nextToNPC)
            {
                if (choiceNumber == dialogues.catherine_correct[dialogues.CatherineF])
                {
                    dialogues.spriteChanger.ChangingSprites(dialogues.catherine_correct_faces[lovelevel]);
                    myText = dialogues.catherine_correctanswers[lovelevel];
                    nextlevel++;
                }
                else { hatelevel++; dialogues.spriteChanger.ChangingSprites(dialogues.catherine_wronganswers_faces[lovelevel]); myText = dialogues.catherine_wronganswers[lovelevel]; }
            }
            else if (who == "Bobo" && nextToNPC)
            {
                if (choiceNumber == dialogues.bobo_correct[dialogues.BoboF])
                {
                    dialogues.spriteChanger.ChangingSprites(dialogues.bobo_correct_faces[lovelevel]);
                    myText = dialogues.bobo_correctanswers[lovelevel];
                    nextlevel++;
                }
                else { hatelevel++; dialogues.spriteChanger.ChangingSprites(dialogues.bobo_wronganswers_faces[lovelevel]); myText = dialogues.bobo_wronganswers[lovelevel]; }
            }
            else if (who == "Therion" && nextToNPC)
            {
                if (choiceNumber == dialogues.therion_correct[dialogues.TherionF])
                {
                    dialogues.spriteChanger.ChangingSprites(dialogues.therion_correct_faces[lovelevel]);
                    myText = dialogues.therion_correctanswers[lovelevel];
                    nextlevel++;
                }
                else { hatelevel++; dialogues.spriteChanger.ChangingSprites(dialogues.therion_wronganswers_faces[lovelevel]); myText = dialogues.therion_wronganswers[lovelevel]; }
            }
            else { myText = "error from check if correct"; }
            choiceOnGoing = true;
            typeWriter(myText);
        }
    }
    void StartLevelUpConversation()
    {
        conversationPlaying = true;
        levelupconversationplaying = true;
        StopMoving();
        myTextbox.SetTextBoxActive();
        if (nextToNPC)
        {
            dialogues.ReturnIteratorToTheBeginning();
            NextTextMajor();
        }
    }
    void StartHateConversation()
    {
        conversationPlaying = true;
        hateconversationplaying = true;
        StopMoving();
        myTextbox.SetTextBoxActive();
        if (nextToNPC)
        {
            dialogues.ReturnIteratorToTheBeginning();
            NextTextMajor();
        }
    }
    //Is executed when conversation ends
    public void EndConversation()
    {
        if (dialogues.howManyMonstersHateYou>=4)
        {
            SceneManager.LoadScene("GameOver");
        }
        Debug.Log("Ended");
        //Conversation is no longer playing
        conversationPlaying = false;
        //Conversation started via buttonpress is no longer playing
        buttonConversation = false;
        //First conversation with a character is complete
        if (dialogues.tutorialPlayed) {
            firstConversation = false;
        }
        pressedButtonName = null;
        //Textbox is emptied
        myText = "";
        //Sets button sets inactive
        dialogues.popeB.SetPopeButtonsInactive();
        SetLoverButtonsInactive();
        SetShopButtonsInactive();
        //Sets the list iterator in dialogues back to 0
        dialogues.ReturnIteratorToTheBeginning();
        myPlayerMovement.enabled = true;
        //Textbox is set inactive
        myTextbox.SetTextBoxInactive();
        //Tutorialstatus is updated
        if (who == "Pope") { dialogues.tutorialPlayed = true; }
        if (true&&NPCType!=1&&!levelupconversationplaying&&!dialogues.saidBye&&!hate&&dialogues.tutorialPlayed)
        {
            StartConversation();
            myTextbox.SetTextBoxActive();
            dialogues.spriteChanger.ChangingSprites(12);
            rand = Random.Range(0, 3);
            if (NPCType == 2) { myText = dialogues.GetLinesMajor(NPCName, rand); }
            else { myText = dialogues.GetLinesLover(NPCName, rand, lovelevel, firstConversation); }
            typeWriter(myText);
        }
        if (dialogues.saidBye)
        {
            dialogues.spriteChanger.DisableEverything();
        }
        dialogues.saidBye = false;
        levelupconversationplaying = false;
        hateconversationplaying = false;
    }
    //Creates the flowing text effect
    void typeWriter(string myText)
    {
        fullText = myText;
        StartCoroutine(ShowText());
    }


    IEnumerator ShowText()
    {

        for (int i = 0; i - 1 < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            GameObject.Find("Text").GetComponent<Text>().text = currentText;
            yield return new WaitForSecondsRealtime(textDelay);
        }

    }
    public void SetLoverButtonsActive()
    {
        TalkButton.gameObject.SetActive(true);
        AskButton.gameObject.SetActive(true);
        FlirtButton.gameObject.SetActive(true);
        GiftButton.gameObject.SetActive(true);
        QuestButton.gameObject.SetActive(true);
        ByeButton.gameObject.SetActive(true);
    }

    public void SetLoverButtonsInactive()
    {
        TalkButton.gameObject.SetActive(false);
        AskButton.gameObject.SetActive(false);
        FlirtButton.gameObject.SetActive(false);
        GiftButton.gameObject.SetActive(false);
        QuestButton.gameObject.SetActive(false);
        ByeButton.gameObject.SetActive(false);
    }

    public void SetShopButtonsActive()
    {
        RumorsButton.gameObject.SetActive(true);
        BuyButton.gameObject.SetActive(true);

        ByeShopButton.gameObject.SetActive(true);
    }

    public void SetShopButtonsInactive()
    {
        RumorsButton.gameObject.SetActive(false);
        BuyButton.gameObject.SetActive(false);

        ByeShopButton.gameObject.SetActive(false);
    }

    public void StopMoving()
    {
        myPlayerMovement.HandleMovement(Vector2.zero);
        myPlayerMovement.enabled = false;
        
    }


    public void GiftGiving()
    {
        GivingGift = true;
        Playerinventory.StartCoroutine(Playerinventory.FadeIn());
    }

    void Updatehearts(int love, bool myhate) {
        if (!hate)
        {
            switch (love)
            {
                case 0:
                    heart0.enabled = false;
                    heart1.enabled = false;
                    heart2.enabled = false;
                    heart3.enabled = false;
                    heart4.enabled = false;
                    heart5.enabled = false;
                    break;
                case 1:
                    heart0.enabled = false;
                    heart1.enabled = true;
                    heart2.enabled = false;
                    heart3.enabled = false;
                    heart4.enabled = false;
                    heart5.enabled = false;
                    break;
                case 2:
                    heart0.enabled = false;
                    heart1.enabled = true;
                    heart2.enabled = true;
                    heart3.enabled = false;
                    heart4.enabled = false;
                    heart5.enabled = false;
                    break;
                case 3:
                    heart0.enabled = false;
                    heart1.enabled = true;
                    heart2.enabled = true;
                    heart3.enabled = true;
                    heart4.enabled = false;
                    heart5.enabled = false;
                    break;
                case 4:
                    heart0.enabled = false;
                    heart1.enabled = true;
                    heart2.enabled = true;
                    heart3.enabled = true;
                    heart4.enabled = true;
                    heart5.enabled = false;
                    break;
                case 5:
                    heart0.enabled = false;
                    heart1.enabled = true;
                    heart2.enabled = true;
                    heart3.enabled = true;
                    heart4.enabled = true;
                    heart5.enabled = true;
                    break;
                default:
                    Debug.Log("Love level display error");
                    break;
            }
        }
        else // HATE
        {
            heart0.enabled = true;
            heart1.enabled = false;
            heart2.enabled = false;
            heart3.enabled = false;
            heart4.enabled = false;
            heart5.enabled = false;
        }
    }
    public void cancelgivinggift()
    {
        conversationPlaying = false;
        Playerinventory.OpenCloseInventory();
        GivingGift = false;
        pressedButtonName = null;
        EndConversation();
    }
}
