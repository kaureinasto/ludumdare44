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

    public ObservableFloat playerAge;
    public ObservableFloat playerIncome;
    public ObservableFloat playerCosts;
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
    }

    public void SetItemData(ItemData itemData)
    {
        _itemData = itemData;
        NameText.text = _itemData.name;
    }

    public void Buy()
    {
        _count++;
        CountText.text = _count.ToString();
        playerAge.Substract(_itemData.value);
        playerIncome.Add(_itemData.incomingRate);
        playerCosts.Add(_itemData.outgoingRate);
        SellButton.interactable = true;
    }

    public void Sell()
    {
        if (_count < 1) return;

        playerAge.Add(_itemData.value);
        playerIncome.Substract(_itemData.incomingRate);
        playerCosts.Substract(_itemData.outgoingRate);
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
