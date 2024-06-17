using System.Collections;
using System.Collections.Generic;
using PlayingCards;
using UnityEditor.ShortcutManagement;
using UnityEngine;

/// <summary> 개별 카드에 대한 주 컨트롤러. </summary>
/// <remarks>
/// 카드의 물리적 상태(Status), 게임적 상태(Attribute) 등을 정의하고, 조작 상호작용 및 스프라이트 제어 객체와의 연결 중추 역할을 함.
/// </remarks>
public class CardController : MonoBehaviour
{
    /******* FIELD *******/
    //~ Status ~//
    [SerializeField] private cardStatus status;
    /// <remarks>카드의 게임엔진상 상태. IDLE, HOLDING, STICK 등.</remarks>
    public cardStatus Status {get {return status;} }

    //~ Attribute ~//
    [SerializeField] private cardPattern pattern;
    public cardPattern Pattern {get {return pattern;} }

    [SerializeField] private cardColor color;
    public cardColor Color {get {return color;} }

    [SerializeField] private int number;
    public int Number {get {return number;} }

    [SerializeField] private bool isOpen;
    public bool IsOpen {get {return isOpen;} }

    //~ Strategies ~//
    private ICardSpriteStrategy cardSpriteStrategy;
    private ICardPlayStrategy cardPlayStrategy;
    private void InitiateStrategies()
    {
        //! Strategy 바뀔 때 이 부분을 수정 !//
        cardSpriteStrategy = gameObject.AddComponent<CardSprite>();
        cardSpriteStrategy.Controller = this;

        /////////////////////////////////////
    }

    //~ 
    
    //~ Debug ~//

    /******* EVENT FUNC *******/
    private void Awake() 
    {
        InitiateStrategies();
    }

    /******* INTERFACE IMPLEMENT *******/

    /******* METHOD *******/
    //~ Internal ~//
    /// <summary> Summary </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <param name="paraName"> param description </param>
    /// <returns>  </returns>

    /// <summary> Summary </summary>
    /// <remarks>
    /// 
    /// </remarks>

    //~ Event Listener ~//

    //~ External ~//
    
}