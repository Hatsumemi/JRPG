using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.PlayerLoop;

public class MenuManager : MonoBehaviour
{
    public Canvas Pause;
    public Canvas Settings;
    public Image Fade;
    public Character Characters;

    private void Start()
    {
        Fade.DOFade(0, 1);
        StartCoroutine(WaitToStart());
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnClickPause();
        }
        if (Enemy.IsEnemyAlive == false)
        {
            Fade.gameObject.SetActive(true);
            Fade.DOFade(1, 1);
            StartCoroutine(WaitToEnd02());
        }
        if (Ally.AllyDead == 2)
        {
            Fade.gameObject.SetActive(true);
            Fade.DOFade(1, 1);
            StartCoroutine(WaitToEnd02());
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
        Fade.DOFade(1, 1);
        Pause.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        StartCoroutine(WaitToRestart());
    }

    public void OnClickQuit()
    {
        Fade.gameObject.SetActive(true);
        Fade.DOFade(1, 1);
        Pause.gameObject.SetActive(false);
        Time.timeScale = 1f;
        StartCoroutine(WaitToMenu());
    }

    public void OnClickBack()
    {
        Settings.gameObject.SetActive(false);
        Pause.gameObject.SetActive(true);
    }


    IEnumerator WaitToStart()
    {
        yield return new WaitForSeconds(1);
        Fade.gameObject.SetActive(false);
    }

    IEnumerator WaitToRestart()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainGame");
    }

    IEnumerator WaitToMenu()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator WaitToEnd()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Defeat");
    }

    IEnumerator WaitToEnd02()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Victory");
    }

}
