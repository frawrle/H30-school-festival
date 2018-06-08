using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlUI : MonoBehaviour {
	public Text uitest;
	// Use this for initialization
	void Start () {
		uitest.text="a";

	}

	// Update is called once per frame
	void Update () {
		uitest.enabled=!uitest.enabled;
	}
}
