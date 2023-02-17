using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
public class VaccineEndGameScript : MonoBehaviour
{
    public PlayerController playercontroller_script;

    public GameObject victoryText;
    private bool creditSceneActive;

    public AudioSource endGameSound;

    [SerializeField]
    private float delayBeforeLoading = 4f;

    private float timeElapsed = 0;

    void Start() {
        victoryText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (creditSceneActive && Input.GetKeyDown(KeyCode.J))
        {
            playercontroller_script.rb2d.constraints = RigidbodyConstraints2D.FreezePosition;
            endGameSound.Play();
            StartCoroutine(WaitForIt(3.5F));
            
            /*
            while(timeElapsed <= delayBeforeLoading)
                timeElapsed += Time.deltaTime;
            if(timeElapsed > delayBeforeLoading) { 
                SceneManager.LoadScene(4);
            }
            */

        }
    }

    IEnumerator WaitForIt(float waitTime) {
        victoryText.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(4);
     }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            creditSceneActive = true;
        }
    }

}
