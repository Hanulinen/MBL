using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTriggers : MonoBehaviour {


    public void OnTriggerStay2D(Collider2D target)
    {
        if (target.transform.CompareTag("Enemy") && Input.GetButtonDown("Attack"))
        {
                    target.gameObject.SetActive(false); }
        }
        
    }

