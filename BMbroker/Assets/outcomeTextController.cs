using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class outcomeTextController : MonoBehaviour {

	GameController gameController;
	private Text currentOutgoing;
	// Use this for initialization

	void Start () {
		this.currentOutgoing = GetComponent<Text>();

		this.gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		
		
	}
	
	// Update is called once per frame
	void Update () {
	}
	
}
