using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventController : MonoBehaviour {

	ObservableFloat age;
	ObservableFloat income;
	ObservableFloat outgoing;

	List<RandomEvent> eventList;
	RandomEvent getEvent(){
		return this.eventList[Random.Range(0,this.eventList.Count)];
	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
