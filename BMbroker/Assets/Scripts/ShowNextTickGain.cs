using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ShowNextTickGain : MonoBehaviour
{

    public ObservableFloat income;
    public ObservableFloat costs;
    public Text text;
    
    private void OnEnable()
    {
        UpdateText(0f);
        income.OnChanged += UpdateText;
    }

    private void OnDisable()
    {
        income.OnChanged -= UpdateText;
    }

    private void UpdateText(float whatever)
    {
        float gain = income.Value() - costs.Value();
        
        if(gain < 0){
        text.text = "Rate: You are getting younger at a rate of: " + gain.ToString("F1")+ " per tick";
        text.color = new Color(1, 0.4745098F, 0.7764706F, 1); //pink
        }
        if(gain == 0){
        text.text = "Rate: You are not aging :O";
        text.color = Color.white;
        }
        if(gain > 0){
        text.text = "Rate: You are growing older at a rate of : " + gain.ToString("F1") +" per tick";
        text.color = new Color(0.3137255F, 0.9803922F, 0.4823529F, 1); //green
        }
    }
}
