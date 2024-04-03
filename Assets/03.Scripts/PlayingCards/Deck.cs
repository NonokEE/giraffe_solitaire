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
    [SerializeField] private CardObject cardPrefab;
    [SerializeField] private string spritePath;
    public string SpritePath { get{ return spritePath; }}
    [SerializeField] private Sprite backSprite;
    public Sprite BackSprite { get{ return backSprite; }}
    [Space]
    [SerializeField] private int shuffleCount = 52;
    [SerializeField] private int randomSeed = 10000000;


    //~ Bindings ~//
    [Space]
    [SerializeField] private List<CardObject> cards;

    //~ For Funcs ~//

    //~ Debug ~//

    /******* EVENT FUNC *******/

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
    [ContextMenu("Init()")]
    public void Init()
    {
        string[] patterns = {"s", "d", "h", "c"};

        foreach(pattern p in Enum.GetValues(typeof(pattern)))
        {
            if (p == pattern.NONE) continue;
            for(int number = 1 ; number < 14 ; number++)
            {
                CardObject newCard = Instantiate(cardPrefab, transform);
                string cardName = p.ToString() + number.ToString();
                
                newCard.name = cardName;
                newCard.Init(this, p, number);

                cards.Add(newCard);
            }
        }
    }

    [ContextMenu("Shuffle()")]
    public void Shuffle()
    {
        UnityEngine.Random.InitState(randomSeed);
        int randNum;
        CardObject temp;
        int count = shuffleCount;

        while(count-- > 0)
        {
            randNum = UnityEngine.Random.Range(0, count);

            temp = cards[randNum];
            cards[randNum] = cards[count];
            cards[count] = temp;
        }
    }
}
