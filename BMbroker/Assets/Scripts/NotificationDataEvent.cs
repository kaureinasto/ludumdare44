using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class NotificationDataEvent : ScriptableObject
{
    public event Action<NotificationData> action;

    public void Fire(NotificationData notificationData)
    {
        if (action != null)
        {
            action.Invoke(notificationData);
        }
    }
}