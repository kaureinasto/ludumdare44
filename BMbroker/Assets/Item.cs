using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Image Image;
    public Text CountText;
    public Button SellButton;
    
    public ObservableFloat currentAge;
    public ObservableFloat incomingRate;
    public ObservableFloat outgoingRate;

    private ItemData _itemData;
    private int _count;

    private void Start()
    {
        SellButton.interactable = false;
        CountText.text = "0";
    }
    public void SetItemData(ItemData itemData)
    {
        _itemData = itemData;
        Image.sprite = _itemData.picture;
    }
    
    public void Buy()
    {
        Debug.Log("Buy " + _itemData.name);
        _count++;
        CountText.text = _count.ToString();
        currentAge.Substract(_itemData.value);
        incomingRate.Add(_itemData.incomingRate);
        outgoingRate.Add(_itemData.outgoingRate);
        SellButton.interactable = true;
    }
    
    public void Sell()
    {
        if (_count < 1) return;
        
        Debug.Log("Sell " + _itemData.name);
        currentAge.Add(_itemData.value);
        incomingRate.Substract(_itemData.incomingRate);
        outgoingRate.Substract(_itemData.outgoingRate);
        _count--;

        CountText.text = _count.ToString();
        SellButton.interactable = _count > 0;
    }
}