using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public float agingPeriod = 5f;
	
	public ObservableFloat currentage;
	public ObservableFloat incomingRate;
	public ObservableFloat outgoingRate;
	void Start () {
		StartCoroutine(calculateAge());
	}
	
	private IEnumerator calculateAge(){	
		while(true){
		this.currentage.Set(currentage.Get() + incomingRate.Get() - outgoingRate.Get()); 

		if(currentage.Get() <= 0 ){
			Debug.Log("Game over, n00b - git gud.");
		}
		
		yield return new WaitForSeconds(agingPeriod);
		}
	}
	 
	// Update is called once per frame
	void Update () {
	}


	
}
