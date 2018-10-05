using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChange : MonoBehaviour {

    public int rightSprite;
    public int leftSprite;

    Image GrandmaDefault;       //0
    Image GuardDefault;         //1
    Image HorrorDefault;        //2
    Image PopeDefault;          //3
    Image InnkeeperDefault;     //4
    Image ShopkeeperDefault;    //5
    Image BoboDefault;          //6
    Image TherionDefault;       //7
    Image FenrisDefault;        //8
    Image CatherineDefault;     //9
    Image GruDefault;           //10
    Image YolaDefault;          //11
    Image GhoulDefault;         //12
    Image GhoulFlirty;          //13
    Image GhoulCrossed;         //14
    Image InnkeeperHappy;       //15
    Image InnkeeperAngry;       //16
    Image ShopkeeperHappy;      //17
    Image ShopkeeperAngry;      //18
    Image GruHappy;             //19
    Image GruAngry;             //20
    Image YolaHappy;            //21
    Image YolaAngry;            //22
    Image CatherineHappy;       //23
    Image CatherineAngry;       //24
    Image FenrisHappy;          //25
    Image FenrisAngry;          //26
    Image BoboHappy;            //27
    Image BoboAngry;            //28
    Image TherionHappy;         //29
    Image TherionAngry;         //30


    List<Image> spriteList = new List<Image>();
   
	void Start () {

        rightSprite = 0;
        leftSprite = 12;

        GrandmaDefault = GameObject.Find("GrandmaDefault").GetComponent<Image>();
        GuardDefault = GameObject.Find("GuardDefault").GetComponent<Image>();
        HorrorDefault = GameObject.Find("HorrorDefault").GetComponent<Image>();
        PopeDefault = GameObject.Find("PopeDefault").GetComponent<Image>();
        InnkeeperDefault = GameObject.Find("InnkeeperDefault").GetComponent<Image>();
        ShopkeeperDefault = GameObject.Find("ShopkeeperDefault").GetComponent<Image>();
        BoboDefault = GameObject.Find("BoboDefault").GetComponent<Image>();
        TherionDefault = GameObject.Find("TherionDefault").GetComponent<Image>();
        FenrisDefault = GameObject.Find("FenrisDefault").GetComponent<Image>();
        CatherineDefault = GameObject.Find("CatherineDefault").GetComponent<Image>();
        GruDefault = GameObject.Find("GruDefault").GetComponent<Image>();
        YolaDefault = GameObject.Find("YolaDefault").GetComponent<Image>();
        GhoulDefault = GameObject.Find("GhoulDefault").GetComponent<Image>();
        GhoulFlirty = GameObject.Find("GhoulFlirty").GetComponent<Image>();
        GhoulCrossed = GameObject.Find("GhoulCrossed").GetComponent<Image>();
        InnkeeperHappy = GameObject.Find("InnkeeperHappy").GetComponent<Image>();
        InnkeeperAngry = GameObject.Find("InnkeeperAngry").GetComponent<Image>();
        ShopkeeperHappy = GameObject.Find("ShopkeeperHappy").GetComponent<Image>();
        ShopkeeperAngry = GameObject.Find("ShopkeeperAngry").GetComponent<Image>();
        GruHappy = GameObject.Find("GruHappy").GetComponent<Image>();
        GruAngry = GameObject.Find("GruAngry").GetComponent<Image>();
        YolaHappy = GameObject.Find("YolaHappy").GetComponent<Image>();
        YolaAngry = GameObject.Find("YolaAngry").GetComponent<Image>();
        CatherineHappy = GameObject.Find("CatherineHappy").GetComponent<Image>();
        CatherineAngry = GameObject.Find("CatherineAngry").GetComponent<Image>();
        FenrisHappy = GameObject.Find("FenrisHappy").GetComponent<Image>();
        FenrisAngry = GameObject.Find("FenrisAngry").GetComponent<Image>();
        BoboHappy = GameObject.Find("BoboHappy").GetComponent<Image>();
        BoboAngry = GameObject.Find("BoboAngry").GetComponent<Image>();
        TherionHappy = GameObject.Find("TherionHappy").GetComponent<Image>();
        TherionAngry = GameObject.Find("TherionAngry").GetComponent<Image>();

        spriteList.Add(GrandmaDefault);
        spriteList.Add(GuardDefault);
        spriteList.Add(HorrorDefault);
        spriteList.Add(PopeDefault);
        spriteList.Add(InnkeeperDefault);
        spriteList.Add(ShopkeeperDefault);
        spriteList.Add(BoboDefault);
        spriteList.Add(TherionDefault);
        spriteList.Add(FenrisDefault);
        spriteList.Add(CatherineDefault);
        spriteList.Add(GruDefault);
        spriteList.Add(YolaDefault);
        spriteList.Add(GhoulDefault);
        spriteList.Add(GhoulFlirty);
        spriteList.Add(GhoulCrossed);
        spriteList.Add(InnkeeperHappy);
        spriteList.Add(InnkeeperAngry);
        spriteList.Add(ShopkeeperHappy);
        spriteList.Add(ShopkeeperAngry);
        spriteList.Add(GruHappy);
        spriteList.Add(GruAngry);
        spriteList.Add(YolaHappy);
        spriteList.Add(YolaAngry);
        spriteList.Add(CatherineHappy);
        spriteList.Add(CatherineAngry);
        spriteList.Add(FenrisHappy);
        spriteList.Add(FenrisAngry);
        spriteList.Add(BoboHappy);
        spriteList.Add(BoboAngry);
        spriteList.Add(TherionHappy);
        spriteList.Add(TherionAngry);

        DisableEverything();
    }

    public void ChangingSprites(int id)
    {
        if (id == 12 || id == 13 || id == 14) { leftSprite = id; }
        else { rightSprite = id; }
        DisableEverything();
        spriteList[leftSprite].gameObject.SetActive(true);
        spriteList[rightSprite].gameObject.SetActive(true);
        if (id == 12 || id == 13 || id == 14)
        {
            Color c = spriteList[rightSprite].gameObject.GetComponent<Image>().color;
            c.a=0.8f;
            spriteList[rightSprite].gameObject.GetComponent<Image>().color = c;
            Color b = spriteList[leftSprite].gameObject.GetComponent<Image>().color;
            b.a = 1f;
            spriteList[leftSprite].gameObject.GetComponent<Image>().color = b;
        }
        else
        {
            Color c = spriteList[leftSprite].gameObject.GetComponent<Image>().color;
            c.a = 0.8f;
            spriteList[leftSprite].gameObject.GetComponent<Image>().color = c;
            Color b = spriteList[rightSprite].gameObject.GetComponent<Image>().color;
            b.a = 1f;
            spriteList[rightSprite].gameObject.GetComponent<Image>().color = b;
        }
    }
    public void DisableEverything() {
        foreach (Image i in spriteList)
        {
            i.gameObject.SetActive(false);
        }
    }
}
