using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    SpriteRenderer enemySprite;
    public GameObject XPgem;
    public float enemySpeed;
    public float enemyDamage;
    public float enemyHP;
    void Start()
    {
        enemySprite = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        FollowByPalyer();
        if(gameObject.transform.childCount == 0)
        {
            GameObject gem = Instantiate(XPgem);
            gem.SetActive(true);
            gem.transform.position = gameObject.transform.position;
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
}
