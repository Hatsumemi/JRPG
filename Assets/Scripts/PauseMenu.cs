using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Canvas Pause;
    public void OnClickPause()
    {
        Pause.gameObject.SetActive(true);
    }

    public void OnClickBack()
    {
        Pause.gameObject.SetActive(false);
    }
}
