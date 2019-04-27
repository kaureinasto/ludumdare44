using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buyable : MonoBehaviour
{
    public Image Image;

    private OwnableItem _item;

    public void SetOwnableItem(OwnableItem item)
    {
        _item = item;
        Image.sprite = _item.picture;
    }
    
    public OwnableItem GetOwnableItem()
    {
        return _item;
    }

    public void Buy()
    {
        Debug.Log("Buy " + _item.name);
    }
    
    public void Sell()
    {
        Debug.Log("Sell " + _item.name);
    }
}