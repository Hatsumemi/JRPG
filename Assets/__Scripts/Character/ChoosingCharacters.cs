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
    private string _choosed01;
    private string _choosed02;


    private void Start()
    {
        Fade.DOFade(0, 1);
        StartCoroutine(WaitToChoose());
        _choosed01 = "Warrior";
        _choosed02 = "Bowman";
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
        PlayerPrefs.SetString("char01", _choosed01);
        PlayerPrefs.SetString("char02", _choosed02);

        Fade.gameObject.SetActive(true);
        Fade.DOFade(1,1);
        StartCoroutine(WaitForStart());
    }

    public void Warrior()
    {
        if (_character01)
        {
            Character01.gameObject.GetComponent<Image>().sprite = WarriorImage;
            _choosed01 = "Warrior";
        }
        if (_character02)
        {
            Character02.gameObject.GetComponent<Image>().sprite = WarriorImage;
            _choosed02 = "Warrior";
        }
    }

    public void Paladin()
    {
        if (_character01)
        {
            Character01.gameObject.GetComponent<Image>().sprite = PaladinImage;
            _choosed01 = "Paladin";
        }
        if (_character02)
        {
            Character02.gameObject.GetComponent<Image>().sprite = PaladinImage;
            _choosed02 = "Paladin";
        }
    }

    public void Wizzard()
    {
        if (_character01)
        {
            Character01.gameObject.GetComponent<Image>().sprite = WizzardImage;
            _choosed01 = "Wizzard";
        }
        if (_character02)
        {
            Character02.gameObject.GetComponent<Image>().sprite = WizzardImage;
            _choosed02 = "Wizzard";
        }
    }

    public void Mage()
    {
        if (_character01)
        {
            Character01.gameObject.GetComponent<Image>().sprite = MageImage;
            _choosed01 = "Mage";
        }
        if (_character02)
        {
            Character02.gameObject.GetComponent<Image>().sprite = MageImage;
            _choosed02 = "Mage";
        }
    }

    public void Bowman()
    {
        if (_character01)
        {
            Character01.gameObject.GetComponent<Image>().sprite = BowmanImage;
            _choosed01 = "Bowman";
        }
        if (_character02)
        {
            Character02.gameObject.GetComponent<Image>().sprite = BowmanImage;
            _choosed02 = "Bowman";
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
