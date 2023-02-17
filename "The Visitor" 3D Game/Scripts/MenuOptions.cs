using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuOptions : MonoBehaviour
{
    public Camera MenuCam, PlayerCam;
    public bool playerCam = false;
    public GameObject rainUI;
    public void LoadSceneAbout()
    {
        SceneManager.LoadScene("Credits");
    }
    public void LoadSceneSettings()
    {
        SceneManager.LoadScene("Settings");
    }
    
    public void LoadSceneQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        //set the PlayMode too stop
#else
        Application.Quit();
#endif
    }
    public void LoadScenePlay()
    {
        MenuCam.gameObject.SetActive(false);
        PlayerCam.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        rainUI.SetActive(false);
        playerCam = true;
    }
    public void LoadSceneMain()
    {
        MenuCam.gameObject.SetActive(true);
        PlayerCam.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;
        playerCam = false;
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadSceneMainMenu()
    {
        Cursor.lockState = CursorLockMode.Confined;
        playerCam = false;
        SceneManager.LoadScene("MainMenu");
    }

}
