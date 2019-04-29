using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Serialization;

public class ObservableDateInitializer : MonoBehaviour
{
    public ObservableDate observableDate;
    public DateTime initialValue;

    private void Start()
    {
        observableDate.Set(initialValue);
    }
}
