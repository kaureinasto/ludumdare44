 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public float agingPeriod = 5f;
	public float randomEventProbability = 0.01f;
	public ObservableFloat currentage;
	public ObservableFloat incomingRate;
	public ObservableFloat outgoingRate;

	void Start () {
		StartCoroutine(calculateAge());
		StartCoroutine(randomEvents());
	}
	
	private IEnumerator calculateAge(){	
		while(true){
		this.doAgeMath();
		yield return new WaitForSeconds(agingPeriod);
		}
	}
	private IEnumerator randomEvents(){
		while(true){
			if(randomEventProbability >= Random.Range(0.00f,1.00f)){
				Debug.Log("random event everybody");
			}
			yield return new WaitForSeconds(agingPeriod);
		}
	}
	// Update is called once per frame
	void Update () {
	}
	
	private void doAgeMath(){
		this.currentage.Set(currentage.Get() + incomingRate.Get() - outgoingRate.Get()); 
	
	}

	
}
