using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static float playerMoveSpeed = 20f;
    public static float playerHP = 50f;
    Rigidbody2D Rigidbody2D;
    Vector2 moveDir;
    SpriteRenderer player;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        player = GetComponent<SpriteRenderer>();

    }
    void Update()
    {
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
