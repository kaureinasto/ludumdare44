using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpawner : MonoBehaviour {


	public GameObject game;
	private GameObject currentGame;
	public GameObject endGameScreen;
	
	public void spawnNormalGame()
	{
		this.currentGame = Instantiate(game);
		currentGame.SetActive(true);
	}

	public void destroyGame(){

		//currentGame.GameController.getStats()
		currentGame.SetActive(false);
		endGameScreen.SetActive(true);
		Destroy(currentGame);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
