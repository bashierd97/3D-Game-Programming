using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public bool moveLock = false;
    // public Camera camera;
    bool isCrouch = false;
   
    private static PlayerMovement instance;

    public static PlayerMovement Instance { get { return instance; } }

    public void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }

    }
    
   

    // Update is called once per frame
    void Update()
    {
        if(!moveLock){
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);
            if (Input.GetKeyDown("c"))  {

                if (isCrouch)
                {
                    //camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y + 3.7f, camera.transform.position.z);
                    transform.localScale = new Vector3(transform.localScale.x, 1F, 1);
                    transform.position = new Vector3(transform.position.x, 3.12F, transform.position.z);
                    isCrouch = false;
                    speed = 12f;
                }
                else
                {
                    //camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y - 3.7f, camera.transform.position.z);
                    transform.localScale = new Vector3(transform.localScale.x, 0.3F, transform.localScale.y);
                    transform.position = new Vector3(transform.position.x, 1, transform.position.z);
                    isCrouch = true;
                    speed = 3f;
                }
            }
        }
        
    }
}
