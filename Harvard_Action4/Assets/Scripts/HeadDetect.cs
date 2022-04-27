using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadDetect : MonoBehaviour
{
    private GameObject Enemy;
	private Rigidbody2D rb2d;
	private bool attacking;
    public GameObject healthLoot;

    void Start()
    {
        Enemy = gameObject.transform.parent.gameObject;
    }
	
	void FixedUpdate(){
		attacking = Enemy.GetComponent<EnemyMoveHit>().isAttacking;
		rb2d = Enemy.GetComponent<Rigidbody2D>();
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
		if (other.gameObject.tag == "Player" && attacking == false) {
			//disable damage
			Enemy.GetComponent<EnemyMoveHit>().isAlive = false;
			Enemy.GetComponent<Collider2D>().enabled = false;
			//play death animation 
			GetComponent<Collider2D>().enabled = false;
            Enemy.GetComponent<SpriteRenderer>().flipY = true;
			rb2d.velocity = Vector2.up * 5f;
			
            //Debug.Log("You killed a baddie. You deserve loot!");
            StartCoroutine(DestroyThis());
			// Enemy.GetComponent<Collider2D>().enabled = false;
            // Vector3 movement = new Vector3(Random.Range(40, 70), Random.Range(-40, 40), 0f);
            // Enemy.transform.position += movement * Time.deltaTime;
            // Enemy.GetComponent<Rigidbody2D>().gravityScale = 4;
		}
    }

	IEnumerator DestroyThis(){
		//anim.SetBool ("isDead", true);
		yield return new WaitForSeconds(0.5f);
		Instantiate (healthLoot, transform.position, Quaternion.identity);
		yield return new WaitForSeconds(0.5f);
		Destroy(Enemy);
	}
}
