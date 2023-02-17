using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParticleHandler : MonoBehaviour
{
    public GameObject P_RecordPlayer;
    PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerMovement.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.transform.position, P_RecordPlayer.transform.position) > 5)
        {
            P_RecordPlayer.SetActive(false);
        }
        else
        {
            P_RecordPlayer.SetActive(true);
        }
    }
}
