using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Enemy : Character
{
    public InstantiateCharacters InstantiateCharacters;

    internal override void Attack(Character defender)
    {
        if (HasAttackedThisTurnOrIsStuned) return;
        if (Character.IsFreeze == true)
        {
            TurnManager.Instance.HasAttacked(this);
            Character.IsFreeze = false;
        }
        else
            base.Attack(defender);
    }

    internal override void Hit(int damage)
    {
        base.Hit(damage);
        CharacterAnimator.SetTrigger("hit");
        Life = Mathf.Clamp(Life - damage, 0, LifeMax);
        if (Life <= 0)
        {
            IsEnemyAlive = false;
        }
          
    }

    
}
