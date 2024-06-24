using System;
using System.Collections;
using System.Collections.Generic;
using PlayingCards;
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
    [SerializeField] private cardStatus status;
    /// <remarks>카드의 게임엔진상 상태. IDLE, HOLDING, STICK 등.</remarks>
    public override cardStatus Status {get {return status;} }

    public override Deck Deck { get; set; }
    private Deck deck;

    //~ Attribute ~//
    [SerializeField] private cardPattern pattern;
    public override cardPattern Pattern {get {return pattern;} }

    [SerializeField] private cardColor color;
    public override cardColor Color {get {return color;} }

    [SerializeField] private int number;
    public override int Number {get {return number;} }

    [SerializeField] private bool isOpened = true;
    public override bool IsOpened {get {return isOpened;} }

    //~ Strategies ~//
    private ICardSpriteStrategy cardSpriteStrategy;
    private ICardPlayStrategy cardPlayStrategy;

    //~ Binding ~//

    //~ Delegate & Event ~//
    public Action<bool> E_Fliped = (value) => {};

    //~ Debug ~//

    /******* EVENT FUNC *******/
    private void Awake() 
    {
        InitiateStrategies();
        E_Fliped(true);
    }

    /******* INTERFACE IMPLEMENT *******/
    public override void SetOpened(bool isOpened)
    {
        if (this.isOpened != isOpened) E_Fliped(isOpened);
        this.isOpened = isOpened;
    }

    public override void SetCard(cardPattern pattern, int number)
    {
        this.pattern = pattern;
        switch(pattern)
        {
            case cardPattern.SPADE: color = cardColor.BLACK; break;
            case cardPattern.CLUB : color = cardColor.BLACK; break;
            case cardPattern.DIA  : color = cardColor.RED  ; break;
            case cardPattern.HEART: color = cardColor.RED  ; break;
        }
        this.number = number;
    }

    public override void SetCard(cardPattern pattern, int number, bool isOpened)
    {
        SetCard(pattern, number);
        SetOpened(isOpened);
    }
    /******* METHOD *******/
    //~ Internal ~//
    /// <summary> Summary </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <param name="paraName"> param description </param>
    /// <returns>  </returns>
    private void InitiateStrategies()
    {
        //! Strategy 바뀔 때 이 부분을 수정 !//
        cardSpriteStrategy = gameObject.AddComponent<CardSprite>();

        /////////////////////////////////////
        cardSpriteStrategy.Controller = this;
        cardSpriteStrategy.BackSprite = Resources.Load<Sprite>("PlayingCards/back");
        //cardSpriteStrategy.BackSprite = deck.BackSprite;
        E_Fliped += cardSpriteStrategy.FlipCallback;
    }
    //~ Event Listener ~//

    //~ External ~//

    //~ Event Listener ~//

    //~ External ~//

    
}