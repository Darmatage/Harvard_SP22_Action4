using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    //public Animator animator;
    public Rigidbody2D rb;
    public float jumpForce = 20f;
    public Transform feet;
    public LayerMask groundLayer;
    public LayerMask enemyLayer;
    public bool isAlive = true;
	public bool myGroundCheck = false;
	public float groundRange = 2f;
    //public AudioSource JumpSFX;

    void Start()
    {
        //animator = gameObject.GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Debug.Log("isAlive variable is: " + isAlive);
        //Debug.Log("IsGrounded variable is: " + IsGrounded());

        if ((Input.GetButtonDown("Jump")) && (IsGrounded()) && (isAlive == true))
        {
            Jump();
            // animator.SetTrigger("Jump");
            // JumpSFX.Play();
        }
    }

    public void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
        //Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
        //rb.velocity = movement;
    }

	// || means or
	// && means and
	// == means equals

    public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, groundRange, groundLayer);
        Collider2D enemyCheck = Physics2D.OverlapCircle(feet.position, groundRange, enemyLayer);
        if ((groundCheck != null) || (enemyCheck != null))
        {
			Debug.Log("I can jump now!");
			myGroundCheck = true;
            return true;
        }
		myGroundCheck = false;
        return false;
    }
}