using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class GamesMenu : MonoBehaviour
{
    public Canvas Settings;
    public Image Fade;

    private void Start()
    {
        Fade.DOFade(0, 2);
        StartCoroutine(WaitToBegin());
    }

    public void OnClickStart()
    {
        Fade.gameObject.SetActive(true);
        Fade.DOFade(1, 2);
        StartCoroutine (WaitToStart());
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

    IEnumerator WaitToBegin()
    {
        yield return new WaitForSeconds(2);
        Fade.gameObject.SetActive(false);
    }

    IEnumerator WaitToStart()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MainGame");
    }
}
