using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using PlayingCards;
using System;

/// <summary> Main component of default playing card deck. </summary>
/// <remarks>
///
/// </remarks>
public class Deck : MonoBehaviour
{
    /******* FIELD *******/
    //~ Properties ~//
    [SerializeField] private CardController cardPrefab;
    [SerializeField] private string spritePath;
    public string SpritePath { get{ return spritePath; }}
    [SerializeField] private Sprite backSprite;
    public Sprite BackSprite { get{ return backSprite; }}
    [Space]
    [SerializeField] private int shuffleCount;

    //~ Bindings ~//
    [Space]
    [SerializeField] private List<CardController> cards;

    //~ For Funcs ~//
    private int remains;

    //~ Debug ~//

    /******* EVENT FUNC *******/
    private void OnDestroy() 
    {
        foreach(CardController card in cards) Destroy(card.gameObject);
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
    public void Init()
    {
        string[] patterns = {"s", "d", "h", "c"};

        cards.Clear();
        foreach(cardPattern p in Enum.GetValues(typeof(cardPattern)))
        {
            if (p == cardPattern.NONE) continue;
            for(int number = 1 ; number < 14 ; number++)
            {
                CardController newCard = Instantiate(cardPrefab, transform);
                string cardName = p.ToString() + number.ToString();
                
                newCard.name = cardName;
                newCard.Deck = this;
                newCard.SetCard(p, number);

                cards.Add(newCard);
            }
        }

        remains = 52;
    }
    public void Shuffle(int randomSeed)
    {
        UnityEngine.Random.InitState(randomSeed);
        int randNum;
        CardController temp;
        int count = shuffleCount;

        while(count-- > 0)
        {
            randNum = UnityEngine.Random.Range(0, count);

            temp = cards[randNum];
            cards[randNum] = cards[count];
            cards[count] = temp;
        }
    }
    /// <summary> Draw top card from deck. </summary>
    public CardController Draw()
    {
        if (remains > 0) return cards[--remains];
        else
        {
            Debug.Log("No card remains in " + name);
            return null;
        }
    }

    public void SetCardStatus(bool stat)
    {
        foreach(CardController card in cards) card.SetOpened(stat);
    }
}
