using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	//Depencencies 
    private GameHandler gameHandler;
	
	//player GameObject info
    private Rigidbody2D pRb2D;
    private Animator pAnimator;
    public GameObject pStand;
	public GameObject pCrouch;
    public Transform pGroundPoint;
    public Transform checkpoint;
    public Transform bottomOfLevel;
	
	//Layer info
    public LayerMask groundLayer;
    public LayerMask enemyLayer;
	
	//Stat Tracker
    public bool isAlive = true;
    private bool FaceRight = false;
	private bool canDoubleJump = false;
    public int fallDamage = 100;
    public float startSpeed = 10f;
    private float runSpeed;
    public float jumpForce = 25f;
	public float deathJumpForce = 10f;
    public float fallGravityMultiplier = 10f;
    public float jumpGravityMultiplier = 8f;
	public float groundRange = 0.01f;
	public float windSpeed = 5f;
	
	//others
    //public AudioSource WalkSFX;
    //public AudioSource JumpSFX;
    private Vector3 hMove;
    private Vector3 hLMove;
    private Vector3 hRMove;

    void Awake()
    {
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        pRb2D = GetComponent<Rigidbody2D>();
        pAnimator = GetComponent<Animator>();
		runSpeed = startSpeed;
    }
	
	void Start()
    {
		pStand.SetActive(true);
		pCrouch.SetActive(false);
    }

    void Update()
    {
		//Player animation
        // if (Input.GetAxis("Horizontal") != 0){
        //       animator.SetBool ("Walk", true);
        //       if (!WalkSFX.isPlaying){
        //             WalkSFX.Play();
        //       }
        // } else {
        //      animator.SetBool ("Walk", false);
        //      WalkSFX.Stop();
        // }

        //Player Facing direction change
        if ((hMove.x < 0 && !FaceRight) || (hMove.x > 0 && FaceRight))
        {
            playerTurn();
        }
		
		//Jump
		if ((Input.GetButtonDown("Jump")) && (IsGrounded()) && (isAlive == true))
        {
            Jump();
            // animator.SetTrigger("Jump");
            // JumpSFX.Play();
        }
		
		if ((Input.GetButtonDown("Jump")) && (canDoubleJump) && (!IsGrounded()) && (isAlive == true))
        {
            Jump();
			canDoubleJump = false;
            // animator.SetTrigger("Jump");
            // JumpSFX.Play();
        }
		
		if ((IsGrounded()) && (!canDoubleJump) && (GameHandler.doubleJumpActive)) {
			canDoubleJump = true;
		}
		
		//Crouch Interactions
		if ((Input.GetButtonDown("Crouch")) && (IsGrounded()) && (isAlive == true) && (GameHandler.finalBank == false))
        {
            pStand.SetActive(false);
			pCrouch.SetActive(true);
            //animator.SetBool("Crouch", true);
        }
		
        if ((Input.GetButtonUp("Crouch") == true) && (GameHandler.finalBank == false))
        {
            pStand.SetActive(true);
			pCrouch.SetActive(false);
            //animator.SetBool("Crouch", false);
        }
		
		//fall respawn mechanic
        if (bottomOfLevel.position.y >= transform.position.y)
		{
			//instantiate a particle effect
			gameHandler.playerLoseEssence(fallDamage);
			Vector3 pSpn2 = new Vector3(checkpoint.position.x, checkpoint.position.y, transform.position.z);
			transform.position = pSpn2;
		}
    }

    void FixedUpdate()
    {
		//Player LR movement
        hMove = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        if (isAlive == true)
        {
            transform.position = transform.position + hMove * runSpeed * Time.deltaTime;
        }
		
        //slow down on hills / stops sliding from velocity
        if (hMove.x == 0)
        {
            pRb2D.velocity = new Vector2(pRb2D.velocity.x / 1.1f, pRb2D.velocity.y);
        }
		
		// better fall
        if (pRb2D.velocity.y < 0) {
            pRb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallGravityMultiplier - 1) * Time.deltaTime;
        } 
		else if (pRb2D.velocity.y > 0) {
            pRb2D.velocity += Vector2.up * Physics2D.gravity.y * (jumpGravityMultiplier - 1) * Time.deltaTime;
        }
    }

    private void playerTurn()
    {
        // NOTE: Switch player facing label
        FaceRight = !FaceRight;

        // NOTE: Multiply player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void playerMoveModify(float multiplier, bool isNormal)
    {
        if (isNormal == true)
        {
            runSpeed = startSpeed;
            //isSpeedChange = false;
            //myRend.material.color = defaultColor;
        }
        else
        {
            runSpeed = (startSpeed * multiplier);
            //isSpeedChange = true;
            //Debug.Log("Speed is now: " + runSpeed);
            //myRend.material.color = new Color(1.0f, 1.0f, 2.5f);
        }
    }
	
	public void Jump()
    {
        pRb2D.velocity = Vector2.up * jumpForce;
    }
	
	public void playerHit(){
        //animator.SetTrigger ("GetHurt");
    }

    public void playerDead(){
		if (isAlive == true) {
			pRb2D.velocity = Vector2.up * deathJumpForce;
			pRb2D.isKinematic = true;
			//animator.SetTrigger ("Dead");
			isAlive = false;
		}
    }
	
	public void WindMoveLeft() {
		if (isAlive == true) {
			hLMove = new Vector3(-1f, 0.0f, 0.0f);
			transform.position = transform.position + hMove * windSpeed * Time.deltaTime;
		}
	}
	
	public void WindMoveRight() {
		if (isAlive == true) {
			hRMove = new Vector3(1f, 0.0f, 0.0f);
			transform.position = transform.position + hMove * windSpeed * Time.deltaTime;
		}
	}

    public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(pGroundPoint.position, 2f, groundLayer);
        Collider2D enemyCheck = Physics2D.OverlapCircle(pGroundPoint.position, 2f, enemyLayer);
        if ((groundCheck != null) || (enemyCheck != null))
        {
            return true;
        }
        return false;
    }
}
