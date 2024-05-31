using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    SpriteRenderer enemySprite;
    [HideInInspector]
    public float enemySpeed, enemyDamage, enemyHP;
    public static float bonusEnemySpeed = 0f, bonusEnemyDamage = 0f, bonusEnemyHP = 0f;
    ObjectPool XPgem;
    public GameObject baseGems;
    public TypeOfEnemy type;
    public enum TypeOfEnemy
    {
        goblin,
        flyingEye,
        mushroom,
        skeleton,
        bossGoblin,
        bossFlyingEye,
        bossMushroom,
        bossSkeleton
    }
    void OnEnable()
    {
        enemySprite = GetComponent<SpriteRenderer>();
        XPgem = baseGems.GetComponent<ObjectPool>();
        GetTypeOfEnemy();
    }

    void FixedUpdate()
    {
        if (player == null) return;
        FollowByPalyer();
        if(enemyHP <= 0)
        {
            GameObject gem = XPgem.SharedInstance.GetPooledObject();
            if (gem != null)
            {
                gem.transform.position = gameObject.transform.position;
                gem.SetActive(true);
            }
            gameObject.SetActive(false);
            Stopwatch.kills++;
        }
    }
    void GetTypeOfEnemy()
    {
        switch(type)
        {
            case TypeOfEnemy.goblin:
                enemyHP = 10f + bonusEnemyHP;
                enemySpeed = 7f + bonusEnemySpeed;
                enemyDamage = 10f + bonusEnemyDamage;
                break;
            case TypeOfEnemy.flyingEye:
                enemyHP = 5f + bonusEnemyHP;
                enemySpeed = 10f + bonusEnemySpeed;
                enemyDamage = 8f + bonusEnemyDamage;
                break;
            case TypeOfEnemy.mushroom:
                enemyHP = 20f + bonusEnemyHP;
                enemySpeed = 4f + bonusEnemySpeed;
                enemyDamage = 12f + bonusEnemyDamage;
                break;
            case TypeOfEnemy.skeleton:
                enemyHP = 15f + bonusEnemyHP;
                enemySpeed = 6f + bonusEnemySpeed;
                enemyDamage = 15f + bonusEnemyDamage;
                break;
            case TypeOfEnemy.bossGoblin:
                enemyHP = 30f + bonusEnemyHP;
                enemySpeed = 3f + bonusEnemySpeed;
                enemyDamage = 20f + bonusEnemyDamage;
                break;
            case TypeOfEnemy.bossFlyingEye:
                enemyHP = 25f + bonusEnemyHP;
                enemySpeed = 4f + bonusEnemySpeed;
                enemyDamage = 16f + bonusEnemyDamage;
                break;
            case TypeOfEnemy.bossMushroom:
                enemyHP = 50f + bonusEnemyHP;
                enemySpeed = 1f + bonusEnemySpeed;
                enemyDamage = 25f + bonusEnemyDamage;
                break;
            case TypeOfEnemy.bossSkeleton:
                enemyHP = 35f + bonusEnemyHP;
                enemySpeed = 2f + bonusEnemySpeed;
                enemyDamage = 30f + bonusEnemyDamage;
                break;
        }
    }
    void FollowByPalyer()
    {
        Vector3 direction = player.transform.position - transform.position;
        if (direction.x > 0)
        {
            enemySprite.flipX = false;
        }
        else
        {
            enemySprite.flipX = true;
        }
        Vector3 velocity = direction.normalized * enemySpeed * Time.deltaTime;
        transform.position = transform.position + velocity;
    }
}
