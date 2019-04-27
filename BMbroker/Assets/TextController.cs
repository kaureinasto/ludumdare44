using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextController : MonoBehaviour {
	GameController gameController;
	
	private Text currentAge;
	// Use this for initialization

	void Start () {
		this.currentAge = GetComponent<Text>();

		this.gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		
		
	}
	
	// Update is called once per frame
	void Update () {
		this.currentAge.text = "Your current age is " + gameController.getPlayer().getAge() + " months.";
	}
}
