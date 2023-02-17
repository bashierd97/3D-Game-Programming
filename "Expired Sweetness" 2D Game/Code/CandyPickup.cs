using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
public class CandyPickup : MonoBehaviour
{
    public PlayerController playercontroller_script;

    private bool pickupCandy;
    public bool doubleCandy;

    public AudioSource candyPickupSound;

    // Update is called once per frame
    void Update()
    {
        if (pickupCandy && Input.GetKeyDown(KeyCode.P))
        {
            if (doubleCandy)
                playercontroller_script.numExpiredCandy += 2;
            else
                playercontroller_script.numExpiredCandy += 1;
            PickUp_ExpiredCandy();
            candyPickupSound.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            pickupCandy = true;
        }
    }

    private void PickUp_ExpiredCandy()
    {
        Destroy(gameObject);
    }
}
