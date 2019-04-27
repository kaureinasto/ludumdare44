using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PopulateShop : MonoBehaviour
{
    public Item itemPrefab;
    public ItemData[] itemDatas;

    private void Start()
    {
        foreach (ItemData itemData in itemDatas)
        {
            Item item = GameObject.Instantiate(itemPrefab, transform);
            item.SetItemData(itemData);
        }
    }
}