using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeEntersManager : MonoBehaviour
{
    public AudioClip lights, enters, thunder;
    public GameObject lightning;
    public AudioSource audio, deathSound;
    public Animator animator;
    public Animator DeathAnim;
    public GameObject light1, light2, light3, light4;

    public GameObject interactiveUI, gameOverText, mainMenuButton;

    bool safe;

    bool Co_active;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        safe = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        MouseLook.screenLock = false;
        PlayerMovement.Instance.moveLock = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void playeLights()
    {
        audio.PlayOneShot(lights);
        Lightning.stopLightning = true;
    }
    public void playeEnter()
    {
        light1.SetActive(false);
        light2.SetActive(false);
        light3.SetActive(false);
        animator.SetTrigger("OpenDoor");
        audio.PlayOneShot(enters);
        StartCoroutine("Leave");
    }
    private void OnTriggerEnter(Collider collision)
    {
        safe = true;
    }
    private void OnTriggerStay(Collider collision)
    {
        
    }
    private void OnTriggerExit(Collider collision)
    {
        safe = false;
    }
    IEnumerator Leave()
    {
        Co_active = true;
        yield return new WaitForSeconds(8);
        audio.PlayOneShot(lights);
        light4.SetActive(false);
        //audio.Play();
        yield return new WaitForSeconds(3);
        if (!safe)
        {
            audio.PlayOneShot(thunder);
            lightning.SetActive(true);
            DeathAnim.SetTrigger("isKill");
            deathSound.Play();
            yield return new WaitForSeconds(1);
            lightning.SetActive(false);
            yield return new WaitForSeconds(3);
            Time.timeScale = 0f;
            gameOverText.SetActive(true);
            mainMenuButton.SetActive(true);
            interactiveUI.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            MouseLook.screenLock = true;
            PlayerMovement.Instance.moveLock = true;
        }
        else
        {
            audio.PlayOneShot(lights);
            light1.SetActive(true);
            light2.SetActive(true);
            light3.SetActive(true);
            light4.SetActive(true);
        }
        Lightning.stopLightning = false;

        Co_active = false;

    }
}
