using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TakedXP : MonoBehaviour
{
    public TextMeshProUGUI XPUI;
    public GameObject LevelUpUI;
    public GameObject AndroidUI;
    public static float radius;
    float newLevel;
    float gemXPSum;
    CircleCollider2D circleCollider;
    BonusElements BonusElements;
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        radius = 2.8f;
        newLevel = 10f;
        gemXPSum = 0f;
        circleCollider.radius = radius;
    }

    // Update is called once per frame
    void Update()
    {
        circleCollider.radius = radius;
        XPUI.text = "XP: " + gemXPSum + " / "+ newLevel;
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
            else if (BonusElements.element == BonusElements.TakedElements.HPGem)
            {
                collision.gameObject.SetActive(false);
                PlayerMovement.playerHP += 15f;
                if(PlayerMovement.playerHP > PlayerMovement.playerMaxHP)
                {
                    PlayerMovement.playerHP = PlayerMovement.playerMaxHP;
                }
            }
            if (IsLevelUp())
            {
                AndroidUI.SetActive(false);
                LevelUpUI.SetActive(true);
                Pause.gamePause = true;
                CrossHair.StandartCursor();
                gemXPSum -= newLevel;
                newLevel += 10f;
            }
        }
    }
    bool IsLevelUp()
    {
        if (gemXPSum >= newLevel)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
