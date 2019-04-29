using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public ObservableFloat tickPeriod;
    public ObservableFloat randomEventProbability;
    public ObservableFloat playerAge;
    public ObservableFloat playerIncome;
    public ObservableFloat playerCosts;
    public ObservableFloat inflationRate;

    public RandomEventsHolder randomEventsHolder;
    public NotificationDataEvent randomEventNotification;

    public GameSpawner gameSpawner;
    void Start()
    {   
        playerAge.Set(216);
        playerIncome.Set(1);
        playerCosts.Set(0);
        StartCoroutine(AgeRoutine());
        StartCoroutine(RandomEventRoutine());
        StartCoroutine(AnnualInflationRoutine());
        StartCoroutine(CheckLosingRoutine());
    }
    
    
    private IEnumerator AgeRoutine()
    {
        while (true)
        {
            this.playerAge.Add(playerIncome.Value());
            this.playerAge.Substract(playerCosts.Value());
            
            yield return new WaitForSeconds(tickPeriod.Value());
        }
    }
    private IEnumerator CheckLosingRoutine(){
        while (true){
            if( playerAge.Value() < 0 || playerAge.Value() > 1200){
                GameOver();
                Debug.Log("You Lose");
            }
            yield return new WaitForSeconds(tickPeriod.Value()/30);
        }
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
                RandomEvent random = randomEventsHolder.GetEvent();
                ProcessRandomEvent(random);
            }
            yield return new WaitForSeconds(tickPeriod.Value());
        }
    }
    private void GameOver(){
        StopAllCoroutines();
        gameSpawner.destroyGame();
    }
    private void ProcessRandomEvent(RandomEvent random)
    {
        this.playerAge.Add(random.ageChange);
        this.playerIncome.Add(random.incomingChange);
        this.playerCosts.Add(random.outGoingChange);
        this.inflationRate.Add(random.inflationChange);
        
        randomEventNotification.Fire(new NotificationData(
            random.description, 
            random.incomingChange,
            random.outGoingChange,
            random.inflationChange));
    }
}