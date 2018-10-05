using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DialogueLists : MonoBehaviour
{    
    //save loadconstructs
    public Loading load;

    public int howManyMonstersHateYou;
    public int howManyObjectsOfLove;
    //Signals to the NPC scripts if the tutorial has been played. Initialized to false;
    public bool tutorialPlayed;
    public bool saidBye;
    //Iterator for going through the lists
    public int i;
    int rand;
    //Random number for pope's random tips
    int popeTips;
    int choiceNumber;
    //Tells the other script how many lines the current conversation has;
    public int currentConversationLength;
    public string itemID;
    //Example list
    public List<string> example = new List<string>();
    //Grandma's list
    public SortedList<string, int> grandma = new SortedList<string, int>();
    //Guard's list
    public SortedList<string, int> guard = new SortedList<string, int>();
    //Eldritch horror's list
    public SortedList<string, int> horror = new SortedList<string, int>();
    //Pope's lists
    public List<string> pope_greeting = new List<string>(); public List<int> pope_greeting_faces = new List<int>();
    public List<string> pope_tutorial = new List<string>(); public List<int> pope_tutorial_faces = new List<int>();
    public List<string> pope_tips = new List<string>();     public List<int> pope_tips_faces = new List<int>();
    public List<string> pope_healing = new List<string>();  public List<int> pope_healing_faces = new List<int>();
    public List<string> pope_objects = new List<string>();  public List<int> pope_objects_faces = new List<int>();
    //Shopkeeper's lists
    public List<string> shopkeeper_greeting = new List<string>();   public List<int> shopkeeper_greeting_faces = new List<int>();
    public List<string> shopkeeper_buy = new List<string>();        public List<int> shopkeeper_buy_faces = new List<int>();
    public List<string> shopkeeper_sell = new List<string>();       public List<int> shopkeeper_sell_faces = new List<int>();
    public List<string> shopkeeper_rumors = new List<string>();     public List<int> shopkeeper_rumors_faces = new List<int>();
    //Innkeeper's lists
    public List<string> innkeeper_greeting = new List<string>();    public List<int> innkeeper_greeting_faces = new List<int>();
    public List<string> innkeeper_buy = new List<string>();         public List<int> innkeeper_buy_faces = new List<int>();
    public List<string> innkeeper_sell = new List<string>();        public List<int> innkeeper_sell_faces = new List<int>();
    public List<string> innkeeper_rumors = new List<string>();      public List<int> innkeeper_rumors_faces = new List<int>();
    //Yola's lists
    public List<string> yola_first = new List<string>();                        public List<int> yola_first_faces = new List<int>();
    public List<string> yola_greetings = new List<string>();                    public List<int> yola_greetings_faces = new List<int>();
    public List<string> yola_byes = new List<string>();                         public List<int> yola_byes_faces = new List<int>();
    public List<string> yola_hay = new List<string>();                          public List<int> yola_hay_faces = new List<int>();
    public List<string> yola_levelup1 = new List<string>();                     public List<int> yola_levelup1_faces = new List<int>();
    public List<string> yola_levelup2 = new List<string>();                     public List<int> yola_levelup2_faces = new List<int>();
    public List<string> yola_levelup3 = new List<string>();                     public List<int> yola_levelup3_faces = new List<int>();
    public List<string> yola_levelup4 = new List<string>();                     public List<int> yola_levelup4_faces = new List<int>();
    public List<string> yola_levelup5 = new List<string>();                     public List<int> yola_levelup5_faces = new List<int>();
    public List<string> yola_gifts = new List<string>();                        public List<int> yola_gifts_faces = new List<int>();
    public List<string> yola_badgifts = new List<string>();                     public List<int> yola_badgifts_faces = new List<int>();
    public List<string> yola_nothingtosay = new List<string>();                 public List<int> yola_nothingtosay_faces = new List<int>();
    public List<string> yola_flirts = new List<string>();                       public List<int> yola_flirts_faces = new List<int>();
    public List<string> yola_wronganswers = new List<string>();                 public List<int> yola_wronganswers_faces = new List<int>();
    public List<string> yola_correctanswers = new List<string>();               public List<int> yola_correct_faces = new List<int>();
    public List<string> yola_choices = new List<string>();
    public List<string> yola_question1 = new List<string>();                    public List<int> yola_question1_faces = new List<int>();
    public List<string> yola_question2 = new List<string>();                    public List<int> yola_question2_faces = new List<int>();
    public List<string> yola_question3 = new List<string>();                    public List<int> yola_question3_faces = new List<int>();
    public List<string> yola_question4 = new List<string>();                    public List<int> yola_question4_faces = new List<int>();
    public List<string> yola_question5 = new List<string>();                    public List<int> yola_question5_faces = new List<int>();
    public List<string> yola_question6 = new List<string>();                    public List<int> yola_question6_faces = new List<int>();
    public List<string> yola_question7 = new List<string>();                    public List<int> yola_question7_faces = new List<int>();
    public List<string> yola_question8 = new List<string>();                    public List<int> yola_question8_faces = new List<int>();
    public List<string> yola_question9 = new List<string>();                    public List<int> yola_question9_faces = new List<int>();
    public List<string> yola_question10 = new List<string>();                   public List<int> yola_question10_faces = new List<int>();
    public List<string> yola_question11 = new List<string>();                   public List<int> yola_question11_faces = new List<int>();
    public List<string> yola_question12 = new List<string>();                   public List<int> yola_question12_faces = new List<int>();
    public List<string> yola_question13 = new List<string>();                   public List<int> yola_question13_faces = new List<int>();
    public List<string> yola_question14 = new List<string>();                   public List<int> yola_question14_faces = new List<int>();
    public List<string> yola_question15 = new List<string>();                   public List<int> yola_question15_faces = new List<int>();
    public List<string> yola_question16 = new List<string>();                   public List<int> yola_question16_faces = new List<int>();
    public List<string> yola_quests = new List<string>();                       public List<int> yola_quests_faces = new List<int>();
    public List<int> yola_correct = new List<int>();
    public List<List<string>> yola_questionLists = new List<List<string>>();    public List<List<int>> yola_questionLists_faces = new List<List<int>>();
    public List<List<string>> yola_levelLists = new List<List<string>>();       public List<List<int>> yola_levelLists_faces = new List<List<int>>();
    //Catherine's lists
    public List<string> catherine_first = new List<string>();                     public List<int> catherine_first_faces = new List<int>();
    public List<string> catherine_greetings = new List<string>();                 public List<int> catherine_greetings_faces = new List<int>();
    public List<string> catherine_byes = new List<string>();                      public List<int> catherine_byes_faces = new List<int>();
    public List<string> catherine_hay = new List<string>();                       public List<int> catherine_hay_faces = new List<int>();
    public List<string> catherine_levelup1 = new List<string>();                  public List<int> catherine_levelup1_faces = new List<int>();
    public List<string> catherine_levelup2 = new List<string>();                  public List<int> catherine_levelup2_faces = new List<int>();
    public List<string> catherine_levelup3 = new List<string>();                  public List<int> catherine_levelup3_faces = new List<int>();
    public List<string> catherine_levelup4 = new List<string>();                  public List<int> catherine_levelup4_faces = new List<int>();
    public List<string> catherine_levelup5 = new List<string>();                  public List<int> catherine_levelup5_faces = new List<int>();
    public List<string> catherine_gifts = new List<string>();                     public List<int> catherine_gifts_faces = new List<int>();
    public List<string> catherine_badgifts = new List<string>();                  public List<int> catherine_badgifts_faces = new List<int>();
    public List<string> catherine_nothingtosay = new List<string>();              public List<int> catherine_nothingtosay_faces = new List<int>();
    public List<string> catherine_flirts = new List<string>();                    public List<int> catherine_flirts_faces = new List<int>();
    public List<string> catherine_wronganswers = new List<string>();              public List<int> catherine_wronganswers_faces = new List<int>();
    public List<string> catherine_correctanswers = new List<string>();            public List<int> catherine_correct_faces = new List<int>();
    public List<string> catherine_choices = new List<string>();
    public List<string> catherine_question1 = new List<string>();                 public List<int> catherine_question1_faces = new List<int>();
    public List<string> catherine_question2 = new List<string>();                 public List<int> catherine_question2_faces = new List<int>();
    public List<string> catherine_question3 = new List<string>();                 public List<int> catherine_question3_faces = new List<int>();
    public List<string> catherine_question4 = new List<string>();                 public List<int> catherine_question4_faces = new List<int>();
    public List<string> catherine_question5 = new List<string>();                 public List<int> catherine_question5_faces = new List<int>();
    public List<string> catherine_question6 = new List<string>();                 public List<int> catherine_question6_faces = new List<int>();
    public List<string> catherine_question7 = new List<string>();                 public List<int> catherine_question7_faces = new List<int>();
    public List<string> catherine_question8 = new List<string>();                 public List<int> catherine_question8_faces = new List<int>();
    public List<string> catherine_question9 = new List<string>();                 public List<int> catherine_question9_faces = new List<int>();
    public List<string> catherine_question10 = new List<string>();                public List<int> catherine_question10_faces = new List<int>();
    public List<string> catherine_question11 = new List<string>();                public List<int> catherine_question11_faces = new List<int>();
    public List<string> catherine_question12 = new List<string>();                public List<int> catherine_question12_faces = new List<int>();
    public List<string> catherine_question13 = new List<string>();                public List<int> catherine_question13_faces = new List<int>();
    public List<string> catherine_question14 = new List<string>();                public List<int> catherine_question14_faces = new List<int>();
    public List<string> catherine_question15 = new List<string>();                public List<int> catherine_question15_faces = new List<int>();
    public List<string> catherine_question16 = new List<string>();                public List<int> catherine_question16_faces = new List<int>();
    public List<string> catherine_quests = new List<string>();                    public List<int> catherine_quests_faces = new List<int>();
    public List<int> catherine_correct = new List<int>();
    public List<List<string>> catherine_questionLists = new List<List<string>>(); public List<List<int>> catherine_questionLists_faces = new List<List<int>>();
    public List<List<string>> catherine_levelLists = new List<List<string>>();     public List<List<int>> catherine_levelLists_faces = new List<List<int>>();
    //Gru's lists
    public List<string> gru_first = new List<string>();            public List<int> gru_first_faces = new List<int>();
    public List<string> gru_greetings = new List<string>();        public List<int> gru_greetings_faces = new List<int>();
    public List<string> gru_byes = new List<string>();             public List<int> gru_byes_faces = new List<int>();
    public List<string> gru_hay = new List<string>();              public List<int> gru_hay_faces = new List<int>();
    public List<string> gru_levelup1 = new List<string>();         public List<int> gru_levelup1_faces = new List<int>();
    public List<string> gru_levelup2 = new List<string>();         public List<int> gru_levelup2_faces = new List<int>();
    public List<string> gru_levelup3 = new List<string>();         public List<int> gru_levelup3_faces = new List<int>();
    public List<string> gru_levelup4 = new List<string>();         public List<int> gru_levelup4_faces = new List<int>();
    public List<string> gru_levelup5 = new List<string>();         public List<int> gru_levelup5_faces = new List<int>();
    public List<string> gru_gifts = new List<string>();            public List<int> gru_gifts_faces = new List<int>();
    public List<string> gru_badgifts = new List<string>();         public List<int> gru_badgifts_faces = new List<int>();
    public List<string> gru_nothingtosay = new List<string>();     public List<int> gru_nothingtosay_faces = new List<int>();
    public List<string> gru_flirts = new List<string>();           public List<int> gru_flirts_faces = new List<int>();
    public List<string> gru_wronganswers = new List<string>();     public List<int> gru_wronganswers_faces = new List<int>();
    public List<string> gru_correctanswers = new List<string>();   public List<int> gru_correct_faces = new List<int>();
    public List<string> gru_choices = new List<string>();
    public List<string> gru_question1 = new List<string>();        public List<int> gru_question1_faces = new List<int>();
    public List<string> gru_question2 = new List<string>();        public List<int> gru_question2_faces = new List<int>();
    public List<string> gru_question3 = new List<string>();        public List<int> gru_question3_faces = new List<int>();
    public List<string> gru_question4 = new List<string>();        public List<int> gru_question4_faces = new List<int>();
    public List<string> gru_question5 = new List<string>();        public List<int> gru_question5_faces = new List<int>();
    public List<string> gru_question6 = new List<string>();        public List<int> gru_question6_faces = new List<int>();
    public List<string> gru_question7 = new List<string>();        public List<int> gru_question7_faces = new List<int>();
    public List<string> gru_question8 = new List<string>();        public List<int> gru_question8_faces = new List<int>();
    public List<string> gru_question9 = new List<string>();        public List<int> gru_question9_faces = new List<int>();
    public List<string> gru_question10 = new List<string>();       public List<int> gru_question10_faces = new List<int>();
    public List<string> gru_question11 = new List<string>();       public List<int> gru_question11_faces = new List<int>();
    public List<string> gru_question12 = new List<string>();       public List<int> gru_question12_faces = new List<int>();
    public List<string> gru_question13 = new List<string>();       public List<int> gru_question13_faces = new List<int>();
    public List<string> gru_question14 = new List<string>();       public List<int> gru_question14_faces = new List<int>();
    public List<string> gru_question15 = new List<string>();       public List<int> gru_question15_faces = new List<int>();
    public List<string> gru_question16 = new List<string>();       public List<int> gru_question16_faces = new List<int>();
    public List<string> gru_quests = new List<string>();           public List<int> gru_quests_faces = new List<int>();
    public List<int> gru_correct = new List<int>();
    public List<List<string>> gru_questionLists = new List<List<string>>();     public List<List<int>> gru_questionLists_faces = new List<List<int>>();
    public List<List<string>> gru_levelLists = new List<List<string>>();        public List<List<int>> gru_levelLists_faces = new List<List<int>>();
    //Bobo's lists
    public List<string> bobo_first = new List<string>();                       public List<int> bobo_first_faces = new List<int>();
    public List<string> bobo_greetings = new List<string>();                   public List<int> bobo_greetings_faces = new List<int>();
    public List<string> bobo_byes = new List<string>();                        public List<int> bobo_byes_faces = new List<int>();
    public List<string> bobo_hay = new List<string>();                         public List<int> bobo_hay_faces = new List<int>();
    public List<string> bobo_levelup1 = new List<string>();                    public List<int> bobo_levelup1_faces = new List<int>();
    public List<string> bobo_levelup2 = new List<string>();                    public List<int> bobo_levelup2_faces = new List<int>();
    public List<string> bobo_levelup3 = new List<string>();                    public List<int> bobo_levelup3_faces = new List<int>();
    public List<string> bobo_levelup4 = new List<string>();                    public List<int> bobo_levelup4_faces = new List<int>();
    public List<string> bobo_levelup5 = new List<string>();                    public List<int> bobo_levelup5_faces = new List<int>();
    public List<string> bobo_gifts = new List<string>();                       public List<int> bobo_gifts_faces = new List<int>();
    public List<string> bobo_badgifts = new List<string>();                    public List<int> bobo_badgifts_faces = new List<int>();
    public List<string> bobo_nothingtosay = new List<string>();                public List<int> bobo_nothingtosay_faces = new List<int>();
    public List<string> bobo_flirts = new List<string>();                      public List<int> bobo_flirts_faces = new List<int>();
    public List<string> bobo_wronganswers = new List<string>();                public List<int> bobo_wronganswers_faces = new List<int>();
    public List<string> bobo_correctanswers = new List<string>();              public List<int> bobo_correct_faces = new List<int>();
    public List<string> bobo_choices = new List<string>();
    public List<string> bobo_question1 = new List<string>();                   public List<int> bobo_question1_faces = new List<int>();
    public List<string> bobo_question2 = new List<string>();                   public List<int> bobo_question2_faces = new List<int>();
    public List<string> bobo_question3 = new List<string>();                   public List<int> bobo_question3_faces = new List<int>();
    public List<string> bobo_question4 = new List<string>();                   public List<int> bobo_question4_faces = new List<int>();
    public List<string> bobo_question5 = new List<string>();                   public List<int> bobo_question5_faces = new List<int>();
    public List<string> bobo_question6 = new List<string>();                   public List<int> bobo_question6_faces = new List<int>();
    public List<string> bobo_question7 = new List<string>();                   public List<int> bobo_question7_faces = new List<int>();
    public List<string> bobo_question8 = new List<string>();                   public List<int> bobo_question8_faces = new List<int>();
    public List<string> bobo_question9 = new List<string>();                   public List<int> bobo_question9_faces = new List<int>();
    public List<string> bobo_question10 = new List<string>();                  public List<int> bobo_question10_faces = new List<int>();
    public List<string> bobo_question11 = new List<string>();                  public List<int> bobo_question11_faces = new List<int>();
    public List<string> bobo_question12 = new List<string>();                  public List<int> bobo_question12_faces = new List<int>();
    public List<string> bobo_question13 = new List<string>();                  public List<int> bobo_question13_faces = new List<int>();
    public List<string> bobo_question14 = new List<string>();                  public List<int> bobo_question14_faces = new List<int>();
    public List<string> bobo_question15 = new List<string>();                  public List<int> bobo_question15_faces = new List<int>();
    public List<string> bobo_question16 = new List<string>();                  public List<int> bobo_question16_faces = new List<int>();
    public List<string> bobo_quests = new List<string>();                      public List<int> bobo_quests_faces = new List<int>();
    public List<int> bobo_correct = new List<int>();
    public List<List<string>> bobo_questionLists = new List<List<string>>();   public List<List<int>> bobo_questionLists_faces = new List<List<int>>();
    public List<List<string>> bobo_levelLists = new List<List<string>>();      public List<List<int>> bobo_levelLists_faces = new List<List<int>>();

    //Fenris' lists
    public List<string> fenris_first = new List<string>();                          public List<int> fenris_first_faces = new List<int>();
    public List<string> fenris_greetings = new List<string>();                      public List<int> fenris_greetings_faces = new List<int>();
    public List<string> fenris_byes = new List<string>();                           public List<int> fenris_byes_faces = new List<int>();
    public List<string> fenris_hay = new List<string>();                            public List<int> fenris_hay_faces = new List<int>();
    public List<string> fenris_levelup1 = new List<string>();                       public List<int> fenris_levelup1_faces = new List<int>();
    public List<string> fenris_levelup2 = new List<string>();                       public List<int> fenris_levelup2_faces = new List<int>();
    public List<string> fenris_levelup3 = new List<string>();                       public List<int> fenris_levelup3_faces = new List<int>();
    public List<string> fenris_levelup4 = new List<string>();                       public List<int> fenris_levelup4_faces = new List<int>();
    public List<string> fenris_levelup5 = new List<string>();                       public List<int> fenris_levelup5_faces = new List<int>();
    public List<string> fenris_gifts = new List<string>();                          public List<int> fenris_gifts_faces = new List<int>();
    public List<string> fenris_badgifts = new List<string>();                       public List<int> fenris_badgifts_faces = new List<int>();
    public List<string> fenris_nothingtosay = new List<string>();                   public List<int> fenris_nothingtosay_faces = new List<int>();
    public List<string> fenris_flirts = new List<string>();                         public List<int> fenris_flirts_faces = new List<int>();
    public List<string> fenris_wronganswers = new List<string>();                   public List<int> fenris_wronganswers_faces = new List<int>();
    public List<string> fenris_correctanswers = new List<string>();                 public List<int> fenris_correct_faces = new List<int>();
    public List<string> fenris_choices = new List<string>();
    public List<string> fenris_question1 = new List<string>();                      public List<int> fenris_question1_faces = new List<int>();
    public List<string> fenris_question2 = new List<string>();                      public List<int> fenris_question2_faces = new List<int>();
    public List<string> fenris_question3 = new List<string>();                      public List<int> fenris_question3_faces = new List<int>();
    public List<string> fenris_question4 = new List<string>();                      public List<int> fenris_question4_faces = new List<int>();
    public List<string> fenris_question5 = new List<string>();                      public List<int> fenris_question5_faces = new List<int>();
    public List<string> fenris_question6 = new List<string>();                      public List<int> fenris_question6_faces = new List<int>();
    public List<string> fenris_question7 = new List<string>();                      public List<int> fenris_question7_faces = new List<int>();
    public List<string> fenris_question8 = new List<string>();                      public List<int> fenris_question8_faces = new List<int>();
    public List<string> fenris_question9 = new List<string>();                      public List<int> fenris_question9_faces = new List<int>();
    public List<string> fenris_question10 = new List<string>();                     public List<int> fenris_question10_faces = new List<int>();
    public List<string> fenris_question11 = new List<string>();                     public List<int> fenris_question11_faces = new List<int>();
    public List<string> fenris_question12 = new List<string>();                     public List<int> fenris_question12_faces = new List<int>();
    public List<string> fenris_question13 = new List<string>();                     public List<int> fenris_question13_faces = new List<int>();
    public List<string> fenris_question14 = new List<string>();                     public List<int> fenris_question14_faces = new List<int>();
    public List<string> fenris_question15 = new List<string>();                     public List<int> fenris_question15_faces = new List<int>();
    public List<string> fenris_question16 = new List<string>();                     public List<int> fenris_question16_faces = new List<int>();
    public List<string> fenris_quests = new List<string>();                         public List<int> fenris_quests_faces = new List<int>();
    public List<int> fenris_correct = new List<int>();
    public List<List<string>> fenris_questionLists = new List<List<string>>();      public List<List<int>> fenris_questionLists_faces = new List<List<int>>();
    public List<List<string>> fenris_levelLists = new List<List<string>>();         public List<List<int>> fenris_levelLists_faces = new List<List<int>>();

    //Therion's lists
    public List<string> therion_first = new List<string>();                         public List<int> therion_first_faces = new List<int>();
    public List<string> therion_greetings = new List<string>();                     public List<int> therion_greetings_faces = new List<int>();
    public List<string> therion_byes = new List<string>();                          public List<int> therion_byes_faces = new List<int>();
    public List<string> therion_hay = new List<string>();                           public List<int> therion_hay_faces = new List<int>();
    public List<string> therion_levelup1 = new List<string>();                      public List<int> therion_levelup1_faces = new List<int>();
    public List<string> therion_levelup2 = new List<string>();                      public List<int> therion_levelup2_faces = new List<int>();
    public List<string> therion_levelup3 = new List<string>();                      public List<int> therion_levelup3_faces = new List<int>();
    public List<string> therion_levelup4 = new List<string>();                      public List<int> therion_levelup4_faces = new List<int>();
    public List<string> therion_levelup5 = new List<string>();                      public List<int> therion_levelup5_faces = new List<int>();
    public List<string> therion_gifts = new List<string>();                         public List<int> therion_gifts_faces = new List<int>();
    public List<string> therion_badgifts = new List<string>();                      public List<int> therion_badgifts_faces = new List<int>();
    public List<string> therion_nothingtosay = new List<string>();                  public List<int> therion_nothingtosay_faces = new List<int>();
    public List<string> therion_flirts = new List<string>();                        public List<int> therion_flirts_faces = new List<int>();
    public List<string> therion_wronganswers = new List<string>();                  public List<int> therion_wronganswers_faces = new List<int>();
    public List<string> therion_correctanswers = new List<string>();                public List<int> therion_correct_faces = new List<int>();
    public List<string> therion_choices = new List<string>();
    public List<string> therion_question1 = new List<string>();                     public List<int> therion_question1_faces = new List<int>();
    public List<string> therion_question2 = new List<string>();                     public List<int> therion_question2_faces = new List<int>();
    public List<string> therion_question3 = new List<string>();                     public List<int> therion_question3_faces = new List<int>();
    public List<string> therion_question4 = new List<string>();                     public List<int> therion_question4_faces = new List<int>();
    public List<string> therion_question5 = new List<string>();                     public List<int> therion_question5_faces = new List<int>();
    public List<string> therion_question6 = new List<string>();                     public List<int> therion_question6_faces = new List<int>();
    public List<string> therion_question7 = new List<string>();                     public List<int> therion_question7_faces = new List<int>();
    public List<string> therion_question8 = new List<string>();                     public List<int> therion_question8_faces = new List<int>();
    public List<string> therion_question9 = new List<string>();                     public List<int> therion_question9_faces = new List<int>();
    public List<string> therion_question10 = new List<string>();                    public List<int> therion_question10_faces = new List<int>();
    public List<string> therion_question11 = new List<string>();                    public List<int> therion_question11_faces = new List<int>();
    public List<string> therion_question12 = new List<string>();                    public List<int> therion_question12_faces = new List<int>();
    public List<string> therion_question13 = new List<string>();                    public List<int> therion_question13_faces = new List<int>();
    public List<string> therion_question14 = new List<string>();                    public List<int> therion_question14_faces = new List<int>();
    public List<string> therion_question15 = new List<string>();                    public List<int> therion_question15_faces = new List<int>();
    public List<string> therion_question16 = new List<string>();                    public List<int> therion_question16_faces = new List<int>();
    public List<string> therion_quests = new List<string>();                        public List<int> therion_quests_faces = new List<int>();
    public List<int> therion_correct = new List<int>();
    public List<List<string>> therion_questionLists = new List<List<string>>();     public List<List<int>> therion_questionLists_faces = new List<List<int>>();
    public List<List<string>> therion_levelLists = new List<List<string>>();        public List<List<int>> therion_levelLists_faces = new List<List<int>>();

    public List<string> yola_giftlist = new List<string>();
    public List<string> gru_giftlist = new List<string>();
    public List<string> fenris_giftlist = new List<string>();
    public List<string> bobo_giftlist = new List<string>();
    public List<string> catherine_giftlist = new List<string>();
    public List<string> therion_giftlist = new List<string>();

    public List<string> yola_hatelevel = new List<string>();        public List<int> yola_hatelevel_faces = new List<int>();
    public List<string> gru_hatelevel = new List<string>();         public List<int> gru_hatelevel_faces = new List<int>();
    public List<string> therion_hatelevel = new List<string>();     public List<int> therion_hatelevel_faces = new List<int>();
    public List<string> fenris_hatelevel = new List<string>();      public List<int> fenris_hatelevel_faces = new List<int>();
    public List<string> bobo_hatelevel = new List<string>();        public List<int> bobo_hatelevel_faces = new List<int>();
    public List<string> catherine_hatelevel = new List<string>();   public List<int> catherine_hatelevel_faces = new List<int>();

    public List<string> yola_questdialogue = new List<string>(); public List<int> yola_questdialogue_faces = new List<int>();
    public List<string> gru_questdialogue = new List<string>(); public List<int> gru_questdialogue_faces = new List<int>();
    public List<string> therion_questdialogue = new List<string>(); public List<int> therion_questdialogue_faces = new List<int>();
    public List<string> fenris_questdialogue = new List<string>(); public List<int> fenris_questdialogue_faces = new List<int>();
    public List<string> bobo_questdialogue = new List<string>(); public List<int> bobo_questdialogue_faces = new List<int>();
    public List<string> catherine_questdialogue = new List<string>(); public List<int> catherine_questdialogue_faces = new List<int>();

    public List<string> yola_questitems = new List<string>(); public List<int> yola_questitems_amount = new List<int>();
    public List<string> gru_questitems = new List<string>(); public List<int> gru_questitems_amount = new List<int>();
    public List<string> therion_questitems = new List<string>(); public List<int> therion_questitems_amount = new List<int>();
    public List<string> fenris_questitems = new List<string>(); public List<int> fenris_questitems_amount = new List<int>();
    public List<string> bobo_questitems = new List<string>(); public List<int> bobo_questitems_amount = new List<int>();
    public List<string> catherine_questitems = new List<string>(); public List<int> catherine_questitems_amount = new List<int>();


    PlayerHealth HP;
    public PopeButtons popeB;
    public SpriteChange spriteChanger;

    //Choice texts
    Text TextA;
    Text TextB;
    Text TextC;

    //Iterators for each character's question + flirtlists;
    //THESE NEED TO BE SAVED IN SAVEGAME
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

    //Savegame variables end

    NPCConversation YolaScript;
    NPCConversation GruScript;
    NPCConversation FenrisScript;
    NPCConversation CatherineScript;
    NPCConversation BoboScript;
    NPCConversation TherionScript;

    public Ending end;

    Button stay;
    Button leave;

    //LINES ARE ADDED TO THEIR RESPECTIVE LISTS
    //
    void Start()
    {
        load = JsonUtility.FromJson<Loading>(File.ReadAllText(Application.persistentDataPath + "/load.json"));
        if (load.load == 0) //If laod.load is 0 this mean it's first time running. Set initial values.
        {
            YolaQ = -1;
            BoboQ = -1;
            GruQ = -1;
            FenrisQ = -1;
            CatherineQ = -1;
            TherionQ = -1;
            YolaF = -1;
            BoboF = -1;
            GruF = -1;
            FenrisF = -1;
            CatherineF = -1;
            TherionF = -1;
            YolaQUEST = -1;
            BoboQUEST = -1;
            GruQUEST = -1;
            FenrisQUEST = -1;
            CatherineQUEST = -1;
            TherionQUEST = -1;
            YolaQuestOngoing = false;
            GruQuestOngoing = false;
            BoboQuestOngoing = false;
            CatherineQuestOngoing = false;
            FenrisQuestOngoing = false;
            TherionQuestOngoing = false;
            tutorialPlayed = false;
            howManyMonstersHateYou = 0;
            howManyObjectsOfLove = 0;
        }

        saidBye = false;
        i = -1;
        popeTips = 0;
        currentConversationLength = 1;
        HP = GameObject.Find("Player").GetComponent<PlayerHealth>();
        spriteChanger = GameObject.Find("Sprites").GetComponent<SpriteChange>();
        end = GameObject.Find("Gameplay").GetComponent<Ending>();
        popeB = GameObject.Find("PopeButtons").GetComponent<PopeButtons>();
        TextA = GameObject.Find("ChoiceAText").GetComponent<Text>();
        TextB = GameObject.Find("ChoiceBText").GetComponent<Text>();
        TextC = GameObject.Find("ChoiceCText").GetComponent<Text>();
        stay = GameObject.Find("Stay").GetComponent<Button>();
        leave = GameObject.Find("Leave").GetComponent<Button>();
        YolaScript = GameObject.Find("Yola").GetComponent<NPCConversation>();
        GruScript = GameObject.Find("Gru").GetComponent<NPCConversation>();
        FenrisScript = GameObject.Find("Fenris").GetComponent<NPCConversation>();
        CatherineScript = GameObject.Find("Catherine").GetComponent<NPCConversation>();
        BoboScript = GameObject.Find("Bobo").GetComponent<NPCConversation>();
        TherionScript = GameObject.Find("Therion").GetComponent<NPCConversation>();
        SetChoicesInactive();

        bobo_questitems.Add("Flower"); bobo_questitems_amount.Add(10);
        bobo_questitems.Add("Rare ale"); bobo_questitems_amount.Add(1);
        bobo_questitems.Add("Perfect sandwich"); bobo_questitems_amount.Add(1);
        bobo_questitems.Add("Extra shiny stone"); bobo_questitems_amount.Add(3);
        bobo_questitems.Add("Little handbook of Demonology"); bobo_questitems_amount.Add(1);
        bobo_questitems.Add("Sparkly lemonade"); bobo_questitems_amount.Add(1);
        bobo_questitems.Add("Plagued claw"); bobo_questitems_amount.Add(5);
        bobo_questitems.Add("Fossilized insect"); bobo_questitems_amount.Add(5);
        bobo_questitems.Add("Chain of sausages"); bobo_questitems_amount.Add(1);
        bobo_questitems.Add("Life and adventures of Wizard Bob"); bobo_questitems_amount.Add(1);

        therion_questitems.Add("Rare ale"); therion_questitems_amount.Add(1);
        therion_questitems.Add("Huge steak"); therion_questitems_amount.Add(1);
        therion_questitems.Add("Exceptional mead"); therion_questitems_amount.Add(1);
        therion_questitems.Add("Enormous leg of a bison"); therion_questitems_amount.Add(1);
        therion_questitems.Add("Chain of sausages"); therion_questitems_amount.Add(1);
        therion_questitems.Add("Sparkly lemonade"); therion_questitems_amount.Add(1);
        therion_questitems.Add("Perfect sandwich"); therion_questitems_amount.Add(1);
        therion_questitems.Add("Dark colored egg"); therion_questitems_amount.Add(5);
        therion_questitems.Add("Chocolate cookie"); therion_questitems_amount.Add(1);
        therion_questitems.Add("Spicy lollipop"); therion_questitems_amount.Add(1);

        yola_questitems.Add("Extra shiny stone"); yola_questitems_amount.Add(5);
        yola_questitems.Add("Plagued fur"); yola_questitems_amount.Add(5);
        yola_questitems.Add("Colorful feather"); yola_questitems_amount.Add(10);
        yola_questitems.Add("Dark colored egg"); yola_questitems_amount.Add(5);
        yola_questitems.Add("Sparkly lemonade"); yola_questitems_amount.Add(1);
        yola_questitems.Add("Plagued bone"); yola_questitems_amount.Add(5);
        yola_questitems.Add("Grilled chicken"); yola_questitems_amount.Add(1);
        yola_questitems.Add("Plagued eyeball"); yola_questitems_amount.Add(7);
        yola_questitems.Add("Pretty bracelet"); yola_questitems_amount.Add(1);
        yola_questitems.Add("Big pearl"); yola_questitems_amount.Add(1);

        fenris_questitems.Add("Plagued fur"); fenris_questitems_amount.Add(5);
        fenris_questitems.Add("Plagued bone"); fenris_questitems_amount.Add(5);
        fenris_questitems.Add("Plagued claw"); fenris_questitems_amount.Add(7);
        fenris_questitems.Add("Colorful feather"); fenris_questitems_amount.Add(5);
        fenris_questitems.Add("Dark colored egg"); fenris_questitems_amount.Add(5);
        fenris_questitems.Add("Plagued eyeball"); fenris_questitems_amount.Add(5);
        fenris_questitems.Add("Fossilized insect"); fenris_questitems_amount.Add(5);
        fenris_questitems.Add("Flower"); fenris_questitems_amount.Add(10);
        fenris_questitems.Add("Medical herbs"); fenris_questitems_amount.Add(10);
        fenris_questitems.Add("Volcanic glass"); fenris_questitems_amount.Add(3);

        catherine_questitems.Add("Big pearl"); catherine_questitems_amount.Add(1);
        catherine_questitems.Add("Pretty bracelet"); catherine_questitems_amount.Add(1);
        catherine_questitems.Add("Flower"); catherine_questitems_amount.Add(10);
        catherine_questitems.Add("Volcanic glass"); catherine_questitems_amount.Add(5);
        catherine_questitems.Add("Sparkly lemonade"); catherine_questitems_amount.Add(1);
        catherine_questitems.Add("Spicy lollipop"); catherine_questitems_amount.Add(1);
        catherine_questitems.Add("Extra shiny stone"); catherine_questitems_amount.Add(5);
        catherine_questitems.Add("Plagued fur"); catherine_questitems_amount.Add(5);
        catherine_questitems.Add("Chocolate cookie"); catherine_questitems_amount.Add(1);
        catherine_questitems.Add("Colorful feather"); catherine_questitems_amount.Add(10);

        gru_questitems.Add("Huge steak"); gru_questitems_amount.Add(1);
        gru_questitems.Add("Enormous leg of a bison"); gru_questitems_amount.Add(1);
        gru_questitems.Add("Sparkly lemonade"); gru_questitems_amount.Add(1);
        gru_questitems.Add("Plagued bone"); gru_questitems_amount.Add(5);
        gru_questitems.Add("Plagued claw"); gru_questitems_amount.Add(10);
        gru_questitems.Add("Plagued fur"); gru_questitems_amount.Add(7);
        gru_questitems.Add("Rare ale"); gru_questitems_amount.Add(1);
        gru_questitems.Add("Grilled chicken"); gru_questitems_amount.Add(1);
        gru_questitems.Add("Exceptional mead"); gru_questitems_amount.Add(1);
        gru_questitems.Add("Plagued eyeball"); gru_questitems_amount.Add(7);

        bobo_questdialogue.Add("Bobo: I want to give something nice to my mother. Bring me ten flowers from the park."); bobo_questdialogue_faces.Add(6);
        bobo_questdialogue.Add("Bobo: I am thirsty. Bring me the best beverage you can find in this town."); bobo_questdialogue_faces.Add(6);
        bobo_questdialogue.Add("Bobo: I am hungry. Bring me something to eat here in the park."); bobo_questdialogue_faces.Add(6);
        bobo_questdialogue.Add("Bobo: My father collects minerals and he wants me to help. Bring me three shiny stones."); bobo_questdialogue_faces.Add(6);
        bobo_questdialogue.Add("Bobo: I am bored. Bring me something to read."); bobo_questdialogue_faces.Add(6);
        bobo_questdialogue.Add("Bobo: I feel thirsty again. Bring me something fresh to drink."); bobo_questdialogue_faces.Add(6);
        bobo_questdialogue.Add("Bobo: I heard that there is plague infected creatures in the forest and they try to find their way into Ferrus. Protect me by killing five of them and bring me their claws as trophies."); bobo_questdialogue_faces.Add(6);
        bobo_questdialogue.Add("Bobo: My father needs more items in his collection and now he wants to have fossils. Bring me five fossils."); bobo_questdialogue_faces.Add(6);
        bobo_questdialogue.Add("Bobo: I heard there are delicious sausages in the tavern but I will not go there where common people gather around. Can you bring me sausages?"); bobo_questdialogue_faces.Add(6);
        bobo_questdialogue.Add("Bobo: I feel bored again. Bring me something amusing to read."); bobo_questdialogue_faces.Add(6);

        catherine_questdialogue.Add("Catherine: I liketh ev'rything quite quaint. Pearls art mine own minion. Couldst thee bringeth me one?"); catherine_questdialogue_faces.Add(9);
        catherine_questdialogue.Add("Catherine: I liketh to dresseth up quaint but I bethink i hath lost mine own bracelet. Can thee receiveth me a new one?"); catherine_questdialogue_faces.Add(9);
        catherine_questdialogue.Add("Catherine: I wisheth to beautify this bitter cold and lifeless crypt. Couldst thee kindly bringeth me ten floweth'rs?"); catherine_questdialogue_faces.Add(9);
        catherine_questdialogue.Add("Catherine: I bethink th're is beauty in ev'rything. I wouldst liketh to seeth some volcanic glass. Couldst thee bringeth me five pieces?"); catherine_questdialogue_faces.Add(9);
        catherine_questdialogue.Add("Catherine: I has't hath heard yond villag'rs enjoyeth some bitter cold and green drinketh. I wouldst loveth to tryeth some myself!"); catherine_questdialogue_faces.Add(9);
        catherine_questdialogue.Add("Catherine: If 't be true thee didn’t guesseth already, I liketh ev'rything sweet. Couldst thee bringeth me some sweet?"); catherine_questdialogue_faces.Add(9);
        catherine_questdialogue.Add("Catherine: Floweth'rs art nice h're but I wanteth something m're to beautify this crypt. I bethink shiny stones wouldst doth the dissemble. Can thee bringeth me five of those folk?"); catherine_questdialogue_faces.Add(9);
        catherine_questdialogue.Add("Catherine: I wouldst liketh to seweth a new cape from warmeth fur. Couldst thee bringeth me five furs from hath killed creatures?"); catherine_questdialogue_faces.Add(9);
        catherine_questdialogue.Add("Catherine: I wanteth m're of something sweet. Bringeth me a cookie, I prithee."); catherine_questdialogue_faces.Add(9);
        catherine_questdialogue.Add("Catherine: To addeth something special to mine own cape I wouldst liketh to has't feath'rs. Bringeth me ten of those!"); catherine_questdialogue_faces.Add(9);

        fenris_questdialogue.Add("Fenris: Jumping Plague infected creatures roam around the forest. Kill five of them and bring me their fur."); fenris_questdialogue_faces.Add(8);
        fenris_questdialogue.Add("Fenris: Jumping Plague infected creatures are increasing their numbers. Kill five of them and bring me their shin bones."); fenris_questdialogue_faces.Add(8);
        fenris_questdialogue.Add("Fenris: Jumping Plague is spreading and I must prevent it reaching the villagers. Help me killing infected creatures. Kill seven of them and bring me their claws."); fenris_questdialogue_faces.Add(8);
        fenris_questdialogue.Add("Fenris: I wish to have some new feathers for my hair. Bring me five feathers."); fenris_questdialogue_faces.Add(8);
        fenris_questdialogue.Add("Fenris: I want to make an omelette. Bring me five eggs."); fenris_questdialogue_faces.Add(8);
        fenris_questdialogue.Add("Fenris: Infected ones are again trying to approach the village. Kill five of them and bring me their eyeballs to use as a warning to others."); fenris_questdialogue_faces.Add(8);
        fenris_questdialogue.Add("Fenris: I have always been interested about our history and I would like to study some fossils. Could you find me five of them?"); fenris_questdialogue_faces.Add(8);
        fenris_questdialogue.Add("Fenris: I enjoy the beauty of the nature and flowers are truly art of nature. Unfortunately there is rarely any flowers here in forest. So, could you bring me ten flowers from the town?"); fenris_questdialogue_faces.Add(8);
        fenris_questdialogue.Add("Fenris: I need to have full supplies of medical herbs so that I can heal myself as I can get injured here in the forest but now I am falling short on herbs. Can you bring me ten herbs?"); fenris_questdialogue_faces.Add(8);
        fenris_questdialogue.Add("Fenris: I think I need to change head of my spear. Bring me three lumps of volcanic glass."); fenris_questdialogue_faces.Add(8);

        gru_questdialogue.Add("Gru: Gru hungry. Give Gru meat!"); gru_questdialogue_faces.Add(10);
        gru_questdialogue.Add("Gru: Gru more hungry. Give Gru something bigger to eat."); gru_questdialogue_faces.Add(10);
        gru_questdialogue.Add("Gru: Gru now thirsty. Bring Gru some fresh drink!"); gru_questdialogue_faces.Add(10);
        gru_questdialogue.Add("Gru: Gru need plague infected creatures’ bones to season soup but Gru can no go to forest because wolftaur. Kill five infected creatures and give Gru their bones."); gru_questdialogue_faces.Add(10);
        gru_questdialogue.Add("Gru: Gru forgot that Gru need plagued claws too. Bring ten claws from creatures."); gru_questdialogue_faces.Add(10);
        gru_questdialogue.Add("Gru: Gru need new fur for bed. Mutated plague infected creatures has best fur for bed. Bring Gru seven furs."); gru_questdialogue_faces.Add(10);
        gru_questdialogue.Add("Gru: Gru know villagers drink mead and ale but they no give it to Gru. Gru want taste too!"); gru_questdialogue_faces.Add(10);
        gru_questdialogue.Add("Gru: Gru want make soup but Gru has no meat for it. Go get Gru some chicken."); gru_questdialogue_faces.Add(10);
        gru_questdialogue.Add("Gru: Gru want drink with soup. Bring Gru mead."); gru_questdialogue_faces.Add(10);
        gru_questdialogue.Add("Gru: Gru now want to make meal pretty. Bring Gru seven eyeballs from infected creatures."); gru_questdialogue_faces.Add(10);

        therion_questdialogue.Add("Therion: Ay am a-feelin' thirsty. Can y'all get me some ale frawum downstairs?"); therion_questdialogue_faces.Add(7);
        therion_questdialogue.Add("Therion: Ay need some meat! Be ayy kaand little person ayn' bring me steak!"); therion_questdialogue_faces.Add(7);
        therion_questdialogue.Add("Therion: Salty food makes me wan-ta drink mawe. Ay need something ta drink, mead would be ‘reat."); therion_questdialogue_faces.Add(7);
        therion_questdialogue.Add("Therion: Now that there ay have done had appetizuurr ay am ready ta start thay ...err feast. First ay could eat ayy whowwl leg av ayy bison."); therion_questdialogue_faces.Add(7);
        therion_questdialogue.Add("Therion: Ay would like ta have some sausages. Bring me one chayn av them please."); therion_questdialogue_faces.Add(7);
        therion_questdialogue.Add("Therion: Now ay need something ta drink agayn. Maybe fresh lemonade could do the trick.. hmmh."); therion_questdialogue_faces.Add(7);
        therion_questdialogue.Add("Therion: Ay would love ta taste thay ...uhh sandwich they are a-sellin' downstairs. Bring me one!"); therion_questdialogue_faces.Add(7);
        therion_questdialogue.Add("Therion: Ay done heard that there raw eggs can help y'all's digesshun. Go pick me five av them frawum the fawest."); therion_questdialogue_faces.Add(7);
        therion_questdialogue.Add("Therion: Ay am ready faw some dessert. Ay would like ta have ayy cookie."); therion_questdialogue_faces.Add(7);
        therion_questdialogue.Add("Therion: Ay secretly luv lollipops even if they are ayy bit awful small but the taste is kind. Bring me one!"); therion_questdialogue_faces.Add(7);

        yola_questdialogue.Add("Yola: Yola wants some pretty stones to make hole prettier. Bring five shiny stones to Yola."); yola_questdialogue_faces.Add(11);
        yola_questdialogue.Add("Yola: Yola wants to change beddings and therefore Yola needs new furs. Bring five furs from plagued creatures."); yola_questdialogue_faces.Add(11);
        yola_questdialogue.Add("Yola: Yola wants to make a pretty dress from colorful feathers. Bring Yola ten feathers."); yola_questdialogue_faces.Add(11);
        yola_questdialogue.Add("Yola: Yola wants to try to hatch little creatures from eggs to be Yola’s pets. Bring Yola five eggs."); yola_questdialogue_faces.Add(11);
        yola_questdialogue.Add("Yola: Yola wants to have same drinks as the townsfolk. Bring me something fresh to drink."); yola_questdialogue_faces.Add(11);
        yola_questdialogue.Add("Yola: Yola wants few bones to make handicrafts. Could you bring Yola five bones from the plagued ones?"); yola_questdialogue_faces.Add(11);
        yola_questdialogue.Add("Yola: Yola would like to cook some dinner. Chicken would be nice. Can you bring Yola one?"); yola_questdialogue_faces.Add(11);
        yola_questdialogue.Add("Yola: Yola wants to have eyes in a jar to put up on the shelf. Just like witches do in their huts. Can you bring seven eyeballs to Yola?"); yola_questdialogue_faces.Add(11);
        yola_questdialogue.Add("Yola: Yola wants to have pretty things like princesses do. Can you bring Yola a bracelet?"); yola_questdialogue_faces.Add(11);
        yola_questdialogue.Add("Yola: Yola loves pearls but there is no sea and clams anywhere near. Can you find and bring Yola a pearl?"); yola_questdialogue_faces.Add(11);

        yola_giftlist.Add("Necklace");
        yola_giftlist.Add("Potato");
        yola_giftlist.Add("Shiny stone");
        yola_giftlist.Add("Bouquet of roses");
        gru_giftlist.Add("Potato");
        gru_giftlist.Add("Chocolate bar");
        gru_giftlist.Add("Grilled chicken leg");
        gru_giftlist.Add("Juicy meat");
        fenris_giftlist.Add("Potato");
        fenris_giftlist.Add("Shiny stone");
        fenris_giftlist.Add("Juicy meat");
        catherine_giftlist.Add("Potato");
        catherine_giftlist.Add("Necklace");
        catherine_giftlist.Add("Bouquet of roses");
        catherine_giftlist.Add("Lipstick");
        bobo_giftlist.Add("Potato");
        bobo_giftlist.Add("Chocolate bar");
        bobo_giftlist.Add("Necklace");
        bobo_giftlist.Add("Bouquet of roses");
        bobo_giftlist.Add("Painting of Ferrus");
        therion_giftlist.Add("Potato");
        therion_giftlist.Add("Chocolate bar");
        therion_giftlist.Add("Painting of Ferrus");
        therion_giftlist.Add("Grilled chicken leg");

        bobo_hatelevel.Add("Bobo: Hmm? Did I hear something? There must be some annoying insects buzzing near me..."); bobo_hatelevel_faces.Add(28);
        bobo_hatelevel.Add("Bobo: I can see how lowly peasant you truly are. You are not worth of my precious time. Leave or I’ll call the guard to take you away."); bobo_hatelevel_faces.Add(28);

        gru_hatelevel.Add("Gru: GRRRUUUAAAAHH! GRU SAY ONE LAST TIME: GO AWAY!"); gru_hatelevel_faces.Add(20);
        gru_hatelevel.Add("Gru: Gru no like you. You stink and must taste bad. You speak so that Gru gets angry. Gro no want you to come back ever. Gru no want to talk with you ever again."); gru_hatelevel_faces.Add(20);

        fenris_hatelevel.Add("Fenris: Get away from me."); fenris_hatelevel_faces.Add(26);
        fenris_hatelevel.Add("Fenris: I see it is pointless to talk with someone like you. Leave me alone and don’t ever try to talk with me again."); fenris_hatelevel_faces.Add(26);

        catherine_hatelevel.Add("Catherine: Thou art lowly worm and thou shalt not talk to me. Don’t even try or I shall put my cousins after thee!"); catherine_hatelevel_faces.Add(24);
        catherine_hatelevel.Add("Catherine: I am so very disappointed of thy actions. Thy very speech makes my own head ache. So from now on I wish thee to stay away evermore. Let me enjoy my lonely life in this crypt without thy nonsense."); catherine_hatelevel_faces.Add(24);

        therion_hatelevel.Add("Therion: Ay have nothing ta say ta y'all, y'all done broke my heart."); therion_hatelevel_faces.Add(30);
        therion_hatelevel.Add("Therion: Y'all are ayy awful huge disappointment. Huguurr than me tummy. Ay don’t wan-ta waste my tahm on y'all's stupidness anymawe. Leave ayn' don’t y'all evuurr come back!"); therion_hatelevel_faces.Add(30);

        yola_hatelevel.Add("Yola: Hmph. Yola don’t want ones like you to come here and make Yola’s hole dirty. Please leave now."); yola_hatelevel_faces.Add(22);
        yola_hatelevel.Add("Yola: Yola thinks you’re not worth of Yola’s time. Yola knows that Yola will find someone who really cares about Yola’s feelings. You should now leave and stay away from Yola forever."); yola_hatelevel_faces.Add(22);


        //Example lines
        example.Add("Get out of my house!");
        example.Add("Take pity on my kitty!");
        example.Add("The Jumping Plague is approaching. I FEEL IT IN MAH BONES!");
        //Grandma's lines
        grandma.Add("Grandma: Geeeet out of my house!",0);
        grandma.Add("Grandma: Take pity on the kitty.",0);
        grandma.Add("Grandma: The Jumping Plague approaches, I feel it in my bones!",0);
        //Guards's lines
        guard.Add("Guard: You can’t leave the town due to the recent outbreak of the Jumping Plague. Watch out for mutants.",1);
        guard.Add("Guard: Can’t you see I am busy guarding…? Very… bus-zzz….. (He’s fast asleep.)",1);
        guard.Add("(The guard is snoring.)",1);
        //Eldritch horror's lines
        horror.Add("???: Mwabbgrgrlrr! (You cannot understand a word it says.)",2);
        horror.Add("???: Aaaaaughibbrgubugbugrguburgle! (You cannot understand a word it says.)",2);
        horror.Add("???: Gwwahhrrlgghhbbrr! (You cannot understand a word it says.)",2);
        //Pope's greeting lines
        pope_greeting.Add("Pope: Greetings, child!"); pope_greeting_faces.Add(3);
        pope_greeting.Add("Pope: The Holy Potato welcomes you!"); pope_greeting_faces.Add(3);
        pope_greeting.Add("Pope: The Great Potato told me you were coming."); pope_greeting_faces.Add(3);
        //Pope's tutorial lines
        pope_tutorial.Add("Pope: Welcome to the house of the Glorious Potato, Our Master Root Vegetable!"); pope_tutorial_faces.Add(3);
        pope_tutorial.Add("Ghoul: Eh well, thanks… Where am I? What is this place?"); pope_tutorial_faces.Add(14);
        pope_tutorial.Add("Pope: You are in a town called Ferrus in a world called Lagicam. And this is the house of the-"); pope_tutorial_faces.Add(3);
        pope_tutorial.Add("Ghoul: Yes, I get it... House of a potato. But what happened to my world? Where is my hometown?"); pope_tutorial_faces.Add(12);
        pope_tutorial.Add("Pope: I saw a big flash of light and I sensed a huge magical aura."); pope_tutorial_faces.Add(3);
        pope_tutorial.Add("Pope: Then your house appeared on the edge of the town."); pope_tutorial_faces.Add(3);
        pope_tutorial.Add("Ghoul: What?"); pope_tutorial_faces.Add(14);
        pope_tutorial.Add("Pope: I suspect that by some magical force your house and you with it were sent to our world from this other world you call home."); pope_tutorial_faces.Add(3);
        pope_tutorial.Add("Pope: You must have really powerful sorcerers where you live to create this amount of magical power."); pope_tutorial_faces.Add(3);
        pope_tutorial.Add("Ghoul: Oh no…"); pope_tutorial_faces.Add(14);
        pope_tutorial.Add("Pope: Hmm?"); pope_tutorial_faces.Add(3);
        pope_tutorial.Add("Ghoul: I think my spell went wrong. I tried to summon a demon but then I woke up here."); pope_tutorial_faces.Add(12);
        pope_tutorial.Add("Pope: I see. Well, you shouldn’t play with magic if you’re not properly trained."); pope_tutorial_faces.Add(3);
        pope_tutorial.Add("Ghoul: Let’s forget that I messed up. How do I get back?"); pope_tutorial_faces.Add(14);
        pope_tutorial.Add("Pope: I am no sorcerer but I know something about portal magic."); pope_tutorial_faces.Add(3);
        pope_tutorial.Add("Pope: To create a portal you must use three objects filled with powerful magic."); pope_tutorial_faces.Add(3);
        pope_tutorial.Add("Ghoul: Great. Where do I find those?"); pope_tutorial_faces.Add(13);
        pope_tutorial.Add("Pope: It is not that simple. The objects generate their powers through strong emotions."); pope_tutorial_faces.Add(3);
        pope_tutorial.Add("Pope: Like love."); pope_tutorial_faces.Add(3);
        pope_tutorial.Add("Ghoul: Love? So how do I get objects touched with love?"); pope_tutorial_faces.Add(12);
        pope_tutorial.Add("Pope: Simple. You can get them as gifts from lovers."); pope_tutorial_faces.Add(3);
        pope_tutorial.Add("Ghoul: Lovers? But I don’t know anyone here…"); pope_tutorial_faces.Add(14);
        pope_tutorial.Add("Pope: So, you must get known with people of Ferrus."); pope_tutorial_faces.Add(3);
        pope_tutorial.Add("Pope: When you know enough of them you can try to seduce them and make them fall in love with you."); pope_tutorial_faces.Add(3);
        pope_tutorial.Add("Pope: But do be cautious."); pope_tutorial_faces.Add(3);
        pope_tutorial.Add("Pope: Citizens of Ferrus can be a little short tempered so if you hurt their feeling they might start to hate you."); pope_tutorial_faces.Add(3);
        pope_tutorial.Add("Pope: Forever."); pope_tutorial_faces.Add(3);
        pope_tutorial.Add("Ghoul: So, I must ask them question to learn about them and then I flirt with them?"); pope_tutorial_faces.Add(13);
        pope_tutorial.Add("Ghoul: And I must try to avoid saying wrong stuff so that they don’t start hating me?"); pope_tutorial_faces.Add(12);
        pope_tutorial.Add("Pope: Yes, indeed. You are a smart one."); pope_tutorial_faces.Add(3);
        pope_tutorial.Add("Pope: And don’t be disappointed if you fail first three times."); pope_tutorial_faces.Add(3);
        pope_tutorial.Add("Pope: We have six different bachelors and bachelorettes so you have six different chances to win their hearts! "); pope_tutorial_faces.Add(3);
        pope_tutorial.Add("Pope: But if you do get the fourth one hate you then it is a game over for you."); pope_tutorial_faces.Add(3);
        pope_tutorial.Add("Pope: Because only two objects cannot create a powerful enough portal to get you home."); pope_tutorial_faces.Add(3);
        pope_tutorial.Add("Ghoul: So. just to make sure:"); pope_tutorial_faces.Add(12);
        pope_tutorial.Add("Ghoul: I must collect three items from Ferrians that I have made fall in love with me."); pope_tutorial_faces.Add(12);
        pope_tutorial.Add("Ghoul: There are six of them waiting for being seduced by flirting so I can fail with three of them."); pope_tutorial_faces.Add(12);
        pope_tutorial.Add("Ghoul: So I still have a chance to be able to get back if I succeed with the three left. Am I right?"); pope_tutorial_faces.Add(3);
        pope_tutorial.Add("Pope: Yes. When you have all three items return to me and I can create the portal for you."); pope_tutorial_faces.Add(3);
        pope_tutorial.Add("Pope: If you need help just return to me for assistance."); pope_tutorial_faces.Add(3);
        pope_tutorial.Add("Ghoul: Thank you… what should I call you?"); pope_tutorial_faces.Add(13);
        pope_tutorial.Add("Pope: I am Papa Patata but you can call me Pope for short."); pope_tutorial_faces.Add(3);
        pope_tutorial.Add("Ghoul: Thank you Pope."); pope_tutorial_faces.Add(13);
        //Pope's answers to flirting lines
        pope_tips.Add("Pope: Remember, you need to ask questions and remember what monsters tell you about themselves before trying to flirt with them! Everyone of them hates if you do not know them well enough!"); pope_tips_faces.Add(3);
        pope_tips.Add("Pope: Giving gifts may boost their affection for you but only at the beginning. After a while they just accept your gifts but they do not make them fall in love with you. You can’t buy love!"); pope_tips_faces.Add(3);
        pope_tips.Add("Pope: To get the object of love from your lovers you must first give them the ultimate gift they desire. Listen closely what they tell you about themselves so you know what they might want!"); pope_tips_faces.Add(3);
        pope_tips.Add("Pope: To get them like you more you have to flirt them at least once per relationship level. After that you can flirt or do tasks they give you to deepen your relationship and get to the next level."); pope_tips_faces.Add(3);
        //Pope's healing lines
        pope_healing.Add("I see you are hurt. Let me heal you with the power of the Mighty Potato!"); pope_healing_faces.Add(3);
        pope_healing.Add("You are already at full health. You don’t need my help."); pope_healing_faces.Add(3);
        //Pope's ending lines
        pope_objects.Add("Ghoul: Hello, Pope. I have collected all three items you asked me to."); pope_objects_faces.Add(3);
        pope_objects.Add("Pope: Marvelous! Give them to me so that I can start the ritual."); pope_objects_faces.Add(3);
        pope_objects.Add("Pope: Now stand back. I will open the portal!"); pope_objects_faces.Add(3);
        pope_objects.Add("Pope: *Weird throat singing sound*"); pope_objects_faces.Add(3);
        pope_objects.Add("Pope: The portal is now open! But I must ask you to think a moment: are you sure you want to leave this realm? You cannot come back and the portal cannot be opened ever again!"); pope_objects_faces.Add(3);
        pope_objects.Add("Pope: You must choose if you want to leave this place behind or stay with your loved ones! Choose now!"); pope_objects_faces.Add(3);
        pope_objects.Add("Ghoul: So, I can’t come back if I leave but if I choose to stay I can’t open the portal again so I’ll be here forever?"); pope_objects_faces.Add(14);
        pope_objects.Add("Pope: That is correct."); pope_objects_faces.Add(3);
        pope_objects.Add("Ghoul: Then I will choose to …"); pope_objects_faces.Add(12);
        pope_objects.Add("Pope: I see you don’t have all three items yet. You must collect three of them so that I can start the ritual."); pope_objects_faces.Add(3);
        //Shopkeeper's greeting lines
        shopkeeper_greeting.Add("Shopkeeper: Come closer, I can almost hear the jingling of coins in your pockets!"); shopkeeper_greeting_faces.Add(17);
        shopkeeper_greeting.Add("Shopkeeper: Why yes I am a gold digger… and silver and copper. Anything valuable works!"); shopkeeper_greeting_faces.Add(5);
        shopkeeper_greeting.Add("Shopkeeper: A customer! Welcome! Did you bring me presents? Are they…. valuable?"); shopkeeper_greeting_faces.Add(17);
        //Shopkeeper's buying lines
        shopkeeper_buy.Add("Shopkeeper: I can sell these to you. If you got the coin for them…But don’t touch what you can’t afford with your grabby hands."); shopkeeper_buy_faces.Add(5);
        shopkeeper_buy.Add("Shopkeeper: Profits! Ohhh, thank you for your business!!"); shopkeeper_buy_faces.Add(17);
        shopkeeper_buy.Add("Shopkeeper: Don’t get a girl excited for nothing!"); shopkeeper_buy_faces.Add(18);
        shopkeeper_buy.Add("Shopkeeper: I don’t make jokes. I MAKE MONEY. And you don’t have any!"); shopkeeper_buy_faces.Add(18);
        //Shopkeeper's answers to selling                                                                                                           
        shopkeeper_sell.Add("Shopkeeper: You got some goods you wish to sell? Show me. I don’t like parting with gold but… I make exceptions. Sometimes."); shopkeeper_sell_faces.Add(5);
        shopkeeper_sell.Add("Shopkeeper: I’ll take that! Here’s your coin. No, you don’t get more."); shopkeeper_sell_faces.Add(17);
        shopkeeper_sell.Add("Shopkeeper: Oh, I see."); shopkeeper_sell_faces.Add(5);
        shopkeeper_sell.Add("Shopkeeper: What kind of a merchant do you think I am?!"); shopkeeper_sell_faces.Add(18);
        //SHopkeeper's rumors
        shopkeeper_rumors.Add("Shopkeeper: Is that your wallet? Or are you just happy to see me? Both, I hope!"); shopkeeper_rumors_faces.Add(17);
        shopkeeper_rumors.Add("Shopkeeper: I’ve heard you have been making quite the buzz in the local populace! It is almost as exciting as a big, shiny pile of gold…. I should’ve married a dragon. What were we talking about?"); shopkeeper_rumors_faces.Add(17);
        shopkeeper_rumors.Add("Shopkeeper: You are so very sweet, but my heart can only be swayed by how big is your purse."); shopkeeper_rumors_faces.Add(5);
        shopkeeper_rumors.Add("Shopkeeper: I know, I know, what kind of succubus likes money over copulation? Well, me! It makes me happy! And happiness is how we succubi and incubi nourish ourselves. I once knew a succubus who loved eating. You would’ve been impressed by the feasts she would devour alone…"); shopkeeper_rumors_faces.Add(17);
        shopkeeper_rumors.Add("Shopkeeper: There’s a creature in the swamps who flocks to people with treasures. Be careful! I would miss your patronage."); shopkeeper_rumors_faces.Add(5);
        //Innkeeper's greeting lines
        innkeeper_greeting.Add("Innkeeper: Come in! We got the best mead in ALL OF Ferrus in here!");   innkeeper_greeting_faces.Add(15);
        innkeeper_greeting.Add("Innkeeper: The Hairless Bear welcomes you traveler! Sit down! Enjoy!"); innkeeper_greeting_faces.Add(15);
        innkeeper_greeting.Add("Innkeeper: Hello, do you need some food or drink? I’ll be happy to show you our wares!.. I hope you like ale and meat pie because that is all we have at the moment. "); innkeeper_greeting_faces.Add(4);
        //Innkeeper's tutorial lines
        innkeeper_buy.Add("Innkeeper: Sorry dear, we’ve only got few kinds of mead and ale since there is the jumping plague roaming around and deliveries are delayed. *scoffs* Back where I came from you could count on getting alcohol even through quarantine. Anyway… What may I interest you in?"); innkeeper_buy_faces.Add(4);
        innkeeper_buy.Add("Innkeeper: Bottoms up, luv! Enjoy!"); innkeeper_buy_faces.Add(15);
        innkeeper_buy.Add("Innkeeper: Hmph, didn’t take you for a milk-drinker."); innkeeper_buy_faces.Add(16);
        innkeeper_buy.Add("Innkeeper: Hey, these are not on the house! No coin, no service!"); innkeeper_buy_faces.Add(16);
        //Innkeeper's answers to buying
        innkeeper_sell.Add("Innkeeper: Do you have something you want to get rid of?"); innkeeper_sell_faces.Add(4);
        innkeeper_sell.Add("Innkeeper: I guess I can pay you something for that."); innkeeper_sell_faces.Add(4);
        innkeeper_sell.Add("Innkeeper: You changed your mind?"); innkeeper_sell_faces.Add(4);
        innkeeper_sell.Add("Innkeeper: Sorry but no innkeeper would ever buy that!"); innkeeper_sell_faces.Add(16);
        //Innkeeper's rumors
        innkeeper_rumors.Add("Innkeeper: I used to do mercenary work before opening this tavern with my dear friend Therion. I still sometimes get the hankering to go out and stab things. *giggles*"); innkeeper_rumors_faces.Add(15);
        innkeeper_rumors.Add("Innkeeper: If you make a ruckus luv, Therion will show you the way out. And as we are the only beerhouse on this side of the city you’ll regret that!"); innkeeper_rumors_faces.Add(16);
        innkeeper_rumors.Add("Innkeeper: Ohh, I wish I had someone to play cards with. Therion’s got no mind for anything more complicated than smashing stuff or eating."); innkeeper_rumors_faces.Add(4);
        innkeeper_rumors.Add("Innkeeper: I’m a modern goblin woman, babe. I still let men do nice things for me, but I stopped giving them any credit. *winks*"); innkeeper_rumors_faces.Add(15);
        innkeeper_rumors.Add("Innkeeper: I’ve discovered that getting pummeled by a blunt weapon can be quite painful."); innkeeper_rumors_faces.Add(16);
        //Yola's First lines
        yola_first.Add("Yola: Ooh! Who approaches little Yola?"); yola_first_faces.Add(21); 
        yola_first.Add("Ghoul: Don’t be afraid, I am friendly."); yola_first_faces.Add(13);
        yola_first.Add("Yola: Yola is not afraid, Yola is the one to be afraid of."); yola_first_faces.Add(11);
        yola_first.Add("Ghoul: Wha-?"); yola_first_faces.Add(12);
        yola_first.Add("Yola: Yola! That’s me!"); yola_first_faces.Add(21);
        //Yola's Greetings
        yola_greetings.Add("Yola: Hi."); yola_greetings_faces.Add(11);
        yola_greetings.Add("Yola: Hello!"); yola_greetings_faces.Add(11);
        yola_greetings.Add("Yola: Oh, you came back already!"); yola_greetings_faces.Add(21);
        yola_greetings.Add("Yola: Yola greets you, friend!"); yola_greetings_faces.Add(21);
        yola_greetings.Add("Yola: Just as Yola started to miss you!"); yola_greetings_faces.Add(11);
        yola_greetings.Add("Yola: Hello, Yola’s treasure!"); yola_greetings_faces.Add(21);
        //Yola's Goodbyes
        yola_byes.Add("Yola: Bye.");    yola_byes_faces.Add(11);
        yola_byes.Add("Yola: See you."); yola_byes_faces.Add(11);
        yola_byes.Add("Yola: Bye, friend!"); yola_byes_faces.Add(11);
        yola_byes.Add("Yola: Yola awaits your return."); yola_byes_faces.Add(11);
        yola_byes.Add("Yola: Yola will miss you."); yola_byes_faces.Add(21);
        yola_byes.Add("Yola: Don’t leave Yola for too long!"); yola_byes_faces.Add(21);
        //Yola's How Are Yous
        yola_hay.Add("Yola: Yola didn’t think you could speak."); yola_hay_faces.Add(11);
        yola_hay.Add("Yola: Yola likes the swamp. It is easy to get forever lost here."); yola_hay_faces.Add(21);
        yola_hay.Add("Yola: Yola doesn’t mind the drowned ones in the swamp, they keep Yola company forever!"); yola_hay_faces.Add(11);
        yola_hay.Add("Yola: Yola found treasures from pockets of the drowned ones. They are gifts for Yola!"); yola_hay_faces.Add(21);
        yola_hay.Add("Yola: Yola knows many secrets of the townsfolk… But Yola won’t tell you any!"); yola_hay_faces.Add(11);
        yola_hay.Add("Yola: Yola doesn’t want you to drown, you are a lot nicer alive!"); yola_hay_faces.Add(21);
        //Yola's Level Up 1
        yola_levelup1.Add("Yola: Yola thinks you are not a complete failure."); yola_levelup1_faces.Add(11);
        //Yola's Level Up 2
        yola_levelup2.Add("Ghoul: It was nice to get known with you."); yola_levelup2_faces.Add(11);
        yola_levelup2.Add("Yola: But you don’t know who Yola is."); yola_levelup2_faces.Add(11);
        yola_levelup2.Add("Ghoul: Yola is you?"); yola_levelup2_faces.Add(12);
        yola_levelup2.Add("Yola: Yola is me, yes. But who Yola really is, is the secret!"); yola_levelup2_faces.Add(21);
        yola_levelup2.Add("Ghoul: I’ll keep that in mind."); yola_levelup2_faces.Add(13);
        //Yola's Level Up 3
        yola_levelup3.Add("Ghoul: I think you are cute! Cute as a fey can be!"); yola_levelup3_faces.Add(11);
        yola_levelup3.Add("Yola: Are you suggesting that feys cannot be cute? Is Yola really an ugly creature?"); yola_levelup3_faces.Add(22);
        yola_levelup3.Add("Ghoul: I didn’t mean it like that! You truly are cute. And I’d like to know you better!"); yola_levelup3_faces.Add(13);
        yola_levelup3.Add("Yola: Oh? Well, Yola thinks you’re kinda cute too. But Yola will keep an eye on you when you wander around the swamp!"); yola_levelup3_faces.Add(11);
        yola_levelup3.Add("Ghoul: Have I done something wrong? Don’t you trust me?"); yola_levelup3_faces.Add(14);
        yola_levelup3.Add("Yola: Yola trusts you, yes. Yola doesn’t want to give you to the swamp yet, so Yola keeps an eye on you!"); yola_levelup3_faces.Add(11);
        yola_levelup3.Add("Ghoul: Oh, thank you Yola!"); yola_levelup3_faces.Add(13);
        //Yola's Level Up 4
        yola_levelup4.Add("Yola: Hey! Yola needs to tell you something!"); yola_levelup4_faces.Add(11);
        yola_levelup4.Add("Ghoul: Has something happened? Are you alright?"); yola_levelup4_faces.Add(14);
        yola_levelup4.Add("Yola: No, Yola is fine. Better than fine! Yola has been smiling today for all day!"); yola_levelup4_faces.Add(21);
        yola_levelup4.Add("Ghoul: Oh, is there a particular reason?"); yola_levelup4_faces.Add(14);
        yola_levelup4.Add("Yola: Yes, there is! You, Yola’s friend! You made Yola’s day by coming here! Yola thinks you’re the best person in this town!"); yola_levelup4_faces.Add(21);
        yola_levelup4.Add("Ghoul: That is nice to hear, Yola. I think you are cool friend too!"); yola_levelup4_faces.Add(13);
        yola_levelup4.Add("Yola: Yola wants you to stay a bit longer.Don’t leave right away, please."); yola_levelup4_faces.Add(11);
        yola_levelup4.Add("Ghoul: You want to do something special?"); yola_levelup4_faces.Add(12);
        yola_levelup4.Add("Yola: Hush! Just stand there for a moment."); yola_levelup4_faces.Add(11);
        yola_levelup4.Add("Ghoul: …?"); yola_levelup4_faces.Add(12);
        yola_levelup4.Add("Yola: ... Thanks! Now you can go!"); yola_levelup4_faces.Add(21);
        yola_levelup4.Add("Ghoul: Well, I’ll be going then. See you again sometime soon!"); yola_levelup4_faces.Add(13);
        yola_levelup4.Add("Yola: Yola waits for your return, friend!"); yola_levelup4_faces.Add(11);
        //Yola's Level Up 5
        yola_levelup5.Add("Yola: Listen! Yola has important stuff to say!"); yola_levelup5_faces.Add(11);
        yola_levelup5.Add("Ghoul: Okay, I am listening. What is it?"); yola_levelup5_faces.Add(14);
        yola_levelup5.Add("Yola: Yola wants you to know that Yola doesn’t want you to become a drowned… Yola will never let the swamp take you."); yola_levelup5_faces.Add(11);
        yola_levelup5.Add("Ghoul: That is nice to hear, Yola. Is there any specific reason for you to not want me to drown in the swamp?"); yola_levelup5_faces.Add(13);
        yola_levelup5.Add("Yola: You mean a lot for Yola. More than any treasure. Yola likes everything shiny but you… You are the one Yola truly loves!"); yola_levelup5_faces.Add(21);
        yola_levelup5.Add("Ghoul: What are you saying? Are you sure?"); yola_levelup5_faces.Add(12);
        yola_levelup5.Add("Yola: Yola is sure! Yola loves you at least the same amount as Yola loves crowns! Yola loves you!"); yola_levelup5_faces.Add(21);
        yola_levelup5.Add("Ghoul: I must tell that I love you too, Yola"); yola_levelup5_faces.Add(14);
        yola_levelup5.Add("Yola: Are you kidding Yola?"); yola_levelup5_faces.Add(11);
        yola_levelup5.Add("Ghoul: There is no reason to! You are one of the most wonderful persons I know!"); yola_levelup5_faces.Add(14);
        yola_levelup5.Add("Yola: Yola is happy! Yola wants to spend all Yola’s life with you! Yola is yours forever!"); yola_levelup5_faces.Add(21);
        //Yola's Gifts (positive)
        yola_gifts.Add("Yola: Hmm? What’s this?"); yola_gifts_faces.Add(11);
        yola_gifts.Add("Yola: You think that Yola likes something like this?"); yola_gifts_faces.Add(11);
        yola_gifts.Add("Yola: Yola thanks you but next time bring something shinier!"); yola_gifts_faces.Add(11);
        yola_gifts.Add("Yola: Yola likes this!"); yola_gifts_faces.Add(21);
        yola_gifts.Add("Yola: This is a lovely gift for Yola! Thank you!"); yola_gifts_faces.Add(21);
        yola_gifts.Add("Yola: Yola likes you more than anything! Yola likes your gifts even more!"); yola_gifts_faces.Add(21);
        yola_gifts.Add("Yola: Thank you! Yola is now forever happy! Yola will never be sad again! Never! Yola can smile every day from now on!"); yola_gifts_faces.Add(21);
        yola_gifts.Add("Yola has a treasure. Yola wants to give this to you to show how much you mean to Yola. Please accept  and take good care of this."); yola_gifts_faces.Add(21);
        //Yola's Gifts (negative)
        yola_badgifts.Add("Yola: Ewwww. No thanks!"); yola_badgifts_faces.Add(22);
        yola_badgifts.Add("Yola: Please take that away from Yola."); yola_badgifts_faces.Add(22);
        yola_badgifts.Add("Yola: Yola doesn’t want that."); yola_badgifts_faces.Add(22);
        yola_badgifts.Add("Yola: A good friend would never give that to Yola."); yola_badgifts_faces.Add(22);
        yola_badgifts.Add("Yola: Yola thinks you are cute but Yola thinks that isn’t."); yola_badgifts_faces.Add(22);
        yola_badgifts.Add("Yola: Thanks, but no thanks!"); yola_badgifts_faces.Add(22);
        //Yola has nothing to say
        yola_nothingtosay.Add("Yola: Yes?"); yola_nothingtosay_faces.Add(11);
        yola_nothingtosay.Add("Yola: Bees go “Bzzz” and Yola goes “Zzzz”."); yola_nothingtosay_faces.Add(11);
        yola_nothingtosay.Add("Yola: Yola doesn’t have anything more to say."); yola_nothingtosay_faces.Add(11);
        //Yola's quests
        yola_quests.Add("Yola: Hmm, thanks."); yola_quests_faces.Add(11);
        yola_quests.Add("Yola: Yola is grateful for the help."); yola_quests_faces.Add(21);
        yola_quests.Add("Yola: Yola appreciates this."); yola_quests_faces.Add(21);
        yola_quests.Add("Yola: You made Yola really happy!"); yola_quests_faces.Add(21);
        //Yola's flirts
        yola_flirts.Add("Ghoul: Are your pants a compressed file? Because I'd like to unzip them."); yola_flirts_faces.Add(13);
        yola_flirts.Add("Yola: You are weird. Do you know who you are talking to?"); yola_flirts_faces.Add(22);
        yola_flirts.Add("Ghoul: You are so pretty that I forgot my best pick-up line!"); yola_flirts_faces.Add(13);
        yola_flirts.Add("Yola: What’s that…? Do you remember what Yola told you about the swamp?"); yola_flirts_faces.Add(11);
        yola_flirts.Add("Ghoul: Do you believe in love at first sight or should I walk past you again?"); yola_flirts_faces.Add(13);
        yola_flirts.Add("Yola: Yola thinks that you are funny! Can you tell what Yola does to the drowned?"); yola_flirts_faces.Add(11);
        yola_flirts.Add("Ghoul: What would you like to have for breakfast at my place?"); yola_flirts_faces.Add(13);
        yola_flirts.Add("Yola: You make Yola smile. Tell me, what Yola is?"); yola_flirts_faces.Add(21);
        yola_flirts.Add("Ghoul: You want to share something else than just opinions?"); yola_flirts_faces.Add(13);
        yola_flirts.Add("Yola: Yola will share you something: a fist in your eye socket. You remember who puts up the lights in the swamp?"); yola_flirts_faces.Add(22);
        yola_flirts.Add("Ghoul: Hi, what's a girl like you doing in a lovely place like this?"); yola_flirts_faces.Add(13);
        yola_flirts.Add("Yola: The swamp is nice! Tell me, what do townsfolk think about the swamp?"); yola_flirts_faces.Add(11);
        yola_flirts.Add("Ghoul: Pardon me, but what pickup line works best with you?"); yola_flirts_faces.Add(13);
        yola_flirts.Add("Yola: Teehee! Yola is amused. Do you remember what Yola told you about Yola’s family?"); yola_flirts_faces.Add(21);
        yola_flirts.Add("Ghoul: Yola, do y-."); yola_flirts_faces.Add(13);
        yola_flirts.Add("Yola: Hush! Can you remember what you were told about family members?"); yola_flirts_faces.Add(11);
        yola_flirts.Add("Ghoul: I miss my teddy bear. Would you sleep with me?"); yola_flirts_faces.Add(13);
        yola_flirts.Add("Yola: You are amusing little thing! Yola told you something about Yola’s way of living, remember?"); yola_flirts_faces.Add(21);
        yola_flirts.Add("Ghoul: Hey, somebody farted. Let's get out of here."); yola_flirts_faces.Add(13);
        yola_flirts.Add("Yola: Don’t worry, it’s just gas from the swamp. What do Yola’s sisters do for living?"); yola_flirts_faces.Add(11);
        yola_flirts.Add("Ghoul: I looked up the word 'beautiful' in the dictionary today, and your name was included."); yola_flirts_faces.Add(13);
        yola_flirts.Add("Yola: Really ? !Can you remember what Yola fears?"); yola_flirts_faces.Add(11);
        yola_flirts.Add("Ghoul: Your daddy must have been a baker, 'cause you've got a nice set of buns."); yola_flirts_faces.Add(13);
        yola_flirts.Add("Yola: Giggle! Do you know what Yola thinks about moving into the town?"); yola_flirts_faces.Add(21);
        yola_flirts.Add("Ghoul: Can I check your shirt label to see if you are made in heaven?"); yola_flirts_faces.Add(13);
        yola_flirts.Add("Yola: Shirt label…? Do you remember what Yola wants to find?"); yola_flirts_faces.Add(11);
        yola_flirts.Add("Ghoul: If I could rearrange the alphabet, I'd put U and I together."); yola_flirts_faces.Add(13);
        yola_flirts.Add("Yola: Yola doesn’t know what an alphabet is! But do you know what Yola knows?"); yola_flirts_faces.Add(11);
        yola_flirts.Add("Ghoul: If I told you had a beautiful body, would you hold it against me?"); yola_flirts_faces.Add(13);
        yola_flirts.Add("Yola: Yola likes your funny questions! Yola told you what Yola wants from the townsfolk, remember?"); yola_flirts_faces.Add(21);
        //Yola's flirt choices
        /*2*/
        yola_choices.Add("Yoda"); yola_choices.Add("Yola"); yola_choices.Add("Yolandi");
        /*2*/
        yola_choices.Add("People come here for picnics"); yola_choices.Add("People drown here after following floating lights"); yola_choices.Add("You don’t like the swamp");
        /*1*/
        yola_choices.Add("You take stuff from their pockets."); yola_choices.Add("You drag them out of the swamp"); yola_choices.Add("You try to stay as far as possible from them");
        /*1*/
        yola_choices.Add("You are a fey"); yola_choices.Add("You are a pixie"); yola_choices.Add("You are a sprite");
        /*2*/
        yola_choices.Add("Orcs"); yola_choices.Add("You"); yola_choices.Add("Townsfolk");
        /*2*/
        yola_choices.Add("That the swamp is lovely"); yola_choices.Add("That the swamp is dangerous"); yola_choices.Add("That there is no swamp");
        /*3*/
        yola_choices.Add("You and your mother are really close"); yola_choices.Add("You and your brother are the only ones in your family"); yola_choices.Add("You don’t remember having parents but you have lots of sisters");
        /*1*/
        yola_choices.Add("You want your sisters to stay away"); yola_choices.Add("You want to find your sisters"); yola_choices.Add("You didn’t tell me anything about them?");
        /*2*/
        yola_choices.Add("You work as a waiter in the tavern"); yola_choices.Add("You loot pockets of the drowned"); yola_choices.Add("You work as a waiter in the tavern");
        /*1*/
        yola_choices.Add("They lure people into swamps and then they loot their pockets"); yola_choices.Add("They have a restaurant in the capital"); yola_choices.Add("There are no sisters");
        /*3*/
        yola_choices.Add("Nothing"); yola_choices.Add("The Drowned"); yola_choices.Add("Dragons");
        /*2*/
        yola_choices.Add("You want to move there as soon as possible"); yola_choices.Add("You would never move there"); yola_choices.Add("Ummmm…?");
        /*2*/
        yola_choices.Add("More coins"); yola_choices.Add("A crown"); yola_choices.Add("A diamond");
        /*1*/
        yola_choices.Add("You know a lot of secrets about townsfolk"); yola_choices.Add("You know how to bake a cake"); yola_choices.Add("You know where to find the best meals around the town");
        /*3*/
        yola_choices.Add("You want them to give you gifts"); yola_choices.Add("You want them to stop coming here"); yola_choices.Add("You want them to see how beautiful the swamp is");
        //Yola's flirt correct answers
        yola_correct.Add(2); yola_correct.Add(2); yola_correct.Add(1); yola_correct.Add(1); yola_correct.Add(2);
        yola_correct.Add(2); yola_correct.Add(3); yola_correct.Add(1); yola_correct.Add(2); yola_correct.Add(1);
        yola_correct.Add(3); yola_correct.Add(2); yola_correct.Add(2); yola_correct.Add(1); yola_correct.Add(3);
        //Yola's flirt wrong answers
        yola_wronganswers.Add("Yola: Yola doesn’t like you at all."); yola_wronganswers_faces.Add(22);
        yola_wronganswers.Add("Yola: Yola thinks you are stupid."); yola_wronganswers_faces.Add(22);
        yola_wronganswers.Add("Yola: Sigh... Yola must be the only smart person in this world."); yola_wronganswers_faces.Add(22);
        yola_wronganswers.Add("Yola: Silly little friend, Yola thinks you are not listening a word Yola says!"); yola_wronganswers_faces.Add(22);
        yola_wronganswers.Add("Yola: Yola thinks that you should know Yola better by now."); yola_wronganswers_faces.Add(22);
        //Yola's flirt correct answers
        yola_correctanswers.Add("Yola: You are correct."); yola_correct_faces.Add(21);
        yola_correctanswers.Add("Yola: Yola agrees with you."); yola_correct_faces.Add(21);
        yola_correctanswers.Add("Yola: Yola sees that you have been listening."); yola_correct_faces.Add(21);
        yola_correctanswers.Add("Yola: You truly know Yola."); yola_correct_faces.Add(21);
        yola_correctanswers.Add("Yola: Yola sees that you are a true friend!"); yola_correct_faces.Add(21);
        //Yola's questions and answers
        //1
        yola_question1.Add("Ghoul: Who are you ?"); yola_question1_faces.Add(12);
        yola_question1.Add("Yola: Don’t you already know who Yola is? Yola is me! I am Yola!"); yola_question1_faces.Add(11);
        //2
        yola_question2.Add("Ghoul: You live here all alone?"); yola_question2_faces.Add(12);
        yola_question2.Add("Yola: Yola lives here yes but not alone! Yola has drowned ones under the water!"); yola_question2_faces.Add(11);
        //3
        yola_question3.Add("Ghoul: Can you tell me anything about this place?"); yola_question3_faces.Add(12);
        yola_question3.Add("Yola: Swamp takes the drowned. Yola takes treasures from the drowned. Circle of life: it all ends at Yola’s pocket."); yola_question3_faces.Add(21);
        //4
        yola_question4.Add("Ghoul: So, you killed all those people to take their riches?"); yola_question4_faces.Add(14);
        yola_question4.Add("Yola: Yola is not a killer, no! They came here themselves. They saw the tiny lights hovering around the swamp and followed them."); yola_question4_faces.Add(22);
        yola_question4.Add("Yola: Then the swamp took them. And Yola took treasures!"); yola_question4_faces.Add(21);
        //5
        yola_question5.Add("Ghoul: But why you haven’t been taken by the swamp?"); yola_question5_faces.Add(12);
        yola_question5.Add("Yola: Yola is not some simple townsfolk. Yola and the swamp are like best friends."); yola_question5_faces.Add(11);
        yola_question5.Add("Yola: They help each other out! The swamp doesn’t want to hurt Yola!"); yola_question5_faces.Add(21);
        //6
        yola_question6.Add("Ghoul: What are you exactly?"); yola_question6_faces.Add(12);
        yola_question6.Add("Yola: Aren’t you a silly little thing! Can’t you see that Yola is a fey!"); yola_question6_faces.Add(11);
        //7
        yola_question7.Add("Ghoul: So, it is you who leads people into the swamp during nights by putting up those lights that people follow?"); yola_question7_faces.Add(14);
        yola_question7.Add("Yola: Oh, you figured it out! That is what Yola does! That is how Yola has always been doing!"); yola_question7_faces.Add(21);
        //8
        yola_question8.Add("Ghoul: Isn’t that wrong? I mean, you are killing people!"); yola_question8_faces.Add(14);
        yola_question8.Add("Yola: Yola is not a killer no! Stupid townsfolk should listen to their mothers and not wander around here during night!"); yola_question8_faces.Add(22);
        yola_question8.Add("Yola: Or at least they should learn how to swim… Or not carry such heavy treasures in their pockets…"); yola_question8_faces.Add(11);
        yola_question8.Add("Yola: Anyway, Yola doesn’t think it is wrong! Yola too needs a way to live!"); yola_question8_faces.Add(21);
        //9
        yola_question9.Add("Ghoul: What about the townsfolk? They might not like the idea that you are killing them…"); yola_question9_faces.Add(13);
        yola_question9.Add("Yola: Yola never tells them, it is a secret. They only know that the swamp has taken them."); yola_question9_faces.Add(11);
        yola_question9.Add("Yola: They blame the swamp and think that Yola is cute."); yola_question9_faces.Add(21);
        //10
        yola_question10.Add("Ghoul: Tell me: who taught you to lure people into the swamp?"); yola_question10_faces.Add(12);
        yola_question10.Add("Yola: Yola doesn’t remember being born. Yola doesn’t remember a mother. Yola has always just been here…"); yola_question10_faces.Add(11);
        yola_question10.Add("Yola: Yola noticed that people like shiny things and are afraid of the dark so they go towards the light during night."); yola_question10_faces.Add(11);
        yola_question10.Add("Yola: Yola started to put up the lights so that people would come here. Then they started to drown and Yola started to find treasures."); yola_question10_faces.Add(11);
        yola_question10.Add("Yola: It has always been so and it will forever be so."); yola_question10_faces.Add(11);
        //11
        yola_question11.Add("Ghoul: So, no parents at all? How about siblings or other family?"); yola_question11_faces.Add(13);
        yola_question11.Add("Yola: Yola doesn’t remember parents but Yola remembers sisters. A lot of sisters. "); yola_question11_faces.Add(11);
        yola_question11.Add("Yola: Hundreds too many."); yola_question11_faces.Add(22);
        yola_question11.Add("Yola: Yola is glad that they are not here!"); yola_question11_faces.Add(21);
        yola_question11.Add("Yola: Yola doesn’t want them to take Yola’s treasures!"); yola_question11_faces.Add(22);
        yola_question11.Add("Yola: Yola wants that they stay away!"); yola_question11_faces.Add(22);
        //12
        yola_question12.Add("Ghoul: So, all of you are killers and thieves?"); yola_question12_faces.Add(13);
        yola_question12.Add("Yola: Shut your little noisy mouth! Yola is not a killer! Yola has told that already!"); yola_question12_faces.Add(22);
        yola_question12.Add("Yola: But yes, sisters live around Lagicam’s swamp areas and live the same way Yola does."); yola_question12_faces.Add(11);
        yola_question12.Add("Yola: They take treasures that no one needs anymore. But they are not killers either! Killing is a no-no!"); yola_question12_faces.Add(11);
        //13
        yola_question13.Add("Ghoul: Will you stop luring people into the swamp at some point? Like when you have enough treasures?"); yola_question13_faces.Add(12);
        yola_question13.Add("Yola: Hmm, Yola has thought about that few times…"); yola_question13_faces.Add(11);
        yola_question13.Add("Yola: Yola thinks that maybe someday Yola has too many treasures and a huge dragon might swoop down and take all of them away from Yola."); yola_question13_faces.Add(22);
        yola_question13.Add("Yola: So, maybe Yola should stop at some point… "); yola_question13_faces.Add(11);
        yola_question13.Add("Yola: Yola really doesn’t know but Yola is a bit scared of the dragons… "); yola_question13_faces.Add(11);
        yola_question13.Add("Yola: But only dragons! Nothing else is scary!"); yola_question13_faces.Add(22);
        //14
        yola_question14.Add("Ghoul: Don’t you think that you already have enough treasures?"); yola_question14_faces.Add(13);
        yola_question14.Add("Ghoul: You cannot even wear all the jewelry and I haven’t seen you use coins at all…"); yola_question14_faces.Add(12);
        yola_question14.Add("Yola: Yola tells you something…"); yola_question14_faces.Add(11);
        yola_question14.Add("Yola: Yola has many lesser trinkets and golden coins but those are not what Yola is looking for!"); yola_question14_faces.Add(11);
        yola_question14.Add("Yola: Yola wants to wear a crown!"); yola_question14_faces.Add(21);
        yola_question14.Add("Yola: Yola must look like a princess so that townsfolk stop thinking that Yola is a dirty creature living in a dirty hole!"); yola_question14_faces.Add(21);
        yola_question14.Add("Yola: Yola is not dirty and the hole is home!"); yola_question14_faces.Add(22);
        //15
        yola_question15.Add("Ghoul: Do you ever think about moving into the town?"); yola_question15_faces.Add(12);
        yola_question15.Add("Yola: No, never!"); yola_question15_faces.Add(22);
        yola_question15.Add("Yola: Hole is home and Yola is happy with all the frogs and the drowned."); yola_question15_faces.Add(21);
        yola_question15.Add("Yola: Yola just wants others to see the beauty of the swamp. It is not dirty, it is peaceful."); yola_question15_faces.Add(21);
        //16
        yola_question16.Add("Ghoul: What is your biggest secret?"); yola_question16_faces.Add(13);
        yola_question16.Add("Yola: You already know what Yola does with the lights…"); yola_question16_faces.Add(11);
        yola_question16.Add("Yola: But you don’t know secrets about townsfolk! The innkeeper is not only a pretty face and bountiful bust."); yola_question16_faces.Add(21);
        yola_question16.Add("Yola: She has been a great hunter before she established the tavern. "); yola_question16_faces.Add(21);
        yola_question16.Add("Yola: I heard that she even killed the hairless bear with her bare hands."); yola_question16_faces.Add(22);
        yola_question16.Add("Yola: The pope used to be a dancer and he used to perform to all the rich people before he found the Potato."); yola_question16_faces.Add(21);
        yola_question16.Add("Yola: Shopkeeper has a secret stash of magical dust you inhale to get a funny feeling of happiness."); yola_question16_faces.Add(21);
        //Lists to lists
        yola_questionLists.Add(yola_question1);
        yola_questionLists.Add(yola_question2);
        yola_questionLists.Add(yola_question3);
        yola_questionLists.Add(yola_question4);
        yola_questionLists.Add(yola_question5);
        yola_questionLists.Add(yola_question6);
        yola_questionLists.Add(yola_question7);
        yola_questionLists.Add(yola_question8);
        yola_questionLists.Add(yola_question9);
        yola_questionLists.Add(yola_question10);
        yola_questionLists.Add(yola_question11);
        yola_questionLists.Add(yola_question12);
        yola_questionLists.Add(yola_question13);
        yola_questionLists.Add(yola_question14);
        yola_questionLists.Add(yola_question15);
        yola_questionLists.Add(yola_question16);
        yola_levelLists.Add(yola_levelup1);
        yola_levelLists.Add(yola_levelup2);
        yola_levelLists.Add(yola_levelup3);
        yola_levelLists.Add(yola_levelup4);
        yola_levelLists.Add(yola_levelup5);

        yola_questionLists_faces.Add(yola_question1_faces);
        yola_questionLists_faces.Add(yola_question2_faces);
        yola_questionLists_faces.Add(yola_question3_faces);
        yola_questionLists_faces.Add(yola_question4_faces);
        yola_questionLists_faces.Add(yola_question5_faces);
        yola_questionLists_faces.Add(yola_question6_faces);
        yola_questionLists_faces.Add(yola_question7_faces);
        yola_questionLists_faces.Add(yola_question8_faces);
        yola_questionLists_faces.Add(yola_question9_faces);
        yola_questionLists_faces.Add(yola_question10_faces);
        yola_questionLists_faces.Add(yola_question11_faces);
        yola_questionLists_faces.Add(yola_question12_faces);
        yola_questionLists_faces.Add(yola_question13_faces);
        yola_questionLists_faces.Add(yola_question14_faces);
        yola_questionLists_faces.Add(yola_question15_faces);
        yola_questionLists_faces.Add(yola_question16_faces);
        yola_levelLists_faces.Add(yola_levelup1_faces);
        yola_levelLists_faces.Add(yola_levelup2_faces);
        yola_levelLists_faces.Add(yola_levelup3_faces);
        yola_levelLists_faces.Add(yola_levelup4_faces);
        yola_levelLists_faces.Add(yola_levelup5_faces);

        //GRU'S LINES
        //Gru's first conversation
        gru_first.Add("???: GRRRUUUUUHH!"); gru_first_faces.Add(20);
        gru_first.Add("Ghoul: Easy! I am friendly! Just like I hope you are too!"); gru_first_faces.Add(14);
        gru_first.Add("???: Grruuuuhhh…?"); gru_first_faces.Add(10);
        gru_first.Add("Ghoul: Just like that. Let’s not harm each other."); gru_first_faces.Add(12);
        gru_first.Add("???: Gruhh."); gru_first_faces.Add(10);
        //Gru's greetings
        gru_greetings.Add("???: Gruuhhh..."); gru_greetings_faces.Add(10);
        gru_greetings.Add("Gru: Gruuhhhh. Hello."); gru_greetings_faces.Add(10);
        gru_greetings.Add("Gru: Gru say hello."); gru_greetings_faces.Add(10);
        gru_greetings.Add("Gru: Hello friend."); gru_greetings_faces.Add(19);
        gru_greetings.Add("Gru: Friend come. Gru happy."); gru_greetings_faces.Add(19);
        gru_greetings.Add("Gru: Gru love when friend come."); gru_greetings_faces.Add(19);
        //Gru's Goodbyes
        gru_byes.Add("???: Grruuuuhhh..."); gru_byes_faces.Add(10);
        gru_byes.Add("Gru: Gru!"); gru_byes_faces.Add(10);
        gru_byes.Add("Gru: Gru say bye."); gru_byes_faces.Add(10);
        gru_byes.Add("Gru: Gru stay here."); gru_byes_faces.Add(19);
        gru_byes.Add("Gru: Gru wait friend. Friend come back."); gru_byes_faces.Add(19);
        gru_byes.Add("Gru: Gru miss friend! "); gru_byes_faces.Add(19);
        //Gru's How are yous
        gru_hay.Add("???: Gruuuuhh."); gru_hay_faces.Add(10);
        gru_hay.Add("Gru: Gru tired."); gru_hay_faces.Add(10);
        gru_hay.Add("Gru: Gru hungry. Chicken good!"); gru_hay_faces.Add(10);
        gru_hay.Add("Gru: Gru like mountain."); gru_hay_faces.Add(10);
        gru_hay.Add("Gru: Gru no eat friend. Friend is no food."); gru_hay_faces.Add(10);
        gru_hay.Add("Gru: Gru happy!"); gru_hay_faces.Add(19);
        //Gru's level ups
        //1
        gru_levelup1.Add("Gru: Gru no angry."); gru_levelup1_faces.Add(10);
        //2
        gru_levelup2.Add("Ghoul: Thank you for not eating me."); gru_levelup2_faces.Add(12);
        gru_levelup2.Add("Gru: Gru?"); gru_levelup2_faces.Add(20);
        gru_levelup2.Add("Ghoul: You. No. Eat. Me. Me thanks you!"); gru_levelup2_faces.Add(12);
        gru_levelup2.Add("Gru: Gru Gru! Gru no eat bad taste."); gru_levelup2_faces.Add(10);
        gru_levelup2.Add("Ghoul: Yes. Me is very bad taste!"); gru_levelup2_faces.Add(12);
        //3
        gru_levelup3.Add("Ghoul: Gru, do you want to do something?"); gru_levelup3_faces.Add(13);
        gru_levelup3.Add("Gru: Gru sit here. Gru listen friend. Friend tell story."); gru_levelup3_faces.Add(10);
        gru_levelup3.Add("Ghoul: Well, hmm… Once upon a time there was a pretty cyclops living in a cave beneath mother mountain. Cyclops was lonely. One day the cyclops met a wanderer and they became friends. The end."); gru_levelup3_faces.Add(12);
        gru_levelup3.Add("Gru: Gru? Story good. Gru and friend story."); gru_levelup3_faces.Add(19);
        gru_levelup3.Add("Ghoul: Yes, the story was about us."); gru_levelup3_faces.Add(13);
        gru_levelup3.Add("Gru: Gru happy!"); gru_levelup3_faces.Add(19);
        //4
        gru_levelup4.Add("Gru: Gru thank friend."); gru_levelup4_faces.Add(10);
        gru_levelup4.Add("Ghoul: For what?"); gru_levelup4_faces.Add(12);
        gru_levelup4.Add("Gru: Gru no more alone. Gru have friend."); gru_levelup4_faces.Add(19);
        gru_levelup4.Add("Ghoul: Well, thank you for being my friend, Gru!"); gru_levelup4_faces.Add(13);
        gru_levelup4.Add("Gru: Gru! Friend teach Gru read?"); gru_levelup4_faces.Add(10);
        gru_levelup4.Add("Ghoul: You know it will be a challenging task? But we can try if you want."); gru_levelup4_faces.Add(14);
        gru_levelup4.Add("Gru: Gru smart. Gru learn!"); gru_levelup4_faces.Add(19);
        gru_levelup4.Add("Ghoul: Well, let’s get to it then!"); gru_levelup4_faces.Add(12);
        //5
        gru_levelup5.Add("Gru: Gru know alphabet. Friend want hear?");gru_levelup5_faces.Add(10);
        gru_levelup5.Add("Ghoul: Sure, go ahead."); gru_levelup5_faces.Add(12);
        gru_levelup5.Add("Gru: A, B, C, D, X, P, G, R, H, T… Gru no remember more."); gru_levelup5_faces.Add(21);
        gru_levelup5.Add("Ghoul: Then we should train a bit more! You will learn them."); gru_levelup5_faces.Add(13);
        gru_levelup5.Add("Gru: Friend no angry? Friend teach more? Friend no go away?"); gru_levelup5_faces.Add(10);
        gru_levelup5.Add("Ghoul: Of course not! I am here for you!"); gru_levelup5_faces.Add(12);
        gru_levelup5.Add("Gru: Gru happy! Gru think friend is good. Gru think Gru like and like friend."); gru_levelup5_faces.Add(19);
        gru_levelup5.Add("Ghoul: Like and like? Like, you like a lot?"); gru_levelup5_faces.Add(13);
        gru_levelup5.Add("Gru: More. Like no enough. Gru love friend!"); gru_levelup5_faces.Add(19);
        gru_levelup5.Add("Ghoul: Are you sure…?"); gru_levelup5_faces.Add(14);
        gru_levelup5.Add("Gru: Gru no stupid. Gru know love. Gru love friend!"); gru_levelup5_faces.Add(10);
        gru_levelup5.Add("Ghoul: Well, then I must tell you that I love you too, Gru!"); gru_levelup5_faces.Add(13);
        gru_levelup5.Add("Gru: GRRRUUUUUUUHH! Gru happy!"); gru_levelup5_faces.Add(19);
        //Gru's reaction to a gift
        gru_gifts.Add("???: Gruuhhh?");gru_gifts_faces.Add(10);
        gru_gifts.Add("Gru: Gru?"); gru_gifts_faces.Add(10);
        gru_gifts.Add("Gru: Gru takes."); gru_gifts_faces.Add(10);
        gru_gifts.Add("Gru: Gru like gift."); gru_gifts_faces.Add(19);
        gru_gifts.Add("Gru: Gru thank friend."); gru_gifts_faces.Add(19);
        gru_gifts.Add("Gru: Gru is happy! Gru love gift!"); gru_gifts_faces.Add(19);
        gru_gifts.Add("Gru: Friend give this to Gru?! Gru no know what to say… Gru thank friend! Gru take good care of this!"); gru_gifts_faces.Add(19);
        gru_gifts.Add("Gru: Gru want to give this. This is treasure. Gru has it looong time. Now Gru give this to friend Gru loves most."); gru_gifts_faces.Add(19);
        //Gru's reaction to bad gifts
        gru_badgifts.Add("???: GRRUUUUHH!"); gru_badgifts_faces.Add(20);
        gru_badgifts.Add("Gru: Gru no want that."); gru_badgifts_faces.Add(20);
        gru_badgifts.Add("Gru: Gru no take that."); gru_badgifts_faces.Add(20);
        gru_badgifts.Add("Gru: Gru no like that."); gru_badgifts_faces.Add(20);
        gru_badgifts.Add("Gru: Gru thank friend but Gru no want that…"); gru_badgifts_faces.Add(20);
        gru_badgifts.Add("Gru: Gru like friend but Gru say no to gift..."); gru_badgifts_faces.Add(20);
        //When gru has nothing to say
        gru_nothingtosay.Add("Gru: Gru?"); gru_nothingtosay_faces.Add(10);
        gru_nothingtosay.Add("Gru: Grrrruuuuuhhhh..."); gru_nothingtosay_faces.Add(10);
        gru_nothingtosay.Add("Gru: Gru no speak…"); gru_nothingtosay_faces.Add(10);
        //Gru's flirts
        gru_flirts.Add("Ghoul: Is it hot in here or is it just you?"); gru_flirts_faces.Add(13);
        gru_flirts.Add("???: Grrruuuhh…. You know who you talk to?"); gru_flirts_faces.Add(20);
        gru_flirts.Add("Ghoul: What else do you do than being beautiful?"); gru_flirts_faces.Add(13);
        gru_flirts.Add("Gru: Gru smash stupids. You know what Gru is?"); gru_flirts_faces.Add(10);
        gru_flirts.Add("Ghoul: There must be something wrong in my eyes ‘cause I can’t take them off of you."); gru_flirts_faces.Add(13);
        gru_flirts.Add("Gru: You say something about Gru’s eye?! You know where Gru live?"); gru_flirts_faces.Add(10);
        gru_flirts.Add("Ghoul: Nice loincloth! It would look nicer on floor of my house!"); gru_flirts_faces.Add(13);
        gru_flirts.Add("Gru: Grrrr… You know what Gru eat?"); gru_flirts_faces.Add(10);
        gru_flirts.Add("Ghoul: Hey babe, you are hotter than a stove at the maximum!"); gru_flirts_faces.Add(13);
        gru_flirts.Add("Gru: Gru? You know how Gru get food?"); gru_flirts_faces.Add(10);
        gru_flirts.Add("Ghoul: How does it feel to be the prettiest in here?"); gru_flirts_faces.Add(13);
        gru_flirts.Add("Gru: Gru is only one in this cave... You remember how old Gru is?"); gru_flirts_faces.Add(10);
        gru_flirts.Add("Ghoul: You must be tired from running in my dreams whole night!"); gru_flirts_faces.Add(13);
        gru_flirts.Add("Gru: Gru is here all night… You know where Gru is from?"); gru_flirts_faces.Add(10);
        gru_flirts.Add("Ghoul: I have just moved to town. Can you help me to find your place?"); gru_flirts_faces.Add(13);
        gru_flirts.Add("Gru: You already here... You know what happen to other cyclopses?"); gru_flirts_faces.Add(10);
        gru_flirts.Add("Ghoul: Your parents must have been fruits since you are so juicy!"); gru_flirts_faces.Add(13);
        gru_flirts.Add("Gru: Gruuuuhh... You know what Gru want do?"); gru_flirts_faces.Add(10);
        gru_flirts.Add("Ghoul: Can I walk you home since my parent told me to follow my dreams?"); gru_flirts_faces.Add(13);
        gru_flirts.Add("Gru: Gruuhuhu... You know what Gru want to write poems about?"); gru_flirts_faces.Add(10);
        gru_flirts.Add("Ghoul: Can I offer you a drink so that I would start to look better?"); gru_flirts_faces.Add(13);
        gru_flirts.Add("Gru: Gru can see without drinks... You know what Gru can lift?"); gru_flirts_faces.Add(10);
        gru_flirts.Add("Ghoul: Would you like to have a coffee brought to bed tomorrow morning?"); gru_flirts_faces.Add(13);
        gru_flirts.Add("Gru: Gru no drink coffee. You remember what Gru do when Gru bored"); gru_flirts_faces.Add(10);
        gru_flirts.Add("Ghoul: I looked in my crystal ball and I saw you in my house with me!"); gru_flirts_faces.Add(13);
        gru_flirts.Add("Gru: Gru can no fit in your tiny house. You remember what Gru think about music?"); gru_flirts_faces.Add(10);
        gru_flirts.Add("Ghoul: Your name must be Dream ‘cause you look like one!"); gru_flirts_faces.Add(13);
        gru_flirts.Add("Gru: Name is Gru! You remember what Gru tell about plague"); gru_flirts_faces.Add(10);
        gru_flirts.Add("Ghoul: If you were my socks I would never change them."); gru_flirts_faces.Add(13);
        gru_flirts.Add("Gru: Gru think you silly. You know what Gru go do behind tavern?"); gru_flirts_faces.Add(19);
        //Gru's correct answers
        gru_correctanswers.Add("Gru: GRUUH!"); gru_correct_faces.Add(19);
        gru_correctanswers.Add("Gru: YOU LISTEN, GRU LIKE!"); gru_correct_faces.Add(19);
        gru_correctanswers.Add("Gru: FRIEND IS CORRECT."); gru_correct_faces.Add(19);
        gru_correctanswers.Add("Gru: Friend listen to Gru. That good."); gru_correct_faces.Add(19);
        gru_correctanswers.Add("Gru: Gru happy. Friend know Gru."); gru_correct_faces.Add(19);
        //Gru's wrong answers
        gru_wronganswers.Add("???: GGRRRRUUUUHHH!"); gru_wronganswers_faces.Add(20);
        gru_wronganswers.Add("Gru: GRU ANGRY! GRU SMASH!"); gru_wronganswers_faces.Add(20);
        gru_wronganswers.Add("Gru: GRU NO LIKE FRIEND!"); gru_wronganswers_faces.Add(20);
        gru_wronganswers.Add("Gru: Gru think friend stupid. Friend no listen."); gru_wronganswers_faces.Add(20);
        gru_wronganswers.Add("Gru: Gru sad. Friend no know Gru."); gru_wronganswers_faces.Add(20);
        //Gru's choices
        gru_choices.Add("Gruh"); gru_choices.Add("Gru"); gru_choices.Add("Gruu"); //2
        gru_choices.Add("You are a cyclop"); gru_choices.Add("You are an ogre"); gru_choices.Add("You are a demon"); //1
        gru_choices.Add("In the village"); gru_choices.Add("In this cave"); gru_choices.Add("In the forest"); //2
        gru_choices.Add("People"); gru_choices.Add("Vegetables"); gru_choices.Add("Chicken"); //3
        gru_choices.Add("16"); gru_choices.Add("56"); gru_choices.Add("156"); //2
        gru_choices.Add("You hunt it yourself"); gru_choices.Add("You have a chicken farm"); gru_choices.Add("Villagers bring you food"); //3
        gru_choices.Add("You were born here"); gru_choices.Add("You came here from the top of the mountain"); gru_choices.Add("You used to live in the forest"); //2
        gru_choices.Add("They went looking for a new mountain"); gru_choices.Add("They were thrown away by a tornado"); gru_choices.Add("They got killed by stampeding sheep"); //2
        gru_choices.Add("You want to have a new flock of sheep"); gru_choices.Add("You want to become a poet"); gru_choices.Add("You want to start a business in the town"); //2
        gru_choices.Add("Chickens and other animals"); gru_choices.Add("Eating and drinking"); gru_choices.Add("Cyclops and mountains"); //3
        gru_choices.Add("You can lift houses but you only lift boulders and fallen trees off the paths"); gru_choices.Add("You can lift mountains if you get really angry"); gru_choices.Add("You don’t really lift anything else than food."); //1
        gru_choices.Add("You sing"); gru_choices.Add("You paint"); gru_choices.Add("You cook"); //2
        gru_choices.Add("You like music but your lute is broken"); gru_choices.Add("You don’t care about music"); gru_choices.Add("You hate music because it hurts your ears"); //1
        gru_choices.Add("You are immune to jumping plague"); gru_choices.Add("You are afraid of it"); gru_choices.Add("You have never told me about it"); //1
        gru_choices.Add("You go listen to music"); gru_choices.Add("You go spying on villagers"); gru_choices.Add("You go looking for food"); //1
        //Gru's correct choices
        gru_correct.Add(2); gru_correct.Add(1); gru_correct.Add(2); gru_correct.Add(3); gru_correct.Add(2);
        gru_correct.Add(3); gru_correct.Add(2); gru_correct.Add(2); gru_correct.Add(2); gru_correct.Add(3);
        gru_correct.Add(1); gru_correct.Add(2); gru_correct.Add(1); gru_correct.Add(1); gru_correct.Add(1);
        //Gru's questions
        //1
        gru_question1.Add("Ghoul: What’s your name?"); gru_question1_faces.Add(12);
        gru_question1.Add("???: Gru. Gru name Gru."); gru_question1_faces.Add(10);
        //2
        gru_question2.Add("Ghoul: Do you live here in this cave?"); gru_question2_faces.Add(13);
        gru_question2.Add("Gru: Gru live here. Mother mountain give home. Gru no leave cave."); gru_question2_faces.Add(10);
        //3
        gru_question3.Add("Ghoul: What are you?"); gru_question3_faces.Add(13);
        gru_question3.Add("Gru: Gru is cyclops Gru."); gru_question3_faces.Add(10);
        //4
        gru_question4.Add("Ghoul: Are you here all alone? Do you have any family?"); gru_question4_faces.Add(14);
        gru_question4.Add("Gru: Gru no alone, Gru have mother mountain. Mother mountain take care. No other family."); gru_question4_faces.Add(19);
        //5
        gru_question5.Add("Ghoul: How do you get food if you are not leaving the cave?"); gru_question5_faces.Add(12);
        gru_question5.Add("Gru: Villagers give food. Gru get food. No food make Gru angry. Villagers no want Gru angry."); gru_question5_faces.Add(20);
        //6
        gru_question6.Add("Ghoul: When I was a child I heard stories about cyclops. Is it true that you eat people?"); gru_question6_faces.Add(12);
        gru_question6.Add("Gru: Gru no really bad cyclop. Gru no eat living food. Gru only eat what villagers give. Gru eat chicken."); gru_question6_faces.Add(10);
        //7
        gru_question7.Add("Ghoul: Well, how old are you?"); gru_question7_faces.Add(13);
        gru_question7.Add("Gru: Gru is no old! Gru only 56 years! Gru pass teenage years but no old."); gru_question7_faces.Add(20);
        //8
        gru_question8.Add("Ghoul: Where do you come from? Or were you born here?"); gru_question8_faces.Add(13);
        gru_question8.Add("Gru: Gru come from mountain. Family on top of mother mountain. Gru have sheep to herd."); gru_question8_faces.Add(10);
        gru_question8.Add("Gru: Big tornado come. Throw all sheep and family away. Gru flee. Gru come here and find cave."); gru_question8_faces.Add(20);
        gru_question8.Add("Gru: Mother mountain give Gru new home. But Gru no know where is others."); gru_question8_faces.Add(19);
        //9
        gru_question9.Add("Ghoul: I am sad to hear about your sheep. Would you like to have new flock to herd?"); gru_question9_faces.Add(12);
        gru_question9.Add("Gru: Gru no want sheep. Sheep stink and they poo. Chicken better. They no smell and they taste good."); gru_question9_faces.Add(20);
        //10
        gru_question10.Add("Ghoul: So, you don’t want to be a shepherd ? What would you like to do then ?"); gru_question10_faces.Add(12);
        gru_question10.Add("Gru: Gru hate sheep. Parents like sheep and make Gru shepherd. Now Gru happy without sheep. Gru want to be poet. But Gru no know how to write."); gru_question10_faces.Add(20);
        //11
        gru_question11.Add("Ghoul: What would you write poems about if you could write?");gru_question11_faces.Add(13);
        gru_question11.Add("Gru: Mother mountain! Other cyclopses! Tell story of cyclopses so no villager want kill anymore cyclopses because of fear."); gru_question11_faces.Add(19);
        //12
        gru_question12.Add("Ghoul: You seem to be pretty strong. How much can you lift?"); gru_question12_faces.Add(12);
        gru_question12.Add("Gru: Gru once lift house but it is accident. Villager angry, Gru sorry. Gru now only lift boulders and trees from paths after storms."); gru_question12_faces.Add(10);
        //13
        gru_question13.Add("Ghoul: What do you do when you get bored?"); gru_question13_faces.Add(13);
        gru_question13.Add("Gru: Gru paint. Look cave walls. Cave paintings. Gru make them. Gru is artist."); gru_question13_faces.Add(19);
        //14
        gru_question14.Add("Ghoul: You seem to really like arts. What do you think about music?"); gru_question14_faces.Add(13);
        gru_question14.Add("Gru: Gru has lute. Gru sit on it. Lute go broken. No more music in cave. Gru go sometime listen music behind tavern."); gru_question14_faces.Add(10);
        //15
        gru_question15.Add("Ghoul: Do you know anyone from the village?"); gru_question15_faces.Add(12);
        gru_question15.Add("Gru: Gru know tiny innkeeper and shopkeeper. They give Gru food. They come tell news from town. They tell when Gru is needed to lift things."); gru_question15_faces.Add(19);
        //16
        gru_question16.Add("Ghoul: Are you afraid of the jumping plague people are talking about in the town?"); gru_question16_faces.Add(13);
        gru_question16.Add("Gru: Gru no fear. Cyclopses can no have plague. Gru immune. Gru smash puny little plague mutants. Gru secretly protect villagers."); gru_question16_faces.Add(19);
        //Gru's quests
        gru_quests.Add("Gru: Gru thank."); gru_quests_faces.Add(19);
        gru_quests.Add("Gru: Gru is grateful."); gru_quests_faces.Add(19);
        gru_quests.Add("Gru: Gru likes you."); gru_quests_faces.Add(19);
        gru_quests.Add("Gru: Gru happy. Thank you."); gru_quests_faces.Add(19);
        //Lists to lists
        gru_questionLists.Add(gru_question1);
        gru_questionLists.Add(gru_question2);
        gru_questionLists.Add(gru_question3);
        gru_questionLists.Add(gru_question4);
        gru_questionLists.Add(gru_question5);
        gru_questionLists.Add(gru_question6);
        gru_questionLists.Add(gru_question7);
        gru_questionLists.Add(gru_question8);
        gru_questionLists.Add(gru_question9);
        gru_questionLists.Add(gru_question10);
        gru_questionLists.Add(gru_question11);
        gru_questionLists.Add(gru_question12);
        gru_questionLists.Add(gru_question13);
        gru_questionLists.Add(gru_question14);
        gru_questionLists.Add(gru_question15);
        gru_questionLists.Add(gru_question16);
        gru_levelLists.Add(gru_levelup1);
        gru_levelLists.Add(gru_levelup2);
        gru_levelLists.Add(gru_levelup3);
        gru_levelLists.Add(gru_levelup4);
        gru_levelLists.Add(gru_levelup5);

        gru_questionLists_faces.Add(gru_question1_faces);
        gru_questionLists_faces.Add(gru_question2_faces);
        gru_questionLists_faces.Add(gru_question3_faces);
        gru_questionLists_faces.Add(gru_question4_faces);
        gru_questionLists_faces.Add(gru_question5_faces);
        gru_questionLists_faces.Add(gru_question6_faces);
        gru_questionLists_faces.Add(gru_question7_faces);
        gru_questionLists_faces.Add(gru_question8_faces);
        gru_questionLists_faces.Add(gru_question9_faces);
        gru_questionLists_faces.Add(gru_question10_faces);
        gru_questionLists_faces.Add(gru_question11_faces);
        gru_questionLists_faces.Add(gru_question12_faces);
        gru_questionLists_faces.Add(gru_question13_faces);
        gru_questionLists_faces.Add(gru_question14_faces);
        gru_questionLists_faces.Add(gru_question15_faces);
        gru_questionLists_faces.Add(gru_question16_faces);
        gru_levelLists_faces.Add(gru_levelup1_faces);
        gru_levelLists_faces.Add(gru_levelup2_faces);
        gru_levelLists_faces.Add(gru_levelup3_faces);
        gru_levelLists_faces.Add(gru_levelup4_faces);
        gru_levelLists_faces.Add(gru_levelup5_faces);

        //FENRIS' LINES
        //Fenris' first conversation
        fenris_first.Add("???: Stay away you plague mutant!"); fenris_first_faces.Add(26);
        fenris_first.Add("Ghoul: What? I am no mutant."); fenris_first_faces.Add(14);
        fenris_first.Add("???: Well you don’t look like any of the townsfolk."); fenris_first_faces.Add(8);
        fenris_first.Add("Ghoul: I have just arrived here so no wonder that you have never seen me before."); fenris_first_faces.Add(12);
        fenris_first.Add("???: Whatever. Just stay away from me."); fenris_first_faces.Add(26);
        //Fenris' greetings
        fenris_greetings.Add("???: ..."); fenris_greetings_faces.Add(26);
        fenris_greetings.Add("Fenris: What do you want?"); fenris_greetings_faces.Add(26);
        fenris_greetings.Add("Fenris: Hello."); fenris_greetings_faces.Add(8);
        fenris_greetings.Add("Fenris: Greetings."); fenris_greetings_faces.Add(8);
        fenris_greetings.Add("Fenris: Nice to see you again, friend."); fenris_greetings_faces.Add(25);
        fenris_greetings.Add("Fenris: Hello… dear… or is that too much…?"); fenris_greetings_faces.Add(25);
        //Fenris' byes
        fenris_byes.Add("???: ..."); fenris_byes_faces.Add(26);
        fenris_byes.Add("Fenris: Finally."); fenris_byes_faces.Add(26);
        fenris_byes.Add("Fenris: Bye."); fenris_byes_faces.Add(8);
        fenris_byes.Add("Fenris: Goodbye."); fenris_byes_faces.Add(8);
        fenris_byes.Add("Fenris: See you soon my friend."); fenris_byes_faces.Add(25);
        fenris_byes.Add("Fenris: I hope to see you soon!"); fenris_byes_faces.Add(25);
        //Fenris' How Are You
        fenris_hay.Add("???: Don’t talk to me."); fenris_hay_faces.Add(26);
        fenris_hay.Add("Fenris: Can’t you see that I am trying to meditate?!"); fenris_hay_faces.Add(26);
        fenris_hay.Add("Fenris: Why you want to know how I am doing? We don’t even know each other…"); fenris_hay_faces.Add(8);
        fenris_hay.Add("Fenris: I am alive. That’s all there is to say."); fenris_hay_faces.Add(8);
        fenris_hay.Add("Fenris: I was hunting this morning and caught a rabbit for us to share but accidentally I ate it…"); fenris_hay_faces.Add(26);
        fenris_hay.Add("Fenris: I am feeling great now that you are here!"); fenris_hay_faces.Add(25);
        //Fenris' Level Ups
        //1
        fenris_levelup1.Add("Fenris: I see you are not deaf. Now leave me alone.");fenris_levelup1_faces.Add(26);
        //2
        fenris_levelup2.Add("Ghoul: Thank you for the conversation."); fenris_levelup2_faces.Add(12);
        fenris_levelup2.Add("Fenris: ..."); fenris_levelup2_faces.Add(26);
        fenris_levelup2.Add("Ghoul: So, you’re not a talkative type?"); fenris_levelup2_faces.Add(14);
        fenris_levelup2.Add("Fenris: I decide when to open my mouth. I speak only when I must."); fenris_levelup2_faces.Add(8);
        fenris_levelup2.Add("Ghoul: Oh."); fenris_levelup2_faces.Add(12);
        //3
        fenris_levelup3.Add("Ghoul: You know what I think... I think that you should go meet townsfolk more often!"); fenris_levelup3_faces.Add(13);
        fenris_levelup3.Add("Fenris: I go there often enough when I sell meat for the shopkeeper."); fenris_levelup3_faces.Add(8);
        fenris_levelup3.Add("Ghoul: Do you know anyone else in town?"); fenris_levelup3_faces.Add(12);
        fenris_levelup3.Add("Fenris: No… Should I?"); fenris_levelup3_faces.Add(8);
        fenris_levelup3.Add("Ghoul: Well, you live close to them. Wouldn’t you want to know your neighbors?"); fenris_levelup3_faces.Add(12);
        fenris_levelup3.Add("Fenris: I think I know them well enough. The bare boned one lives in the tall building and the innkeeper in the tavern with the fat orc. I think there are some more people but really, I couldn’t care less."); fenris_levelup3_faces.Add(26);
        fenris_levelup3.Add("Ghoul: Okay, I won’t pressure you more about the subject."); fenris_levelup3_faces.Add(12);
        //4
        fenris_levelup4.Add("Fenris: I want you to know something."); fenris_levelup4_faces.Add(8);
        fenris_levelup4.Add("Ghoul: Hmm? What is it?"); fenris_levelup4_faces.Add(13);
        fenris_levelup4.Add("Fenris: You are the only one I think I can call a friend in this filthy mudhole."); fenris_levelup4_faces.Add(25);
        fenris_levelup4.Add("Ghoul: Oh, really? So that means you don’t hate me?"); fenris_levelup4_faces.Add(14);
        fenris_levelup4.Add("Fenris: What? Why would I hate you?"); fenris_levelup4_faces.Add(8);
        fenris_levelup4.Add("Ghoul: Well, you always seemed angry at me so I thought that you hated me."); fenris_levelup4_faces.Add(12);
        fenris_levelup4.Add("Fenris: Well that couldn’t be further from the truth. I… I think I truly might even like you."); fenris_levelup4_faces.Add(25);
        fenris_levelup4.Add("Ghoul: You what?"); fenris_levelup4_faces.Add(13);
        fenris_levelup4.Add("Fenris: Nothing! Just forget that I said anything."); fenris_levelup4_faces.Add(8);
        fenris_levelup4.Add("Ghoul: Fenris?"); fenris_levelup4_faces.Add(12);
        fenris_levelup4.Add("Fenris: Silence! I must meditate to gather my thoughts before heading to the woods."); fenris_levelup4_faces.Add(26);
        fenris_levelup4.Add("Ghoul: Whatever you say, friend."); fenris_levelup4_faces.Add(13);
        //5
        fenris_levelup5.Add("Fenris: I must tell you something. I need you to be completely silent and just listen."); fenris_levelup5_faces.Add(8);
        fenris_levelup5.Add("Ghoul: Okay, what is it Fenris?"); fenris_levelup5_faces.Add(13);
        fenris_levelup5.Add("Fenris: I have been thinking a lot of this… This feeling I have, I mean. I have never felt this before and I do not have enough words to describe it."); fenris_levelup5_faces.Add(26);
        fenris_levelup5.Add("Ghoul: Are you okay?"); fenris_levelup5_faces.Add(12);
        fenris_levelup5.Add("Fenris: Just listen. I heard the townsfolk talking about feelings and I thought about them and the only feeling that could be used to describe the flame burning inside of me is Love. I… I think I love you."); fenris_levelup5_faces.Add(8);
        fenris_levelup5.Add("Ghoul: Are you sure?"); fenris_levelup5_faces.Add(14);
        fenris_levelup5.Add("Fenris: Yes, that’s it, I love you!"); fenris_levelup5_faces.Add(25);
        fenris_levelup5.Add("Ghoul: I have been waiting for this!"); fenris_levelup5_faces.Add(12);
        fenris_levelup5.Add("Fenris: What?"); fenris_levelup5_faces.Add(8);
        fenris_levelup5.Add("Ghoul: I love you too, Fenris!"); fenris_levelup5_faces.Add(13);
        fenris_levelup5.Add("Fenris: … I am happy to hear that!"); fenris_levelup5_faces.Add(25);
        //Fenris' reaction to gifts
        fenris_gifts.Add("???: What is this dirty little thing?"); fenris_gifts_faces.Add(26);
        fenris_gifts.Add("Fenris: Why do you offer me trash like this?"); fenris_gifts_faces.Add(26);
        fenris_gifts.Add("Fenris: I will take it but don’t think that it changes the way I think about you."); fenris_gifts_faces.Add(8);
        fenris_gifts.Add("Fenris: What? For me? Really?"); fenris_gifts_faces.Add(8);
        fenris_gifts.Add("Fenris: Thank you. I appreciate this, friend."); fenris_gifts_faces.Add(25);
        fenris_gifts.Add("Fenris: I think this is beautiful gesture. I will keep this close to me."); fenris_gifts_faces.Add(25);
        fenris_gifts.Add("Fenris: You… You really want to give this to me? I… I don’t know what to say!"); fenris_gifts_faces.Add(25);
        fenris_gifts.Add("Fenris: I want to give you something. It might not look like much but for me it is priceless. I love you and I want to show it to you somehow. So, this is my way to show my love. Take it."); fenris_gifts_faces.Add(25);
        //Fenris's reaction to wrong kind of gifts
        fenris_badgifts.Add("???: Don’t give me your foul things."); fenris_badgifts_faces.Add(26);
        fenris_badgifts.Add("Fenris: No. Just don’t."); fenris_badgifts_faces.Add(26);
        fenris_badgifts.Add("Fenris: I don’t want that."); fenris_badgifts_faces.Add(26);
        fenris_badgifts.Add("Fenris: Just keep that to yourself.."); fenris_badgifts_faces.Add(26);
        fenris_badgifts.Add("Fenris: I have to say no to that."); fenris_badgifts_faces.Add(26);
        fenris_badgifts.Add("Fenris: Thank you for the thought but I don’t want that."); fenris_badgifts_faces.Add(26);
        //When fenris has nothing to say
        fenris_nothingtosay.Add("Fenris: What?"); fenris_nothingtosay_faces.Add(8);
        fenris_nothingtosay.Add("Fenris: I don’t have anything to say."); fenris_nothingtosay_faces.Add(8);
        fenris_nothingtosay.Add("Fenris: ..."); fenris_nothingtosay_faces.Add(8);
        //Flirting with Fenris
        fenris_flirts.Add("Ghoul: Are you cold since you are so blue? I could warm you up!");fenris_flirts_faces.Add(13);
        fenris_flirts.Add("???: … What nonsense. Do you even remember my name?"); fenris_flirts_faces.Add(26);
        fenris_flirts.Add("Ghoul: Your place or my place?"); fenris_flirts_faces.Add(13);
        fenris_flirts.Add("Fenris: What...? You know what happens if you wander into the woods, right?"); fenris_flirts_faces.Add(8);
        fenris_flirts.Add("Ghoul: Did the fall hurt since you are such an angel?"); fenris_flirts_faces.Add(13);
        fenris_flirts.Add("Fenris: Do you think that I will fall for that… Can you tell what part of me is sharper than my mind?"); fenris_flirts_faces.Add(8);
        fenris_flirts.Add("Ghoul: Were your parents some kind of clams since you are such a pearl?"); fenris_flirts_faces.Add(13);
        fenris_flirts.Add("Fenris: Haven’t you listened anything I said? Who really was my father?"); fenris_flirts_faces.Add(8);
        fenris_flirts.Add("Ghoul: Uh, do you come here often?"); fenris_flirts_faces.Add(13);
        fenris_flirts.Add("Fenris: None of your business. Can you tell what I am?"); fenris_flirts_faces.Add(8);
        fenris_flirts.Add("Ghoul: Are you a fisherman since I am so hooked?"); fenris_flirts_faces.Add(13);
        fenris_flirts.Add("Fenris: What is wrong with you? Can you tell what I really used to do in my pack?"); fenris_flirts_faces.Add(26);
        fenris_flirts.Add("Ghoul: Am I part of your plans for the weekend?"); fenris_flirts_faces.Add(13);
        fenris_flirts.Add("Fenris: You really are a weird one… Do you remember what happened to my family?"); fenris_flirts_faces.Add(8);
        fenris_flirts.Add("Ghoul: I think I got little burnt by looking at you."); fenris_flirts_faces.Add(13);
        fenris_flirts.Add("Fenris: ... Can you remember what my tribe was called?"); fenris_flirts_faces.Add(8);
        fenris_flirts.Add("Ghoul: Can you come help me choose new bedsheets at my place?"); fenris_flirts_faces.Add(13);
        fenris_flirts.Add("Fenris: You must be joking... You know how I feel about joking, right?"); fenris_flirts_faces.Add(8);
        fenris_flirts.Add("Ghoul: Don’t be startled if a big fat old man in red clothes come and stuff you in a sack in the middle of a night. You were on my wish list for Christmas!"); fenris_flirts_faces.Add(13);
        fenris_flirts.Add("Fenris: Christ… mas...? Well anyhow, can you remember what I think about that big fat orc in the tavern?"); fenris_flirts_faces.Add(8);
        fenris_flirts.Add("Ghoul: If you were a hamburger, your name would be McGorgeous!"); fenris_flirts_faces.Add(13);
        fenris_flirts.Add("Fenris: I see... Can you remember what my mother told me when I was a cub?"); fenris_flirts_faces.Add(8);
        fenris_flirts.Add("Ghoul: Do you believe in magic? I could show you my magic wand!"); fenris_flirts_faces.Add(13);
        fenris_flirts.Add("Fenris: Excuse me? Do you know what kind of creatures are told to bring wolflings into this world?"); fenris_flirts_faces.Add(8);
        fenris_flirts.Add("Ghoul: Do you know how much a polar bear weighs? I don’t but at least it can break the ice!"); fenris_flirts_faces.Add(13);
        fenris_flirts.Add("Fenris: Are you trying to imply something? Do you remember what I think about being lonely?"); fenris_flirts_faces.Add(8);
        fenris_flirts.Add("Ghoul: I have a waterbed; do you want to come over to create some waves?"); fenris_flirts_faces.Add(13);
        fenris_flirts.Add("Fenris: What are you suggesting? Can you tell how I feel about you visiting me?"); fenris_flirts_faces.Add(8);
        fenris_flirts.Add("Ghoul: Do you have a map? I think I got lost in your eyes"); fenris_flirts_faces.Add(13);
        fenris_flirts.Add("Fenris: Can you stop with the silly questions and be serious for a while? Tell me, do you remember what I told my dream for the future is?"); fenris_flirts_faces.Add(25);
        //Wrong answer reactions for fenris
        fenris_wronganswers.Add("???: You’re pathetic."); fenris_wronganswers_faces.Add(26);
        fenris_wronganswers.Add("Fenris: Are you even trying?"); fenris_wronganswers_faces.Add(26);
        fenris_wronganswers.Add("Fenris: You are a weakling."); fenris_wronganswers_faces.Add(26);
        fenris_wronganswers.Add("Fenris: Are you not listening a word I say?"); fenris_wronganswers_faces.Add(26);
        fenris_wronganswers.Add("Fenris: You should know me better than this, friend."); fenris_wronganswers_faces.Add(26);
        //Correct answer reactions for Fenris
        fenris_correctanswers.Add("Fenris: I see your hearing is working"); fenris_correct_faces.Add(8);
        fenris_correctanswers.Add("Fenris: Correct."); fenris_correct_faces.Add(25);
        fenris_correctanswers.Add("Fenris: You seem to have been listening what I told you."); fenris_correct_faces.Add(25);
        fenris_correctanswers.Add("Fenris: That is right."); fenris_correct_faces.Add(25);
        fenris_correctanswers.Add("Fenris: I appreciate that you have been listening me.");fenris_correct_faces.Add(25);
        //Fenris' choices
        /*3*/fenris_choices.Add("Felix"); fenris_choices.Add("Woofer"); fenris_choices.Add("Fenris");
        /*1*/fenris_choices.Add("You won’t help me if I get into trouble"); fenris_choices.Add("You shall run after me and save me from trouble"); fenris_choices.Add("I will find treasures?");
        /*2*/fenris_choices.Add("A toothpick"); fenris_choices.Add("Your teeth"); fenris_choices.Add("Your claws");
        /*3*/fenris_choices.Add("Ummmmm…"); fenris_choices.Add("A hunter"); fenris_choices.Add("The leader");
        /*1*/fenris_choices.Add("A wolftaur"); fenris_choices.Add("A centaur"); fenris_choices.Add("A dog");
        /*1*/fenris_choices.Add("You were a hunter"); fenris_choices.Add("You were really a fisherman"); fenris_choices.Add("You were a herbalist");
        /*2*/fenris_choices.Add("They left you since you are such a angsty teenager"); fenris_choices.Add("They were killed by the orc tribe"); fenris_choices.Add("I really don’t remember");
        /*3*/fenris_choices.Add("The Pinkfurs"); fenris_choices.Add("The Redeyes"); fenris_choices.Add("The Greypaws");
        /*1*/fenris_choices.Add("You hate joking people"); fenris_choices.Add("You try to make up new jokes"); fenris_choices.Add("You laugh every time you hear one!");
        /*2*/fenris_choices.Add("You are best friends"); fenris_choices.Add("You can't stand him"); fenris_choices.Add("Who?");
        /*2*/fenris_choices.Add("She told you how to use herbs to heal wounds"); fenris_choices.Add("She told you bedtime stories"); fenris_choices.Add("Nothing?");
        /*3*/fenris_choices.Add("Wolftaurs"); fenris_choices.Add("Orcs"); fenris_choices.Add("Griffins");
        /*1*/fenris_choices.Add("You think that lonely people can be the strongest ones"); fenris_choices.Add("Loneliness is a burden"); fenris_choices.Add("I can’t remember");
        /*3*/fenris_choices.Add("You want me to stop coming here"); fenris_choices.Add("You think I smell bad"); fenris_choices.Add("You want me to come here more often");
        /*2*/fenris_choices.Add("You want to explore the world"); fenris_choices.Add("You want to have a family"); fenris_choices.Add("You want to start a business in the town");
        //Fenris' correct choices
        fenris_correct.Add(3); fenris_correct.Add(1); fenris_correct.Add(2); fenris_correct.Add(3); fenris_correct.Add(1);
        fenris_correct.Add(1); fenris_correct.Add(2); fenris_correct.Add(3); fenris_correct.Add(1); fenris_correct.Add(2);
        fenris_correct.Add(2); fenris_correct.Add(3); fenris_correct.Add(1); fenris_correct.Add(3); fenris_correct.Add(2);
        //Fenris' questions
        //1
        fenris_question1.Add("Ghoul: Who are you?"); fenris_question1_faces.Add(13);
        fenris_question1.Add("???: Why am I always approached by idiots… Well, they call me Fenris but you are not allowed to use my name EVER."); fenris_question1_faces.Add(26);
        //2
        fenris_question2.Add("Ghoul: Why are you so angry?"); fenris_question2_faces.Add(14);
        fenris_question2.Add("Fenris: That is not any of your business! Why you keep pestering me?! Leave me alone!"); fenris_question2_faces.Add(26);
        //3
        fenris_question3.Add("Ghoul: You seem to be pretty smart to be honest."); fenris_question3_faces.Add(13);
        fenris_question3.Add("Fenris: Yes, I have sharp mind but my teeth are sharper, so watch yourself."); fenris_question3_faces.Add(26);
        //4
        fenris_question4.Add("Ghoul: Can I ask you something? What species are you?"); fenris_question4_faces.Add(13);
        fenris_question4.Add("Fenris: What is that stupid question?! Can’t you see that I am a wolftaur?!"); fenris_question4_faces.Add(26);
        //5
        fenris_question5.Add("Ghoul: I read about centaurs in a storybook when I was a child. Are you like a centaur? Can you carry others on your back?"); fenris_question5_faces.Add(12);
        fenris_question5.Add("Fenris: WHAT?! Do I look like a dirty horse to you?! Wolftaurs and centaurs are nothing alike and you better remember that!"); fenris_question5_faces.Add(26);
        //6
        fenris_question6.Add("Ghoul: Uh, can you tell me something about your family?"); fenris_question6_faces.Add(14);
        fenris_question6.Add("Fenris: If you must know I am son of the alphawolf, the leader of our pack! I was the strongest hunter in my tribe so I don’t need help from anyone!"); fenris_question6_faces.Add(8);
        //7
        fenris_question7.Add("Ghoul: You told me that you were a hunter in your tribe so why are you here all alone?"); fenris_question7_faces.Add(12);
        fenris_question7.Add("Fenris: … I will tell you this but we never ever will speak about this again. My tribe was destroyed by orcs few years ago. I am all that is left from the Greypaws…"); fenris_question7_faces.Add(8);
        //8
        fenris_question8.Add("Ghoul: I am so sorry about your family. Do you want to hear a joke to lift your spirits?"); fenris_question8_faces.Add(12);
        fenris_question8.Add("Fenris: Please don’t. I can’t stand people who try so desperately to be funny. Why can’t people just have serious conversations."); fenris_question8_faces.Add(8);
        //9
        fenris_question9.Add("Ghoul: Sorry! I didn’t mean to be annoying! What do you do here in the town?"); fenris_question9_faces.Add(14);
        fenris_question9.Add("Fenris: I work as a hunter. I hunt, bring the game to the shopkeeper, claim my pay and then I return here to stay away from simple townsfolk. Especially that dirty orcperson in the tavern gets on my nerves."); fenris_question9_faces.Add(8);
        //10
        fenris_question10.Add("Ghoul: What would you like to do in town?"); fenris_question10_faces.Add(12);
        fenris_question10.Add("Fenris: What kind of a question is that? I want to hunt and that is what I do. I am already doing what I would like to do in Ferrus."); fenris_question10_faces.Add(8);
        //11
        fenris_question11.Add("Ghoul: I am wondering how are you doing here all by yourself. Aren’t you lonely?"); fenris_question11_faces.Add(14);
        fenris_question11.Add("Fenris: I hate it when people try to show pity to those who are alone. Did you know that the loneliest people may also be the strongest?"); fenris_question11_faces.Add(8);
        //12
        fenris_question12.Add("Ghoul: But you are here without a pack? Isn’t that bothering you?"); fenris_question12_faces.Add(13);
        fenris_question12.Add("Fenris: My mother used to tell me bedtime stories. Once she told me that little wolflings are brought to this world by griffins during a full moon."); fenris_question12_faces.Add(8);
        fenris_question12.Add("Fenris: Though I seriously doubt that. But who knows if it is true, maybe one day a pack of griffins will bring here enough wolflings to have a new tribe..."); fenris_question12_faces.Add(8);
        //13
        fenris_question13.Add("Ghoul: Do you mind if I stay here with you for a while?"); fenris_question13_faces.Add(12);
        fenris_question13.Add("Fenris: No, not at all! It feels nice to have a friend like yourself. I think you should come and see me more often. I think I… Nothing. Nevermind."); fenris_question13_faces.Add(25);
        //14
        fenris_question14.Add("Ghoul: Well let’s discuss about something else then. Tell me what would you like to do when you grow up?"); fenris_question14_faces.Add(12);
        fenris_question14.Add("Fenris: What you mean? I am a grownup! … Well the thing I would love to do is to have a family. I’d like to have a place where to live without fear to be left alone… Please don’t think that I am weakling!"); fenris_question14_faces.Add(8);
        //15
        fenris_question15.Add("Ghoul: Have you ever thought of leaving this place?"); fenris_question15_faces.Add(13);
        fenris_question15.Add("Fenris: Few times, yes. I have been thinking that maybe I should try to find other tribes of wolftaurs and try to join them. But now that the jumping plague is everywhere I cannot leave too far from the town."); fenris_question15_faces.Add(8);
        //Fenris quests
        fenris_quests.Add("Fenris: Hmm, it seems that you are not completely useless after all."); fenris_quests_faces.Add(8);
        fenris_quests.Add("Fenris: You can complete simple tasks. So you must have some kind of a brain in your head."); fenris_quests_faces.Add(8);
        fenris_quests.Add("Fenris: Thank you for helping me."); fenris_quests_faces.Add(25);
        fenris_quests.Add("Fenris: Thank you friend. I appreciate this."); fenris_quests_faces.Add(25);

        fenris_questionLists.Add(fenris_question1);
        fenris_questionLists.Add(fenris_question2);
        fenris_questionLists.Add(fenris_question3);
        fenris_questionLists.Add(fenris_question4);
        fenris_questionLists.Add(fenris_question5);
        fenris_questionLists.Add(fenris_question6);
        fenris_questionLists.Add(fenris_question7);
        fenris_questionLists.Add(fenris_question8);
        fenris_questionLists.Add(fenris_question9);
        fenris_questionLists.Add(fenris_question10);
        fenris_questionLists.Add(fenris_question11);
        fenris_questionLists.Add(fenris_question12);
        fenris_questionLists.Add(fenris_question13);
        fenris_questionLists.Add(fenris_question14);
        fenris_questionLists.Add(fenris_question15);
        fenris_levelLists.Add(fenris_levelup1);
        fenris_levelLists.Add(fenris_levelup2);
        fenris_levelLists.Add(fenris_levelup3);
        fenris_levelLists.Add(fenris_levelup4);
        fenris_levelLists.Add(fenris_levelup5);

        fenris_questionLists_faces.Add(fenris_question1_faces);
        fenris_questionLists_faces.Add(fenris_question2_faces);
        fenris_questionLists_faces.Add(fenris_question3_faces);
        fenris_questionLists_faces.Add(fenris_question4_faces);
        fenris_questionLists_faces.Add(fenris_question5_faces);
        fenris_questionLists_faces.Add(fenris_question6_faces);
        fenris_questionLists_faces.Add(fenris_question7_faces);
        fenris_questionLists_faces.Add(fenris_question8_faces);
        fenris_questionLists_faces.Add(fenris_question9_faces);
        fenris_questionLists_faces.Add(fenris_question10_faces);
        fenris_questionLists_faces.Add(fenris_question11_faces);
        fenris_questionLists_faces.Add(fenris_question12_faces);
        fenris_questionLists_faces.Add(fenris_question13_faces);
        fenris_questionLists_faces.Add(fenris_question14_faces);
        fenris_questionLists_faces.Add(fenris_question15_faces);
        fenris_levelLists_faces.Add(fenris_levelup1_faces);
        fenris_levelLists_faces.Add(fenris_levelup2_faces);
        fenris_levelLists_faces.Add(fenris_levelup3_faces);
        fenris_levelLists_faces.Add(fenris_levelup4_faces);
        fenris_levelLists_faces.Add(fenris_levelup5_faces);

        //CATHERINE'S LINES
        //Cathy's first conversation
        catherine_first.Add("???: Oh, a strang'r approaches a mistress! Shouldst I runneth? Shouldst I flee?"); catherine_first_faces.Add(9);
        catherine_first.Add("Ghoul: Er, hello. I mean you no harm, miss."); catherine_first_faces.Add(13);
        catherine_first.Add("???:  T speaks! Shalt t tryeth to enthrall me with sweet words?"); catherine_first_faces.Add(23);
        catherine_first.Add("Ghoul: No, nothing of the sort, I just wanted to talk."); catherine_first_faces.Add(12);
        catherine_first.Add("???:  To talk! Unimaginable! What kind of a mistress doth thee bethink I am!"); catherine_first_faces.Add(24);
        catherine_first.Add("Ghoul: … You’re enjoying this aren’t you."); catherine_first_faces.Add(14);
        catherine_first.Add("???:  Lies and slander!"); catherine_first_faces.Add(23);
        //Cathy's greetings by love level
        catherine_greetings.Add("???: Ohh, woe is me."); catherine_greetings_faces.Add(9);
        catherine_greetings.Add("Catherine: Greetings, ser."); catherine_greetings_faces.Add(9);
        catherine_greetings.Add("Catherine: What a lovely day t is, I did bet."); catherine_greetings_faces.Add(9);
        catherine_greetings.Add("Catherine: I bid thee good tidings, friend."); catherine_greetings_faces.Add(23);
        catherine_greetings.Add("Catherine: ‘T is valorous to see thee!"); catherine_greetings_faces.Add(23);
        catherine_greetings.Add("Catherine: A ray of sunshine walks into mine own crypt! Wonderful!"); catherine_greetings_faces.Add(23);
        //Cathy's goodbyes by love level
        catherine_byes.Add("???: I returneth to loneliness."); catherine_byes_faces.Add(9);
        catherine_byes.Add("Catherine: Fare thee well."); catherine_byes_faces.Add(9);
        catherine_byes.Add("Catherine: Beest careful."); catherine_byes_faces.Add(9);
        catherine_byes.Add("Catherine: I desire to see thee again anon."); catherine_byes_faces.Add(23);
        catherine_byes.Add("Catherine: Beest not gone too long!"); catherine_byes_faces.Add(23);
        catherine_byes.Add("Catherine: I shalt bethink of thee!"); catherine_byes_faces.Add(23);
        //WHen Cathy is talked to by love level
        catherine_hay.Add("???: Mine own heart aches and nay one understands!"); catherine_hay_faces.Add(9);
        catherine_hay.Add("Catherine: This is a grand season f'r hikes on the road."); catherine_hay_faces.Add(9);
        catherine_hay.Add("Catherine: Oh, if 't be true I couldst just see the sun again!"); catherine_hay_faces.Add(9);
        catherine_hay.Add("Catherine: All is well, considering yond I am dead."); catherine_hay_faces.Add(23);
        catherine_hay.Add("Catherine: Thy presence warms mine own bitter cold, dead heart."); catherine_hay_faces.Add(23);
        catherine_hay.Add("Catherine: Mine own heart jumps with joy!"); catherine_hay_faces.Add(23);
        //Cathy's love level ups
        //1
        catherine_levelup1.Add("Catherine: I am joyous to sayeth thou art not like these peasants."); catherine_levelup1_faces.Add(23);
        catherine_levelup1.Add("Ghoul: You.. thought I was a peasant?"); catherine_levelup1_faces.Add(14);
        catherine_levelup1.Add("Catherine: Thee talk like one, but I has't a valorous humour about thee."); catherine_levelup1_faces.Add(9);
        catherine_levelup1.Add("Ghoul: Uh… thanks?"); catherine_levelup1_faces.Add(13);
        //2
        catherine_levelup2.Add("Catherine: Pray to bid me, how didst thee end up in Ferrus of all places?"); catherine_levelup2_faces.Add(9);
        catherine_levelup2.Add("Ghoul: I’m afraid I have no idea. I tried a spell but I probably did something wrong."); catherine_levelup2_faces.Add(14);
        catherine_levelup2.Add("Catherine: A spell? Thee doth not behold like a witch. Ev'r bethink yond peradventure ‘t wast fate yond sendeth thee hither?"); catherine_levelup2_faces.Add(9);
        catherine_levelup2.Add("Ghoul: Who knows. But so far I am pretty happy, it has been an interesting journey."); catherine_levelup2_faces.Add(12);
        catherine_levelup2.Add("Catherine: Yond's valorous to heareth. Alloweth me knoweth if 't be true thee needeth help!"); catherine_levelup2_faces.Add(23);
        //3
        catherine_levelup3.Add("Ghoul: Catherine, hey. You seem like there is something you want to share."); catherine_levelup3_faces.Add(12);
        catherine_levelup3.Add("Catherine: Is yond so transparent? F'r hundreds of years I has't just hadst one cousin. ‘T is a strange humour having someone new. I feeleth like I has't hath lost mine own manners. I wilt apologize if 't be true I has't offend'd thee!"); catherine_levelup3_faces.Add(9);
        catherine_levelup3.Add("Ghoul: Don’t worry, Catherine. You haven’t. You are a wonderful vampire. Not that I know any others…"); catherine_levelup3_faces.Add(13);
        catherine_levelup3.Add("Catherine: I shalt taketh yond as a compliment! *giggles*"); catherine_levelup3_faces.Add(23);
        //4
        catherine_levelup4.Add("Catherine: Ghoul, sweet, I has't been bethinking. If 't be true thither would beest nay Jumping Plague I would showeth thee the city. ‘T is quite a sight to see."); catherine_levelup4_faces.Add(9);
        catherine_levelup4.Add("Ghoul: Hey, who knows. I might be here for a loooong time. Enough for an outbreak to cease."); catherine_levelup4_faces.Add(14);
        catherine_levelup4.Add("Catherine: I desire this doest not sound possessive but I would like yond. Thee've seen nothing until thee've seen the Grand cathedral of Potato, the spires of the demon lords castle…"); catherine_levelup4_faces.Add(9);
        catherine_levelup4.Add("Ghoul: I’ll hold you to it. You can be my tour guide!"); catherine_levelup4_faces.Add(12);
        catherine_levelup4.Add("Catherine: I desire thee like midnight walks, then!"); catherine_levelup4_faces.Add(23);
        //5
        catherine_levelup5.Add("Catherine: ‘T is customary f'r a gentle to asketh f'r another nobles parents f'r their handeth in marriage. Alas, I doth not knoweth thee heritage, but…. we might has't to wake mine own parents up if 't be true yond's what we wanteth."); catherine_levelup5_faces.Add(9);
        catherine_levelup5.Add("Ghoul: Wait a second there. Marriage?"); catherine_levelup5_faces.Add(14);
        catherine_levelup5.Add("Catherine: Aye! Is thither aught moo solid to prove one's love f'r another?"); catherine_levelup5_faces.Add(23);
        catherine_levelup5.Add("Ghoul: Oh… love. Do you… love me, Catherine?"); catherine_levelup5_faces.Add(13);
        catherine_levelup5.Add("Catherine: Thee has't hath brought sun into mine own heart. Very much so."); catherine_levelup5_faces.Add(23);
        catherine_levelup5.Add("Ghoul: I am glad to hear that, Cath!"); catherine_levelup5_faces.Add(13);
        catherine_levelup5.Add("Catherine: Anon alloweth's seal our love in blood!"); catherine_levelup5_faces.Add(23);
        //Cathy's reactions to correct gifts + ultimate gift + object of love
        catherine_gifts.Add("???: Thee five a maiden a gift?"); catherine_gifts_faces.Add(9);
        catherine_gifts.Add("Catherine: Is't something nice?"); catherine_gifts_faces.Add(9);
        catherine_gifts.Add("Catherine: Oh, wherefore thank thee."); catherine_gifts_faces.Add(23);
        catherine_gifts.Add("Catherine: I am joyous with this."); catherine_gifts_faces.Add(23);
        catherine_gifts.Add("Catherine: This is most wondrous! Thank thee!"); catherine_gifts_faces.Add(23);
        catherine_gifts.Add("Catherine: I needeth to receiveth thee something, lief!"); catherine_gifts_faces.Add(23);
        catherine_gifts.Add("Catherine: Oh... is yond….. How didst thee knoweth? I has't nev'r hath felt so alive! I couldst caterwauling! But a fine mistress doest not caterwaul."); catherine_gifts_faces.Add(23);
        catherine_gifts.Add("Catherine: Thee has't been a wonderful companion, and i wenteth through mine own family's most priz'd living to findeth thee something to showeth mine own undying appreciation."); catherine_gifts_faces.Add(23);
        //Cathy's reactions to unsatisfactory gifts by love level
        catherine_badgifts.Add("???: Yond is disgusting..."); catherine_badgifts_faces.Add(24);
        catherine_badgifts.Add("Catherine: What art thee bethinking?!"); catherine_badgifts_faces.Add(24);
        catherine_badgifts.Add("Catherine: Putteth ‘t back whither ‘t cameth from."); catherine_badgifts_faces.Add(24);
        catherine_badgifts.Add("Catherine: Thee offend a fine mistress I'll has't thee knoweth!"); catherine_badgifts_faces.Add(24);
        catherine_badgifts.Add("Catherine: Art thee sure thou art right in the headeth?"); catherine_badgifts_faces.Add(24);
        catherine_badgifts.Add("Catherine: We may beest cater-cousins but this is just ridiculous."); catherine_badgifts_faces.Add(24);
        //When Cathty has nothing to say
        catherine_nothingtosay.Add("Catherine: Alas… death is depress'd and lonely..."); catherine_nothingtosay_faces.Add(24);
        catherine_nothingtosay.Add("Catherine: I wonder if 't be true demon blood tastes valorous… mmh.."); catherine_nothingtosay_faces.Add(9);
        catherine_nothingtosay.Add("Catherine: A mistress needeth that lady high-lone time."); catherine_nothingtosay_faces.Add(9);
        //Flirting with Cathy
        catherine_flirts.Add("Ghoul: Hey, I’m looking for treasure. Can I look around your chest?"); catherine_flirts_faces.Add(13);
        catherine_flirts.Add("???: How lacking valor! Doth thee coequal recall who is't I am thee blinking idiot!"); catherine_flirts_faces.Add(9);
        catherine_flirts.Add("Ghoul: Hey, I lost my underwear, can I see yours?"); catherine_flirts_faces.Add(13);
        catherine_flirts.Add("Catherine: How distasteful! Thee doth not talk to mine own kind like yond!"); catherine_flirts_faces.Add(9);
        catherine_flirts.Add("Ghoul: Lady, you better have a license, because you are driving me crazy."); catherine_flirts_faces.Add(13);
        catherine_flirts.Add("Catherine: Such language! And in the presence of mine own. Doth thee coequal recall?!"); catherine_flirts_faces.Add(9);
        catherine_flirts.Add("Ghoul: Oh no, I am choking! I need mouth to mouth, quick!"); catherine_flirts_faces.Add(13);
        catherine_flirts.Add("Catherine: Oh thee joker, I would knoweth if 't be true thee wast dying. And I receiveth mine own food from..."); catherine_flirts_faces.Add(9);
        catherine_flirts.Add("Ghoul: Save a horse, ride a cowboy… me… I swear I am a cowboy."); catherine_flirts_faces.Add(13);
        catherine_flirts.Add("Catherine: *giggle* Oh horseman, doth thee recall what mine own dream is?"); catherine_flirts_faces.Add(9);
        catherine_flirts.Add("Ghoul: Be unique and different, and just say yes!"); catherine_flirts_faces.Add(13);
        catherine_flirts.Add("Catherine: Thee may mistress all thee like, but doth thee recall mine own age thee so rudely hath asked?"); catherine_flirts_faces.Add(9);
        catherine_flirts.Add("Ghoul: Can I carry your boob… books?"); catherine_flirts_faces.Add(13);
        catherine_flirts.Add("Catherine: Filthy peasant! Doth thee coequal remember what food I like on top of blood?"); catherine_flirts_faces.Add(9);
        catherine_flirts.Add("Ghoul: Hey, will you reject me if I try and pick you up?"); catherine_flirts_faces.Add(13);
        catherine_flirts.Add("Catherine: T's fine, as long as thee carryeth not me to mine own least disgusting lodging."); catherine_flirts_faces.Add(9);
        catherine_flirts.Add("Ghoul: Do you mind if I stare at you up close instead of the other side of the room?"); catherine_flirts_faces.Add(13);
        catherine_flirts.Add("Catherine: Oh, I give you couldst stare at me at mine own and mine own friend loved establishment."); catherine_flirts_faces.Add(9);
        catherine_flirts.Add("Ghoul: If beauty was measured in seconds, you’d be an hour!"); catherine_flirts_faces.Add(13);
        catherine_flirts.Add("Catherine: Who is't is mine own most wondrous friend??"); catherine_flirts_faces.Add(9);
        catherine_flirts.Add("Ghoul: If I followed you home, would you keep me?"); catherine_flirts_faces.Add(13);
        catherine_flirts.Add("Catherine: Peradventure, thee fartuous person. Thee doth recall if 't be true I has't someone special in mine own life?"); catherine_flirts_faces.Add(9);
        catherine_flirts.Add("Ghoul: If you were a fruit you’d be a FINEAPPLE!"); catherine_flirts_faces.Add(13);
        catherine_flirts.Add("Catherine: Nay fruits! I enjoy what in mine own free time?"); catherine_flirts_faces.Add(9);
        catherine_flirts.Add("Ghoul: Are you sandpaper? ‘Cos I want you to rub my wood."); catherine_flirts_faces.Add(13);
        catherine_flirts.Add("Catherine: Eh, what wood. ? Is't mine own favourite colour?"); catherine_flirts_faces.Add(9);
        catherine_flirts.Add("Ghoul: Girl, if I was a fly, I’d be all over you ‘cos you’re the shit!"); catherine_flirts_faces.Add(13);
        catherine_flirts.Add("Catherine: Mine own family would not approve thy language. After all, we art..."); catherine_flirts_faces.Add(9);
        catherine_flirts.Add("Ghoul: I’d like to drink your bathwater."); catherine_flirts_faces.Add(13);
        catherine_flirts.Add("Catherine: Thee maketh me chuckle, Ghoul. Whither would thee taketh me on a date?"); catherine_flirts_faces.Add(9);
        //Choices to Cathy's flirts
        /*1*/
        catherine_choices.Add("Catherine De Nychterida"); catherine_choices.Add("Katherine?"); catherine_choices.Add("Uh… boobs?");
        /*1*/
        catherine_choices.Add("Vampires?"); catherine_choices.Add("Lifestyle goths?"); catherine_choices.Add("Stuck up bitches?");
        /*1*/
        catherine_choices.Add("Your family"); catherine_choices.Add("Empty graves"); catherine_choices.Add("Spooky ghosts");
        /*1*/
        catherine_choices.Add("Outside!"); catherine_choices.Add("Someone brings it to you"); catherine_choices.Add("You don’t eat");
        /*3*/
        catherine_choices.Add("Getting a huge family"); catherine_choices.Add("Becoming a stripper"); catherine_choices.Add("Walking in the sun");
        /*2*/
        catherine_choices.Add("You’re like… a teenager"); catherine_choices.Add("256"); catherine_choices.Add("Over 300!");
        /*2*/
        catherine_choices.Add("Vegetables?"); catherine_choices.Add("Sweet things?"); catherine_choices.Add("MEAT?");
        /*1*/
        catherine_choices.Add("The tavern is the worst"); catherine_choices.Add("The church is the worst"); catherine_choices.Add("The entire city is the worst");
        /*2*/
        catherine_choices.Add("I swear it was a bar"); catherine_choices.Add("It was a teahouse"); catherine_choices.Add("Must’ve been a cake shop");
        /*3*/
        catherine_choices.Add("Pope!"); catherine_choices.Add("Gru!"); catherine_choices.Add("Bobo!");
        /*1*/
        catherine_choices.Add("You have no one"); catherine_choices.Add("You have a girlfriend"); catherine_choices.Add("You have a boyfriend");
        /*2*/
        catherine_choices.Add("Jogging"); catherine_choices.Add("Sewing"); catherine_choices.Add("Sleeping");
        /*3*/
        catherine_choices.Add("Black"); catherine_choices.Add("Blue"); catherine_choices.Add("Red and yellow");
        /*1*/
        catherine_choices.Add("Nobles"); catherine_choices.Add("Hobos"); catherine_choices.Add("PEASANTS!");
        /*2*/
        catherine_choices.Add("Around the graveyard"); catherine_choices.Add("Show you off to everyone in daylight"); catherine_choices.Add("Ew, dates");
        //Catherine's correct answers
        catherine_correct.Add(1); catherine_correct.Add(1); catherine_correct.Add(1); catherine_correct.Add(1); catherine_correct.Add(3);
        catherine_correct.Add(2); catherine_correct.Add(2); catherine_correct.Add(1); catherine_correct.Add(2); catherine_correct.Add(3);
        catherine_correct.Add(1); catherine_correct.Add(2); catherine_correct.Add(3); catherine_correct.Add(1); catherine_correct.Add(2);
        //Correct answer reactions for cathy by love level
        catherine_correctanswers.Add("Catherine: I am did impress!"); catherine_correct_faces.Add(23);
        catherine_correctanswers.Add("Catherine: Ah, I suppose thee aren't completely deaf."); catherine_correct_faces.Add(9);
        catherine_correctanswers.Add("Catherine: Well done."); catherine_correct_faces.Add(23);
        catherine_correctanswers.Add("Catherine: Thee doth hark, ‘t maketh a mistress joyous."); catherine_correct_faces.Add(23);
        catherine_correctanswers.Add("Catherine: Thou art a wonderful person..."); catherine_correct_faces.Add(23);
        //catherine's reactions to wrong answers by love level
        catherine_wronganswers.Add("???: How dare thee!"); catherine_wronganswers_faces.Add(24);
        catherine_wronganswers.Add("Catherine: I am so did insult even but now."); catherine_wronganswers_faces.Add(24);
        catherine_wronganswers.Add("Catherine: Oh, and ‘t gets just worse."); catherine_wronganswers_faces.Add(24);
        catherine_wronganswers.Add("Catherine: The gall!"); catherine_wronganswers_faces.Add(24);
        catherine_wronganswers.Add("Catherine: Fie! How distasteful."); catherine_wronganswers_faces.Add(24);
        //Catherine's questions
        //1
        catherine_question1.Add("Ghoul: So, mistress. What are you called?"); catherine_question1_faces.Add(13);
        catherine_question1.Add("???: The name yond mine own parents bestow'd upon me is Catherine De Nychterida. Mine own father wast the most wondrous viscount of our clan I'll has't thee knoweth!"); catherine_question1_faces.Add(9);
        //2
        catherine_question2.Add("Ghoul: Do you always stay in this crypt?"); catherine_question2_faces.Add(12);
        catherine_question2.Add("Catherine: Behold at mine own complexion and feeleth mine own heartbeat and knoweth yond I cannot walketh in the sun - a curse most foul."); catherine_question2_faces.Add(24);
        //3
        catherine_question3.Add("Ghoul: So if you are a vampire, and can’t go out during day, how do you get food?"); catherine_question3_faces.Add(13);
        catherine_question3.Add("Catherine: The night is at which hour I can roam free, unshackl'd from this darkness. I has't mine own ways!"); catherine_question3_faces.Add(23);
        //4
        catherine_question4.Add("Ghoul: So what’s in these other graves? Are they empty?"); catherine_question4_faces.Add(12);
        catherine_question4.Add("Catherine: Mine own kin sleeps in those until the sickness is gone. I am so lonely..."); catherine_question4_faces.Add(24);
        //5
        catherine_question5.Add("Ghoul:  How come you are awake unlike your family, Catherine?"); catherine_question5_faces.Add(13);
        catherine_question5.Add("Catherine: I am still a young vampire and wanteth to see what the ordinary hast to giveth. And mine own parents n'r siblings can't very much bid me what to doth if 't be true they art asleep!"); catherine_question5_faces.Add(9);
        //6
        catherine_question6.Add("Ghoul: Anything special you’d like to do?"); catherine_question6_faces.Add(12);
        catherine_question6.Add("Catherine: I dream of walking in the sun. I recall t being quite quite quaint."); catherine_question6_faces.Add(23);
        catherine_question6.Add("Catherine: Mine own parents would beest so nimble-footed to heareth me, an immortal being of darkness dream of something so fartuous."); catherine_question6_faces.Add(24);
        //7
        catherine_question7.Add("Ghoul: You… make it sound you’re quite old."); catherine_question7_faces.Add(14);
        catherine_question7.Add("Catherine: How dare thee asketh a mistress how fusty the lady is! I'll has't thee knoweth I am of the wee age of 256!"); catherine_question7_faces.Add(9);
        //8
        catherine_question8.Add("Ghoul: Where I come from, there are tales that say vampires kill their victims."); catherine_question8_faces.Add(13);
        catherine_question8.Add("Catherine: Oh, yond is a filthy forswear. I only drinketh blood from cater-cousins. Besides, tasty cakes and other marchpanes gust so much better than blood!"); catherine_question8_faces.Add(9);
        //9
        catherine_question9.Add("Ghoul: You know the tavern here has pretty good food. Have you ever visited?"); catherine_question9_faces.Add(13);
        catherine_question9.Add("Catherine: Ah, ‘t is such a crusty establishment, visit'd by barbarians like yond orc and other disgraces! A true mistress hast nay lodging thither!"); catherine_question9_faces.Add(9);
        //10
        catherine_question10.Add("Ghoul: Do you have any place you prefer, then?"); catherine_question10_faces.Add(12);
        catherine_question10.Add("Catherine: Thither is a wonderful tea house in the city meet. We hath used to visit ‘t a lot with lovely Bobo ‘ere the plague hath happened."); catherine_question10_faces.Add(9);
        //11
        catherine_question11.Add("Ghoul: You and Bobo are friends?"); catherine_question11_faces.Add(14);
        catherine_question11.Add("Catherine: Oh aye. He is a fine gentleman of a valorous lineage. Both our families art the greatest in all of Ferrus!"); catherine_question11_faces.Add(9);
        //12
        catherine_question12.Add("Ghoul: Do you have anyone special in your life, Catherine?"); catherine_question12_faces.Add(12);
        catherine_question12.Add("Catherine: Alas, nay. I am a fine mistress and most of these villagers art far too barbaric f'r mine own tastes."); catherine_question12_faces.Add(9);
        //13
        catherine_question13.Add("Ghoul: Seems pretty lonely. What do you do with your time?"); catherine_question13_faces.Add(14);
        catherine_question13.Add("Catherine: I has't thee knoweth I am a fine seamstress. I sew all mine own robes! Coequal the pope hast hath asked me to help him with his robes!"); catherine_question13_faces.Add(9);
        //14
        catherine_question14.Add("Ghoul: Your style is indeed luxurious. Is black your favourite color?"); catherine_question14_faces.Add(12);
        catherine_question14.Add("Catherine: Oh, nay. I love r'd and yellow, colors of the day. Which of course apparently doest not fit a bloodsucker like me."); catherine_question14_faces.Add(9);
        //15
        catherine_question15.Add("Ghoul: Why do you care so much what your family thinks?"); catherine_question15_faces.Add(13);
        catherine_question15.Add("Catherine: ‘T is what ‘t is, being a noble and all. Thee has't to uphold a certain level of grace at all costs."); catherine_question15_faces.Add(9);
        //16
        catherine_question16.Add("Ghoul: If you could do anything without fear of retaliation, what would it be?"); catherine_question16_faces.Add(13);
        catherine_question16.Add("Catherine: Oh, I would wish to has't a quite quaint parasol and showeth the town a lovely gold gown I has't sewn. In daylight!"); catherine_question16_faces.Add(23);
        //quests
        catherine_quests.Add("Catherine: Thee have my thanks."); catherine_quests_faces.Add(23);
        catherine_quests.Add("Catherine: Thank thee so much!"); catherine_quests_faces.Add(23);
        catherine_quests.Add("Catherine: Most wonderful. I am very grateful!"); catherine_quests_faces.Add(23);
        catherine_quests.Add("Catherine: Thou art mine own knight in shining armor, riding to mine own rescue..."); catherine_quests_faces.Add(23);
        //Lists to lists
        catherine_questionLists.Add(catherine_question1);
        catherine_questionLists.Add(catherine_question2);
        catherine_questionLists.Add(catherine_question3);
        catherine_questionLists.Add(catherine_question4);
        catherine_questionLists.Add(catherine_question5);
        catherine_questionLists.Add(catherine_question6);
        catherine_questionLists.Add(catherine_question7);
        catherine_questionLists.Add(catherine_question8);
        catherine_questionLists.Add(catherine_question9);
        catherine_questionLists.Add(catherine_question10);
        catherine_questionLists.Add(catherine_question11);
        catherine_questionLists.Add(catherine_question12);
        catherine_questionLists.Add(catherine_question13);
        catherine_questionLists.Add(catherine_question14);
        catherine_questionLists.Add(catherine_question15);
        catherine_questionLists.Add(catherine_question16);
        catherine_levelLists.Add(catherine_levelup1);
        catherine_levelLists.Add(catherine_levelup2);
        catherine_levelLists.Add(catherine_levelup3);
        catherine_levelLists.Add(catherine_levelup4);
        catherine_levelLists.Add(catherine_levelup5);

        catherine_questionLists_faces.Add(catherine_question1_faces);
        catherine_questionLists_faces.Add(catherine_question2_faces);
        catherine_questionLists_faces.Add(catherine_question3_faces);
        catherine_questionLists_faces.Add(catherine_question4_faces);
        catherine_questionLists_faces.Add(catherine_question5_faces);
        catherine_questionLists_faces.Add(catherine_question6_faces);
        catherine_questionLists_faces.Add(catherine_question7_faces);
        catherine_questionLists_faces.Add(catherine_question8_faces);
        catherine_questionLists_faces.Add(catherine_question9_faces);
        catherine_questionLists_faces.Add(catherine_question10_faces);
        catherine_questionLists_faces.Add(catherine_question11_faces);
        catherine_questionLists_faces.Add(catherine_question12_faces);
        catherine_questionLists_faces.Add(catherine_question13_faces);
        catherine_questionLists_faces.Add(catherine_question14_faces);
        catherine_questionLists_faces.Add(catherine_question15_faces);
        catherine_questionLists_faces.Add(catherine_question16_faces);
        catherine_levelLists_faces.Add(catherine_levelup1_faces);
        catherine_levelLists_faces.Add(catherine_levelup2_faces);
        catherine_levelLists_faces.Add(catherine_levelup3_faces);
        catherine_levelLists_faces.Add(catherine_levelup4_faces);
        catherine_levelLists_faces.Add(catherine_levelup5_faces);

        //BOBO'S LISTS
        bobo_first.Add("???: This park is private property. Your kind is not welcome here."); bobo_first_faces.Add(28);
        bobo_first.Add("Ghoul: Actually I don’t think it is."); bobo_first_faces.Add(14);
        bobo_first.Add("???: Just leave!"); bobo_first_faces.Add(28);

        bobo_greetings.Add("???: Leave me alone."); bobo_greetings_faces.Add(28);
        bobo_greetings.Add("Bobo: You again?"); bobo_greetings_faces.Add(28);
        bobo_greetings.Add("Bobo: Good day, I guess?"); bobo_greetings_faces.Add(6);
        bobo_greetings.Add("Bobo: Hello!"); bobo_greetings_faces.Add(6);
        bobo_greetings.Add("Bobo: You should see me more often."); bobo_greetings_faces.Add(27);
        bobo_greetings.Add("Bobo: Always so nice to see you."); bobo_greetings_faces.Add(27);

        bobo_byes.Add("???: And stay gone."); bobo_byes_faces.Add(27);
        bobo_byes.Add("Bobo: ..."); bobo_byes_faces.Add(27);
        bobo_byes.Add("Bobo: Goodbye."); bobo_byes_faces.Add(6);
        bobo_byes.Add("Bobo: That’s right. Leave me. I’m not worth spending time with."); bobo_byes_faces.Add(6);
        bobo_byes.Add("Bobo: Bye! See you soon!"); bobo_byes_faces.Add(28);
        bobo_byes.Add("Bobo: Come back soon, darling!"); bobo_byes_faces.Add(28);

        bobo_hay.Add("???: Begone, lowly peasant!"); bobo_hay_faces.Add(28);
        bobo_hay.Add("Bobo: Start talking, my time might be infinite, but I’d still rather be somewhere else."); bobo_hay_faces.Add(6);
        bobo_hay.Add("Bobo: What do you want?"); bobo_hay_faces.Add(6);
        bobo_hay.Add("Bobo: It is fine day for a picnic."); bobo_hay_faces.Add(6);
        bobo_hay.Add("Bobo: Greetings, my friend, how are you today?"); bobo_hay_faces.Add(27);
        bobo_hay.Add("Bobo: My feelings for you are eternal."); bobo_hay_faces.Add(27);

        bobo_levelup1.Add("Bobo: Hmmm. At least you have a decent memory."); bobo_levelup1_faces.Add(28);

        bobo_levelup2.Add("Ghoul: You seem like a really proud person."); bobo_levelup2_faces.Add(14);
        bobo_levelup2.Add("Bobo: Of course I am. I have everything to be proud of. My life is perfect!"); bobo_levelup2_faces.Add(28);
        bobo_levelup2.Add("Ghoul: Still something seems off about you."); bobo_levelup2_faces.Add(13);
        bobo_levelup2.Add("Bobo: You are very persistent. I’ll let you talk to me, because I have nothing better to do. But for your own good you should never think of my wings. I repeat; Never!"); bobo_levelup2_faces.Add(28);
        bobo_levelup2.Add("Ghoul: Why are you so angry?"); bobo_levelup2_faces.Add(12);
        bobo_levelup2.Add("Bobo: You miserable little peasant don't even know what true anger looks like but soon you'll find out if you don't stop this nonsense!"); bobo_levelup2_faces.Add(28);

        //bobo_levelup3.Add("Ghoul: (His facade is cracking.)"); bobo_levelup3_faces.Add(13);
        bobo_levelup3.Add("Bobo: *sigh* I admit it. Everything you might have heard of me is true. My wings are tiny. I can’t even fly. I am not as mighty as you might think..."); bobo_levelup3_faces.Add(6);
        bobo_levelup3.Add("Ghoul: Uh, ok..."); bobo_levelup3_faces.Add(13);
        bobo_levelup3.Add("Bobo: I really hate my name too. My parents decided I would be their last child, so they gave me EVERY name they liked, since there wouldn’t be anyone after me they could name."); bobo_levelup3_faces.Add(6);
        bobo_levelup3.Add("Ghoul: Sounds rough."); bobo_levelup3_faces.Add(14);
        bobo_levelup3.Add("Bobo: It is. You have no idea how long it takes to sign simple documents."); bobo_levelup3_faces.Add(6);
        bobo_levelup3.Add("Ghoul: Your name is quite a mouthful."); bobo_levelup3_faces.Add(12);
        bobo_levelup3.Add("Bobo: Fortunately everyone just calls me Bobo."); bobo_levelup3_faces.Add(27);

        bobo_levelup4.Add("Bobo: You know I’m sorry I was such a jerk at first. I’m not very good at making friends."); bobo_levelup4_faces.Add(6);
        bobo_levelup4.Add("Ghoul: I figured that might be the reason. I didn’t mind though, some challenge is never boring."); bobo_levelup4_faces.Add(12);
        bobo_levelup4.Add("Bobo: So are we friends now?"); bobo_levelup4_faces.Add(6);
        bobo_levelup4.Add("Ghoul: Sure are!"); bobo_levelup4_faces.Add(12);
        bobo_levelup4.Add("Bobo: That’s good…"); bobo_levelup4_faces.Add(27);
        bobo_levelup4.Add("Ghoul: …"); bobo_levelup4_faces.Add(14);
        bobo_levelup4.Add("Bobo: So, do you want some tea?"); bobo_levelup4_faces.Add(6);
        bobo_levelup4.Add("Ghoul: I'd like to! I just need to do some things first. But I'll return with some biscuits!"); bobo_levelup4_faces.Add(13);
        bobo_levelup4.Add("Bobo: Oh, that is nice! I'll prepare the tea then."); bobo_levelup4_faces.Add(28);
        /*bobo_levelup4.Add("Ghoul: Alright, alright! (I guess he’s getting some of that confidence back, if he can get this annoyed.)"); bobo_levelup4_faces.Add(12);
        bobo_levelup4.Add("Ghoul: There are really no guidelines to friendship or anything. Maybe you should think what you WANT to do."); bobo_levelup4_faces.Add(13);
        bobo_levelup4.Add("Bobo: I want to fly."); bobo_levelup4_faces.Add(27);
        bobo_levelup4.Add("Ghoul: Sorry?"); bobo_levelup4_faces.Add(14);
        bobo_levelup4.Add("Bobo: I want to fly."); bobo_levelup4_faces.Add(27);
        bobo_levelup4.Add("Ghoul: (Of course!)"); bobo_levelup4_faces.Add(12);*/

        bobo_levelup5.Add("Bobo: I know, I will love you eternally! Let’s get married!"); bobo_levelup5_faces.Add(27);
        bobo_levelup5.Add("Ghoul: Wait, what?"); bobo_levelup5_faces.Add(14);
        bobo_levelup5.Add("Bobo: I’m serious! I’ve never felt this way before."); bobo_levelup5_faces.Add(6);
        bobo_levelup5.Add("Ghoul: To be frank, I love you too Bobo, but that doesn’t mean we have to get married right now."); bobo_levelup5_faces.Add(12);
        bobo_levelup5.Add("Bobo: Don’t two people have to get married to live together?"); bobo_levelup5_faces.Add(6);
        bobo_levelup5.Add("Ghoul: Not where I come from."); bobo_levelup5_faces.Add(12);
        bobo_levelup5.Add("Bobo: Umm, alright. So what DO we do now?"); bobo_levelup5_faces.Add(6);
        bobo_levelup5.Add("Ghoul: Let’s just spend more time together. We need no one’s permission for that."); bobo_levelup5_faces.Add(13);
        bobo_levelup5.Add("Bobo: That sounds lovely!"); bobo_levelup5_faces.Add(27);

        bobo_gifts.Add("???: Don’t give me your filthy things!"); bobo_gifts_faces.Add(28);
        bobo_gifts.Add("Bobo: Why would you want to give me anything?"); bobo_gifts_faces.Add(6);
        bobo_gifts.Add("Bobo: Huh? For me? Don’t expect me to return the favor."); bobo_gifts_faces.Add(6);
        bobo_gifts.Add("Bobo: This is for me?"); bobo_gifts_faces.Add(6);
        bobo_gifts.Add("Bobo: For me? I’m touched!"); bobo_gifts_faces.Add(27);
        bobo_gifts.Add("Bobo: You would give this to ME? Really?!"); bobo_gifts_faces.Add(27);
        bobo_gifts.Add("Bobo: HOW DID YOU KNOW? I have always wanted this! You are the best human in the whole world!"); bobo_gifts_faces.Add(27);
        bobo_gifts.Add("Bobo: You have done so much for me. I want you to return the favor and give you this."); bobo_gifts_faces.Add(27);

        bobo_badgifts.Add("???: I have never seen an item more disgusting."); bobo_badgifts_faces.Add(28);
        bobo_badgifts.Add("Bobo: Are you insane? To think I would want that?"); bobo_badgifts_faces.Add(28);
        bobo_badgifts.Add("Bobo: I hate those things."); bobo_badgifts_faces.Add(28);
        bobo_badgifts.Add("Bobo: No thanks."); bobo_badgifts_faces.Add(28);
        bobo_badgifts.Add("Bobo: ..."); bobo_badgifts_faces.Add(28);
        bobo_badgifts.Add("Bobo: Well, it’s the thought that counts."); bobo_badgifts_faces.Add(6);

        bobo_nothingtosay.Add("Bobo: I don’t have anything to say anymore."); bobo_nothingtosay_faces.Add(6);
        bobo_nothingtosay.Add("Bobo: I’m tired. Leave me please."); bobo_nothingtosay_faces.Add(6);
        bobo_nothingtosay.Add("Bobo: … What?"); bobo_nothingtosay_faces.Add(6);

        bobo_flirts.Add("Ghoul: Sooooo, Do you come here often?"); bobo_flirts_faces.Add(13);
        bobo_flirts.Add("???: … I told you my whole name. But I bet you cannot even remember my nickname!"); bobo_flirts_faces.Add(28);
        bobo_flirts.Add("Ghoul: Are you a doctor? Because I have a bone for you to examine."); bobo_flirts_faces.Add(13);
        bobo_flirts.Add("Bobo: I'll pretend I didn’t hear that. What is my full name?"); bobo_flirts_faces.Add(6);
        bobo_flirts.Add("Ghoul: Would you like to-"); bobo_flirts_faces.Add(13);
        bobo_flirts.Add("Bobo: What species am I a member of?"); bobo_flirts_faces.Add(6);
        bobo_flirts.Add("Ghoul: The weather is very fine today, is it not?"); bobo_flirts_faces.Add(13);
        bobo_flirts.Add("Bobo: You attempt at small talk is pathetic. Have you paid any attention to me? How old am I?"); bobo_flirts_faces.Add(6);
        bobo_flirts.Add("Ghoul: Hey-"); bobo_flirts_faces.Add(13);
        bobo_flirts.Add("Bobo: Don’t even start! What do I want as a gift?"); bobo_flirts_faces.Add(6);
        bobo_flirts.Add("Ghoul: Can I have your phone number, since I forgot mine?"); bobo_flirts_faces.Add(13);
        bobo_flirts.Add("Bobo: Founnumber? What is that? Let us ask more questions. What did I tell you about my family?"); bobo_flirts_faces.Add(6);
        bobo_flirts.Add("Ghoul: I think your wings are cute."); bobo_flirts_faces.Add(13);
        bobo_flirts.Add("Bobo: ARE MY WINGS TINY?"); bobo_flirts_faces.Add(6);
        bobo_flirts.Add("Ghoul: Are you an angel? Becau-"); bobo_flirts_faces.Add(13);
        bobo_flirts.Add("Bobo: You know very well that I’m an incubus! You should also know what my hobby is."); bobo_flirts_faces.Add(6);
        bobo_flirts.Add("Ghoul: I’m prepared to answer ANY quizzes you might give to me!"); bobo_flirts_faces.Add(13);
        bobo_flirts.Add("Bobo: What does my family do for living?"); bobo_flirts_faces.Add(6);
        bobo_flirts.Add("Ghoul: I ask again: Do you come here often?"); bobo_flirts_faces.Add(13);
        bobo_flirts.Add("Bobo: And I answer with a question: What do I think of this park?"); bobo_flirts_faces.Add(6);
        bobo_flirts.Add("Ghoul: Hello-"); bobo_flirts_faces.Add(13);
        bobo_flirts.Add("Bobo: Pop quiz! How many siblings do I have?"); bobo_flirts_faces.Add(6);
        bobo_flirts.Add("Ghoul: The color of your skin really fits perfectly together with the sky"); bobo_flirts_faces.Add(13);
        bobo_flirts.Add("Bobo: Good one, try again. How am I treated by my siblings?"); bobo_flirts_faces.Add(6);
        bobo_flirts.Add("Ghoul: Now that we are friends, we can probably drop these stupid questions?"); bobo_flirts_faces.Add(13);
        bobo_flirts.Add("Bobo: Muahahaha, no dice. What is my dream?"); bobo_flirts_faces.Add(27);
        bobo_flirts.Add("Ghoul: I’m all out of pick up lines."); bobo_flirts_faces.Add(13);
        bobo_flirts.Add("Bobo: Good. They were insufferable. Where is the best view of Ferrus?"); bobo_flirts_faces.Add(27);
        bobo_flirts.Add("Ghoul: Will these questions never end?!"); bobo_flirts_faces.Add(13);
        bobo_flirts.Add("Bobo: Don’t worry this is the last one and I’m sure you’ll get it right: Do I like this park?"); bobo_flirts_faces.Add(27);

        /*1*/
        bobo_choices.Add("Bobo"); bobo_choices.Add("Bibi"); bobo_choices.Add("Bebe");
        /*2*/
        bobo_choices.Add("Alexander Casimir  Hubert George Bernhard Lucius Filippe Frederick Magnus von Virtanen"); bobo_choices.Add("Alexander Hubert Filippe George Bernhard Lucius Frederick Magnus Oscar Richard von Val-Royeaux"); bobo_choices.Add("Uuuhhh.. It was pretty long wasn't it?");
        /*1*/
        bobo_choices.Add("Incubus"); bobo_choices.Add("Succubus"); bobo_choices.Add("Minotaur");
        /*3*/
        bobo_choices.Add("15"); bobo_choices.Add("150"); bobo_choices.Add("1500");
        /*2*/
        bobo_choices.Add("Beer"); bobo_choices.Add("Chocolate"); bobo_choices.Add("Kittens");
        /*3*/
        bobo_choices.Add("They are the best"); bobo_choices.Add("They are the finest"); bobo_choices.Add("They are the most powerful");
        /*3*/
        bobo_choices.Add("Yes"); bobo_choices.Add("Maybe"); bobo_choices.Add("No");
        /*1*/
        bobo_choices.Add("Reading"); bobo_choices.Add("Drawing"); bobo_choices.Add("Slacking off");
        /*2*/
        bobo_choices.Add("That’s a bad one..."); bobo_choices.Add("They deal information"); bobo_choices.Add("They play badminton");
        /*2*/
        bobo_choices.Add("You like it"); bobo_choices.Add("You might like it"); bobo_choices.Add("You don't like it");
        /*2*/
        bobo_choices.Add("54"); bobo_choices.Add("55"); bobo_choices.Add("56");
        /*2*/
        bobo_choices.Add("They spoil you"); bobo_choices.Add("They tease you"); bobo_choices.Add("You know, whatever a succubus or an incubus would do?");
        /*3*/
        bobo_choices.Add("You want to open an ice-cream shop in the north pole"); bobo_choices.Add("You want to conquer the world"); bobo_choices.Add("You want to learn to fly");
        /*3*/
        bobo_choices.Add("At the mansion"); bobo_choices.Add("At the tavern"); bobo_choices.Add("At the church");
        /*1*/
        bobo_choices.Add("You do"); bobo_choices.Add("You don't"); bobo_choices.Add("You don't give a damn");

        bobo_correct.Add(1); bobo_correct.Add(2); bobo_correct.Add(1); bobo_correct.Add(3); bobo_correct.Add(2);
        bobo_correct.Add(3); bobo_correct.Add(3); bobo_correct.Add(1); bobo_correct.Add(2); bobo_correct.Add(2);
        bobo_correct.Add(2); bobo_correct.Add(2); bobo_correct.Add(3); bobo_correct.Add(3); bobo_correct.Add(1);

        bobo_wronganswers.Add("???: I should have known you have only one brain cell"); bobo_wronganswers_faces.Add(28);
        bobo_wronganswers.Add("Bobo: How RUDE!"); bobo_wronganswers_faces.Add(28);
        bobo_wronganswers.Add("Bobo: Bzzzzt."); bobo_wronganswers_faces.Add(28);
        bobo_wronganswers.Add("Bobo: Nooooooo"); bobo_wronganswers_faces.Add(28);
        bobo_wronganswers.Add("Bobo: WRONG!"); bobo_wronganswers_faces.Add(28);

        bobo_correctanswers.Add("Bobo: I guess that’s correct."); bobo_correct_faces.Add(6);
        bobo_correctanswers.Add("Bobo: Surprising! You are correct!"); bobo_correct_faces.Add(27);
        bobo_correctanswers.Add("Bobo: Correct"); bobo_correct_faces.Add(27);
        bobo_correctanswers.Add("Bobo: I’m impressed!"); bobo_correct_faces.Add(27);
        bobo_correctanswers.Add("Bobo: You know me well."); bobo_correct_faces.Add(27);

        bobo_question1.Add("Ghoul: Tell me your name."); bobo_question1_faces.Add(12);
        bobo_question1.Add("???: Hm. Fine. It’s Alexander Hubert Filippe George Bernhard Casimir Lucius Frederick Magnus Oscar Richard von Val-Royeaux. Your kind won't ever remember my flawless noble name so you may call me Bobo for short."); bobo_question1_faces.Add(28);

        bobo_question2.Add("Ghoul: Okay, Bobo, can you remind me what was your glorious noble name?"); bobo_question2_faces.Add(13);
        bobo_question2.Add("Bobo: For the love of… Fine. Now listen closely; it is Alexander Hubert Filippe George Bernhard Casimir Lucius Frederick Magnus Oscar Richard von Val-Royeaux. I will make you regret the day you were born if you dare to forget it now that I have repeated it for you."); bobo_question2_faces.Add(6);

        bobo_question3.Add("Ghoul: So, are you an incubus?"); bobo_question3_faces.Add(13);
        bobo_question3.Add("Bobo: Yes, I am! Isn’t that obvious?"); bobo_question3_faces.Add(28);

        bobo_question4.Add("Ghoul: How come your wings are so tiny?"); bobo_question4_faces.Add(12);
        bobo_question4.Add("Bobo: Th-They ARE NOT tiny!"); bobo_question4_faces.Add(28);

        bobo_question5.Add("Ghoul: I’m going to the tavern. Do you want something?"); bobo_question5_faces.Add(12);
        bobo_question5.Add("Bobo: If they have chocolate, bring me some."); bobo_question5_faces.Add(6);

        bobo_question6.Add("Ghoul: How old are you?"); bobo_question6_faces.Add(13);
        bobo_question6.Add("Bobo: I don’t see what you could possibly gain from asking that, but if you must know, I just turned 1500. I might be rather young, but I am far from a teenager!"); bobo_question6_faces.Add(6);

        bobo_question7.Add("Ghoul: Tell me about your family"); bobo_question7_faces.Add(12);
        bobo_question7.Add("Bobo: My family is the most powerful of them all. We practically own this world. Going against me and my family would be your last mistake!"); bobo_question7_faces.Add(6);

        bobo_question8.Add("Ghoul: So what do they do? Your family I mean."); bobo_question8_faces.Add(14);
        bobo_question8.Add("Bobo: We… provide information. Actually, that’s none of your business."); bobo_question8_faces.Add(6);

        bobo_question9.Add("Ghoul: Do you like this park?");bobo_question9_faces.Add(12);
        bobo_question9.Add("Bobo: I might like it. I might not like it. Maybe you should stop prying?"); bobo_question9_faces.Add(6);

        bobo_question10.Add("Ghoul: Do you have any hobbies Bobo?"); bobo_question10_faces.Add(13);
        bobo_question10.Add("Bobo: I like to read and enjoy tea with my friend Catherine."); bobo_question10_faces.Add(27);

        bobo_question11.Add("Ghoul: Do you have any siblings?"); bobo_question11_faces.Add(12);
        bobo_question11.Add("Bobo: I have 55 older siblings. I’m the youngest of my family."); bobo_question11_faces.Add(6);

        bobo_question12.Add("Ghoul: Do they bully you?"); bobo_question12_faces.Add(14);
        bobo_question12.Add("Bobo: Well, not really, but they are always teasing me. And sometimes I feel left out because of, you know, my wings."); bobo_question12_faces.Add(6);

        bobo_question13.Add("Ghoul: Do you have a dream?"); bobo_question13_faces.Add(13);
        bobo_question13.Add("Bobo: Not really. Other than that I wish I could fly. But that’s not happening with these wings."); bobo_question13_faces.Add(6);

        bobo_question14.Add("Ghoul: Do you like this park?"); bobo_question14_faces.Add(12);
        bobo_question14.Add("Bobo: I love it! This is public space, so no one in my family ever visits. It’s peaceful here."); bobo_question14_faces.Add(27);

        bobo_question15.Add("Ghoul: If you could fly, where would you go?"); bobo_question15_faces.Add(13);
        bobo_question15.Add("Bobo: I would fly to the top of the church and look down on the world. Also I would leave the town. It’s nice here but I want to see the world."); bobo_question15_faces.Add(27);

        bobo_quests.Add("Bobo: Oh, you really did what I asked."); bobo_quests_faces.Add(6);
        bobo_quests.Add("Bobo: Thank you."); bobo_quests_faces.Add(27);
        bobo_quests.Add("Bobo: You were faster than I thought!"); bobo_quests_faces.Add(27);
        bobo_quests.Add("Bobo: I will not forget this."); bobo_quests_faces.Add(27);

        //Lists to lists
        bobo_questionLists.Add(bobo_question1);
        bobo_questionLists.Add(bobo_question2);
        bobo_questionLists.Add(bobo_question3);
        bobo_questionLists.Add(bobo_question4);
        bobo_questionLists.Add(bobo_question5);
        bobo_questionLists.Add(bobo_question6);
        bobo_questionLists.Add(bobo_question7);
        bobo_questionLists.Add(bobo_question8);
        bobo_questionLists.Add(bobo_question9);
        bobo_questionLists.Add(bobo_question10);
        bobo_questionLists.Add(bobo_question11);
        bobo_questionLists.Add(bobo_question12);
        bobo_questionLists.Add(bobo_question13);
        bobo_questionLists.Add(bobo_question14);
        bobo_questionLists.Add(bobo_question15);
        bobo_levelLists.Add(bobo_levelup1);
        bobo_levelLists.Add(bobo_levelup2);
        bobo_levelLists.Add(bobo_levelup3);
        bobo_levelLists.Add(bobo_levelup4);
        bobo_levelLists.Add(bobo_levelup5);

        bobo_questionLists_faces.Add(bobo_question1_faces);
        bobo_questionLists_faces.Add(bobo_question2_faces);
        bobo_questionLists_faces.Add(bobo_question3_faces);
        bobo_questionLists_faces.Add(bobo_question4_faces);
        bobo_questionLists_faces.Add(bobo_question5_faces);
        bobo_questionLists_faces.Add(bobo_question6_faces);
        bobo_questionLists_faces.Add(bobo_question7_faces);
        bobo_questionLists_faces.Add(bobo_question8_faces);
        bobo_questionLists_faces.Add(bobo_question9_faces);
        bobo_questionLists_faces.Add(bobo_question10_faces);
        bobo_questionLists_faces.Add(bobo_question11_faces);
        bobo_questionLists_faces.Add(bobo_question12_faces);
        bobo_questionLists_faces.Add(bobo_question13_faces);
        bobo_questionLists_faces.Add(bobo_question14_faces);
        bobo_questionLists_faces.Add(bobo_question15_faces);
        bobo_levelLists_faces.Add(bobo_levelup1_faces);
        bobo_levelLists_faces.Add(bobo_levelup2_faces);
        bobo_levelLists_faces.Add(bobo_levelup3_faces);
        bobo_levelLists_faces.Add(bobo_levelup4_faces);
        bobo_levelLists_faces.Add(bobo_levelup5_faces);

        //THERION
        therion_first.Add("???: Arrr! Who comes?! Is it ay devil?! A-wearin' such unnervin’ vestments!! Stop this here instant!"); therion_first_faces.Add(30);
        therion_first.Add("´???: Ay will cut y'all's head off if y'all come closer!"); therion_first_faces.Add(30);
        therion_first.Add("Ghoul: I mean no harm, ser… orc? Please watch your axe, that last swing cut a tad too close."); therion_first_faces.Add(12);
        therion_first.Add("???:  I’m nahwt a mister! Ayn' ay will… urh… sawry. This here place gets on me nerves."); therion_first_faces.Add(7);
        therion_first.Add("Ghoul: *chuckles* It’s okay. I would probably attack someone looking like me, too…"); therion_first_faces.Add(13);

        therion_greetings.Add("???: This here axe would look mighty awful fine attached ta ye cawpse."); therion_greetings_faces.Add(7);
        therion_greetings.Add("Therion: Ay don't think y'all are a-goin' ta get anything worthwhile out av me."); therion_greetings_faces.Add(7);
        therion_greetings.Add("Therion: Y'all sure y'all done got thay ...uhh raheet person?"); therion_greetings_faces.Add(7);
        therion_greetings.Add("Therion: Ye want a beer? Me treat."); therion_greetings_faces.Add(29);
        therion_greetings.Add("Therion: Ye evuurr get stuffy in those there robes? Come have a drink with me."); therion_greetings_faces.Add(29);
        therion_greetings.Add("Therion: Hey Ghoul. Ye look very nice an' alive!"); therion_greetings_faces.Add(29);

        therion_byes.Add("???: Don’t let th’ door hit ye ass."); therion_byes_faces.Add(7);
        therion_byes.Add("Therion: Buh-bye."); therion_byes_faces.Add(7);
        therion_byes.Add("Therion: *burps* Bye mate."); therion_byes_faces.Add(29);
        therion_byes.Add("Therion: Don't stray too far away!"); therion_byes_faces.Add(29);
        therion_byes.Add("Therion: Come back soon faw dinner, yeah!"); therion_byes_faces.Add(29);
        therion_byes.Add("Therion: Have ayy darn good one, Ghoulie!"); therion_byes_faces.Add(29);

        therion_hay.Add("???: So hungry..."); therion_hay_faces.Add(7);
        therion_hay.Add("Therion; Well, ay never."); therion_hay_faces.Add(7);
        therion_hay.Add("Therion: Do y'all like this here tavern? Ay certainly do."); therion_hay_faces.Add(7);
        therion_hay.Add("Therion: Ay wonduurr if y'all could make steak out av thay plagued ones."); therion_hay_faces.Add(7);
        therion_hay.Add("Therion: Still here, Ghoul."); therion_hay_faces.Add(29);
        therion_hay.Add("Therion: We should barbecue togithuurr sometime!"); therion_hay_faces.Add(29);

        therion_levelup1.Add("Therion: Ye know, me mum always used ta say not to trust strangers, but... *smirks* Yer kind of funny, lil' guy."); therion_levelup1_faces.Add(29);
        therion_levelup2.Add("Therion: Heya. Ye wanna play sum cards or sumthin sometime? We take me friend Shazura the the barkeeper with us too."); therion_levelup2_faces.Add(7);
        therion_levelup2.Add("Ghoul: Cards? That's sweet. I only thought you were all about hunting and boasting and drinking."); therion_levelup2_faces.Add(13);
        therion_levelup2.Add("Therion: Well, is there anthin' bettur than havin' fun with mates? Ay think I had the cards here 'round somewhere..."); therion_levelup2_faces.Add(29);
        therion_levelup2.Add("Ghoul: I mean sure! Sounds fun. Evening with two crazy green people."); therion_levelup2_faces.Add(12);
        therion_levelup2.Add("Therion: Ye never stop joking do ye?"); therion_levelup2_faces.Add(29);

        therion_levelup3.Add("Ghoul: Hey there bear-man. I liked playing cards with Shazura with you. It’s like… I’M MAKING FRIENDS YES!"); therion_levelup3_faces.Add(12);
        therion_levelup3.Add("Therion: That there's me. the darn good friend-candidate who fawces people ta play cards. Wait y'all done liked it?"); therion_levelup3_faces.Add(7);
        therion_levelup3.Add("Ghoul: Yes I did. I wouldn’t mind making it a regular thing… like… poker tuesdays. Everyone’s invited!"); therion_levelup3_faces.Add(13);
        therion_levelup3.Add("Therion: Y'all have such ayy strange maand. Darn good idea, though. Ay doubtr Gru fits thru thay ...uhh doaw ayn' Fenris would just declahn on purpose."); therion_levelup3_faces.Add(7);
        therion_levelup3.Add("Ghoul: Poker tuesdays for everyone capable and wanting to enter!"); therion_levelup3_faces.Add(13);
        therion_levelup3.Add("Therion: Ay'll bring the snacks!"); therion_levelup3_faces.Add(29);

        therion_levelup4.Add("Ghoul: Therion. I heard minotaurs and orcs are two of the most violent species there is and then there is... you."); therion_levelup4_faces.Add(12);
        therion_levelup4.Add("Therion: Weelll, ye know.... Me parents did want ta make me into a great warrior! Not that ay dun enjoy bashing heads in every know an then."); therion_levelup4_faces.Add(7);
        therion_levelup4.Add("Ghoul: Buuut...? You know. You are almost sweet."); therion_levelup4_faces.Add(13);
        therion_levelup4.Add("Therion: Sweet? *laughs* Ay think ye got the wrong person, friend. Ay like me friends and good food and warm hearths an beer, does that make me a softie?"); therion_levelup4_faces.Add(7);
        therion_levelup4.Add("Ghoul: Not at all, Therion. I mean you still hate Fenris, yeah?"); therion_levelup4_faces.Add(14);
        therion_levelup4.Add("Therion: Hah, ye done it. Indeed he is the one me hates. Need ta have a bit of balance to even out all the lovin'."); therion_levelup4_faces.Add(30);
        therion_levelup4.Add("Ghoul: True words!"); therion_levelup4_faces.Add(12);

        therion_levelup5.Add("Therion: So uh... yer a good mate of mine, and ay dun even know yer name. What'sit?"); therion_levelup5_faces.Add(7);
        therion_levelup5.Add("Ghoul: 'Tis a secret. People who know it die mysteriously. I always thought that if I had any friends, they would call me Nameless Ghoul or NG for short. Because that is cool and mysterious."); therion_levelup5_faces.Add(13);
        therion_levelup5.Add("Therion: So cool, Ghoul. Well ay am yer friend, ain't I?"); therion_levelup5_faces.Add(7);
        therion_levelup5.Add("Ghoul: Yeah. Never thought I had my own one man sized army as my friend."); therion_levelup5_faces.Add(12);
        therion_levelup5.Add("Therion: Ah yes. Ay will crush yer enemies while we feast on their remains!"); therion_levelup5_faces.Add(29);
        therion_levelup5.Add("Ghoul: Sounds like a date."); therion_levelup5_faces.Add(13);
        therion_levelup5.Add("Therion: It's only a date if ye have somethin' nice for me. Like a cake."); therion_levelup5_faces.Add(29);
        therion_levelup5.Add("Ghoul: I'll keep that in mind. I wouldn't mind getting to kill my enemies. *laughs*"); therion_levelup5_faces.Add(13);

        therion_gifts.Add("???: Me is not usually th' type to get gifts... not that ay dun appreciate it."); therion_gifts_faces.Add(7);
        therion_gifts.Add("Therion: Thanks ay suppose!"); therion_gifts_faces.Add(29);
        therion_gifts.Add("Therion: Nice! Ye want a bear hug in return?"); therion_gifts_faces.Add(29);
        therion_gifts.Add("Therion: That there's cool! Do y'all want ayy beuurr now?"); therion_gifts_faces.Add(29);
        therion_gifts.Add("Therion: Ye always know how ta make me happy."); therion_gifts_faces.Add(29);
        therion_gifts.Add("Therion: Aww Ghoulie, the only thing me needs is you."); therion_gifts_faces.Add(29);
        therion_gifts.Add("Therion: Ahh, it's been a mighty long while since I've had any good cake... Ye have me thanks."); therion_gifts_faces.Add(29);
        therion_gifts.Add("Therion: I have something for ye, Ghoulie. I hope ye find it useful... maybe for ye rituals?"); therion_gifts_faces.Add(29);

        therion_badgifts.Add("???: Y'all don't have ta pick up trash, y'all know."); therion_badgifts_faces.Add(30);
        therion_badgifts.Add("Therion: Oh, dat’s disgusting."); therion_badgifts_faces.Add(30);
        therion_badgifts.Add("Therion: Ay can't eat this here..."); therion_badgifts_faces.Add(30);
        therion_badgifts.Add("Therion: What's this here? It's... hawrible!"); therion_badgifts_faces.Add(30);
        therion_badgifts.Add("Therion: Ay done thought y'all done knew what ay like by now."); therion_badgifts_faces.Add(30);
        therion_badgifts.Add("Therion: Sawry friend, that there's awful bad."); therion_badgifts_faces.Add(30);

        therion_nothingtosay.Add("Therion: Uhh, bye?"); therion_nothingtosay_faces.Add(7);
        therion_nothingtosay.Add("Therion: Heya cowboy."); therion_nothingtosay_faces.Add(7);
        therion_nothingtosay.Add("Therion: I AM HUNGRY! Les do somethin' else."); therion_nothingtosay_faces.Add(7);

        therion_flirts.Add("Ghoul: Did it get hot here or is it just me?"); therion_flirts_faces.Add(13);
        therion_flirts.Add("???: Ehhh? I betcha ye dun even remember my name?"); therion_flirts_faces.Add(30);
        therion_flirts.Add("Ghoul: So what is a hairy bear like you doing in Hairless Bear? ;)"); therion_flirts_faces.Add(13);
        therion_flirts.Add("Therion: ... Ain't ye too young fo' dat? ....Me and ye talked 'bout age, right?"); therion_flirts_faces.Add(7);
        therion_flirts.Add("Ghoul: Wanna come sharpen your axe at my place?"); therion_flirts_faces.Add(13);
        therion_flirts.Add("Therion: Ye call me hairy, but ay bets ye dun even rememburr what me am!"); therion_flirts_faces.Add(7);
        therion_flirts.Add("Ghoul: If I could rearrange the alphabet I would but U and I together!"); therion_flirts_faces.Add(13);
        therion_flirts.Add("Therion: Ye talk about alphabets yet ay bet ye don' even remembur whose handiwork dat rug is."); therion_flirts_faces.Add(7);
        therion_flirts.Add("Ghoul: Can you get that for me? I dropped my jaw."); therion_flirts_faces.Add(13);
        therion_flirts.Add("Therion: Erh? Ye still hav ye jaw on ye face.. Ohh. Well tell me lil' person, wat's me favooourite stuff to do?"); therion_flirts_faces.Add(7);
        therion_flirts.Add("Ghoul: You are like a chubby polar bear. All cuddly and soft."); therion_flirts_faces.Add(13);
        therion_flirts.Add("Therion: Ay will cuddle ye arms off if ye don rememburr what ay like 'bout this place!"); therion_flirts_faces.Add(7);
        therion_flirts.Add("Ghoul: Are you book in a library? ‘Cos I’m checking you out!"); therion_flirts_faces.Add(13);
        therion_flirts.Add("Therion: Are ye implying ay can't read? I read a lot of recipes for my... hobby! Do you remember what that is?"); therion_flirts_faces.Add(7);
        therion_flirts.Add("Ghoul: Heyyy, what's a-shakin' bacon?"); therion_flirts_faces.Add(13);
        therion_flirts.Add("Therion: The stuff ye say is so weird, ye know. Could ye mabe annoy that Fenris-wolf? Do ye remember why ay diss 'im?"); therion_flirts_faces.Add(7);
        therion_flirts.Add("Ghoul: I’d like to see you in a kilt."); therion_flirts_faces.Add(13);
        therion_flirts.Add("Therion: Y'all like ayy man in ayy dress? Ay done might do that there, aftuurr all ay am just ayy awful big…"); therion_flirts_faces.Add(7);
        therion_flirts.Add("Ghoul: I like you like I like my coffee: hot and green."); therion_flirts_faces.Add(13);
        therion_flirts.Add("Therion: Green coffee? What the blazin' hells? Dat's like I would say the thing on my axe is red whipped cream. Wat is it anyway?"); therion_flirts_faces.Add(7);
        therion_flirts.Add("Ghoul: I must be asleep, 'cause you are a dream come true. Also, I'm slightly damp."); therion_flirts_faces.Add(13);
        therion_flirts.Add("Therion: Damp like ayy sweet cake? Ay weysh ay done had cake raheet now…"); therion_flirts_faces.Add(7);
        therion_flirts.Add("Ghoul: Hey, baby cakes."); therion_flirts_faces.Add(13);
        therion_flirts.Add("Therion: Ay would make y'all ayy cake if ay could. Best ay can do raheet now is…"); therion_flirts_faces.Add(29);
        therion_flirts.Add("Ghoul: The night’s are so chilly here… *wink*"); therion_flirts_faces.Add(13);
        therion_flirts.Add("Therion: Y'all could bunk with me. I’m sure Shazura won’t maand an extra person here. Remembuurr when ay met her?"); therion_flirts_faces.Add(29);
        therion_flirts.Add("Ghoul: Did you sit in honey? 'Cos you got a sweet ass!"); therion_flirts_faces.Add(13);
        therion_flirts.Add("Therion: *laughs* Dat's a bad one. I dun think Shazura has any honey for us to sit on. Erm... do ye rememburr wat me dream was?"); therion_flirts_faces.Add(29);
        therion_flirts.Add("Ghoul: You make me feel horny.... you know... your horns…"); therion_flirts_faces.Add(13);
        therion_flirts.Add("Therion: Ye like me horns?! Ay will definitely name my bakery aftuurr y'all!"); therion_flirts_faces.Add(29);

        /*2*/
        therion_choices.Add("Therion Bloodaxe"); therion_choices.Add("Just Therion"); therion_choices.Add("Something incredibly orcy, I bet");
        /*1*/
        therion_choices.Add("You said you are older than me"); therion_choices.Add("You are totally younger!"); therion_choices.Add("Can't tell with you guys");
        /*3*/
        therion_choices.Add("Orc"); therion_choices.Add("Orc-goblin"); therion_choices.Add("Orc-minotaur");
        /*2*/
        therion_choices.Add("Yours?"); therion_choices.Add("The barkeeper"); therion_choices.Add("Fenris!");
        /*3*/
        therion_choices.Add("Killing people!"); therion_choices.Add("Talkin' stupid"); therion_choices.Add("Drinking and stuff");
        /*2*/
        therion_choices.Add("The beer is good"); therion_choices.Add("The people around are your buddies"); therion_choices.Add("It's the only place you can fit into");
        /*2*/
        therion_choices.Add("Drinking?"); therion_choices.Add("Cooking"); therion_choices.Add("Horseback");
        /*1*/
        therion_choices.Add("You hate everything about him"); therion_choices.Add("His hair is too luxurious for you to handle"); therion_choices.Add("He called you fat once");
        /*1*/
        therion_choices.Add("Biggest softie ever"); therion_choices.Add("An idiot?"); therion_choices.Add("Eager to please…");
        /*2*/
        therion_choices.Add("Blood"); therion_choices.Add("Strawberry jam"); therion_choices.Add("Someone's insides");
        /*1*/
        therion_choices.Add("But ingredients are hard to find"); therion_choices.Add("You don’t have money"); therion_choices.Add("NO CAKE IN DEMON LAND!");
        /*3*/
        therion_choices.Add("Steak"); therion_choices.Add("Muffins"); therion_choices.Add("Sandwich!");
        /*2*/
        therion_choices.Add("You were both hunters"); therion_choices.Add("You were both in the army"); therion_choices.Add("You were both novices in the church");
        /*1*/
        therion_choices.Add("You want to open a bakery"); therion_choices.Add("You want to kill Fenris"); therion_choices.Add("You want to dance ballet");
        /*2*/
        therion_choices.Add("Please don’t"); therion_choices.Add("Yes, the Ghoul’s buns"); therion_choices.Add("What bakery..?");

        therion_correct.Add(2); therion_correct.Add(1); therion_correct.Add(3); therion_correct.Add(2); therion_correct.Add(3);
        therion_correct.Add(2); therion_correct.Add(2); therion_correct.Add(1); therion_correct.Add(1); therion_correct.Add(2);
        therion_correct.Add(1); therion_correct.Add(3); therion_correct.Add(2); therion_correct.Add(1); therion_correct.Add(2);

        therion_wronganswers.Add("???: This here makes me sad.."); therion_wronganswers_faces.Add(30);
        therion_wronganswers.Add("Therion: Ay shouldn't be disappointed but ay am..."); therion_wronganswers_faces.Add(30);
        therion_wronganswers.Add("Therion: Ay'm sadduurr than an uneaten sandwich."); therion_wronganswers_faces.Add(30);
        therion_wronganswers.Add("Therion: U DUN IT NAO 'ARRY"); therion_wronganswers_faces.Add(30);
        therion_wronganswers.Add("Therion: This here makes me devastatingly sad..."); therion_wronganswers_faces.Add(30);

        therion_correctanswers.Add("Therion: Hey, y'all done remembered!"); therion_correct_faces.Add(29);
        therion_correctanswers.Add("Therion: Praise the potato!"); therion_correct_faces.Add(29);
        therion_correctanswers.Add("Therion: Ay like y'all!"); therion_correct_faces.Add(29);
        therion_correctanswers.Add("Therion: Heh, didn' think ye get it."); therion_correct_faces.Add(29);
        therion_correctanswers.Add("Therion: Ay done knew y'all done knew it!"); therion_correct_faces.Add(29);

        therion_quests.Add("Therion: Hey, this here is great!"); therion_quests_faces.Add(29);
        therion_quests.Add("Therion: Well, goo'ness gracious, mister, that there's ayy mighty kind thing y'all done."); therion_quests_faces.Add(29);
        therion_quests.Add("Therion: Ay should haahyr y'all ta be my squaahyr aw something!"); therion_quests_faces.Add(29);
        therion_quests.Add("Therion: Y'all are so darn good at this here, Ghoul."); therion_quests_faces.Add(29);

        therion_question1.Add("Ghoul: So mister axe, what do they call you?"); therion_question1_faces.Add(13);
        therion_question1.Add("???: Me name is Therion. Me parents weren't mighty imaginative, my fathurr is done called Theon ayn' my mowthur were Rionna. Imagahn that there."); therion_question1_faces.Add(7);

        therion_question2.Add("Ghoul: How old are you?"); therion_question2_faces.Add(12);
        therion_question2.Add("Therion: Oldur than ye, little person. Biggur too."); therion_question2_faces.Add(7);

        therion_question3.Add("Ghoul: Not to be rude, but what exactly are you?"); therion_question3_faces.Add(13);
        therion_question3.Add("Therion: Me is a proud mercanry ayn' hunter! Me hunt boars ayn' bears and… yeah."); therion_question3_faces.Add(7);
        therion_question3.Add("Ghoul: I mean… I meant your… genetic makeup, so to speak."); therion_question3_faces.Add(14);
        therion_question3.Add("Therion: Gene-whatnow? Ohh y'all mean me parents! Me mum were an orc, me dad were an minotaur. Me am something in between."); therion_question3_faces.Add(7);

        therion_question4.Add("Ghoul: You aren’t the only hunter here, are you?"); therion_question4_faces.Add(12);
        therion_question4.Add("Therion: Naw. There is that there son av ay damn wolf, thank me ancestors he doesn’t appreciate this here watering howwl much. The lass does some hunting too. Thay rug here is all huurr wawk. Packs a punch, that lil’ miss."); therion_question4_faces.Add(7);

        therion_question5.Add("Ghoul: You seem funny, Therion. Like there is something you want to tell me."); therion_question5_faces.Add(13);
        therion_question5.Add("Therion: What could ye possibly mean? Me is ay simple man. Ay like a-drinkin' ayn' hunting ayn' sharpening me axe."); therion_question5_faces.Add(7);

        therion_question6.Add("Ghoul: You seem to like this tavern a lot? "); therion_question6_faces.Add(12);
        therion_question6.Add("Therion: Thay beerr is cheap ayn' thay missus at thay bar is nice. Nahwt much ta it."); therion_question6_faces.Add(7);

        therion_question7.Add("Ghoul: Do you have any hobbies? Apart from drinking, I mean."); therion_question7_faces.Add(12);
        therion_question7.Add("Therion: Me appreciate ay darn good meal. Me considuurr meself quite thay cook."); therion_question7_faces.Add(29);

        therion_question8.Add("Ghoul: What do you have against Fenris?"); therion_question8_faces.Add(14);
        therion_question8.Add("Therion: Everything! He even smells awful bad when he gets wet. Grr."); therion_question8_faces.Add(30);

        therion_question9.Add("Ghoul: You seem to have mellowed out as time has gone. Was the angry orc just an act when we met?"); therion_question9_faces.Add(13);
        therion_question9.Add("Therion: Eh… whel. Ye done got it. Ay have ta act tough ta nahwt stayn my lineage, ye know. Naw one would take me seriously if they done knew what ay softie ay actually am. What are y'all grinning at? Don’t tell anyone!"); therion_question9_faces.Add(7);

        therion_question10.Add("Ghoul: Is that blood on your axe?"); therion_question10_faces.Add(14);
        therion_question10.Add("Therion: Whet? Naw! It’s. . strawberry jam. Ay cut ay slice av cake with it."); therion_question10_faces.Add(7);

        therion_question11.Add("Ghoul: Strawberry jam…? Cake? You can get cake here?"); therion_question11_faces.Add(13);
        therion_question11.Add("Therion: Nahwt mighty. Ay usually make it myself. It's quite awful hard ta faand thay ingredients, though."); therion_question11_faces.Add(7);

        therion_question12.Add("Ghoul: I think it is quite sweet you find joy in baking. Best I can do is cook instant noodles…"); therion_question12_faces.Add(13);
        therion_question12.Add("Therion: Instant noodles sownd like sawcery. Next tahm Shazura lets me handle thay bar ay will make y'all thay best sandwich y'all'll evuurr eat!"); therion_question12_faces.Add(29);

        therion_question13.Add("Ghoul: You and Shazura are really good friends, huh? How’d a bonafide chef and a tiny sword swinging goblin end up together?"); therion_question13_faces.Add(12);
        therion_question13.Add("Therion: Now that there's ayy stawy. It were way back when ay didn't have my tummy ayn' could fit in plate armaw. We actually both done served in the Devil regent’s army!"); therion_question13_faces.Add(7);

        therion_question14.Add("Ghoul: You seem way too sweet to do murdering at some monarch’s command."); therion_question14_faces.Add(13);
        therion_question14.Add("Therion: Ahh, Ghoul, why do y'all think ay stopped? *laughs*"); therion_question14_faces.Add(29);

        therion_question15.Add("Ghoul: Come on, Therion. What is it that you really want?"); therion_question15_faces.Add(12);
        therion_question15.Add("Therion: Whel me guess ay can tell y'all. Ye been a darn good friend. If there wasn’t such ay pressure on me ta be like me parents ay would… ay would estableysh ay bakery."); therion_question15_faces.Add(29);

        therion_question16.Add("Ghoul: That sounds wonderful. Have you thought of a name?"); therion_question16_faces.Add(13);
        therion_question16.Add("Therion: What would y'all say ta Ghoul's buns? *smirks*"); therion_question16_faces.Add(29);

        //Lists to lists
        therion_questionLists.Add(therion_question1);
        therion_questionLists.Add(therion_question2);
        therion_questionLists.Add(therion_question3);
        therion_questionLists.Add(therion_question4);
        therion_questionLists.Add(therion_question5);
        therion_questionLists.Add(therion_question6);
        therion_questionLists.Add(therion_question7);
        therion_questionLists.Add(therion_question8);
        therion_questionLists.Add(therion_question9);
        therion_questionLists.Add(therion_question10);
        therion_questionLists.Add(therion_question11);
        therion_questionLists.Add(therion_question12);
        therion_questionLists.Add(therion_question13);
        therion_questionLists.Add(therion_question14);
        therion_questionLists.Add(therion_question15);
        therion_questionLists.Add(therion_question16);
        therion_levelLists.Add(therion_levelup1);
        therion_levelLists.Add(therion_levelup2);
        therion_levelLists.Add(therion_levelup3);
        therion_levelLists.Add(therion_levelup4);
        therion_levelLists.Add(therion_levelup5);

        therion_questionLists_faces.Add(therion_question1_faces);
        therion_questionLists_faces.Add(therion_question2_faces);
        therion_questionLists_faces.Add(therion_question3_faces);
        therion_questionLists_faces.Add(therion_question4_faces);
        therion_questionLists_faces.Add(therion_question5_faces);
        therion_questionLists_faces.Add(therion_question6_faces);
        therion_questionLists_faces.Add(therion_question7_faces);
        therion_questionLists_faces.Add(therion_question8_faces);
        therion_questionLists_faces.Add(therion_question9_faces);
        therion_questionLists_faces.Add(therion_question10_faces);
        therion_questionLists_faces.Add(therion_question11_faces);
        therion_questionLists_faces.Add(therion_question12_faces);
        therion_questionLists_faces.Add(therion_question13_faces);
        therion_questionLists_faces.Add(therion_question14_faces);
        therion_questionLists_faces.Add(therion_question15_faces);
        therion_questionLists_faces.Add(therion_question16_faces);
        therion_levelLists_faces.Add(therion_levelup1_faces);
        therion_levelLists_faces.Add(therion_levelup2_faces);
        therion_levelLists_faces.Add(therion_levelup3_faces);
        therion_levelLists_faces.Add(therion_levelup4_faces);
        therion_levelLists_faces.Add(therion_levelup5_faces);

        itemID = null;
    }

    //LINE GETTERS
    //
    //Returns lines for minor NPC's
    public string GetLinesMinor(string name, int no)
    {
        if (name == "example") { return example[no]; }
        else if (name == "Grandma") { spriteChanger.ChangingSprites(grandma.Values[no]);  return grandma.Keys[no]; }
        else if (name == "Guard") { spriteChanger.ChangingSprites(guard.Values[no]); return guard.Keys[no]; }
        else if (name == "Horror") { spriteChanger.ChangingSprites(horror.Values[no]); return horror.Keys[no]; }
        else { return "This is an error from GetLinesMinor. You shouldn't be able to see me"; }
    }
    //Return's lines for major NPC's
    public string GetLinesMajor(string name, int no)
    {
        i++;
        currentConversationLength = 0;
        if (name == "Pope") { return PopeLogic(no); }
        else if (name == "Innkeeper") { return InnkeeperLogic(no); }
        else if (name == "Shopkeeper") { return ShopkeeperLogic(no); }
        else { return "This an error from GetLinesMajor. You shouldn't see me."; }
    }
    //Return's lines for lovers
    public string GetLinesLover(string name, int no, int lovelevel, bool first)
    {
        i++;
        currentConversationLength = 0;
        if (name == "Bobo") { return BoboLogic(no, lovelevel, first); }
        else if (name == "Fenris") { return FenrisLogic(no,lovelevel,first); }
        else if (name == "Therion") { return TherionLogic(no,lovelevel,first); }
        else if (name == "Gru") { return GruLogic(no, lovelevel, first); }
        else if (name == "Yola") { return YolaLogic(no, lovelevel, first); }
        else if (name == "Catherine") { return CatherineLogic(no, lovelevel, first); }
        else { return "This an error from GetLinesLover. You shouldn't see me."; }
    }

    //LOGIG FOR WHEN A CONVERSATION BUTTON IS PRESSED
    public string GetLinesButton(string buttonName, string NPC, int lovelevel)
    {
        i++;
        rand = Random.Range(0,3);
        popeB.pope.SetLoverButtonsInactive();
        popeB.pope.SetShopButtonsInactive();
        popeB.SetPopeButtonsInactive();
        currentConversationLength = 0;
        if (buttonName == "Tips") //If tips button is pressed
        {
            currentConversationLength = 0;
            popeTips++;
            spriteChanger.ChangingSprites(pope_tips_faces[popeTips % 4]);
            return pope_tips[popeTips % 4];
        }
        else if (buttonName == "Objects") //If objects button is pressed
        {
            if (howManyObjectsOfLove >= 3)
            {
                currentConversationLength = 999999999;
                
                if (i >= pope_objects.Count - 2)
                {
                    stay.gameObject.SetActive(true);
                    leave.gameObject.SetActive(true);
                    spriteChanger.ChangingSprites(pope_objects_faces[pope_objects.Count - 2]);
                    return pope_objects[pope_objects.Count - 2];
                }
                spriteChanger.ChangingSprites(pope_objects_faces[i]);
                return pope_objects[i];
            }
            else { currentConversationLength = 0;
                spriteChanger.ChangingSprites(pope_objects_faces[pope_objects.Count - 1]);
                return pope_objects[pope_objects.Count - 1];
            }
        }
        else if (buttonName == "Heal") //if heal button is pressed
        {
            currentConversationLength = 0;
            if (HP.fullHealth == HP.currentHealth)
            {
                spriteChanger.ChangingSprites(pope_healing_faces[1]);
                return pope_healing[1];
            }
            else
            {
                HP.currentHealth = HP.fullHealth;
                spriteChanger.ChangingSprites(pope_healing_faces[0]);
                return pope_healing[0];
            }
        }
        else if (buttonName == "ByePope") //if bye is pressed
        {
            currentConversationLength = 0;
            spriteChanger.ChangingSprites(pope_healing_faces[0]);
            saidBye = true;
            return "Pope: May the Potato be with you.";
        }
        else if (buttonName == "Talk") //if talk is pressed
        {
            if (NPC == "Yola") { spriteChanger.ChangingSprites(yola_hay_faces[lovelevel]); return yola_hay[lovelevel]; }
            else if (NPC == "Gru") { spriteChanger.ChangingSprites(gru_hay_faces[lovelevel]); return gru_hay[lovelevel]; }
            else if (NPC == "Fenris") { spriteChanger.ChangingSprites(fenris_hay_faces[lovelevel]); return fenris_hay[lovelevel]; }
            else if (NPC == "Catherine") { spriteChanger.ChangingSprites(catherine_hay_faces[lovelevel]); return catherine_hay[lovelevel]; }
            else if (NPC == "Bobo") { spriteChanger.ChangingSprites(bobo_hay_faces[lovelevel]); return bobo_hay[lovelevel]; }
            else if (NPC == "Therion") { spriteChanger.ChangingSprites(therion_hay_faces[lovelevel]); return therion_hay[lovelevel]; }
            return "Error from talking";
        }
        else if (buttonName == "Ask") //if Ask is pressed
        {
            if (NPC == "Yola")
            {
                if (i == 0) { YolaQ++; }
                if (lovelevel == 0 && YolaQ < 1 || lovelevel ==1 && YolaQ<5||lovelevel==2&&YolaQ<8||lovelevel==3&&YolaQ<12||lovelevel==4&&YolaQ<yola_questionLists.Count)
                {
                    currentConversationLength = yola_questionLists[YolaQ].Count - 1;
                    spriteChanger.ChangingSprites(yola_questionLists_faces[YolaQ][i]);
                    return yola_questionLists[YolaQ][i];
                }
                else { YolaQ--; spriteChanger.ChangingSprites(yola_nothingtosay_faces[rand]); return yola_nothingtosay[rand]; }
            }
            else if (NPC == "Gru")
            {
                Debug.Log(GruQ);
                if (i == 0) { GruQ++; }
                if (lovelevel == 0 && GruQ < 1 || lovelevel == 1 && GruQ < 5 || lovelevel == 2 && GruQ < 8 || lovelevel == 3 && GruQ < 12 || lovelevel == 4 && GruQ < gru_questionLists.Count)
                {
                    currentConversationLength = gru_questionLists[GruQ].Count - 1;
                    spriteChanger.ChangingSprites(gru_questionLists_faces[GruQ][i]);
                    return gru_questionLists[GruQ][i];
                }
                else
                {
                    GruQ--; spriteChanger.ChangingSprites(gru_nothingtosay_faces[rand]);
                    if (lovelevel == 0)
                    {
                        return "???: Gruuuuuuuuu....";
                    }
                    return gru_nothingtosay[rand];
                }
            }
            else if (NPC == "Fenris")
            {
                if (i == 0) { FenrisQ++; }
                if (lovelevel == 0 && FenrisQ < 1 || lovelevel == 1 && FenrisQ < 5 || lovelevel == 2 && FenrisQ < 8 || lovelevel == 3 && FenrisQ < 12 || lovelevel == 4 && FenrisQ < fenris_questionLists.Count)
                {
                    currentConversationLength = fenris_questionLists[FenrisQ].Count - 1;
                    spriteChanger.ChangingSprites(fenris_questionLists_faces[FenrisQ][i]);
                    return fenris_questionLists[FenrisQ][i];
                }
                else
                {
                    FenrisQ--; spriteChanger.ChangingSprites(fenris_nothingtosay_faces[rand]);
                    if (lovelevel == 0)
                    {
                        return "???: ...";
                    }
                    return fenris_nothingtosay[rand];
                }
            }
            else if (NPC == "Catherine")
            {
                if (i == 0) { CatherineQ++; }
                if (lovelevel == 0 && CatherineQ < 1 || lovelevel == 1 && CatherineQ < 5 || lovelevel == 2 && CatherineQ < 8 || lovelevel == 3 && CatherineQ < 12 || lovelevel == 4 && CatherineQ < catherine_questionLists.Count)
                {
                    currentConversationLength = catherine_questionLists[CatherineQ].Count - 1;
                    spriteChanger.ChangingSprites(catherine_questionLists_faces[CatherineQ][i]);
                    return catherine_questionLists[CatherineQ][i];
                }
                else
                {
                    CatherineQ--; spriteChanger.ChangingSprites(catherine_nothingtosay_faces[rand]);
                    if (lovelevel == 0)
                    {
                        return "???: Thou silence sy golden.";
                    }
                    return catherine_nothingtosay[rand];
                }
            }
            else if (NPC == "Bobo")
            {
                if (i == 0) { BoboQ++; }
                if (lovelevel == 0 && BoboQ < 1 || lovelevel == 1 && BoboQ < 5 || lovelevel == 2 && BoboQ < 8 || lovelevel == 3 && BoboQ < 12 || lovelevel == 4 && BoboQ < bobo_questionLists.Count)
                {
                    currentConversationLength = bobo_questionLists[BoboQ].Count - 1;
                    spriteChanger.ChangingSprites(bobo_questionLists_faces[BoboQ][i]);
                    return bobo_questionLists[BoboQ][i];
                }
                else
                {
                    BoboQ--; spriteChanger.ChangingSprites(bobo_nothingtosay_faces[rand]);
                    if (lovelevel == 0)
                    {
                        return "???: Just leave me be!";
                    }
                    return bobo_nothingtosay[rand];
                }
            }
            else if (NPC == "Therion")
            {
                if (i == 0) { TherionQ++; }
                if (lovelevel==0&&TherionQ<1||lovelevel == 1 && TherionQ < 5 || lovelevel == 2 && TherionQ < 8 || lovelevel == 3 && TherionQ < 12 || lovelevel == 4 && TherionQ < therion_questionLists.Count)
                {
                    currentConversationLength = therion_questionLists[TherionQ].Count - 1;
                    spriteChanger.ChangingSprites(therion_questionLists_faces[TherionQ][i]);
                    return therion_questionLists[TherionQ][i];
                }
                else {
                    TherionQ--; spriteChanger.ChangingSprites(therion_nothingtosay_faces[rand]);
                    if (lovelevel == 0)
                    {
                        return "???: Off ya go buddy.";
                    }
                    return therion_nothingtosay[rand];
                }
            }
            else
            {
                currentConversationLength = 0;
                return "Error from asking a question";
            }
        }
        else if (buttonName == "Flirt") //if flirt is pressed
        {
            if (NPC == "Yola")
            {
                if (lovelevel == 5) { spriteChanger.ChangingSprites(yola_nothingtosay_faces[rand]); return yola_nothingtosay[rand]; }
                currentConversationLength = 1;
                if (i == 0)
                {
                    if(YolaF >= 14)
                    {
                        currentConversationLength = 0;
                        spriteChanger.ChangingSprites(yola_nothingtosay_faces[rand]);
                        return yola_nothingtosay[rand];
                    }
                    YolaF++;
                    spriteChanger.ChangingSprites(yola_flirts_faces[YolaF*2]);
                    return yola_flirts[YolaF * 2];
                }
                else
                {
                    SetChoicesActive();
                    TextA.text = yola_choices[YolaF * 3];
                    TextB.text = yola_choices[YolaF * 3 + 1];
                    TextC.text = yola_choices[YolaF * 3 + 2];
                    spriteChanger.ChangingSprites(yola_flirts_faces[YolaF * 2 + 1]);
                    return yola_flirts[YolaF * 2 + 1];
                }
            }
            else if (NPC == "Gru")
            {
                if (lovelevel == 5) { spriteChanger.ChangingSprites(gru_nothingtosay_faces[rand]); return gru_nothingtosay[rand]; }
                currentConversationLength = 1;
                if (i == 0)
                {
                    if (GruF >= 14)
                    {
                        currentConversationLength = 0;
                        spriteChanger.ChangingSprites(gru_nothingtosay_faces[rand]);
                        if (lovelevel == 0)
                        {
                            return "???: Gruuuuuuuuu....";
                        }
                        return gru_nothingtosay[rand];
                    }
                    GruF++;
                    spriteChanger.ChangingSprites(gru_flirts_faces[GruF * 2]);
                    return gru_flirts[GruF * 2];
                }
                else
                {
                    SetChoicesActive();
                    TextA.text = gru_choices[GruF * 3];
                    TextB.text = gru_choices[GruF * 3 + 1];
                    TextC.text = gru_choices[GruF * 3 + 2];
                    spriteChanger.ChangingSprites(gru_flirts_faces[GruF * 2 + 1]);
                    return gru_flirts[GruF * 2 + 1];
                }
            }
            else if (NPC == "Fenris")
            {
                if (lovelevel == 5) { spriteChanger.ChangingSprites(fenris_nothingtosay_faces[rand]); return fenris_nothingtosay[rand]; }
                currentConversationLength = 1;
                if (i == 0)
                {
                    if (FenrisF >= 14)
                    {
                        currentConversationLength = 0;
                        spriteChanger.ChangingSprites(fenris_nothingtosay_faces[rand]);
                        if (lovelevel == 0)
                        {
                            return "???: ...";
                        }
                        return fenris_nothingtosay[rand];
                    }
                    FenrisF++;
                    spriteChanger.ChangingSprites(fenris_flirts_faces[FenrisF * 2]);
                    return fenris_flirts[FenrisF * 2];
                }
                else
                {
                    SetChoicesActive();
                    TextA.text = fenris_choices[FenrisF * 3];
                    TextB.text = fenris_choices[FenrisF * 3 + 1];
                    TextC.text = fenris_choices[FenrisF * 3 + 2];
                    spriteChanger.ChangingSprites(fenris_flirts_faces[FenrisF * 2 + 1]);
                    return fenris_flirts[FenrisF * 2 + 1];
                }
            }
            else if (NPC == "Catherine")
            {
                if (lovelevel == 5) { spriteChanger.ChangingSprites(catherine_nothingtosay_faces[rand]); return catherine_nothingtosay[rand]; }
                currentConversationLength = 1;
                if (i == 0)
                {
                    if (CatherineF >= 14)
                    {
                        currentConversationLength = 0;
                        spriteChanger.ChangingSprites(catherine_nothingtosay_faces[rand]);
                        if (lovelevel == 0)
                        {
                            return "???: Thou silence sy golden";
                        }
                        return catherine_nothingtosay[rand];
                    }
                    CatherineF++;
                    spriteChanger.ChangingSprites(catherine_flirts_faces[CatherineF * 2]);
                    return catherine_flirts[CatherineF * 2];
                }
                else
                {
                    SetChoicesActive();
                    TextA.text = catherine_choices[CatherineF * 3];
                    TextB.text = catherine_choices[CatherineF * 3 + 1];
                    TextC.text = catherine_choices[CatherineF * 3 + 2];
                    spriteChanger.ChangingSprites(catherine_flirts_faces[CatherineF * 2 + 1]);
                    return catherine_flirts[CatherineF * 2 + 1];
                }
            }
            else if (NPC == "Bobo")
            {
                if (lovelevel == 5) { spriteChanger.ChangingSprites(bobo_nothingtosay_faces[rand]); return bobo_nothingtosay[rand]; }
                currentConversationLength = 1;
                if (i == 0)
                {
                    if (BoboF >= 14)
                    {
                        currentConversationLength = 0;
                        spriteChanger.ChangingSprites(bobo_nothingtosay_faces[rand]);
                        if (lovelevel == 0)
                        {
                            return "???: Leave me be.";
                        }
                        return bobo_nothingtosay[rand];
                    }
                    BoboF++;
                    spriteChanger.ChangingSprites(bobo_flirts_faces[BoboF * 2]);
                    return bobo_flirts[BoboF * 2];
                }
                else
                {
                    SetChoicesActive();
                    TextA.text = bobo_choices[BoboF * 3];
                    TextB.text = bobo_choices[BoboF * 3 + 1];
                    TextC.text = bobo_choices[BoboF * 3 + 2];
                    spriteChanger.ChangingSprites(bobo_flirts_faces[BoboF * 2 + 1]);
                    return bobo_flirts[BoboF * 2 + 1];
                }
            }
            else if (NPC == "Therion")
            {
                if (lovelevel == 5) { spriteChanger.ChangingSprites(therion_nothingtosay_faces[rand]); return therion_nothingtosay[rand]; }
                currentConversationLength = 1;
                if (i == 0)
                {
                    if (TherionF >= 14)
                    {
                        currentConversationLength = 0;
                        spriteChanger.ChangingSprites(therion_nothingtosay_faces[rand]);
                        if (lovelevel == 0)
                        {
                            return "???: Uh, bye?";
                        }
                        return therion_nothingtosay[rand];
                    }
                    TherionF++;
                    spriteChanger.ChangingSprites(therion_flirts_faces[TherionF * 2]);
                    return therion_flirts[TherionF * 2];
                }
                else
                {
                    SetChoicesActive();
                    TextA.text = therion_choices[TherionF * 3];
                    TextB.text = therion_choices[TherionF * 3 + 1];
                    TextC.text = therion_choices[TherionF * 3 + 2];
                    spriteChanger.ChangingSprites(therion_flirts_faces[TherionF * 2 + 1]);
                    return therion_flirts[TherionF * 2 + 1];
                }
            }
            return "Error from flirting";
        }
        else if (buttonName == "Gift") //if gift is pressed
        {
            currentConversationLength = 0;
            if (i == 0)
            {
                return "(Choose an item to give)";
                //Open inventory and click an item
            }                                            
            return "Error from gifts";
        }
        else if (buttonName == "Quest") //if quests is pressed
        {
            if (NPC == "Yola") {
                if (YolaQuestOngoing && InventoryManager.Instance.playerInventory.SearchItem(yola_questitems[YolaQUEST], yola_questitems_amount[YolaQUEST]))
                {
                    YolaQuestOngoing = false;
                    YolaScript.nextlevel++;
                    spriteChanger.ChangingSprites(yola_quests_faces[lovelevel - 1]);
                    return yola_quests[lovelevel - 1];
                }
                else if (YolaQuestOngoing && !InventoryManager.Instance.playerInventory.SearchItem(yola_questitems[YolaQUEST], yola_questitems_amount[YolaQUEST])) { spriteChanger.ChangingSprites(yola_quests_faces[1]); return "Yola: Yola isn't pleased until you gat me what I want."; }
                if (lovelevel == 0 || lovelevel == 5 || YolaQUEST >= 9) { spriteChanger.ChangingSprites(yola_quests_faces[1]); return "Yola: Yola has no quest for you."; }
                else if (!YolaQuestOngoing)
                {
                    YolaQUEST++;
                    YolaQuestOngoing = true;
                    spriteChanger.ChangingSprites(yola_questdialogue_faces[YolaQUEST]);
                    return yola_questdialogue[YolaQUEST];
                }
            }
            else if (NPC == "Gru")
            {
                if(GruQuestOngoing && InventoryManager.Instance.playerInventory.SearchItem(gru_questitems[GruQUEST], gru_questitems_amount[GruQUEST]))
                {
                    GruQuestOngoing = false;
                    GruScript.nextlevel++;
                    spriteChanger.ChangingSprites(gru_quests_faces[lovelevel-1]);
                    return gru_quests[lovelevel-1];
                }
                else if (GruQuestOngoing&& !InventoryManager.Instance.playerInventory.SearchItem(gru_questitems[GruQUEST], gru_questitems_amount[GruQUEST])) { spriteChanger.ChangingSprites(gru_quests_faces[1]); return "Gru: YOU NO HAVE WHAT GRU WANT!"; }
                if (lovelevel == 0)
                {
                    return "???: UUURRRGGGHH!!! NO QUEST!";
                }
                else if (lovelevel == 5 || GruQUEST >= 9) { spriteChanger.ChangingSprites(gru_quests_faces[1]); return "Gru: Gru no have quest now!"; }
                else if (!GruQuestOngoing)
                {
                    GruQUEST++;
                    GruQuestOngoing = true;
                    spriteChanger.ChangingSprites(gru_questdialogue_faces[GruQUEST]);
                    return gru_questdialogue[GruQUEST];
                }
            }
            else if (NPC == "Fenris")
            {
                if(FenrisQuestOngoing && InventoryManager.Instance.playerInventory.SearchItem(fenris_questitems[FenrisQUEST], fenris_questitems_amount[FenrisQUEST]))
                {
                    FenrisQuestOngoing = false;
                    FenrisScript.nextlevel++;
                    spriteChanger.ChangingSprites(fenris_quests_faces[lovelevel-1]);
                    return fenris_quests[lovelevel-1];
                }
                else if (FenrisQuestOngoing && !InventoryManager.Instance.playerInventory.SearchItem(fenris_questitems[FenrisQUEST], fenris_questitems_amount[FenrisQUEST])) { spriteChanger.ChangingSprites(fenris_quests_faces[1]); return "Fenris: Come back when you have what I want."; }
                if (lovelevel == 0)
                {
                    return "???: I don't need anything from you. Leave!";
                }
                else if (lovelevel == 5 || FenrisQUEST >= 9) { spriteChanger.ChangingSprites(fenris_quests_faces[1]); return "Fenris: I have nothing for you now."; }
                else if (!FenrisQuestOngoing)
                {
                    FenrisQUEST++;
                    FenrisQuestOngoing = true;
                    spriteChanger.ChangingSprites(fenris_questdialogue_faces[FenrisQUEST]);
                    return fenris_questdialogue[FenrisQUEST];
                }
            }
            else if (NPC == "Catherine")
            {
                if(CatherineQuestOngoing && InventoryManager.Instance.playerInventory.SearchItem(catherine_questitems[CatherineQUEST], catherine_questitems_amount[CatherineQUEST]))
                {
                    CatherineQuestOngoing = false;
                    CatherineScript.nextlevel++;
                    spriteChanger.ChangingSprites(catherine_quests_faces[lovelevel-1]);
                    return catherine_quests[lovelevel-1];
                }
                else if (CatherineQuestOngoing && !InventoryManager.Instance.playerInventory.SearchItem(catherine_questitems[CatherineQUEST], catherine_questitems_amount[CatherineQUEST])) { spriteChanger.ChangingSprites(catherine_quests_faces[1]); return "Catherine: Thou hast not found whatever I want."; }
                if (lovelevel == 0)
                {
                    return "???: I hath nothing to give thee.";
                }
                else if (lovelevel == 5 || CatherineQUEST >= 9) { spriteChanger.ChangingSprites(catherine_quests_faces[1]); return "Catherine: I hath nay quest for thee."; }
                else if (!CatherineQuestOngoing)
                {
                    CatherineQUEST++;
                    CatherineQuestOngoing = true;
                    spriteChanger.ChangingSprites(catherine_questdialogue_faces[CatherineQUEST]);
                    return catherine_questdialogue[CatherineQUEST];
                }
            }
            else if (NPC == "Bobo")
            {
                if(BoboQuestOngoing && InventoryManager.Instance.playerInventory.SearchItem(bobo_questitems[BoboQUEST], bobo_questitems_amount[BoboQUEST]))
                {
                    BoboQuestOngoing = false;
                    BoboScript.nextlevel++;
                    spriteChanger.ChangingSprites(bobo_quests_faces[lovelevel-1]);
                    return bobo_quests[lovelevel-1];
                }
                else if (BoboQuestOngoing && !InventoryManager.Instance.playerInventory.SearchItem(bobo_questitems[BoboQUEST], bobo_questitems_amount[BoboQUEST])) { spriteChanger.ChangingSprites(bobo_quests_faces[1]); return "Bobo: You do no have what I requested for."; }
                if (lovelevel == 0)
                {
                    return "???: I wouldn't trust you with the simplest of errands. Just go away!";
                }
                else if (lovelevel == 5 || BoboQUEST >= 9) { spriteChanger.ChangingSprites(bobo_quests_faces[1]); return "Bobo: No quests for you."; }
                else if (!BoboQuestOngoing)
                {
                    BoboQUEST++;
                    BoboQuestOngoing = true;
                    spriteChanger.ChangingSprites(bobo_questdialogue_faces[BoboQUEST]);
                    return bobo_questdialogue[BoboQUEST];
                }
            }
            else if (NPC == "Therion")
            {
                if(TherionQuestOngoing && InventoryManager.Instance.playerInventory.SearchItem(therion_questitems[TherionQUEST], therion_questitems_amount[TherionQUEST]))
                {
                    TherionQuestOngoing = false;
                    TherionScript.nextlevel++;
                    spriteChanger.ChangingSprites(therion_quests_faces[lovelevel-1]);
                    return therion_quests[lovelevel-1];
                }
                else if (TherionQuestOngoing && !InventoryManager.Instance.playerInventory.SearchItem(therion_questitems[TherionQUEST], therion_questitems_amount[TherionQUEST])) { spriteChanger.ChangingSprites(therion_quests_faces[1]); return "Therion: Ye don't have what ay need."; }
                if (lovelevel ==0)
                {
                    return "???: Off you go mate, nothing to see here.";
                }
                else if (lovelevel == 5||TherionQUEST>=9) { spriteChanger.ChangingSprites(therion_quests_faces[1]); return "Therion: Nuthin' fer ye naw."; }
                else if (!TherionQuestOngoing)
                {
                    TherionQUEST++;
                    TherionQuestOngoing = true;
                    spriteChanger.ChangingSprites(therion_questdialogue_faces[TherionQUEST]);
                    return therion_questdialogue[TherionQUEST];
                }
            }
            return "Error from quests";
        }
        else if (buttonName == "Bye") //if bye is pressed
        {
            saidBye = true;
            if (NPC == "Yola") { spriteChanger.ChangingSprites(yola_byes_faces[lovelevel]); return yola_byes[lovelevel]; }
            else if (NPC == "Gru") { spriteChanger.ChangingSprites(gru_byes_faces[lovelevel]); return gru_byes[lovelevel]; }
            else if (NPC == "Fenris") { spriteChanger.ChangingSprites(fenris_byes_faces[lovelevel]); return fenris_byes[lovelevel]; }
            else if (NPC == "Catherine") { spriteChanger.ChangingSprites(catherine_byes_faces[lovelevel]); return catherine_byes[lovelevel]; }
            else if (NPC == "Bobo") { spriteChanger.ChangingSprites(bobo_byes_faces[lovelevel]); return bobo_byes[lovelevel]; }
            else if (NPC == "Therion") { spriteChanger.ChangingSprites(therion_byes_faces[lovelevel]); return therion_byes[lovelevel]; }
            return "Error from saying bye";
        }
        else if (buttonName == "Rumors")
        {
            popeTips++;
            if (NPC=="Shopkeeper")
            {
                spriteChanger.ChangingSprites(shopkeeper_rumors_faces[popeTips % shopkeeper_rumors.Count]);
                return shopkeeper_rumors[popeTips % shopkeeper_rumors.Count];
            }
            if (NPC == "Innkeeper")
            {
                spriteChanger.ChangingSprites(innkeeper_rumors_faces[popeTips % innkeeper_rumors.Count]);
                return innkeeper_rumors[popeTips % innkeeper_rumors.Count];
            }
            return "Error from rumors";
        }
        else if (buttonName == "Buy")
        {
            currentConversationLength = 1;
            if (NPC == "Shopkeeper")
            {
                if (i > 0)
                {
                    InventoryManager.Instance.Shop.ShopInventories.StartCoroutine(InventoryManager.Instance.Shop.ShopInventories.StartShopping());
                    spriteChanger.ChangingSprites(shopkeeper_buy_faces[1]);
                    return shopkeeper_buy[1];
                }
                spriteChanger.ChangingSprites(shopkeeper_buy_faces[0]);
                return shopkeeper_buy[0];
            }
            if (NPC == "Innkeeper")
            {
                if (i > 0)
                {
                    InventoryManager.Instance.Shop.ShopInventories.StartCoroutine(InventoryManager.Instance.Shop.ShopInventories.StartShopping());
                    spriteChanger.ChangingSprites(innkeeper_buy_faces[1]);
                    return innkeeper_buy[1];
                }
                spriteChanger.ChangingSprites(innkeeper_buy_faces[0]);
                return innkeeper_buy[0];
            }
            return "Error from buying";
        }
        else if (buttonName == "Sell")
        {
            currentConversationLength = 1;
            if (NPC == "Shopkeeper")
            {
                if (i > 0)
                {
                    InventoryManager.Instance.Shop.ShopInventories.StartCoroutine(InventoryManager.Instance.Shop.ShopInventories.StartShopping());
                    spriteChanger.ChangingSprites(shopkeeper_sell_faces[1]);
                    return shopkeeper_sell[1];
                }
                spriteChanger.ChangingSprites(shopkeeper_sell_faces[0]);
                return shopkeeper_sell[0];
            }
            if (NPC == "Innkeeper")
            {
                if (i > 0)
                {
                    InventoryManager.Instance.Shop.ShopInventories.StartCoroutine(InventoryManager.Instance.Shop.ShopInventories.StartShopping());
                    spriteChanger.ChangingSprites(innkeeper_sell_faces[1]);
                    return innkeeper_sell[1];
                }
                spriteChanger.ChangingSprites(innkeeper_sell_faces[0]);
                return innkeeper_sell[0];
            }
            return "Error from selling";
        }
        else if (buttonName == "ByeShop")
        {
            saidBye = true;
            if (NPC == "Shopkeeper")
            {
                return "Shopkeeper: I hope to see your purse again soon!";
            }
            if (NPC == "Innkeeper")
            {
                return "Innkeeper: You know where to find the best beverages when you get thirsty!";
            }
            return "Error from byeshop";
        }
        else //Error message
        {
            Debug.Log(NPC);
            currentConversationLength = 0;
            return "This is a error from Getlinesbutton";
        }
    }
    public string GetLinesLevelUp(string name, int lovelevel)
    {
        i++;
        if(name == "Yola")
        {
            currentConversationLength = yola_levelLists[lovelevel-1].Count - 1;
            spriteChanger.ChangingSprites(yola_levelLists_faces[lovelevel-1][i]);
            return yola_levelLists[lovelevel-1][i];
        }
        if (name == "Gru")
        {
            currentConversationLength = gru_levelLists[lovelevel - 1].Count - 1;
            spriteChanger.ChangingSprites(gru_levelLists_faces[lovelevel - 1][i]);
            return gru_levelLists[lovelevel - 1][i];
        }
        if (name == "Fenris")
        {
            currentConversationLength = fenris_levelLists[lovelevel - 1].Count - 1;
            spriteChanger.ChangingSprites(fenris_levelLists_faces[lovelevel - 1][i]);
            return fenris_levelLists[lovelevel - 1][i];
        }
        if (name == "Catherine")
        {
            currentConversationLength = catherine_levelLists[lovelevel - 1].Count - 1;
            spriteChanger.ChangingSprites(catherine_levelLists_faces[lovelevel - 1][i]);
            return catherine_levelLists[lovelevel - 1][i];
        }
        if (name == "Bobo")
        {
            currentConversationLength = bobo_levelLists[lovelevel - 1].Count - 1;
            spriteChanger.ChangingSprites(bobo_levelLists_faces[lovelevel - 1][i]);
            return bobo_levelLists[lovelevel - 1][i];
        }
        if (name == "Therion")
        {
            currentConversationLength = therion_levelLists[lovelevel - 1].Count - 1;
            spriteChanger.ChangingSprites(therion_levelLists_faces[lovelevel - 1][i]);
            return therion_levelLists[lovelevel - 1][i];
        }
        currentConversationLength = 0;
        return "This is an error from GetLinesLevelUp";
    }

    public string GetLinesHate(string name)
    {
        i++;
        currentConversationLength = 0;
        if (name == "Yola") { spriteChanger.ChangingSprites(yola_hatelevel_faces[1]); return yola_hatelevel[1]; }
        if (name == "Gru") { spriteChanger.ChangingSprites(gru_hatelevel_faces[1]); return gru_hatelevel[1]; }
        if (name == "Fenris") { spriteChanger.ChangingSprites(fenris_hatelevel_faces[1]); return fenris_hatelevel[1]; }
        if (name == "Catherine") { spriteChanger.ChangingSprites(catherine_hatelevel_faces[1]); return catherine_hatelevel[1]; }
        if (name == "Bobo") { spriteChanger.ChangingSprites(bobo_hatelevel_faces[1]); return bobo_hatelevel[1]; }
        if (name == "Therion") { spriteChanger.ChangingSprites(therion_hatelevel_faces[1]); return therion_hatelevel[1]; }
        else return "Error from hate";
    }

    public string GetLinesHateGreeting(string name)
    {
        i++;
        currentConversationLength = 0;
        if (name == "Yola") { spriteChanger.ChangingSprites(yola_hatelevel_faces[0]); return yola_hatelevel[0]; }
        if (name == "Gru") { spriteChanger.ChangingSprites(gru_hatelevel_faces[0]); return gru_hatelevel[0]; }
        if (name == "Fenris") { spriteChanger.ChangingSprites(fenris_hatelevel_faces[0]); return fenris_hatelevel[0]; }
        if (name == "Catherine") { spriteChanger.ChangingSprites(catherine_hatelevel_faces[0]); return catherine_hatelevel[0]; }
        if (name == "Bobo") { spriteChanger.ChangingSprites(bobo_hatelevel_faces[0]); return bobo_hatelevel[0]; }
        if (name == "Therion") { spriteChanger.ChangingSprites(therion_hatelevel_faces[0]); return therion_hatelevel[0]; }
        else return "Error from hate";
    }

    //FUNCTIONS FOR EACH CHARACTER
    //////////
    ///YOLA///
    //////////
    string YolaLogic(int no, int lovelevel, bool first)
    {
        //Happens if first conversation
        if (first && tutorialPlayed)
        {
            currentConversationLength = yola_first.Count - 1;
            spriteChanger.ChangingSprites(yola_first_faces[i]);
            return yola_first[i];
        }
        else if (tutorialPlayed)
        {
            currentConversationLength = 0;
            popeB.pope.SetLoverButtonsActive();
            spriteChanger.ChangingSprites(yola_greetings_faces[lovelevel]);
            return yola_greetings[lovelevel];
        }
        else
        {
            spriteChanger.ChangingSprites(22);
            return "???: What are you doing in the swamp?! Go see the pope you silly little thing!";
        }
    }
    //////////
    ///BOBO///
    //////////
    string BoboLogic(int no, int lovelevel, bool first)
    {
        //Happens if first conversation
        if (first && tutorialPlayed)
        {
            currentConversationLength = bobo_first.Count - 1;
            spriteChanger.ChangingSprites(bobo_first_faces[i]);
            return bobo_first[i];
        }
        else if (tutorialPlayed)
        {
            currentConversationLength = 0;
            popeB.pope.SetLoverButtonsActive();
            spriteChanger.ChangingSprites(bobo_greetings_faces[lovelevel]);
            return bobo_greetings[lovelevel];
        }
        else
        {
            spriteChanger.ChangingSprites(bobo_greetings_faces[lovelevel]);
            return "???: Pope is the one to help your miserable little soul.";
        }
    }
    /////////////
    ///THERION///
    /////////////
    string TherionLogic(int no, int lovelevel, bool first)
    {
        //Happens if first conversation
        if (first && tutorialPlayed)
        {
            currentConversationLength = therion_first.Count - 1;
            spriteChanger.ChangingSprites(therion_first_faces[i]);
            return therion_first[i];
        }
        else if (tutorialPlayed)
        {
            currentConversationLength = 0;
            popeB.pope.SetLoverButtonsActive();
            spriteChanger.ChangingSprites(therion_greetings_faces[lovelevel]);
            return therion_greetings[lovelevel];
        }
        else
        {
            spriteChanger.ChangingSprites(therion_greetings_faces[lovelevel]);
            return "*He seems too busy drinking beer to pay notice to you*";
        }
    }
    ///////////////
    ///CATHERINE///
    ///////////////
    string CatherineLogic(int no, int lovelevel, bool first)
    {
        //Happens if first conversation
        if (first && tutorialPlayed)
        {
            currentConversationLength = catherine_first.Count - 1;
            spriteChanger.ChangingSprites(catherine_first_faces[i]);
            return catherine_first[i];
        }
        else if (tutorialPlayed)
        {
            Debug.Log("Catherine activeted buttons");
            currentConversationLength = 0;
            popeB.pope.SetLoverButtonsActive();
            spriteChanger.ChangingSprites(catherine_greetings_faces[lovelevel]);
            return catherine_greetings[lovelevel];
        }
        else
        {
            spriteChanger.ChangingSprites(23);
            return "???: Oh, strang'r! Thee shouldst wend seeth the pope!";
        }
    }
    ////////////
    ///FENRIS///
    ////////////
    string FenrisLogic(int no, int lovelevel, bool first)
    {
        //Happens if first conversation
        if (first && tutorialPlayed)
        {
            currentConversationLength = fenris_first.Count - 1;
            spriteChanger.ChangingSprites(fenris_first_faces[i]);
            return fenris_first[i];
        }
        else if (tutorialPlayed)
        {
            Debug.Log("Fenris activeted buttons");
            currentConversationLength = 0;
            popeB.pope.SetLoverButtonsActive();
            spriteChanger.ChangingSprites(fenris_greetings_faces[lovelevel]);
            return fenris_greetings[lovelevel];
        }
        else
        {
            spriteChanger.ChangingSprites(fenris_greetings_faces[lovelevel]);
            return "???: I can’t help you. Go see the pope if you need guidance...";
        }
    }
    /////////
    ///GRU///
    /////////
    string GruLogic(int no, int lovelevel, bool first)
    {
        //Happens if first conversation
        if (first && tutorialPlayed)
        {
            currentConversationLength = gru_first.Count - 1;
            spriteChanger.ChangingSprites(gru_first_faces[i]);
            return gru_first[i];
        }
        else if (tutorialPlayed)
        {
            Debug.Log("Gru activeted buttons");
            currentConversationLength = 0;
            popeB.pope.SetLoverButtonsActive();
            spriteChanger.ChangingSprites(gru_greetings_faces[lovelevel]);
            return gru_greetings[lovelevel];
        }
        else
        {
            spriteChanger.ChangingSprites(20);
            return "???: GGRRRUUUUHH! GO AWAY! GO TO POPE! GRRRUUUH!";
        }
    }

    //////////
    ///POPE///
    //////////
    string PopeLogic(int number)
    {
        if (!tutorialPlayed)
        {
            currentConversationLength = pope_tutorial.Count - 1;
            if (i == currentConversationLength)
            {
                tutorialPlayed = true;
            }
            spriteChanger.ChangingSprites(pope_tutorial_faces[i]);
            return pope_tutorial[i];
        }
        else
        {
            Debug.Log("Set Pope button set active");
            popeB.SetPopeButtonsActive();
            spriteChanger.ChangingSprites(pope_greeting_faces[number]);
            return pope_greeting[number];
        }
    }
    ///////////////
    ///INNKEEPER///
    ///////////////
    string InnkeeperLogic(int number)
    {
        if (tutorialPlayed)
        {
            popeB.pope.SetShopButtonsActive();
            spriteChanger.ChangingSprites(innkeeper_greeting_faces[number]);
            return innkeeper_greeting[number];
        }
  
        else {
            spriteChanger.ChangingSprites(innkeeper_greeting_faces[number]);
            return "Innkeeper: Hey there luv, I don’t think we’ve met! My name is Shazura and this here is my lovely establishment! You should reaaally go to meet the Pope first though, he knows who’s who and what’s what.";
        }
    }
                

    ////////////////
    ///SHOPKEEPER///
    ////////////////
    string ShopkeeperLogic(int number)
    {
        if (tutorialPlayed)
        {
            popeB.pope.SetShopButtonsActive();
            spriteChanger.ChangingSprites(shopkeeper_greeting_faces[number]);
            return shopkeeper_greeting[number];
        }
        else {
            spriteChanger.ChangingSprites(shopkeeper_greeting_faces[number]);
            return "Shopkeeper: Hey there stranger. It must have been fate that lead you to *my* store! I’ve got all kinds of items of interest, artifacts of lost histories, relics of…. you look confused. Have you seen the Pope? He can set your head on straight, dear.";
        }
    }

    //OTHER FUNCTIONS
    //
    //Returns the list iterator back to the beginnig once conversation ends;
    public void ReturnIteratorToTheBeginning()
    {
        i = -1;
    }
    //Sets choices active/inactive
   public void SetChoicesActive()
    {
        popeB.pope.A.gameObject.SetActive(true);
        popeB.pope.B.gameObject.SetActive(true);
        popeB.pope.C.gameObject.SetActive(true);
    }
    public void SetChoicesInactive()
    {
        popeB.pope.A.gameObject.SetActive(false);
        popeB.pope.B.gameObject.SetActive(false);
        popeB.pope.C.gameObject.SetActive(false);
    }

    //Checks if choice was correct
    void choiceMade(int number)
    {
        choiceNumber=number;
    }

    public void SetItemID(string id)
    {
        itemID = id;
    }

}
