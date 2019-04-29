using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstance : MonoBehaviour {
	public GameController gameController;
	
	public void SetActive(bool active){
		transform.gameObject.SetActive(active);
	}
}
