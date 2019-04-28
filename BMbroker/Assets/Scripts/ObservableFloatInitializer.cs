using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ObservableFloatInitializer : MonoBehaviour
{
    public ObservableFloat observableFloat;
    public float initialValue;
    
    private void Start()
    {
        observableFloat.Set(initialValue);
    }
}