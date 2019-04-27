using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float agingPeriod = 5f;
    public ObservableFloat randomEventProbability;
    public ObservableFloat currentAge;
    public ObservableFloat incomingRate;
    public ObservableFloat outgoingRate;
    public ObservableFloat inflationRate;

	public RandomEventController randomEventController;
	void Start () {
		StartCoroutine(calculateAge());
		StartCoroutine(randomEvents());
		StartCoroutine(yearlyChange());
	}
    private IEnumerator calculateAge()
    {
        while (true)
        {
            this.doAgeMath();
            yield return new WaitForSeconds(agingPeriod);
        }
    }

	private IEnumerator yearlyChange(){	
		while(true){
			this.inflationRate.Set(this.inflationRate.Get()*Random.Range(0.01f, 0.03f));
		yield return new WaitForSeconds(agingPeriod*12);
		}
	}
	private IEnumerator randomEvents(){
		while(true){
			if(randomEventProbability.Get() >= Random.Range(0.00f,1.00f)){
				RandomEvent random = randomEventController.getEvent();
				doRandomMath(random);
				Debug.Log("random event happened, and changed some values, haha");
				Debug.Log(random.description);
			}
			yield return new WaitForSeconds(agingPeriod);
		}
	}
	// Update is called once per frame
	void Update () {
	}
	
	public void doRandomMath(RandomEvent random){
		this.currentAge.Add(random.ageChange);
		this.incomingRate.Add(random.incomingChange);
		this.outgoingRate.Add(random.outGoingChange);
		this.inflationRate.Add(random.inflationChange);
	}

    private void doAgeMath()
    {
        this.currentAge.Add(incomingRate.Get());
        this.currentAge.Substract(outgoingRate.Get());
    }
}