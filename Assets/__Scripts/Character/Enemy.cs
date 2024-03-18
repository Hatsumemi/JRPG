using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Enemy : Character
{
    private MenuManager menuManager;
    private InstantiateCharacters _instantiateCharacters;
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
        base.ShowHitPoint(damage);
        if (Life <= 0)
        {
            menuManager.Fade.gameObject.SetActive(true);
            menuManager.Fade.DOFade(1, 1);
            StartCoroutine(WaitToEnd());
        }
          
    }

    IEnumerator WaitToEnd()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Victory");
    }
}
