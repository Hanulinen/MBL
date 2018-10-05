using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Textbox : MonoBehaviour {

    Image myBox;
    Text myText;

	// Use this for initialization
	void Start () {
        myBox = GetComponent<Image>();
        myBox.enabled = false;
        myText = GetComponentInChildren<Text>();
        myText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetTextBoxActive()
    {
        //gameObject.SetActive(true);
        myBox.enabled = true;
        myText.enabled = true;
    }
    public void SetTextBoxInactive()
    {
        //gameObject.SetActive(false);
        myBox.enabled = false;
        myText.enabled = false;
    }
}
