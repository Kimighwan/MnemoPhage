using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveInputDirection;

    private bool isFacingRight = true;

    private Rigidbody2D rigid;

    public float moveSpeed = 10.0f;
    public float jumpForce = 15.0f;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckInput();
        CheckMoveDirection();
    }

    private void FixedUpdate()
    {
        ApplyMove();
    }

    private void CheckMoveDirection()
    {
        if(isFacingRight && moveInputDirection < 0) 
        {
            Flip();
        }
        else if(!isFacingRight && moveInputDirection > 0)
        {
            Flip();
        }
    }

    private void CheckInput()
    {
        moveInputDirection = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void Jump()
    {
        rigid.linearVelocityY = jumpForce;
    }

    private void ApplyMove()
    {
        rigid.linearVelocityX = moveSpeed * moveInputDirection;
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
}
