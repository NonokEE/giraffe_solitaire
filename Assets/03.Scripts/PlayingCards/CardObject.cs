using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using PlayingCards;
using System;

[RequireComponent(typeof(CardSprite))]
[RequireComponent(typeof(Image))]

/// <summary> Main component of single card. </summary>
/// <remarks>
///
/// </remarks>
public class CardObject : MonoBehaviour
{
    /******* FIELD *******/
    //~ Properties ~//
    [SerializeField] private pattern cardPattern;
    public pattern CardPattern { get{ return cardPattern; } }

    [SerializeField] private int cardNumber;
    public int CardNumber { get{ return cardNumber; } }

    ///<remarks>true: opened, false: closed</remarks>
    [SerializeField] private bool status = false;
    public bool Status { get{ return status; } }

    //~ Binding ~//
    private Deck deck;
    private CardSprite cardSprite;

    //~ Event ~//
    public Action<bool> StatusChanged;

    //~ For Funcs ~//

    //~ Debug ~//

    /******* EVENT FUNC *******/

    /******* INTERFACE IMPLEMENT *******/

    /******* METHOD *******/
    //~ Internal ~//
    private void SetCard(pattern pattern, int number)
    {
        cardPattern = pattern;
        cardNumber = number;
    }
    private void SetCard(pattern pattern, int number, bool status)
    {
        SetCard(pattern, number);
        this.status = status;
    }
    private void InitSprite(Deck deck)
    {
        cardSprite = GetComponent<CardSprite>();
        cardSprite.Init(deck);
    }
    //~ Event Listener ~//

    //~ External ~//
    public void Init(Deck deck, pattern pattern, int number, bool status)
    {
        this.deck = deck;
        cardPattern = pattern;
        cardNumber = number;
        this.status = status;
        
        InitSprite(deck);
    }
    public void Init(Deck deck, pattern pattern, int number)
    {
        Init(deck, pattern, number, true);
    }
    public void Flip()
    {
        status = !status;
        StatusChanged(status);
    }
}