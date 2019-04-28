﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ShowNextTickGain : MonoBehaviour
{
    private Text _text;
    private List<IAgeEffector> ageEffectors = new List<IAgeEffector>();
    
    public ObservableFloat income;
    private void Start()
    {
        _text = GetComponent<Text>();
        StartCoroutine(FindEffectors());
    }

    private IEnumerator FindEffectors()
    {
        while (ageEffectors.Count == 0)
        {
            ageEffectors = FindObjectsOfType<MonoBehaviour>().OfType<IAgeEffector>().ToList();
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void Update()
    {
        float sum = 0f;
        foreach (IAgeEffector ageEffector in ageEffectors)
        {
            sum += ageEffector.GetEffectPerTick();
        }
        if(sum < 0){
        _text.text = "You are getting younger at a rate of: " + sum.ToString("F1")+ " per tick";
        }
        if(sum == 0){
        _text.text = "You are not aging :O";
        }
        if(sum > 0){
        _text.text = "You are growing older at a rate of : " + sum.ToString("F1") +" per tick";
        }
    }
}