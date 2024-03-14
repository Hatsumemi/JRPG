using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Canvas Pause;
    public Canvas Settings;
    public Image Fade;

    private void Start()
    {
        Fade.DOFade(0, 2);
        StartCoroutine(WaitToStart());
    }



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
        Fade.gameObject.SetActive(true);
        Fade.DOFade(1, 2);
        Pause.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        StartCoroutine(WaitToRestart());
    }

    public void OnClickQuit()
    {
        Fade.gameObject.SetActive(true);
        Fade.DOFade(1, 2);
        Time.timeScale = 1f;
    }

    public void OnClickBack()
    {
        Settings.gameObject.SetActive(false);
        Pause.gameObject.SetActive(true);
    }

    IEnumerator WaitToStart()
    {
        yield return new WaitForSeconds(2);
        Fade.gameObject.SetActive(false);
    }

    IEnumerator WaitToRestart()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MainGame");
    }

    IEnumerator WaitToMenu()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MainMenu");
    }
}
