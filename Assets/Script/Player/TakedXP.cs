using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakedXP : MonoBehaviour
{
    public static float radius = 2.8f;
    float newLevel = 10f;
    float gemXPSum = 0f;
    CircleCollider2D circleCollider;
    bool pause = false;
    BonusElements BonusElements;
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.radius = radius;
    }

    // Update is called once per frame
    void Update()
    {
        circleCollider.radius = radius;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BonusElements = collision.gameObject.GetComponent<BonusElements>();
        if (BonusElements != null)
        {
            if (BonusElements.element == BonusElements.TakedElements.baseXP)
            {
                collision.gameObject.SetActive(false);
                gemXPSum++;
            }
            else if (BonusElements.element == BonusElements.TakedElements.bossXP)
            {
                collision.gameObject.SetActive(false);
                gemXPSum += 5f;
            }
            if (IsLevelUp())
            {
                //
                //newLevel += newLevel;
                //gemXPValue = 0;
            }
        }
    }
    bool IsLevelUp()
    {
        if (gemXPSum == newLevel)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
