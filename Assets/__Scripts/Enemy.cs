using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    internal override void Attack(Character defender)
    {
        if (HasAttackedThisTurnOrIsStuned) return;
        base.Attack(defender);
    }

    internal override void Hit(int damage)
    {
        base.Hit(PlayerPrefs.GetInt("damage"));
        CharacterAnimator.SetTrigger("hit");
        Life = Mathf.Clamp(Life - PlayerPrefs.GetInt("damage"), 0, LifeMax);
    }
}
