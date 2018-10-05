using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour {

    Button stay;
    Button leave;

	// Use this for initialization
	void Start () {
        stay = GameObject.Find("Stay").GetComponent<Button>();
        stay.onClick.AddListener(() => End());
        leave = GameObject.Find("Leave").GetComponent<Button>();
        leave.onClick.AddListener(() => End());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void End()
    {
        SceneManager.LoadScene("Ending");
    }

    public void Deactivate()
    {
        stay.gameObject.SetActive(false);
        leave.gameObject.SetActive(false);
    }
}
