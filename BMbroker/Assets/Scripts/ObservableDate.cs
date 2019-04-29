using System;
using UnityEngine;

[CreateAssetMenu]
public class ObservableDate : ScriptableObject
{
    [SerializeField]
    private DateTime value = DateTime.Now;
    public event Action<DateTime> OnChanged;

    public void Set(DateTime newValue)
    {
        value = newValue;
        if (OnChanged != null)
        {
            OnChanged.Invoke(value);
        }
    }

    public void AddMonths(int amount)
    {
        Set(value.AddMonths(amount));
    }

    public DateTime Value()
    {
        return value;
    }
}
