using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using System.Linq;

public class PopulateShop : MonoBehaviour
{
    public Item itemPrefab;
    public ItemData[] itemDatas;

    private void Start()
    {
        List<ItemData> sortedList = itemDatas.OrderBy(o=>o.value).ToList();
        foreach (ItemData itemData in sortedList)
        {
            Item item = GameObject.Instantiate(itemPrefab, transform);
            item.SetItemData(itemData);
        }
    }
}
