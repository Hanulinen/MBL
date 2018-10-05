using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    //Player's full health
    public float fullHealth;
    //Player's current health
    public float currentHealth;


	void Update () {

        GameObject.Find("HealthBarGreen").transform.localScale = new Vector3(1, currentHealth / fullHealth, 1);

        //Damage taken value
        float damage = 20f;

        //check if player is alive
        if (currentHealth > 0f)
        {
            //press T to take damage
            if (Input.GetKeyDown(KeyCode.T))
            {
                TakeDamage(damage);
            }
        }
        //Player is dead, disable controls
        else if (currentHealth <= 0f)
        {
            GameObject.Find("DeadText").GetComponent<Text>().text = "YOU ARE DEAD";
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
        }
        
	}

    public void TakeDamage(float damage)
    {
        currentHealth = currentHealth - damage;
        //Scale the green bar 
        GameObject.Find("HealthBarGreen").transform.localScale = new Vector3(1, currentHealth / fullHealth, 1);
    }

}
