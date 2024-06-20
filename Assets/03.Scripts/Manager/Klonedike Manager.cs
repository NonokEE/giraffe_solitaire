using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.PlayerLoop;

/// <summary> </summary>
/// <remarks>
///
/// </remarks>
public class KlonedikeManager : MonoBehaviour
{
    /******* FIELD *******/
    //~ Properties ~//   
    [Header("Prefabs")]
    [SerializeField] private Deck deckPrefab;

    [Header("Positions")]
    [SerializeField] private Transform deckTransform;
    [SerializeField] private Transform intervalTransform;
    [SerializeField] private Transform lineGroupTransform;
    [SerializeField] private Transform baseGroupTransform;

    [Header("Configs")]
    [SerializeField] private int gameSeed = 0;

    //~ Bindings ~//

    //~ For Funcs ~//
    [Space]
    [Header("Debug - For Funcs")]
    private Deck deck = null;
    [SerializeField] private Transform[] lineTransform = new Transform[7];
    [SerializeField] private Transform[] baseTransform = new Transform[4];

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
    private void SetPosition()
    {
        deck.SetCardStatus(false);
        for(int lineIndex = 0 ; lineIndex < 7 ; lineIndex++)
        {
            for(int cardCount = 0 ; cardCount < lineIndex+1 ; cardCount++)
            {
                var card = deck.Draw();
                if (cardCount == lineIndex) card.SetOpened(true);
                card.transform.SetParent(lineTransform[lineIndex].transform);
            }
        }
    }

    //~ Event Listener ~//

    //~ External ~//
    [ContextMenu("KlonedikeManager.Init()")]
    public void Init()
    {
        for(int lineIndex = 0; lineIndex < 7; lineIndex++) lineTransform[lineIndex] = lineGroupTransform.GetChild(lineIndex);
        for(int baseIndex = 0; baseIndex < 4; baseIndex++) baseTransform[baseIndex] = baseGroupTransform.GetChild(baseIndex);

        SetGame();
    }

    public void SetGame()
    {
        //Initiate deck for game
        if (deck != null) Destroy(deck.gameObject);
        deck = Instantiate(deckPrefab, deckTransform);
        deck.Init();

        //Set Cards for Klonedike
        if (gameSeed == 0) deck.Shuffle(UnityEngine.Random.Range(0, int.MaxValue));
        else               deck.Shuffle(gameSeed);
        SetPosition();
    }
}