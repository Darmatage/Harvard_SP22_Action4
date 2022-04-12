using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch_StateChange : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public GameObject crouch;
	public GameObject stand;
	public GameObject test;
    public Transform feet;
    public bool isAlive = true;
    public LayerMask groundLayer;
    public LayerMask enemyLayer;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if ((Input.GetButtonDown("Crouch")) && (IsGrounded()) && (isAlive == true))
        {
            crouch.SetActive(true);
			stand.SetActive(false);
        }
		
        if (Input.GetButtonUp("Crouch") == true)
        {
            crouch.SetActive(false);
			stand.SetActive(true);
        }
    }

    public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 2f, groundLayer);
        Collider2D enemyCheck = Physics2D.OverlapCircle(feet.position, 2f, enemyLayer);
        if ((groundCheck != null) || (enemyCheck != null))
        {
            return true;
        }
        return false;
    }
}
