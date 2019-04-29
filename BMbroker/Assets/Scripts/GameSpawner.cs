using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameSpawner : MonoBehaviour {


	public GameInstance game;
	private GameInstance currentGame;
	public GameObject endGameScreen;
	public Text endgametext;	

	public void spawnNormalGame()
	{
		this.currentGame = Instantiate(game);
		currentGame.gameController.SetDefaultValues();
		currentGame.SetActive(true);
	}

	public void spawnTurboGame(){
		this.currentGame = Instantiate(game);
		currentGame.gameController.SetTurboValues();
		currentGame.SetActive(true);
	}

	public void destroyGame(){
		endgametext.text = currentGame.gameController.getDeathStats();
		
		currentGame.SetActive(false);
		endGameScreen.SetActive(true);
		Destroy(currentGame);
	}

}
