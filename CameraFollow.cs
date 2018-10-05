using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;

    void Start () {
        
	}
	    
	void Update () {
        if (target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position,0.05f) + new Vector3 (0,0,-10);
        }
	}
    

}