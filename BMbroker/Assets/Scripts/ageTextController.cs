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
		this.currentAge.text = "You are " + (int)Math.Ceiling(this.age.Value()/12 - 1) + " years old. \n(Equal to " + this.age.Value() + " months)";
	}

}
