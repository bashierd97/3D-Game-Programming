// Bashier Dahman
// Simple script to display the JSON output in the play game
// scene only for the professor and TA to view and see that it works
// as intended 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlaySceneJSONOutput : MonoBehaviour
{
    public InputField jsonPlayScene;

    public void JSONButton()
    {
        // get the player preference 
        jsonPlayScene.text = PlayerPrefs.GetString("JSONOutput");
    }
}
