using System;
using System.Collections;
using System.Collections.Generic;
using Cards;
using EventBus;
using UnityEngine;

public class CardPack : MonoBehaviour
{
    public int cardPackValue;
    public int cardCount;
    public List<Card> cards;
    public List<Card> gameCards = new List<Card>();
    
    [SerializeField] private TMPro.TextMeshProUGUI cardCostText;

    private void Start()
    {
        cardCostText.text = cardPackValue.ToString();
    }

    public void OnClick()
    {
        if (CardManager.instance.GetHand().Count >= CardManager.instance.maxHandSize)
        {
            EventBus<ErrorPromptEvent>.Raise(new ErrorPromptEvent(ErrorPromptEvent.ErrorType.NotEnoughSpace));
            return;
        }
        
        if(ShopManager.GetMoneyFunc?.Invoke() < cardPackValue)
        {
            EventBus<ErrorPromptEvent>.Raise(new ErrorPromptEvent(ErrorPromptEvent.ErrorType.NotEnoughMoney));
            return;
        }
        
        EventBus<CardPackEvent>.Raise(new CardPackEvent(this, true));
    }
}
