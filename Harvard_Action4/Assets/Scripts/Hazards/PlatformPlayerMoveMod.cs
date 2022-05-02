using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPlayerMoveMod : MonoBehaviour
{
	private PlayerMovement pMove;
    public bool isSlippery = false;
    public float slipperyMultiplier = 3f;
    public float stickyMultiplier = 0.2f;
    public float slipperyMultiplierTrigger = 1.5f;
    public float stickyMultiplierTrigger = 0.8f;

    void Start()
    {
        pMove = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (isSlippery == true)
            {
                //Debug.Log("I am a slippery platform");
                pMove.playerMoveModify(slipperyMultiplier, false);
            }
            else
            {
                //Debug.Log("I am a sticky platform");
                pMove.playerMoveModify(stickyMultiplier, false);
            }
        }
    }
	
	void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (isSlippery == true)
            {
                //Debug.Log("I am a slippery platform");
                pMove.playerMoveModify(slipperyMultiplier, false);
            }
            else
            {
                //Debug.Log("I am a sticky platform");
                pMove.playerMoveModify(stickyMultiplier, false);
            }
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            pMove.playerMoveModify(0f, true);
            //Debug.Log("I am moving normally!");
        }
    }
	
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            pMove.playerMoveModify(0f, true);
            //Debug.Log("I am moving normally!");
        }
    }
}
