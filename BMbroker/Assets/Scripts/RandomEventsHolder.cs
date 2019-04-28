using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RandomEventsHolder : ScriptableObject {

	public List<RandomEvent> eventList;
	public RandomEvent GetEvent(){
		return this.eventList[Random.Range(0,this.eventList.Count)];
	}
}
