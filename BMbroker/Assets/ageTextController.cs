using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ageTextController : MonoBehaviour {
	
	private Text currentAge;
	// Use this for initialization
	public ObservableFloat age;
	void Start() {
		this.currentAge = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		this.currentAge.text = "You are " + this.age.Get() + " months old, which means you are " + this.age.Get()/12 + " years old.";
	}
	
}
