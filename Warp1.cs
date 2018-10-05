using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    string examinedObject = "door";
    public Transform warpTarget;
    PlayerInventory myPlayerInventory;
    PlayerMovement myPlayerMovement;
    int hourInt;
    [SerializeField]
    GameObject typewriter, textBox;
    [SerializeField]
    bool locked = false;

    private void Awake()
    {

        
        myPlayerInventory = GameObject.Find("Inventory").GetComponent<PlayerInventory>();
        myPlayerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();

    }
    private void Update()
    {
        hourInt = GameObject.FindGameObjectWithTag("Gameplay").GetComponent<TimeOfDay>().hourInt;
    }

    IEnumerator OnTriggerEnter2D(Collider2D target)
    //void OnTriggerEnter2D(Collider2D target)
    {
        if (target.transform.CompareTag("Player"))
        {
            if (locked)
            {
                if (hourInt < 18 && hourInt > 6)
                {
                    myPlayerMovement.HandleMovement(Vector2.zero);
                    myPlayerMovement.enabled = false;
                    if (myPlayerInventory.IsOpen)
                    {
                        myPlayerInventory.OpenCloseInventory();
                    }

                    ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();

                    yield return StartCoroutine(sf.FadeToBlack());

                    target.gameObject.transform.position = warpTarget.position;
                    Camera.main.transform.position = warpTarget.position;
                    yield return StartCoroutine(sf.FadeToClear());
                    myPlayerMovement.enabled = true;
                }
                else if (hourInt >= 18 || hourInt <= 6)
                {
                    textBox.SetActive(true);
                    typewriter.GetComponent<Examine>().RecieveText(examinedObject);
                }
            }
            else if (!locked)
            {
                myPlayerMovement.HandleMovement(Vector2.zero);
                myPlayerMovement.enabled = false;
                if (myPlayerInventory.IsOpen)
                {
                    myPlayerInventory.OpenCloseInventory();
                }

                ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();

                yield return StartCoroutine(sf.FadeToBlack());

                target.gameObject.transform.position = warpTarget.position;
                Camera.main.transform.position = warpTarget.position;
                yield return StartCoroutine(sf.FadeToClear());
                myPlayerMovement.enabled = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D target)
    {
        if (textBox.activeSelf)
        {
            textBox.SetActive(false);
        }
    }
}