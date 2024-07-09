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
public class CardSprite : AbsCardSpriteStrategy
{
    /******* FIELD *******/
    //~ Attribute ~//
    [SerializeField] private Sprite frontSprite;
    public override Sprite FrontSprite { get{ return frontSprite; } }

    [SerializeField] private Sprite backSprite;
    public override Sprite BackSprite { get{ return backSprite; } set{ backSprite = value;} }

    [Space]

    //~ Bindings ~//
    [SerializeField] private AbsCardControllerStrategy controller;
    public override AbsCardControllerStrategy Controller { get { return controller; } set{ controller = value;} }
    private Image currentImage;

    //~ For Funcs ~//
    [SerializeField] private string spritePath = "PlayingCards/";

    //~ Debug ~//

    /******* EVENT FUNC *******/
    public override void Initiate()
    {
        currentImage = GetComponent<Image>();
        GetSprite();
    }

    /******* INTERFACE IMPLEMENT *******/
    public override void FlipCallback(bool value)
    {
        UpdateSprite(value);
    }
    
    /******* METHOD *******/
    //~ Internal ~//
    private void GetSprite()
    {
        string cardString;
        switch(Controller.Pattern)
        {
            case CardPattern.SPADE: cardString = "s"; break;
            case CardPattern.DIA  : cardString = "d"; break;
            case CardPattern.HEART: cardString = "h"; break;
            case CardPattern.CLUB : cardString = "c"; break;
            default           : return;
        }
        cardString = Controller.Number.ToString() + cardString;

        frontSprite = Resources.Load<Sprite>(spritePath + cardString);
    }

    //~ Event Listener ~//
    private void UpdateSprite(bool value)
    {
        if(value) currentImage.sprite = FrontSprite;
        else      currentImage.sprite = BackSprite;
    }

    //~ External ~//
}