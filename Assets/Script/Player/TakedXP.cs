using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakedXP : MonoBehaviour
{
    [HideInInspector] 
    public static float radius = 2.8f;
    float newLevel = 10f;
    float gemXPValue;
    CircleCollider2D circleCollider;
    bool pause = false;
    public TakedElements elements;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        gemXPValue ++;
        if(IsLevelUp())
        {
            //
            //newLevel += newLevel;
            //gemXPValue = 0;
        }
    }
    bool IsLevelUp()
    {
        if (gemXPValue == newLevel)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
public enum TakedElements{
    XP,
    bust,

}
