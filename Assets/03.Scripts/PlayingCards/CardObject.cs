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
    [SerializeField] private bool status = true;
    public bool Status { get{ return status; } }

    //~ Binding ~//

    //~ Event ~//
    public Action<bool> StatusChanged;

    //~ For Funcs ~//

    //~ Debug ~//
    private CardSprite cardSprite;

    /******* EVENT FUNC *******/
    private void Awake() 
    {
        Init();
    }

    /******* INTERFACE IMPLEMENT *******/

    /******* METHOD *******/
    //~ Internal ~//

    //~ Event Listener ~//

    //~ External ~//
    public void Init()
    {
        cardSprite = GetComponent<CardSprite>();
    }
    private void Start() 
    {
        cardSprite.Init();
    }
    public void SetCard(pattern pattern, int number, bool status)
    {
        SetCard(pattern, number);
        this.status = status;
        StatusChanged(status);
    }
    
    public void SetCard(pattern pattern, int number)
    {
        cardPattern = pattern;
        cardNumber = number;
    }

    [ContextMenu("Flip()")]
    public void Flip()
    {
        status = !status;
        StatusChanged(status);
    }
}