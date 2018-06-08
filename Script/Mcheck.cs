using System.Collections;
using UnityEngine;

public class Mcheck : MonoBehaviour {

		public static bool check = false;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		check = true;
	}

	void OnTriggerExit(Collider other) {
		check = false;
}
}
