using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    public void IncreaseXPTakingRadius()
    {
        TakedXP.radius += 0.5f;
    }
    public void IncreasePlayerDamage()
    {
        BulletMovement.bulletDamage += 3f;
    }
    public void IncreasePlayerSpeed()
    {
        PlayerMovement.playerMoveSpeed += 2f;
    }
    public void IncreasePlayerHP()
    {
        PlayerMovement.playerMaxHP += 5f;
    }
}
