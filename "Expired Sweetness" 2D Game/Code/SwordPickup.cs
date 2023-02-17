using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
public class SwordPickup : MonoBehaviour
{
    public PlayerController player_script;
    public AudioSource swordEquipSound;

    private bool pickUpAllowed;

    // Update is called once per frame
    void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
        {
            player_script.swordEquip = true;
            swordEquipSound.Play();
            PickUpWeapon();

        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            pickUpAllowed = true;
        }
    }

    private void PickUpWeapon()
    {
        Destroy(gameObject);
    }
}
