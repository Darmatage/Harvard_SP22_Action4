using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankCheckpoint : MonoBehaviour
{
    private PlayerMovement playerMov;
	
    // Start is called before the first frame update
    void Start()
    {
        playerMov = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }
	
	void OnTriggerEnter2D(Collider2D other) {
		if (playerMov.checkpoint != null) {
			playerMov.checkpoint.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
			Debug.Log("position is" + playerMov.checkpoint.position);
			
		} else {
			Debug.Log("position is null");
		}
	}
}
