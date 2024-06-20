using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using PlayingCards;

[RequireComponent(typeof(Image))]
/// <summary> Component for management of card sprite  </summary>
/// <remarks>
///
/// </remarks>
public class CardSprite : MonoBehaviour, ICardSpriteStrategy
{
    /******* FIELD *******/
    //~ Attribute ~//
    [SerializeField] private Sprite frontSprite;
    public Sprite FrontSprite { get{ return frontSprite; } }

    [SerializeField] private Sprite backSprite;
    public Sprite BackSprite { get{ return backSprite; } set{ backSprite = value;} }

    //~ Bindings ~//
    public CardController Controller { get; set; }
    private Image currentImage;

    //~ For Funcs ~//
    [SerializeField] private string spritePath = "PlayingCards/";

    //~ Debug ~//

    /******* EVENT FUNC *******/
    private void Awake()
    {
        currentImage = GetComponent<Image>();

        GetSprite();
    }

    /******* INTERFACE IMPLEMENT *******/
    public void FlipCallback(bool value)
    {
        UpdateSprite(value);
    }
    
    /******* METHOD *******/
    //~ Internal ~//
    private void GetSprite()
    {
        // string cardString;
        // switch(Controller.Pattern)
        // {
        //     case cardPattern.SPADE: cardString = "s"; break;
        //     case cardPattern.DIA  : cardString = "d"; break;
        //     case cardPattern.HEART: cardString = "h"; break;
        //     case cardPattern.CLUB : cardString = "c"; break;
        //     default           : return;
        // }
        // cardString = Controller.Number.ToString() + cardString;

        frontSprite = Resources.Load<Sprite>(spritePath + gameObject.name);
    }

    //~ Event Listener ~//
    private void UpdateSprite(bool value)
    {
        if(value) currentImage.sprite = FrontSprite;
        else      currentImage.sprite = BackSprite;
    }

    //~ External ~//

}