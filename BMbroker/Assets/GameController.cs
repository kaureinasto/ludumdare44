using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	 private float nextActionTime = 0;
	 public float agingPeriod = 5;
	
	Player currentPlayer;
	// Use this for initialization
	void Start () {
		this.currentPlayer = new Player();
	}
	
	 
	// Update is called once per frame
	void Update () {
		if (Time.time > nextActionTime ) {
        nextActionTime = Time.time + agingPeriod;

		Debug.Log("One ingame monthpassed, age in years");
		Debug.Log(currentPlayer.getAge()/12);
		Debug.Log("age in months");
		Debug.Log(currentPlayer.getAge());
		currentPlayer.AddAge(currentPlayer.incomeRate);
		currentPlayer.RemoveAge(currentPlayer.outgoingRate);

		if(currentPlayer.getAge() <= 0){
			Debug.Log("Game over, n00b - git gud.");
		}
	 }

	}

	public Player getPlayer(){
		return this.currentPlayer;	
	}
	
}
