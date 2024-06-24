using System.Collections;
using System.Collections.Generic;
using PlayingCards;
using UnityEngine;

/// <summary>기초적인 덱 행동. 
/// 게임 종류와 관계 없이 행해지는 동작들을 먼저 정립하고, 게임별로 달라지는 행동은 BasicDeck을 상속받은 클래스에서 구현. 
/// abstract라서 자체적으로는 사용 불가.</summary>
/// <remarks>
///
/// </remarks>
public abstract class BasicDeck : AbsDeck
{
    /******* FIELD *******/
    //~ Properties ~//
    [SerializeField] protected AbsCardControllerStrategy cardPrefab;
    public override AbsCardControllerStrategy CardPrefab { get{ return cardPrefab; } set{ cardPrefab = value; } }

    [SerializeField] protected AbsCardControllerStrategy[] cards;
    public override AbsCardControllerStrategy[] Cards { get{ return cards; } }

    [Space]

    [SerializeField] private string backSpritePath;
    public override string BackSpritePath { get{ return backSpritePath; } set{} }

    [SerializeField] private int remains;
    public override int Remains => throw new System.NotImplementedException();


    //~ variables ~//

    //~ For Funcs ~//

    //~ Delegate & Event ~//

    //~ Debug ~//

    /******* EVENT FUNC *******/
    private void OnDestroy() 
    {
        foreach(AbsCardControllerStrategy card in Cards) Destroy(card.gameObject);
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

    //~ Event Listener ~//

    //~ External ~//
    public abstract override AbsCardControllerStrategy Draw();
    public abstract override void Initialize(bool doShuffle);

}