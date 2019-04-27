using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour, IAgeEffector
{
    public Image Image;
    public Text CountText;
    public Button SellButton;
    
    public ObservableFloat currentAge;
    public ObservableFloat tickPeriod;

    private ItemData _itemData;
    private int _count;

    private void Start()
    {
        SellButton.interactable = false;
        CountText.text = "0";
        StartCoroutine(TickRoutine());
    }

    private IEnumerator TickRoutine()
    {
        while(true)
        {
            currentAge.Add(_itemData.incomingRate * _count);
            currentAge.Substract(_itemData.outgoingRate * _count);
            yield return new WaitForSeconds(tickPeriod.Value());
        }
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
        SellButton.interactable = true;
    }
    
    public void Sell()
    {
        if (_count < 1) return;
        
        Debug.Log("Sell " + _itemData.name);
        currentAge.Add(_itemData.value);
        _count--;

        CountText.text = _count.ToString();
        SellButton.interactable = _count > 0;
    }

    public float GetEffectPerTick()
    {
        return _count * (_itemData.incomingRate - _itemData.outgoingRate);
    }
}