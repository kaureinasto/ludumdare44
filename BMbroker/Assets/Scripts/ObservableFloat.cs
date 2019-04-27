using System;
using UnityEngine;

[CreateAssetMenu]
public class ObservableFloat : ScriptableObject
{
    [SerializeField]
    private float value = 0f;
    public event Action<float> OnChanged;

    public void Set(float newValue)
    {
        value = newValue;
        if (OnChanged != null)
        {
            OnChanged.Invoke(value);
        }
    }

    public void Add(float amount)
    {
        Set(value + amount);
    }

    public void Substract(float amount)
    {
        Set(value - amount);
    }

    public float Value()
    {
        return value;
    }
}