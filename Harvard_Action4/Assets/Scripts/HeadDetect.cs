using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadDetect : MonoBehaviour
{
    GameObject Enemy;
    public GameObject healthLoot;

    void Start()
    {
        Enemy = gameObject.transform.parent.gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            GetComponent<Collider2D>().enabled = false;
            Enemy.GetComponent<SpriteRenderer>().flipY = true;
            Debug.Log("You killed a baddie. You deserve loot!");
            Die();
            // Enemy.GetComponent<Collider2D>().enabled = false;
            // Vector3 movement = new Vector3(Random.Range(40, 70), Random.Range(-40, 40), 0f);
            // Enemy.transform.position += movement * Time.deltaTime;
            // Enemy.GetComponent<Rigidbody2D>().gravityScale = 4;
    }

    void Die(){
           Instantiate (healthLoot, transform.position, Quaternion.identity);
           //anim.SetBool ("isDead", true);
           GetComponent<Collider2D>().enabled = false;
           Destroy(Enemy);
    }
}
