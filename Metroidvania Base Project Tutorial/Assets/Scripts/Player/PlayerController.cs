using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed;

    [Header("Jumping")]
    [SerializeField] private float jumpVelocity;
    [SerializeField] private float groundingCheckDistance;
    [SerializeField] private LayerMask groundLayer;

    [Header("Stopping")]
    [SerializeField] private float stoppingDistance;
    [SerializeField] private LayerMask wallLayer;

    private Rigidbody2D rb;
    private float gravityScale;
    private int playerDirection;
    public Animator anim;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        gravityScale = rb.gravityScale;
        anim = GetComponent<Animator>();
    }

    private void Update() {
        Walking();
        Jumping();
    }

    private void Walking() {
        if (Input.GetKey(KeyCode.D) && !CheckIfPlayerShouldStop(Vector2.right)) {
            transform.position += transform.right * movementSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            playerDirection = 1;
            anim.SetBool("isWalking", true);
        }
        else if (Input.GetKey(KeyCode.A) && !CheckIfPlayerShouldStop(Vector2.left)) {
            transform.position += transform.right * movementSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            playerDirection = -1;
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }

    private void Jumping() {
        var isGrounded = CheckIfGrounded();

        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(transform.up * jumpVelocity, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("isJumping", true);
            anim.SetBool("isGrounded", false);
            anim.SetBool("isWalking", false);
        }
        if (isGrounded)
        {
            anim.SetBool("isGrounded", true);
            anim.SetBool("isJumping", false);
        }
        else if (!isGrounded)
        {
            anim.SetBool("isGrounded", false);
            anim.SetBool("isWalking", false);
        }
    }


    private bool CheckIfGrounded() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundingCheckDistance, groundLayer);

        if (hit.collider)
        {
            return true;
        }
        else return false;
    }

    private bool CheckIfPlayerShouldStop(Vector2 direction) {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, stoppingDistance, wallLayer);

        if (hit.collider) return true;
        else return false;
    }

    public int ReturnPlayerDirection() {
        return playerDirection;
    }
}
