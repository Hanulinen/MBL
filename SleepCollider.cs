using UnityEngine;
using UnityEngine.UI;

public class SleepCollider : MonoBehaviour
{

    [SerializeField]
    string examinedObject;
    [SerializeField]
    GameObject text_examine, gameplay, fader, typewriter, textBox, text_examine2, timeofday;
    bool examinable = false;
    bool goingtosleep = false;

    void OnTriggerStay2D(Collider2D target)
    {
        if (target.transform.CompareTag("Player"))
        {
            
            examinable = true;
            if (timeofday.GetComponent<TimeOfDay>().hourInt <= 6 || timeofday.GetComponent<TimeOfDay>().hourInt >= 18)
            {
                text_examine.SetActive(true);
            }
            else if ((timeofday.GetComponent<TimeOfDay>().hourInt > 6 && timeofday.GetComponent<TimeOfDay>().hourInt < 18))
            {
                text_examine2.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D target)
    {
        examinable = false;
        text_examine.SetActive(false);
        text_examine2.SetActive(false);
        if (textBox.activeSelf)
        {
            textBox.SetActive(false);
        }
    }

    void Update()
    {
        if (goingtosleep)
        {
            fader.GetComponent<Image>().color = Color.Lerp(fader.GetComponent<Image>().color, Color.black, 1f * Time.deltaTime);
        }
        if (examinable && Input.GetButtonDown("Use"))
        {
            if (timeofday.GetComponent<TimeOfDay>().hourInt <= 6 || timeofday.GetComponent<TimeOfDay>().hourInt >= 18)
            {
                goingtosleep = true;
                StartCoroutine(gameplay.GetComponent<TimeOfDay>().endDay());
            }
            else if ((timeofday.GetComponent<TimeOfDay>().hourInt > 6 && timeofday.GetComponent<TimeOfDay>().hourInt < 18))
            {
                textBox.SetActive(true);
                typewriter.GetComponent<Examine>().RecieveText(examinedObject);
            }

        }
    }
}