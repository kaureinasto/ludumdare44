using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	Player currentPlayer;
	// Use this for initialization
	void Start () {
		this.currentPlayer = new Player();
	}
	

	// Update is called once per frame
	void Update () {
		Debug.Log(currentPlayer.getAge());
	}

	public Player getPlayer(){
		return this.currentPlayer;	
	}
}
