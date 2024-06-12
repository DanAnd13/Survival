using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public MoveJoystick joystick;
    private SpriteRenderer player;
    private Rigidbody2D Rigidbody2D;
    Vector2 moveDir;

    private void Start()
    {
        player = GetComponent<SpriteRenderer>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Move();
        FlipSprite();
    }

    void Move()
    {
        moveDir = new Vector2(joystick.Horizontal(), joystick.Vertical()).normalized;
        Rigidbody2D.velocity = moveDir * PlayerMovement.playerMoveSpeed;
    }

    void FlipSprite()
    {
        if (moveDir.x != 0)
        {
            player.flipX = moveDir.x < 0;
        }
    }
}
