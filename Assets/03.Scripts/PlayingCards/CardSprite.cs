using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using PlayingCards;

/// <summary> Component for management of card sprite  </summary>
/// <remarks>
///
/// </remarks>
public class CardSprite : MonoBehaviour, ICardSpriteStrategy
{
    /******* FIELD *******/
    //~ SerializeField ~//
    [SerializeField] private Sprite frontSprite;
    [SerializeField] private Sprite backSprite;

    //~ Bindings ~//
    public CardController Controller { get; set; }

    private Image image;

    //~ For Funcs ~//

    //~ Debug ~//

    /******* EVENT FUNC *******/

    /******* INTERFACE IMPLEMENT *******/

    /******* METHOD *******/
    //~ Internal ~//
    private void GetSprite(Deck deck)
    {
        string cardString;
        switch(Controller.Pattern)
        {
            case cardPattern.SPADE: cardString = "s"; break;
            case cardPattern.DIA  : cardString = "d"; break;
            case cardPattern.HEART: cardString = "h"; break;
            case cardPattern.CLUB : cardString = "c"; break;
            default           : return;
        }
        cardString = Controller.Number.ToString() + cardString;

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
        image = GetComponent<Image>();

        // Initiations //
        GetSprite(deck);
        UpdateStatus(cardObject.Status);

        // Event Binding //
        cardObject.StatusChanged += UpdateStatus;
    }

}