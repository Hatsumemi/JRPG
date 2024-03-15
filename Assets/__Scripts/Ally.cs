using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : Character
{
    public GameObject f;
    
    string _visuChoosed01;
    string _visuChoosed02;

    private void Start()
    {
        LoadVisu01();
        LoadVisu02();
        Character visu = GetComponent<Character>();

        if (gameObject.name == "Character01")
        {
            Transform _chara01 = transform.Find(_visuChoosed01);
            SpriteRenderer _toShow01SR = _chara01.GetComponent<SpriteRenderer>();
            Animator _toShow01A = _chara01.GetComponent<Animator>();
            if (_toShow01SR.name == _visuChoosed01) 
            {
                _chara01.gameObject.SetActive(true);
                visu.Visual = _toShow01SR;
                visu.CharacterAnimator = _toShow01A;
            }
        }
        if (gameObject.name == "Character02")
        {
            Transform _chara02 = transform.Find(_visuChoosed02);
            SpriteRenderer _toShow02SR = _chara02.GetComponent<SpriteRenderer>();
            Animator _toShow02A = _chara02.GetComponent<Animator>();
            if (_toShow02SR.name == _visuChoosed02)
            {
                visu.Visual = _toShow02SR;
                visu.CharacterAnimator = _toShow02A;
            }
        }
    }

    internal override void Attack(Character defender)
    {
        if (HasAttackedThisTurnOrIsStuned) return;
        print(defender.GetType());
        if (defender.GetType() == typeof(Ally))
        {
            Debug.LogWarning("You should not hit your allies");
            return;
        }
        base.Attack(defender);
    }

    internal override void SpecialAttack(Character defender)
    {
        if (HasAttackedThisTurnOrIsStuned) return;
        print(defender.GetType());
        if (defender.GetType() == typeof(Ally))
        {
            Debug.LogWarning("You should not hit your allies");
            return;
        }
        base.SpecialAttack(defender);
    }

    internal override void Ulti(Character defender)
    {
        if (HasAttackedThisTurnOrIsStuned) return;
        print(defender.GetType());
        if (defender.GetType() == typeof(Ally))
        {
            Debug.LogWarning("You should not hit your allies");
            return;
        }
        base.Ulti(defender);
    }

    internal override void Hit(int damage)
    {
        base.Hit(damage);
        CharacterAnimator.SetTrigger("hit");
        Life = Mathf.Clamp(Life - damage, 0, LifeMax);
    }

    private void LoadVisu01()
    {
        _visuChoosed01 = PlayerPrefs.GetString("character01");
    }

    private void LoadVisu02()
    {
        _visuChoosed02 = PlayerPrefs.GetString("character02");
    }
}
