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
    public ObservableDate currentDate;
    
    public RandomEventsHolder randomEventsHolder;
    public NotificationDataEvent randomEventNotification;

    public GameSpawner gameSpawner;
    public AudioSource maingameMusic;
    private Coroutine aging;
    private Coroutine random;
    private Coroutine dateincrementor;
    
    private float score;
    
    void Start()
    {
        aging = StartCoroutine(AgeRoutine());
        random = StartCoroutine(RandomEventRoutine());
        StartCoroutine(AnnualInflationRoutine());
        StartCoroutine(CheckLosingRoutine());
        dateincrementor = StartCoroutine(AdvanceGameDay());
    }

    private IEnumerator AdvanceGameDay(){
      while (true)
      {
          this.currentDate.AddDays(1);

          yield return new WaitForSeconds(tickPeriod.Value()/30);
      }
    }
    private IEnumerator AgeRoutine()
    {
        while (true)
        {
            this.playerAge.Add(playerIncome.Value());
            this.score+=playerIncome.Value();
            this.playerAge.Substract(playerCosts.Value());

            yield return new WaitForSeconds(tickPeriod.Value());
        }
    }
    private IEnumerator CheckLosingRoutine(){
        while (true){
            if( playerAge.Value() < 0 || playerAge.Value() > 1200){
                StopCoroutine(RandomEventRoutine());
                StopCoroutine(aging);
                StopCoroutine(random);
                StopCoroutine(dateincrementor);                
                yield return new WaitForSeconds(4);
                StopAllCoroutines();
                gameSpawner.destroyGame();
                Debug.Log("You Lose");
            }
            yield return new WaitForSeconds(tickPeriod.Value()/30);
        }
    }
    public string printScoreString(){
            
        if(score < 100){
            return "You ascend and are reborn as a fly. ";
        }
        if(score < 200){
            return "You ascend and are reborn as a horse. ";
        }
        if(score < 300){
            return "You ascend and are reborn as a horse. ";
        }
        return "You ascend and are reborn as a cockroach. ";
    }
    private string yourScoreWas(float score){
        return "Your score was " + score.ToString() +" .";
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

    }

    public void SetDefaultValues(){
        playerAge.Set(216.0f);
        playerIncome.Set(1.0f);
        playerCosts.Set(0.0f);
        tickPeriod.Set(5);
    }
    public void SetTurboValues(){
        playerAge.Set(216f);
        playerIncome.Set(1.1f);
        playerCosts.Set(0.1f);
        tickPeriod.Set(0.33f);
        maingameMusic.pitch = 2f;

    }
    public string getStats(){
        string yearslasted = "You lasted " + currentDate.getYearsLasted() + " years. ";
        Debug.Log(yearslasted);
        return yearslasted + yourScoreWas(score) + printScoreString();
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
