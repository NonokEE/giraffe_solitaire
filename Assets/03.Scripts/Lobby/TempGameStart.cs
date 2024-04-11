using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary> </summary>
/// <remarks>
///
/// </remarks>
public class TempGameStart : MonoBehaviour
{
    /******* FIELD *******/
    //~ Properties ~//

    //~ Bindings ~//

    //~ For Funcs ~//

    //~ Debug ~//
    private Button startButton;

    /******* EVENT FUNC *******/
    private void Start() 
    {
        startButton = GetComponent<Button>();
        startButton.onClick.AddListener(()=>{SceneManager.LoadScene("Game-Klonedike");});
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
}