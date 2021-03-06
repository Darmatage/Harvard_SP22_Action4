using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	//Depencencies 
    private GameHandler gameHandler;
	public WindSpawner wind;
	
	//player GameObject info
    private Rigidbody2D pRb2D;
    private Animator pAnimator;
    public Transform checkpoint;
    public GameObject pStand;
	public GameObject pCrouch;
    public Transform pGroundPoint;
    public Transform bottomOfLevel;
	
	//Layer info
    public LayerMask groundLayer;
    public LayerMask enemyLayer;
	
	//Stat Tracker
    public bool isAlive = true;
    public bool isCrouching = false;
    private bool FaceRight = false;
	private bool canDoubleJump = false;
	private bool isMoveMod = false;
    public int fallDamage = 100;
    public float startSpeed = 10f;
    public float runSpeed;
    public float jumpForce = 25f;
    public float fallGravityMultiplier = 10f;
    public float jumpGravityMultiplier = 8f;
	public float groundRange = 0.1f;
	public float windSpeed = 5f;
    public float slipperyMultiplier = 3f;
    public float waterMultiplier = 0.8f;
    public float stickyMultiplier = 0.2f;
	public float deathJumpForce = 10f;
	
	//others
    //public AudioSource WalkSFX;
    //public AudioSource JumpSFX;
    private Vector3 hMove;
    public Vector3 windMove;

    void Awake()
    {
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
		checkpoint = GameObject.FindWithTag("PlayerSpawn").GetComponent<Transform>();
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
		if ((Input.GetButtonDown("Jump")) && (IsGrounded()) && (isAlive == true) && (isCrouching == false))
        {
            Jump();
            // animator.SetTrigger("Jump");
            // JumpSFX.Play();
        }
		
		if ((Input.GetButtonDown("Jump")) && (canDoubleJump) && (!IsGrounded()) && (isAlive == true) && (isCrouching == false))
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
		if ((Input.GetButtonDown("Crouch")) && (isAlive == true) && (GameHandler.finalBank == false) && (GameHandler.crouchStopWind == true))
        {
			isCrouching = true;
            pStand.SetActive(false);
			pCrouch.SetActive(true);
            //animator.SetBool("Crouch", true);
        }
		
        if ((Input.GetButtonUp("Crouch") == true) && (GameHandler.finalBank == false))
        {
			isCrouching = false;
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
		
		if (isCrouching == true) {
			runSpeed = 7.5f;
		} else if (isMoveMod == false) {
			runSpeed = startSpeed;
		}
    }

    void FixedUpdate()
    {
		//Player LR movement
        hMove = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        if (isAlive == true)
        {
            transform.position = transform.position + (hMove + windMove) * runSpeed * Time.deltaTime;
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
            pRb2D.velocity += Vector2.up * Physics2D.gravity.y * (jumpGravityMultiplier - 1) *  Time.deltaTime;
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
			isMoveMod = false;
            runSpeed = startSpeed;
            //isSpeedChange = false;
            //myRend.material.color = defaultColor;
        }
        else
        {
			isMoveMod = true;
            runSpeed = (startSpeed * multiplier);
            //isSpeedChange = true;
            //myRend.material.color = new Color(1.0f, 1.0f, 2.5f);
        }
    }
	
	public void Jump()
    {
		// if (gameHandler.isAlive == false) {
			// pRb2D.velocity = Vector2.up * deathJumpForce;
			// pRb2D.isKinematic = true;
			// isAlive = false;
		// } else {
			FindObjectOfType<AudioManager>().PlaySFX("Jump");
			pRb2D.velocity = Vector2.up * jumpForce;
		// }
    }

    // public void playerDead(){
		// if (isAlive == true) {
			// pRb2D.velocity = Vector2.up * deathJumpForce;
			// pRb2D.isKinematic = true;
			// animator.SetTrigger ("Dead");
			// isAlive = false;
		// }
    // }

    public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(pGroundPoint.position, groundRange, groundLayer);
        Collider2D enemyCheck = Physics2D.OverlapCircle(pGroundPoint.position, groundRange, enemyLayer);
        if ((groundCheck != null) || (enemyCheck != null))
        {
            return true;
        }
        return false;
    }
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Bank") {
			checkpoint.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
			// Debug.Log("position is" + checkpoint.position);
		}
		
        if (other.gameObject.tag == "Slippery") {
			playerMoveModify(slipperyMultiplier, false);
        } else if (other.gameObject.tag == "Sticky") {
            playerMoveModify(stickyMultiplier, false);
        } else if (other.gameObject.tag == "Water") {
			wind.windMod = 0.3f;
            playerMoveModify(waterMultiplier, false);
        }
	}	
	
	void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Slippery") {
			playerMoveModify(slipperyMultiplier, false);
        } else if (collider.gameObject.tag == "Sticky") {
            playerMoveModify(stickyMultiplier, false);
        }
    }

    void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Slippery") {
			playerMoveModify(0f, true);
        } else if (collider.gameObject.tag == "Sticky") {
            playerMoveModify(0f, true);
        } else if (collider.gameObject.tag == "Water") {
			wind.windMod = 0.75f;
            playerMoveModify(0f, true);
        }
    }
	
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Slippery") {
			playerMoveModify(0f, true);
        } else if (other.gameObject.tag == "Sticky") {
            playerMoveModify(0f, true);
        } else if (other.gameObject.tag == "Water") {
			wind.windMod = 0.75f;
            playerMoveModify(0f, true);
        }
    }
}
