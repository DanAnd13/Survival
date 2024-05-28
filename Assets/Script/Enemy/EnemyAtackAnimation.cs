using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtackAnimation : MonoBehaviour
{
    public Animator enemyAtack;
    void Start()
    {
        enemyAtack = GetComponent<Animator>();   
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (gameObject.tag)
        {
            case "Goblin":
                enemyAtack.SetBool("isGoblinAtackRadius", true);
                break;
            case "FlyingEye":
                enemyAtack.SetBool("isEyeAtackRadius", true);
                break;
            case "Mushroom":
                enemyAtack.SetBool("isMushroomAtackRadius", true);
                break;
            case "Skeleton":
                enemyAtack.SetBool("isSkeletonAtackRadius", true);
                break;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        switch (gameObject.tag)
        {
            case "Goblin":
                enemyAtack.SetBool("isGoblinAtackRadius", false);
                break;
            case "FlyingEye":
                enemyAtack.SetBool("isEyeAtackRadius", false);
                break;
            case "Mushroom":
                enemyAtack.SetBool("isMushroomAtackRadius", false);
                break;
            case "Skeleton":
                enemyAtack.SetBool("isSkeletonAtackRadius", false);
                break;
        }
    }
}
