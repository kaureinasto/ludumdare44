using System;
using UnityEngine;

[CreateAssetMenu]
public class ObservableDate : ScriptableObject
{
    [SerializeField]
    private DateTime value = DateTime.Now;
    private DateTime startingDate = DateTime.Now;
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
    public string getYearsLasted(){
        int yearslasted = value.Year - startingDate.Year;
        return yearslasted.ToString();
    }
    public void AddDays(int amount){
        Set(value.AddDays(amount));
    }
    public DateTime Value()
    {
        return value;
    }
}
