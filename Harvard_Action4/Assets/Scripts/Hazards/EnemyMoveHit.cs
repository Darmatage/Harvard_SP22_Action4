using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyMoveHit : MonoBehaviour {
	private GameHandler gameHandler;
	private Transform target;
	public GameObject enemyHead;
	public Animator anim;

	//metrics 
	public float speed = 4f;
	public double damage = 100;
	public float attackRange = 10;
	public float damageTime = 0.5f;

	//stats
	public bool isAttacking = false;
	public bool isAlive = true;
	private float scaleX;
	private float damageTimer = 0f;

	void Start () {
		anim = GetComponentInChildren<Animator> ();
		scaleX = gameObject.transform.localScale.x;

		if (GameObject.FindGameObjectWithTag ("Player") != null) {
			target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		}

		if (GameObject.FindWithTag ("GameHandler") != null) {
			gameHandler = GameObject.FindWithTag ("GameHandler").GetComponent<GameHandler> ();
		}
	}

	void Update () {
		float DistToPlayer = Vector3.Distance(transform.position, target.position);
				

		//enemy Basic AI movement
		if ((target != null) && (DistToPlayer <= attackRange)){
			transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
			if (isAttacking == false) {
				//anim.SetBool("Walk", true);
				//flip enemy to face player direction. Wrong direction? Swap the * -1.
				if (target.position.x > gameObject.transform.position.x){
					gameObject.transform.localScale = new Vector2(scaleX, gameObject.transform.localScale.y);
				} else {
					gameObject.transform.localScale = new Vector2(scaleX * -1, gameObject.transform.localScale.y);
				}
			}
			//else  { anim.SetBool("Walk", false);}
		}
		//else { anim.SetBool("Walk", false);}
	}
	   
	void FixedUpdate(){
		if (isAttacking == true && isAlive) {
			//deals continuous damage while in contact
			damageTimer += 0.1f;
			if (damageTimer >= damageTime) {
				gameHandler.playerLoseEssence(damage);
				damageTimer = 0f;
			}
		}
	}

       public void OnCollisionEnter2D(Collision2D collider){
              if (collider.gameObject.tag == "Player" && isAlive) {
                     isAttacking = true;
                     //anim.SetBool("Attack", true);
              }
       }

       public void OnCollisionExit2D(Collision2D collider){
              if (collider.gameObject.tag == "Player") {
                     isAttacking = false;
                     //anim.SetBool("Attack", false);
              }
       }

       //DISPLAY the range of enemy's attack when selected in the Editor
       void OnDrawGizmosSelected(){
              Gizmos.DrawWireSphere(transform.position, attackRange);
       }
}
