using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using PlayingCards;

/// <summary> Component for management of card sprite  </summary>
/// <remarks>
///
/// </remarks>
public class CardSprite : MonoBehaviour
{
    /******* FIELD *******/
    //~ SerializeField ~//
    [SerializeField] private Sprite frontSprite;
    [SerializeField] private Sprite backSprite;

    //~ Bindings ~//
    private Image image;
    private CardObject cardObject;

    //~ For Funcs ~//

    //~ Debug ~//

    /******* EVENT FUNC *******/

    /******* INTERFACE IMPLEMENT *******/

    /******* METHOD *******/
    //~ Internal ~//
    private void GetSprite(Deck deck)
    {
        string cardString;
        switch(cardObject.CardPattern)
        {
            case pattern.SPADE: cardString = "s"; break;
            case pattern.DIA  : cardString = "d"; break;
            case pattern.HEART: cardString = "h"; break;
            case pattern.CLUB : cardString = "c"; break;
            default           : return;
        }
        cardString = cardObject.CardNumber.ToString() + cardString;

        frontSprite = Resources.Load<Sprite>(deck.SpritePath + cardString);
        backSprite  = deck.BackSprite;
    }

    //~ Event Listener ~//
    private void UpdateStatus(bool status)
    {
        if(status) image.sprite = frontSprite;
        else       image.sprite = backSprite;
    }

    //~ External ~//
    public void Init(Deck deck)
    {
        // Binding //
        cardObject = GetComponent<CardObject>();
        image = GetComponent<Image>();

        // Initiations //
        GetSprite(deck);
        UpdateStatus(cardObject.Status);

        // Event Binding //
        cardObject.StatusChanged += UpdateStatus;
    }

}