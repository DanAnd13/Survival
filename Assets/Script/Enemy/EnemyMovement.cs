using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    SpriteRenderer enemySprite;
    public float enemySpeed;
    public float enemyDamage;
    public float enemyHP;
    ObjectPool XPgem;
    public GameObject baseGems;
    void Start()
    {
        enemySprite = GetComponent<SpriteRenderer>();
        XPgem = baseGems.GetComponent<ObjectPool>();
    }

    void FixedUpdate()
    {
        FollowByPalyer();
        if(enemyHP == 0)
        {
            GameObject gem = XPgem.SharedInstance.GetPooledObject();
            gem.transform.position = gameObject.transform.position;
            gem.SetActive(true);
            gameObject.SetActive(false);
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
    public float EnemyDamage()
    {
        return enemyDamage;
    }
}
