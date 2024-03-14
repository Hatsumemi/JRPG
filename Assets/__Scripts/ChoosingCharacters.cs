using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class ChoosingCharacters : MonoBehaviour
{
    public GameObject Character01;
    public GameObject Character02;

    bool _character01 = false;
    bool _character02 = false;

    public Sprite WarriorImage;
    public Sprite PaladinImage;
    public Sprite WizzardImage;
    public Sprite MageImage;
    public Sprite BowmanImage;

    private void Start()
    {
        PlayerPrefs.SetString("character01", "warrior");
        PlayerPrefs.SetString("character02", "bowman");
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

    public void Warrior()
    {
        if (_character01)
        {
            Character01.gameObject.GetComponent<Image>().sprite = WarriorImage;
            PlayerPrefs.SetString("character01", "warrior");
        }
        if (_character02)
        {
            Character02.gameObject.GetComponent<Image>().sprite = WarriorImage;
            PlayerPrefs.SetString("character02", "warrior");
        }
    }

    public void Paladin()
    {
        if (_character01)
        {
            Character01.gameObject.GetComponent<Image>().sprite = PaladinImage;
            PlayerPrefs.SetString("character01", "paladin");
        }
        if (_character02)
        {
            Character02.gameObject.GetComponent<Image>().sprite = PaladinImage;
            PlayerPrefs.SetString("character02", "paladin");
        }
    }

    public void Wizzard()
    {
        if (_character01)
        {
            Character01.gameObject.GetComponent<Image>().sprite = WizzardImage;
            PlayerPrefs.SetString("character01", "wizzard");
        }
        if (_character02)
        {
            Character02.gameObject.GetComponent<Image>().sprite = WizzardImage;
            PlayerPrefs.SetString("character02", "wizzard");
        }
    }

    public void Mage()
    {
        if (_character01)
        {
            Character01.gameObject.GetComponent<Image>().sprite = MageImage;
            PlayerPrefs.SetString("character01", "mage");
        }
        if (_character02)
        {
            Character02.gameObject.GetComponent<Image>().sprite = MageImage;
            PlayerPrefs.SetString("character02", "mage");
        }
    }

    public void Bowman()
    {
        if (_character01)
        {
            Character01.gameObject.GetComponent<Image>().sprite = BowmanImage;
            PlayerPrefs.SetString("character01", "bowman");
        }
        if (_character02)
        {
            Character02.gameObject.GetComponent<Image>().sprite = BowmanImage;
            PlayerPrefs.SetString("character02", "bowman");
        }
    }
}
