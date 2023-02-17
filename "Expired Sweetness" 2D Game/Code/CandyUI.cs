// Bashier Dahman

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CandyUI : MonoBehaviour
{

    public PlayerController player_controller;
    public Text CandiesCollected;
    public Text NumberBox;
    int zero = 0;

    void Start() {

        CandiesCollected.text = zero.ToString();

    }

    // Update is called once per frame
    void Update()    {
        
       int numCandyCollected = player_controller.numExpiredCandy;

       CandiesCollected.text = numCandyCollected.ToString();
        
    }


} // class
