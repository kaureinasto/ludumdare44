using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ageTextController : MonoBehaviour {
	GameController gameController;
	
	private Text currentAge;
	// Use this for initialization
	public ObservableFloat age;
	void Start () {
		this.currentAge = GetComponent<Text>();

		this.gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		
		
	}
	
	// Update is called once per frame
	void Update () {
		currentAge.text = "You are " + age.Get() + " months old. ";
	}
	
}
