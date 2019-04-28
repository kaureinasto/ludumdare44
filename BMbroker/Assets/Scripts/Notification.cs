using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
    public Text infoText;
    public Text incomeText;
    public Text outgoingText;
    public Text inflationText;
    public Console console;
    public Button closeButton;
    
    public void Destroy()
    {
        GetComponent<Animator>().SetBool("close", true);
        Destroy(gameObject, 0.5f);
    }
    
    private void Start()
    {
        closeButton.onClick.AddListener(() =>
        {
            this.Destroy();
            console.ScheduleNextDestroy();
        });
    }
}