using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class Character : MonoBehaviour
{
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
        CharacterAnimator.SetTrigger("attack");

        TurnManager.Instance.HasAttacked(this);

        if (defender.GetType() == typeof(Ally)) ((Ally)defender).Hit(damage: NormalAttackDamage);
        else if (defender.GetType() == typeof(Enemy)) ((Enemy)defender).Hit(damage: NormalAttackDamage);
    }

    #region SpecialAttack

    virtual internal void Freeze(Character defender)
    {
        print($"{name} is using their special attack {defender.name} of type {defender.GetType()}");
        CharacterAnimator.SetTrigger("special");

        TurnManager.Instance.HasAttacked(this);

        
        if (defender.GetType() == typeof(Ally)) ((Ally)defender).Hit(damage: SpecialAttackDamage);
        else if (defender.GetType() == typeof(Enemy))
        {
            ((Enemy)defender).Hit(damage: SpecialAttackDamage);
            IsFreeze = true;
        }
    }

    virtual internal void Regen(Character defender)
    {
        print($"{name} is using their special attack {defender.name} of type {defender.GetType()}");
        CharacterAnimator.SetTrigger("special");

        TurnManager.Instance.HasAttacked(this);

        if (defender.GetType() == typeof(Ally)) ((Ally)defender).Hit(damage: -20);
        else if (defender.GetType() == typeof(Enemy)) ((Enemy)defender).Hit(damage: -20);
    }

    virtual internal void Critical(Character defender)
    {
        print($"{name} is using their special attack {defender.name} of type {defender.GetType()}");
        CharacterAnimator.SetTrigger("special");

        TurnManager.Instance.HasAttacked(this);

        if (defender.GetType() == typeof(Ally)) ((Ally)defender).Hit(damage: SpecialAttackDamage);
        else if (defender.GetType() == typeof(Enemy)) ((Enemy)defender).Hit(damage: SpecialAttackDamage);
    }

    virtual internal void MinPV(Character defender)
    {
        print($"{name} is using their special attack {defender.name} of type {defender.GetType()}");
        CharacterAnimator.SetTrigger("special");

        TurnManager.Instance.HasAttacked(this);

        if (defender.GetType() == typeof(Ally)) ((Ally)defender).Hit(damage: SpecialAttackDamage);
        else if (defender.GetType() == typeof(Enemy)) ((Enemy)defender).Hit(damage: SpecialAttackDamage);
    }

    virtual internal void ConstantPV(Character defender)
    {
        print($"{name} is using their special attack {defender.name} of type {defender.GetType()}");
        CharacterAnimator.SetTrigger("special");

        TurnManager.Instance.HasAttacked(this);

        if (defender.GetType() == typeof(Ally)) ((Ally)defender).Hit(damage: SpecialAttackDamage);
        else if (defender.GetType() == typeof(Enemy)) ((Enemy)defender).Hit(damage: SpecialAttackDamage);
    }

    #endregion


    #region Ulti

    virtual internal void Ulti(Character defender)
    {
        print($"{name} is using their ult {defender.name} of type {defender.GetType()}");
        CharacterAnimator.SetTrigger("ult");

        TurnManager.Instance.HasAttacked(this);

        if (defender.GetType() == typeof(Ally)) ((Ally)defender).Hit(damage: UltimateAttackDamage);
        else if (defender.GetType() == typeof(Enemy)) ((Enemy)defender).Hit(damage: UltimateAttackDamage);
    }

    virtual internal void TwoTimes(Character defender)
    {
        print($"{name} is using their ult {defender.name} of type {defender.GetType()}");
        CharacterAnimator.SetTrigger("ult");


        TurnManager.Instance.HasAttacked(this);

        StartCoroutine(WaitToHit(defender));

    }

    virtual internal void Skip(Character defender)
    {
        
        print($"{name} is using their ult {defender.name} of type {defender.GetType()}");
        CharacterAnimator.SetTrigger("ult");

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


    virtual internal void Hit(int damage)
    {
        print($"{name} is hit and took {damage} damages");
        CharacterAnimator.SetTrigger("hit");
    }

    IEnumerator WaitToHit(Character defender)
    {
        if (defender.GetType() == typeof(Ally)) ((Ally)defender).Hit(damage: UltimateAttackDamage);
        else if (defender.GetType() == typeof(Enemy)) ((Enemy)defender).Hit(damage: UltimateAttackDamage);
        yield return new WaitForSeconds(3);
        if (defender.GetType() == typeof(Ally)) ((Ally)defender).Hit(damage: NormalAttackDamage);
        else if (defender.GetType() == typeof(Enemy)) ((Enemy)defender).Hit(damage: NormalAttackDamage);
    }
    IEnumerator WaitToFinish(Character defender)
    {
        if (defender.GetType() == typeof(Ally)) ((Ally)defender).Hit(damage: NormalAttackDamage);
        else if (defender.GetType() == typeof(Enemy)) ((Enemy)defender).Hit(damage: NormalAttackDamage);
        yield return new WaitForSeconds(3);
        if (defender.GetType() == typeof(Ally)) ((Ally)defender).Hit(damage: NormalAttackDamage);
        else if (defender.GetType() == typeof(Enemy)) ((Enemy)defender).Hit(damage: NormalAttackDamage);
    }
    
    
}