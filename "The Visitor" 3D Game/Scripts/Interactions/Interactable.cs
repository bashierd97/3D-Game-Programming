using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Start is called before the first frame update
    public int index;
    public bool b_yes;
    public bool b_no;
    public bool b_ok;
    public string message;
    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.name == "First Person Player" && Input.GetMouseButtonDown(0))
        {
            ObjectTrigger.Instance.triggerActivated(index, b_yes, b_no, b_ok, message);
        }
    }
}
