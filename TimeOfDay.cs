using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Collections;

public class TimeOfDay : MonoBehaviour
{
    [SerializeField]
    Text clockfield;
    float minuteFloat = 0;
    public int hourInt = 9, minuteInt = 0;
    [SerializeField]
    float timeSpeed;
    [SerializeField]
    GameObject nightfilter, savingpanel, player, passout, fader, sleeping;
    public Loading load;
    Animator anim;
    bool isFading = false;

    void Start()
    {
        load = new Loading();
        anim = GetComponent<Animator>();
        clockfield.text = "09:00";
    }


    void Update()
    {
        minuteFloat += (Time.deltaTime * timeSpeed);

        if (minuteFloat >= 60f)
        {
            minuteFloat -= 60f;
            hourInt += 1;
        }
        if (hourInt >= 24)
        {
            hourInt -= 24;
        }
        minuteInt = ((int)((float)((int)minuteFloat) / 10)) * 10;

        nightSky();
        printClock();

        /*if (hourInt >= 2 && hourInt <= 6)
        { 
            StartCoroutine(passingOut());
        }*/

    }

   /* public IEnumerator passingOut()
    {
        fader.GetComponent<Image>().color = Color.Lerp(fader.GetComponent<Image>().color, Color.black, 1f * Time.deltaTime);
        player.GetComponent<PlayerMovement>().HandleMovement(Vector2.zero);
        player.GetComponent<PlayerMovement>().enabled = false;
        passout.SetActive(true);
        yield return new WaitForSeconds(6);
        player.GetComponent<PlayerHealth>().currentHealth = 50;
        load.load = 6;
        string jsonData = JsonUtility.ToJson(load, true);
        File.WriteAllText(Application.persistentDataPath + "/load.json", jsonData);
        savingpanel.GetComponent<Save_manager>().onSave(6);
        SceneManager.LoadScene(2);
    }
    */

    public IEnumerator endDay()
    {
        
        player.GetComponent<PlayerMovement>().HandleMovement(Vector2.zero);
        player.GetComponent<PlayerMovement>().enabled = false;
        sleeping.SetActive(true);
        yield return new WaitForSeconds(6);
        load.load = 6;
        string jsonData = JsonUtility.ToJson(load, true);
        File.WriteAllText(Application.persistentDataPath + "/load.json", jsonData);
        savingpanel.GetComponent<Save_manager>().onSave(6);
        SceneManager.LoadScene(2);
    }
    

    void nightSky()
    {
        if (hourInt < 18 && hourInt >= 6)
        {
            nightfilter.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 0.0f);
        }
        else if (hourInt == 18)
        {
            switch (minuteInt)
            {
                case 0:
                    nightfilter.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 0.05f);
                    break;
                case 10:
                    nightfilter.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 0.1f);
                    break;
                case 20:
                    nightfilter.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 0.15f);
                    break;
                case 30:
                    nightfilter.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 0.2f);
                    break;
                case 40:
                    nightfilter.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 0.25f);
                    break;
                case 50:
                    nightfilter.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 0.3f);
                    break;
            }
        }
        else if (hourInt == 19)
        {
            switch (minuteInt)
            {
                case 0:
                    nightfilter.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 0.35f);
                    break;
                case 10:
                    nightfilter.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 0.4f);
                    break;
                case 20:
                    nightfilter.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 0.45f);
                    break;
                case 30:
                    nightfilter.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 0.5f);
                    break;
                case 40:
                    nightfilter.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 0.55f);
                    break;
                case 50:
                    nightfilter.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 0.6f);
                    break;
            }
        }
        else if (hourInt >= 20 || hourInt < 4)
        {
            nightfilter.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 0.65f);
        }

        else if (hourInt == 4)
        {
            switch (minuteInt)
            {
                case 0:
                    nightfilter.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 0.6f);
                    break;
                case 10:
                    nightfilter.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 0.55f);
                    break;
                case 20:
                    nightfilter.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 0.5f);
                    break;
                case 30:
                    nightfilter.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 0.45f);
                    break;
                case 40:
                    nightfilter.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 0.4f);
                    break;
                case 50:
                    nightfilter.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 0.35f);
                    break;
            }
        }

        else if (hourInt == 5)
        {
            switch (minuteInt)
            {
                case 0:
                    nightfilter.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 0.3f);
                    break;
                case 10:
                    nightfilter.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 0.25f);
                    break;
                case 20:
                    nightfilter.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 0.2f);
                    break;
                case 30:
                    nightfilter.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 0.15f);
                    break;
                case 40:
                    nightfilter.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 0.1f);
                    break;
                case 50:
                    nightfilter.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 0.05f);
                    break;
            }
        }
    }


    void printClock()
    {
        if (minuteInt == 0)
        {
            if (hourInt == 9)
            {
                clockfield.text = "09:00";
            }
            else if (hourInt == 0)
            {
                clockfield.text = "00:00";
            }
            else if (hourInt == 1)
            {
                clockfield.text = "01:00";
            }
            else if (hourInt == 2)
            {
                clockfield.text = "02:00";
            }
            else
            {
                clockfield.text = hourInt + ":00";
            }
        }
        else
        {
            if (hourInt == 9)
            {
                clockfield.text = "09:" + minuteInt;
            }
            else if (hourInt == 0)
            {
                clockfield.text = "00:" + minuteInt;
            }
            else if (hourInt == 1)
            {
                clockfield.text = "01:" + minuteInt;
            }
            else if (hourInt == 2)
            {
                clockfield.text = "02:" + minuteInt;
            }
            else
            {
                clockfield.text = hourInt + ":" + minuteInt;
            }
        }
    }

}
