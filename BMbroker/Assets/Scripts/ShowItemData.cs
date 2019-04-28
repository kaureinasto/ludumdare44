using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ShowItemData : MonoBehaviour
{
    public Text nameText;
    public Text valueText;
    public Text incomeText;
    public Text costsText;
    public ItemDataEvent showItemDataEvent;

    private void OnEnable()
    {
        showItemDataEvent.action += Show;
    }

    private void OnDisable()
    {
        showItemDataEvent.action -= Show;
    }

    private void Show(ItemData obj)
    {
        nameText.text = obj.name;
        valueText.text = Math.Round(obj.value/12f, 2) + " years";
        incomeText.text = obj.incomingRate.ToString();
        costsText.text = obj.outgoingRate.ToString();
    }
}
