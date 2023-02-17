using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class UIController : MonoBehaviour
{
    // awake function that will be called in the beginning of the script
    void Awake()
    {
        // print out just a friendly message for now

    }

    // this will load the play game scene 
    public void PlayGame()
    {
        // we know that the only button that will call this function is in scene index 0
        // loading the next scene index will load the play screen 
        SceneManager.LoadScene(1);
        Cursor.lockState = CursorLockMode.Locked;
    }

    // this function will be used to quit the game
    public void QuitGame()
    {
        // print out to the screen that we're quitting the game
        Debug.Log("Quitting Game");
        // this section essentially will close the play mode editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

#else
        // if its not in editor mode:
        // quit application
        Application.Quit();
#endif
    }

    // this function will serve the purpose as a back button from play scene -> menu ui
    public void BackButton()
    {
        // this will load the previous scene index, which will be the MENU UI
        SceneManager.LoadScene(0);
    }

    // this function will serve the purpose as the settings button in menu ui
    public void SettingsButton()
    {
        // this will load the the settings scene index
        SceneManager.LoadScene(2);
    }

    // this function will serve the purpose as the about button in menu ui
    public void AboutButton()
    {
        // this will load the about scene index
        SceneManager.LoadScene(3);
    }

    public void RestartPlayGame()
    {
        // we know that the only button that will call this function is in scene index 0
        // loading the next scene index will load the play screen 
        SceneManager.LoadScene("PlatformGameScene");
    }

}
