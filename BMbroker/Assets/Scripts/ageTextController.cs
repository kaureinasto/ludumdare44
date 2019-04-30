using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ageTextController : MonoBehaviour {

	private Text currentAge;
	// Use this for initialization
	public ObservableFloat age;
	void Start() {
		this.currentAge = GetComponent<Text>();
	}

	// Update is called once per frame
	void Update () {
		this.currentAge.text = "Current Age: " + (int)Math.Floor(this.age.Value()/12) + " years old.";
	}

}
