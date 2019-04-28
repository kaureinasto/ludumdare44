using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemDataEvent : ScriptableObject
{
	public event Action<ItemData> action;
	public ItemData defaultItemData;

	public void Fire(ItemData itemData)
	{
		if (action != null)
		{
			action.Invoke(itemData);
		}
	}
}
