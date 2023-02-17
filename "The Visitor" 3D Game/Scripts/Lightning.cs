using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    bool Co_active;
    public static bool stopLightning;
    public AudioSource audio;
    public GameObject lightGameObject;
    // Start is called before the first frame update
    void Start()
    {
        lightGameObject.SetActive(false);
        Co_active = false;
        stopLightning = false;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Co_active && !stopLightning)
        {
            StartCoroutine("Clap");
        }
    }
    IEnumerator Clap()
    {
        Co_active = true;
        yield return new WaitForSeconds(7);
        lightGameObject.SetActive(true);
        yield return new WaitForSeconds(.05f);
        lightGameObject.SetActive(false);
        yield return new WaitForSeconds(.05f);
        lightGameObject.SetActive(true);
        audio.Play();
        yield return new WaitForSeconds(1f);
        lightGameObject.SetActive(false);
        yield return new WaitForSeconds(10);
        Co_active = false;

    }

}
