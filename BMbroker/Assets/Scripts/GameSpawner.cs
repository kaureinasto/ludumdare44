using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpawner : MonoBehaviour {


	public GameInstance game;
	private GameInstance currentGame;
	public GameObject endGameScreen;
	
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

		//currentGame.GameController.getStats()
		currentGame.SetActive(false);
		endGameScreen.SetActive(true);
		Destroy(currentGame);
	}

}
