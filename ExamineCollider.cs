using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamineCollider : MonoBehaviour
{

    [SerializeField]
    string examinedObject;
    [SerializeField]
    GameObject typewriter, textBox, text_examine;
    bool examinable = false;

    void OnTriggerStay2D(Collider2D target)
    {
        if (target.transform.CompareTag("Player"))
        {
            examinable = true;
            text_examine.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D target)
    {
        examinable = false;
        text_examine.SetActive(false);
        if (textBox.activeSelf)
        {
            textBox.SetActive(false);
        }
    }

    void Update()
    {
        if (examinable && Input.GetButtonDown("Use"))
        {
            textBox.SetActive(true);
            typewriter.GetComponent<Examine>().RecieveText(examinedObject);
        }
    }
}