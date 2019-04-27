using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class incomeTextController : MonoBehaviour {
	private Text currentIncome;
	// Use this for initialization
	public ObservableFloat income;
	void Start () {
		this.currentIncome = GetComponent<Text>();		
	}
	
	// Update is called once per frame
	void Update () {
		currentIncome.text = "You gain age at " + income.Get() + " per tick,";
	}
	
}
