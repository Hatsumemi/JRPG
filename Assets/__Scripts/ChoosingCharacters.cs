using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using DG.Tweening;

public class ChoosingCharacters : MonoBehaviour
{
    public GameObject Character01;
    public GameObject Character02;

    public Sprite WarriorImage;
    public Sprite PaladinImage;
    public Sprite WizzardImage;
    public Sprite MageImage;
    public Sprite BowmanImage;

    public Image Fade;

    bool _character01 = false;
    bool _character02 = false;


    private void Start()
    {
        Fade.DOFade(0, 1);
        StartCoroutine(WaitToChoose());
        PlayerPrefs.SetString("character01", "Warrior");
        PlayerPrefs.SetString("character02", "Bowman");
    }

    public void Char01Choosed()
    {
        _character01 = true;
        _character02 = false;
    }

    public void Char02Choosed()
    {
        _character01 = false;
        _character02 = true;
    }

    public void Validate()
    {
        Fade.gameObject.SetActive(true);
        Fade.DOFade(1,1);
        StartCoroutine(WaitForStart());
    }

    public void Warrior()
    {
        if (_character01)
        {
            Character01.gameObject.GetComponent<Image>().sprite = WarriorImage;
            PlayerPrefs.SetString("character01", "Warrior");
        }
        if (_character02)
        {
            Character02.gameObject.GetComponent<Image>().sprite = WarriorImage;
            PlayerPrefs.SetString("character02", "Warrior");
        }
    }

    public void Paladin()
    {
        if (_character01)
        {
            Character01.gameObject.GetComponent<Image>().sprite = PaladinImage;
            PlayerPrefs.SetString("character01", "Paladin");
        }
        if (_character02)
        {
            Character02.gameObject.GetComponent<Image>().sprite = PaladinImage;
            PlayerPrefs.SetString("character02", "Paladin");
        }
    }

    public void Wizzard()
    {
        if (_character01)
        {
            Character01.gameObject.GetComponent<Image>().sprite = WizzardImage;
            PlayerPrefs.SetString("character01", "Wizzard");
        }
        if (_character02)
        {
            Character02.gameObject.GetComponent<Image>().sprite = WizzardImage;
            PlayerPrefs.SetString("character02", "Wizzard");
        }
    }

    public void Mage()
    {
        if (_character01)
        {
            Character01.gameObject.GetComponent<Image>().sprite = MageImage;
            PlayerPrefs.SetString("character01", "Mage");
        }
        if (_character02)
        {
            Character02.gameObject.GetComponent<Image>().sprite = MageImage;
            PlayerPrefs.SetString("character02", "Mage");
        }
    }

    public void Bowman()
    {
        if (_character01)
        {
            Character01.gameObject.GetComponent<Image>().sprite = BowmanImage;
            PlayerPrefs.SetString("character01", "Bowman");
        }
        if (_character02)
        {
            Character02.gameObject.GetComponent<Image>().sprite = BowmanImage;
            PlayerPrefs.SetString("character02", "Bowman");
        }
    }


    IEnumerator WaitToChoose()
    {
        yield return new WaitForSeconds(1);
        Fade.gameObject.SetActive(false);
    }

    IEnumerator WaitForStart()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainGame");
    }
}
