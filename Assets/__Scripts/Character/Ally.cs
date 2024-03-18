using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class Ally : Character
{

    private MenuManager menuManager;
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


    #region SpecialAttack
    
    internal override void Freeze(Character defender)
    {
        if (HasAttackedThisTurnOrIsStuned) return;
        print(defender.GetType());
        if (defender.GetType() == typeof(Ally))
        {
            Debug.LogWarning("You should not hit your allies");
            return;
        }
        
        base.Freeze(defender);
    }
    
    internal override void Regen(Character defender)
    {
        if (HasAttackedThisTurnOrIsStuned) return;
        print(defender.GetType());
        if (defender.GetType() == typeof(Enemy))
        {
            Debug.LogWarning("You should not heal your enemies");
            return;
        }

        base.Regen(defender);
    }
    
    internal override void Critical(Character defender)
    {
        if (HasAttackedThisTurnOrIsStuned) return;
        print(defender.GetType());
        if (defender.GetType() == typeof(Ally))
        {
            Debug.LogWarning("You should not hit your allies");
            return;
        }

        base.Critical(defender);
    }
    
    internal override void MinPV(Character defender)
    {
        if (HasAttackedThisTurnOrIsStuned) return;
        print(defender.GetType());
        if (defender.GetType() == typeof(Ally))
        {
            Debug.LogWarning("You should not hit your allies");
            return;
        }

        base.MinPV(defender);
    }

    #endregion
    

    #region Ulti

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

    internal override void TwoTimes(Character defender)
    {
        if (HasAttackedThisTurnOrIsStuned) return;
        print(defender.GetType());
        if (defender.GetType() == typeof(Ally))
        {
            Debug.LogWarning("You should not hit your allies");
            return;
        }

        base.TwoTimes(defender);
    }

    internal override void Skip(Character defender)
    {
        if (HasAttackedThisTurnOrIsStuned) return;
        print(defender.GetType());
        if (defender.GetType() == typeof(Ally))
        {
            Debug.LogWarning("You should not hit your allies");
            return;
        }

        base.Skip(defender);
    }

    #endregion

    internal override void Hit(int damage)
    {
        base.Hit(damage);
        CharacterAnimator.SetTrigger("hit");
        Life = Mathf.Clamp(Life - damage, 0, LifeMax);
        if (Life <= 0)
        {
            AllyDead++;
        }
    }

}