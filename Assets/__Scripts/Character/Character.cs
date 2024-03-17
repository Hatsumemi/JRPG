using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

[Serializable]
public class Character : MonoBehaviour
{
    public GameObject PrefabHitPoint;
    public GameObject WhereToShowHP;
    public int LifeMax = 100;
    public int Life = 100;
    public Sprite SpritePortrait;
    public SpriteRenderer Visual;
    public Animator CharacterAnimator;
    public int NormalAttackDamage = 10;
    public int SpecialAttackDamage = 30;
    public int UltimateAttackDamage = 60;
    public Color CanAttackColor = Color.white;
    public Color StandByColor = Color.grey;
    private bool _hasAttackedThisTurnOrIsStuned = false;
    public AttackType[] SpecialAttacks;

    public static bool IsFreeze;

    public bool HasAttackedThisTurnOrIsStuned
    {
        get { return _hasAttackedThisTurnOrIsStuned; }
        set
        {
            _hasAttackedThisTurnOrIsStuned = value;
            Visual.color = _hasAttackedThisTurnOrIsStuned ? StandByColor : CanAttackColor;
        }
    }

    private void Start()
    {
        Life = LifeMax;
    }

    public bool isAlive()
    {
        return Life > 0;
    }

    virtual internal void Attack(Character defender)
    {
        print($"{name} is attacking {defender.name} of type {defender.GetType()}");
        CharacterAnimator.SetTrigger("AttackBase");

        TurnManager.Instance.HasAttacked(this);
        
        if (defender.GetType() == typeof(Ally)) ((Ally)defender).Hit(damage: NormalAttackDamage);
        else if (defender.GetType() == typeof(Enemy)) ((Enemy)defender).Hit(damage: NormalAttackDamage);
        //IsIdleBase(defender);
    }

    #region SpecialAttack

    virtual internal void Freeze(Character defender)
    {
        print($"{name} is using their special attack {defender.name} of type {defender.GetType()}");
        CharacterAnimator.SetTrigger("SpecialAttack");

        TurnManager.Instance.HasAttacked(this);
        
        IsIdleSpecialFreeze(defender);
    }

    virtual internal void Regen(Character defender)
    {
        print($"{name} is using their special attack {defender.name} of type {defender.GetType()}");
        CharacterAnimator.SetTrigger("SpecialAttack");

        TurnManager.Instance.HasAttacked(this);

        IsIdleSpecialRegen(defender);
    }

    virtual internal void Critical(Character defender)
    {
        print($"{name} is using their special attack {defender.name} of type {defender.GetType()}");
        CharacterAnimator.SetTrigger("SpecialAttack");

        TurnManager.Instance.HasAttacked(this);

        IsIdleSpecial(defender);
    }

    virtual internal void MinPV(Character defender)
    {
        print($"{name} is using their special attack {defender.name} of type {defender.GetType()}");
        CharacterAnimator.SetTrigger("SpecialAttack");

        TurnManager.Instance.HasAttacked(this);

        IsIdleSpecial(defender);
    }

    virtual internal void ConstantPV(Character defender)
    {
        print($"{name} is using their special attack {defender.name} of type {defender.GetType()}");
        CharacterAnimator.SetTrigger("SpecialAttack");

        TurnManager.Instance.HasAttacked(this);

        IsIdleSpecial(defender);
    }

    #endregion


    #region Ulti

    virtual internal void Ulti(Character defender)
    {
        print($"{name} is using their ult {defender.name} of type {defender.GetType()}");
        CharacterAnimator.SetTrigger("Ulti");

        TurnManager.Instance.HasAttacked(this);

        IsIdleUlti(defender);
    }

    virtual internal void TwoTimes(Character defender)
    {
        print($"{name} is using their ult {defender.name} of type {defender.GetType()}");
        CharacterAnimator.SetTrigger("Ulti");


        TurnManager.Instance.HasAttacked(this);

        StartCoroutine(WaitToHit(defender));

    }

    virtual internal void Skip(Character defender)
    {
        
        print($"{name} is using their ult {defender.name} of type {defender.GetType()}");
        CharacterAnimator.SetTrigger("Ulti");

        TurnManager.Instance.HasAttacked(this);
        for (int i = 0; i < TurnManager.Instance.Allies.Count; i++)
        {
            if (TurnManager.Instance.Allies[i] != defender)
            {
                defender = TurnManager.Instance.Allies[i];
                StartCoroutine(WaitToFinish(defender) );
                break;
            }
        }
    }

    #endregion
    
    private void IsIdleBase(Character defender)
    {
        if (CharacterAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "idle")
        {
            if (defender.GetType() == typeof(Ally)) ((Ally)defender).Hit(damage: NormalAttackDamage);
            else if (defender.GetType() == typeof(Enemy)) ((Enemy)defender).Hit(damage: NormalAttackDamage);
        }
    }
    
    private void IsIdleSpecial(Character defender)
    {
        if (CharacterAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "idle")
        {
            if (defender.GetType() == typeof(Ally)) ((Ally)defender).Hit(damage: SpecialAttackDamage);
            else if (defender.GetType() == typeof(Enemy)) ((Enemy)defender).Hit(damage: SpecialAttackDamage);
        }
    }
    private void IsIdleSpecialFreeze(Character defender)
    {
        if (CharacterAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "idle")
        {
            if (defender.GetType() == typeof(Ally)) ((Ally)defender).Hit(damage: SpecialAttackDamage);
            else if (defender.GetType() == typeof(Enemy))
            {
                ((Enemy)defender).Hit(damage: SpecialAttackDamage);
                IsFreeze = true;
            }
        }
    }
        
    private void IsIdleSpecialRegen(Character defender)
    {
        if (CharacterAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "idle")
        {
            if (defender.GetType() == typeof(Ally)) ((Ally)defender).Hit(damage: -SpecialAttackDamage);
            else if (defender.GetType() == typeof(Enemy)) ((Enemy)defender).Hit(damage: -SpecialAttackDamage);
        }
    }
    
    private void IsIdleUlti(Character defender)
    {
        if (CharacterAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "idle")
        {
            if (defender.GetType() == typeof(Ally)) ((Ally)defender).Hit(damage: UltimateAttackDamage);
            else if (defender.GetType() == typeof(Enemy)) ((Enemy)defender).Hit(damage: UltimateAttackDamage);
        }
    }

    virtual internal void Hit(int damage)
    {
        print($"{name} is hit and took {damage} damages");
        CharacterAnimator.SetTrigger("hit");
    }

    public void ShowHitPoint(int damage)
    {
        GameObject prefab = GameObject.Instantiate(PrefabHitPoint);
        prefab.transform.position = WhereToShowHP.transform.position;
        prefab.GetComponent<Text>().DOFade(0, 0.8f);
    }
    
    IEnumerator WaitToHit(Character defender)
    {
        IsIdleUlti(defender);
        yield return new WaitForSeconds(3);
        IsIdleBase(defender);
    }
    IEnumerator WaitToFinish(Character defender)
    {
        IsIdleBase(defender);
        yield return new WaitForSeconds(3);
        IsIdleBase(defender);
    }

}