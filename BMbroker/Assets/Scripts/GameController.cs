using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public ObservableFloat tickPeriod;
    public ObservableFloat randomEventProbability;
    public ObservableFloat currentAge;
    public ObservableFloat randomIncomeRate;
    public ObservableFloat randomOutgoingRate;
    public ObservableFloat inflationRate;

    public RandomEventController randomEventController;

    void Start()
    {
        randomIncomeRate.Set(0f);
        randomOutgoingRate.Set(0f);
        StartCoroutine(RandomEventRoutine());
        StartCoroutine(AnnualInflationRoutine());
    }

    private IEnumerator AnnualInflationRoutine()
    {
        while (true)
        {
            this.inflationRate.Set(this.inflationRate.Value() * Random.Range(0.01f, 0.03f));
            yield return new WaitForSeconds(tickPeriod.Value() * 12);
        }
    }

    private IEnumerator RandomEventRoutine()
    {
        while (true)
        {
            if (randomEventProbability.Value() >= Random.Range(0.00f, 1.00f))
            {
                RandomEvent random = randomEventController.getEvent();
                doRandomMath(random);
            }
            
            this.currentAge.Add(randomIncomeRate.Value());
            this.currentAge.Substract(randomOutgoingRate.Value());

            yield return new WaitForSeconds(tickPeriod.Value());
        }
    }

    private void doRandomMath(RandomEvent random)
    {
        this.currentAge.Add(random.ageChange);
        this.randomIncomeRate.Add(random.incomingChange);
        this.randomOutgoingRate.Add(random.outGoingChange);
        this.inflationRate.Add(random.inflationChange);
    }
}