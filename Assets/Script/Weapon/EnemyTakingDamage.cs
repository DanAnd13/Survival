using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakingDamage : MonoBehaviour
{
    public GameObject enemyDamageAnimation;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyMovement enemyMovement = collision.gameObject.GetComponentInParent<EnemyMovement>();
        BulletMovement bulletMovement = gameObject.GetComponent<BulletMovement>();
        enemyMovement.enemyHP -= bulletMovement.bulletDamage;
        GameObject damage = Instantiate(enemyDamageAnimation);
        damage.transform.position = collision.gameObject.transform.position;
        damage.SetActive(true);
        Destroy(damage, 0.3f);
        if (enemyMovement.enemyHP <= 0)
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
