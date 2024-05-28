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

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyMovement.enemyHP -= BulletMovement.BulletDamage();
        GameObject damage = damageAnimationPool.SharedInstance.GetPooledObject();
        if (damage != null)
        {
            damage.transform.position = gameObject.transform.position;
            damage.SetActive(true);
            StartCoroutine(DamageAnimationTime(damage));
            collision.gameObject.SetActive(false);
        }
    }
    IEnumerator DamageAnimationTime(GameObject damageAnimation)
    {
        yield return new WaitForSeconds(0.1f);
        damageAnimation.SetActive(false);
    }
}
