using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public Canvas Pause;
    public Canvas Settings;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnClickPause();
        }
    }
    public void OnClickPause()
    {
        Time.timeScale = 0f;
        Pause.gameObject.SetActive(true);
    }

    public void OnClickResume()
    {
        Pause.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void OnClickSettings()
    {
        Pause.gameObject.SetActive(false);
        Settings.gameObject.SetActive(true);
    }

    public void OnClickRestart()
    {
        Pause.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainGame");
    }

    public void OnClickQuit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void OnClickBack()
    {
        Pause.gameObject.SetActive(true);
    }
}
