using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    [SerializeField] PlayerData playerData;
    public LayerMask groundLayer;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool shouldJump;
    public int damage = -1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Is Grounded?
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1.5f, groundLayer);

        //Player Direction
        float direction = Mathf.Sign(player.position.x - transform.position.x);

        //Player Above
        bool isPlayerAbove = Physics2D.Raycast(transform.position, Vector2.up, 3f, 1 << player.gameObject.layer);  //"1 << player.gameObject.layer" no tengo layer especifico del player

        if (isGrounded) 
        {
            //Chase
            rb.velocity =  new Vector2(direction * playerData.chaseSpeed, rb.velocity.y);

            //Jump if there is no gap ahead & no ground in front, else if there is a player  above and platform above

            //If Ground
            RaycastHit2D groundInFornt = Physics2D.Raycast(transform.position, new Vector2(direction, 0), 5f, groundLayer);

            //if Gap
            RaycastHit2D gapAhead = Physics2D.Raycast(transform.position + new Vector3(direction, 0, 0 ), Vector2.down, 2f , groundLayer);

            //If Platform above
            RaycastHit2D platformAbove = Physics2D.Raycast(transform.position , Vector2.up, 5f, groundLayer);

            if (!groundInFornt.collider && !gapAhead.collider ) 
            {
                shouldJump = true;
            }
            if (isPlayerAbove && platformAbove.collider) 
            {
                shouldJump = true;
            }


        }

    }

    private void FixedUpdate()
    {
        if (isGrounded && shouldJump) 
        {
            shouldJump = false;
            Vector2 direction = (player.position - transform.position).normalized;
            Vector2 jumpDirection = direction * playerData.jumpForce;

            rb.AddForce(new Vector2(jumpDirection.x, playerData.jumpForce), ForceMode2D.Impulse);
        }
    }
}
