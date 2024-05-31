using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtackAnimation : MonoBehaviour
{
    Animator enemyAtack;
    EnemyMovement enemyType;
    Coroutine damageCoroutine;
    void OnEnable()
    {
        enemyAtack = GetComponent<Animator>(); 
        enemyType = GetComponent<EnemyMovement>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string attackParameter = GetAttackParameter(enemyType.type);
        if (attackParameter != null)
        {
            enemyAtack.SetBool(attackParameter, true);
            damageCoroutine = StartCoroutine(PlayerTakingDamage());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        string attackParameter = GetAttackParameter(enemyType.type);
        if (attackParameter != null)
        {
            enemyAtack.SetBool(attackParameter, false);
            StopCoroutine(damageCoroutine);
            damageCoroutine = null;
        }
    }

    private string GetAttackParameter(EnemyMovement.TypeOfEnemy type)
    {
        switch (type)
        {
            case EnemyMovement.TypeOfEnemy.goblin:
            case EnemyMovement.TypeOfEnemy.bossGoblin:
                return "isGoblinAtackRadius";
            case EnemyMovement.TypeOfEnemy.flyingEye:
            case EnemyMovement.TypeOfEnemy.bossFlyingEye:
                return "isEyeAtackRadius";
            case EnemyMovement.TypeOfEnemy.mushroom:
            case EnemyMovement.TypeOfEnemy.bossMushroom:
                return "isMushroomAtackRadius";
            case EnemyMovement.TypeOfEnemy.skeleton:
            case EnemyMovement.TypeOfEnemy.bossSkeleton:
                return "isSkeletonAtackRadius";
            default:
                return null;
        }
    }

    IEnumerator PlayerTakingDamage()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.45f);
            PlayerMovement.playerHP -= enemyType.enemyDamage;
        }
    }
}
