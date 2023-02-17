using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class FireScript : MonoBehaviour {

    public PlayerController player_script;

    private bool throwAwayCandy;

    public AudioSource candyThrowSound;

    // Update is called once per frame
    void Update() {
        if (throwAwayCandy && Input.GetKeyDown(KeyCode.P))  {
            player_script.numExpiredCandy = 0;
            candyThrowSound.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            throwAwayCandy = true;
        }
    }

}
