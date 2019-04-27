using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class outcomeTextController : MonoBehaviour {
	public ObservableFloat outgoing;
	private Text currentOutgoing;
	// Use this for initialization

	void Start () {
		this.currentOutgoing = GetComponent<Text>();		
	}
	
	// Update is called once per frame
	void Update () {
		this.currentOutgoing.text = "You lose age at " + outgoing.Value() + " per tick.";
	}
	
}
