using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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
    public SimpleEvent ascendTrigger;

    private Coroutine aging;
    private Coroutine random;
    private Coroutine dateincrementor;
    
    

    private float score;
    public bool ascended = false;
    public Button ascendButton;

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
            if( ascended ) {
                ascendTrigger.Fire();
                StopCoroutine(RandomEventRoutine());
                StopCoroutine(aging);
                StopCoroutine(random);
                StopCoroutine(dateincrementor);                
                yield return new WaitForSeconds(4);
                StopAllCoroutines();
                gameSpawner.destroyGame();
                Debug.Log("You Lose, because you killed yourself");
            } 

            if( playerAge.Value() < 0 || playerAge.Value() > 1200) {
                ascendButton.enabled = false;
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

    public void setAscended(bool value){
        ascended = value;
    }
    public string getAscendScoreString(){
        int balancefactor = 6;
        if(score < 5*balancefactor){
            return "You ascend and are reborn as a stock broker. "+ yourScoreWas(score);
        }            
        if(score < 10*balancefactor){
            return "You ascend and are reborn as a cockroach. "+ yourScoreWas(score);
        }
        if(score < 200*balancefactor){
            return "You ascend and are reborn as a prostitute. "+ yourScoreWas(score);
        }
        if(score < 300*balancefactor){
            return "You ascend and are reborn as a pokemon. More specifically, a Magicarp. A life of splashing awaits you. "+ yourScoreWas(score);
        }
        if(score < 400*balancefactor){
            return "You ascend and are reborn as a Jerry Lee Lewis. "+ yourScoreWas(score);
        }
        if(score < 500*balancefactor){
            return "You ascend and are reborn as a Cartman. "+ yourScoreWas(score);
        }
        if(score < 600*balancefactor){
            return "You ascend and are reborn in an alternate universe as a crack-addicted George W. Bush. Too bad you're not president anymore. "+ yourScoreWas(score);
        }
        if(score < 700*balancefactor){
            return "You ascend find yourself to walking the streets as a Homer Simpson. D'oh! "+ yourScoreWas(score);
        }
        if(score < 800*balancefactor){
            return "You ascend and reincarnate into the body of Harry Potter, right as he is about to kiss Draco Malfoy. "+ yourScoreWas(score);
        }
        if(score < 900*balancefactor){
            return "You ascend and are reborn as a regular dude, tough shit. "+ yourScoreWas(score);
        }
        if(score < 933*balancefactor){
            return "You ascend to find yourself transformed into Daenerys Targaryen, ruler of the Seven Kingdoms. Get ready for all that incest . "+ yourScoreWas(score);
        }
        if(score < 1000*balancefactor){
            return "You ascend and are reborn as a Rick, bitch, wubbalubbadubduub. "+ yourScoreWas(score);
        }
        if(score > 1200*balancefactor){
            return "You ascend and are reborn as a thousand year old tree. Get ready to grow!!!"+ yourScoreWas(score);
        }
        
        return "You ascend and are reborn as a insect, tough break. " + yourScoreWas(score);
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
     

    public string getDeathStats(){
        string yearslasted = "You lasted " + currentDate.getYearsLasted() + " years. ";
        if(ascended){
            return yearslasted + getAscendScoreString();
        }
        return "You died like a noob. " + yearslasted + yourScoreWas(score);
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
