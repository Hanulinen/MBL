using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour {

    Button Continue;

	// Use this for initialization
	void Start () {
        Continue = GameObject.Find("Button").GetComponent<Button>();
        Continue.onClick.AddListener(() => GameOver());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void GameOver()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
