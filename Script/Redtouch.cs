using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redtouch : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        Judge.Red = true;
    }

    void OnTriggerExit(Collider other)
    {
        Judge.Red = false;
    }

}
