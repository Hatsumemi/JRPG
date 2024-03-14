using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject Button;
    public GameObject SelectedButton;

    private void Start()
    {
        Button.gameObject.SetActive(true);
        SelectedButton.gameObject.SetActive(false);
    }

    public void EnterCursor()
    {
        Button.gameObject.SetActive(false);
        SelectedButton.gameObject.SetActive(true);
    }

    public void ExitCursor()
    {
        Button.gameObject.SetActive(true);
        SelectedButton.gameObject.SetActive(false);
    }
}
