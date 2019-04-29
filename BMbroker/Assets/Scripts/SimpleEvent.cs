using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SimpleEvent : ScriptableObject
{

	public event Action action;
	
	public void Fire()
	{
		if (action != null)
		{
			action.Invoke();
		}
	}
}
