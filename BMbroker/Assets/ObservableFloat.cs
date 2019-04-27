using System;
using UnityEngine;

[CreateAssetMenu]
public class ObservableFloat : ScriptableObject
{
    [SerializeField]
    private float value = 0f;
    public event Action<float> OnChanged;

    public void set(float newValue)
    {
        value = newValue;
        if (OnChanged != null)
        {
            OnChanged.Invoke(value);
        }
    }

    public float get()
    {
        return value;
    }
}