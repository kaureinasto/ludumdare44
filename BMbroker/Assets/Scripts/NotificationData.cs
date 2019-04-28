
public class NotificationData 
{
    public string text { get; private set; }

    public float incomeChange { get; private set; }

    public float costsChange { get; private set; }

    public float inflationChange { get; private set; }

    public NotificationData(string text, float incomeChange, float costsChange, float inflationChange)
    {
        this.text = text;
        this.incomeChange = incomeChange;
        this.costsChange = costsChange;
        this.inflationChange = inflationChange;
    }
}