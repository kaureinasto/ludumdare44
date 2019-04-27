using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateShop : MonoBehaviour
{
    public Buyable buyablePrefab;
    public OwnableItem[] Items;

    private void Start()
    {
        foreach (OwnableItem item in Items)
        {
            Buyable buyable = GameObject.Instantiate(buyablePrefab, transform);
            buyable.SetOwnableItem(item);
        }
    }
}