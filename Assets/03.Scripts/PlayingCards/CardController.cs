using System;
using System.Collections;
using System.Collections.Generic;
using PlayingCards;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.ShortcutManagement;
using UnityEngine;

/// <summary> 개별 카드에 대한 주 컨트롤러. </summary>
/// <remarks>
/// 카드의 물리적 상태(Status), 게임적 상태(Attribute) 등을 정의하고, 조작 상호작용 및 스프라이트 제어 객체와의 연결 중추 역할을 함.
/// </remarks>
public class CardController : AbsCardControllerStrategy
{
    /******* FIELD *******/
    //~ Status ~//
    [SerializeField] private CardStatus status;
    /// <remarks>카드의 게임엔진상 상태. IDLE, HOLDING, STICK 등.</remarks>
    public override CardStatus Status { get{ return status; } }

    [SerializeField] private IDeck deck;
    public override IDeck Deck { get{ return deck; } set{deck = value; } }

    //~ Attribute ~//
    [SerializeField] private CardPattern pattern;
    public override CardPattern Pattern { get{ return pattern; } }

    [SerializeField] private CardColor color;
    public override CardColor Color { get{ return color; } }

    [SerializeField] private int number;
    public override int Number { get{ return number; } }

    [SerializeField] private bool isOpened = true;
    public override bool IsOpened { get{ return isOpened; } }

    //~ Strategies ~//
    private AbsCardSpriteStrategy cardSpriteStrategy;
    private AbscardPlayStrategy cardPlayStrategy;

    //~ Binding ~//

    //~ Delegate & Event ~//
    public Action<bool> E_Fliped = (value) => {};

    //~ Debug ~//

    /******* EVENT FUNC *******/

    /******* INTERFACE IMPLEMENT *******/
    public override void Initiate()
    {
        //! Strategy 바뀔 때 이 부분을 수정 !//
        cardSpriteStrategy = gameObject.AddComponent<CardSprite>();

        /////////////////////////////////////
        cardSpriteStrategy.Controller = this;
        cardSpriteStrategy.BackSprite = Resources.Load<Sprite>(deck.BackSpritePath);
        cardSpriteStrategy.Initiate();
        E_Fliped += cardSpriteStrategy.FlipCallback;
    }

    public override void SetOpened(bool isOpened)
    {
        if (this.isOpened != isOpened) E_Fliped(isOpened);
        this.isOpened = isOpened;
    }

    public override void SetCard(CardPattern pattern, int number)
    {
        this.pattern = pattern;
        switch(pattern)
        {
            case CardPattern.SPADE: color = CardColor.BLACK; break;
            case CardPattern.CLUB : color = CardColor.BLACK; break;
            case CardPattern.DIA  : color = CardColor.RED  ; break;
            case CardPattern.HEART: color = CardColor.RED  ; break;
        }
        this.number = number;
        SetOpened(isOpened);
    }

    public override void SetCard(CardPattern pattern, int number, bool isOpened)
    {
        this.isOpened = isOpened;
        SetCard(pattern, number);
    }
    /******* METHOD *******/
    //~ Internal ~//
    /// <summary> Summary </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <param name="paraName"> param description </param>
    /// <returns>  </returns>
    //~ Event Listener ~//

    //~ External ~//

    //~ Event Listener ~//

    //~ External ~//
}