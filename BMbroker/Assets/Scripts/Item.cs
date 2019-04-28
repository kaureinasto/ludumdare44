using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text CountText;
    public Text NameText;
    public Button SellButton;

    public ObservableFloat currentAge;
    public ObservableFloat tickPeriod;
    public ItemDataEvent OnDataHover;
    public Image backgroundImage;

    private ItemData _itemData;
    private int _count;

    private void Start()
    {
        SellButton.interactable = false;
        CountText.text = "0";
        backgroundImage.color = Color.white;
        backgroundImage.CrossFadeAlpha(0.1f, 0f, true);
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
        NameText.text = _itemData.name;
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnDataHover.Fire(_itemData);
        backgroundImage.CrossFadeAlpha(0.2f, 0.2f, true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        backgroundImage.CrossFadeAlpha(0.1f, 0.2f, true);
    }
}
