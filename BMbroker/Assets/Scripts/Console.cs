using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Console : MonoBehaviour
{
    public NotificationDataEvent notificationDataEvent;
    public GameObject notificationPrefab;
    public ObservableFloat notificationLifeTime;

    private void OnEnable()
    {
        notificationDataEvent.action += MakeNotification;
    }

    private void OnDisable()
    {
        notificationDataEvent.action -= MakeNotification;
    }

    private void MakeNotification(NotificationData o)
    {
        Notification notification = GameObject.Instantiate(notificationPrefab, transform).GetComponent<Notification>();
        notification.infoText.text = o.text;
        notification.incomeText.text = o.incomeChange.ToString("+0.0; -0.0; 0");
        notification.outgoingText.text = o.costsChange.ToString("+0.0; -0.0; 0");
        notification.inflationText.text = o.inflationChange.ToString("+0.0; -0.0; 0");
        notification.console = this;
        ScheduleNextDestroy();
    }

    public void ScheduleNextDestroy()
    {
        StopAllCoroutines(); //reset countdown
        StartCoroutine(DestroyNextNotification());
    }

    private IEnumerator DestroyNextNotification()
    {
        yield return new WaitForSecondsRealtime(notificationLifeTime.Value());
        if (transform.childCount > 0)
        {
            Transform lastChild = transform.GetChild(transform.childCount - 1);
            lastChild.GetComponent<Notification>().Destroy();
            ScheduleNextDestroy();
        }
    }
}