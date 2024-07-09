using System;
using System.Collections;
using System.Collections.Generic;
using PlayingCards;
using UnityEngine;

/// <summary> </summary>
/// <remarks>
///
/// </remarks>
public class KlonedikeDeck : BasicDeck
{
    /******* FIELD *******/
    //~ Properties ~//

    //~ Bindings ~//

    //~ For Funcs ~//

    //~ Delegate & Event ~//

    //~ Debug ~//

    /******* EVENT FUNC *******/

    /******* INTERFACE IMPLEMENT *******/

    /******* METHOD *******/
    //~ Internal ~//

    //~ Event Listener ~//

    //~ External ~//
    /// <summary> 기본 초기화. 셔플 사용.</summary>
    public override void Initialize(int randomSeed)
    {

    }
    /// <summary> 기본 초기화. </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <param name="randomSeed"> randomSeed를 0으로 설정할 시 셔플하지 않음. </param>
    /// <returns>  </returns>
    
    [ContextMenu("Initialize()")]
    public override void Initialize()
    {
        //TODO 클론다이크용 셔플 필요
        
        //~ 덱 초기화 ~//
        foreach(AbsCardControllerStrategy card in cards) Destroy(card.gameObject);
        cards.Clear();

        //~ 덱 재생성 ~//
        foreach(CardPattern pattern in Enum.GetValues(typeof(CardPattern)))
        {
            if (pattern == CardPattern.NONE) continue;
            for(int number = 1 ; number < 14 ; number++)
            {
                AbsCardControllerStrategy newCard = Instantiate(cardPrefab, transform);

                newCard.name = pattern.ToString() + number.ToString();
                newCard.Deck = this;
                
                newCard.SetCard(pattern, number);
                newCard.Initiate();

                cards.Add(newCard);
                remains += 1;
                
            }
        }

        //~ 셔플 ~//
        // AbsCardControllerStrategy tempCard;
        // int randNum;
        // for(int deckIndex = 51 ; deckIndex >= 0 ; deckIndex--)
        // {

        // }
    }
    public override AbsCardControllerStrategy Draw()
    {
        throw new System.NotImplementedException();
    }
}