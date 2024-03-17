using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private InstantiateCharacters _instantiateCharacters;
    internal override void Attack(Character defender)
    {
        if (HasAttackedThisTurnOrIsStuned) return;
        if (Character.IsFreeze == true) TurnManager.Instance.HasAttacked(this);
        else
            base.Attack(defender);
    }

    internal override void Hit(int damage)
    {
        base.Hit(damage);
        CharacterAnimator.SetTrigger("hit");
        Life = Mathf.Clamp(Life - damage, 0, LifeMax);
        base.ShowHitPoint(damage);
        if (Life <= 0)
        {
            Destroy(GameObject.Find(_instantiateCharacters.EnemyName));
            _instantiateCharacters.ChangeEnemy();
        }
           
    }
}
