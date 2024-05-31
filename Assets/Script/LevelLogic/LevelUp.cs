using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    public void IncreaseXPTakedRadius()
    {
        TakedXP.radius += 0.4f;
    }
    public void IncreasePlayerDamage()
    {
        BulletMovement.bulletDamage += 3f;
    }
    public void IncreasePlayerSpeed()
    {
        PlayerMovement.playerMoveSpeed += 3f;
    }
    public void IncreasePlayerHP()
    {
        PlayerMovement.playerHP += 5f;
    }
}
