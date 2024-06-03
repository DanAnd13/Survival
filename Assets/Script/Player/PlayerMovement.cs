using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static float playerMoveSpeed;
    public static float playerHP;
    public TextMeshProUGUI playerHPUI;
    public LoseGame loseGame;
    Rigidbody2D Rigidbody2D;
    Vector2 moveDir;
    SpriteRenderer player;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        player = GetComponent<SpriteRenderer>();
        playerHP = 50f;
        playerMoveSpeed = 20f;
    }
    void Update()
    {
        playerHPUI.text = "Health: " + playerHP;
        InputMove();
        if(moveDir.x !=0 || moveDir.y !=0)
        {
            if (moveDir.x > 0)
            {
                player.flipX = false;
            }
            else
            {
                player.flipX = true;
            }
        }
        if(playerHP <= 0)
        {
            gameObject.SetActive(false);
            loseGame.LoseValues();
            Pause.gamePause = true;
        }
    }
    private void FixedUpdate()
    {
        Move();
    }
    void InputMove()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDir = new Vector2(moveX, moveY).normalized;
    }
    void Move()
    {
        Rigidbody2D.velocity = new Vector2(moveDir.x * playerMoveSpeed, moveDir.y * playerMoveSpeed);
    }
}
