﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class incomeTextController : MonoBehaviour {
	GameController gameController;
	
	private Text currentIncome;
	// Use this for initialization

	void Start () {
		this.currentIncome = GetComponent<Text>();

		this.gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		
		
	}
	
	// Update is called once per frame
	void Update () {
	}
	
}
