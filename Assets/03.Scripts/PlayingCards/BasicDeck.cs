using System.Collections;
using System.Collections.Generic;
using PlayingCards;
using UnityEngine;

/// <summary> </summary>
/// <remarks>
///
/// </remarks>
public class BasicDeck : MonoBehaviour, IDeck
{
    /******* FIELD *******/
    //~ Properties ~//
    [SerializeField, SerializeReference] protected ICardControllerStrategy cardControllerStrategy;
    [SerializeField] protected CardController cardController;
    public ICardControllerStrategy CardController { get { return cardControllerStrategy; } set { cardControllerStrategy = value; }}

    protected string backSpritePath = "PlayingCards/back";
    public string BackSpritePath { get { return backSpritePath; } set { backSpritePath = value; }}

    protected int remains;
    public int Remains { get{ return remains; }}

    //~ variables ~//

    //~ For Funcs ~//

    //~ Delegate & Event ~//

    //~ Debug ~//

    /******* EVENT FUNC *******/
    protected void OnDestroy() 
    {
        //foreach(CardController card in cards) Destroy(card.gameObject);
    }

    /******* INTERFACE IMPLEMENT *******/
    public virtual ICardControllerStrategy Draw()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Initialize(bool doShuffle)
    {
        remains = 52;

    }
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



}