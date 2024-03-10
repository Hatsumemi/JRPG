using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamesMenu : MonoBehaviour
{
    public Canvas Settings;

    public void OnClickStart()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void OnClickSettings()
    {
        Settings.gameObject.SetActive(true);
    }

    public void OnClickQuit()
    {
        //If we are running in a standalone build of the game
#if UNITY_STANDALONE
        //Quit the application
        Application.Quit();
#endif

        //If we are running in the editor
#if UNITY_EDITOR
        //Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void OnClickBack()
    {
        Settings.gameObject.SetActive(false);
    }
}
