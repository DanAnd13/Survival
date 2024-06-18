using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakingDamage : MonoBehaviour
{
    public GameObject enemyDamageAnimation;
    EnemyMovement EnemyMovement;
    ObjectPool damageAnimationPool;
    void Start()
    {
        EnemyMovement = GetComponentInParent<EnemyMovement>();
        damageAnimationPool = enemyDamageAnimation.GetComponent<ObjectPool>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject damage = damageAnimationPool.SharedInstance.GetPooledObject();
        if (damage != null)
        {
            damage.transform.position = gameObject.transform.position;
            damage.SetActive(true);
            StartCoroutine(DamageAnimationTime(damage));
            collision.gameObject.SetActive(false);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    IEnumerator DamageAnimationTime(GameObject damageAnimation)
    {
        yield return new WaitForSeconds(0.1f);
        damageAnimation.SetActive(false);
        //yield return null;
        EnemyMovement.enemyHP -= BulletMovement.bulletDamage;

    }
}
