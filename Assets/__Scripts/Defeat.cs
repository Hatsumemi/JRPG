using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Defeat : MonoBehaviour
{
    public Image Fade;
    void Start()
    {
        Fade.DOFade(0, 1);
        StartCoroutine(GoBackStart());
    }

    IEnumerator GoBackStart()
    {
        yield return new WaitForSeconds(4);
        Fade.DOFade(1, 1);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }


}
