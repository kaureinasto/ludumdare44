using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventController : MonoBehaviour {

	ObservableFloat age;
	ObservableFloat income;
	ObservableFloat outgoing;

	public List<RandomEvent> eventList;
	public RandomEvent getEvent(){
		return this.eventList[Random.Range(0,this.eventList.Count)];
	}
}
