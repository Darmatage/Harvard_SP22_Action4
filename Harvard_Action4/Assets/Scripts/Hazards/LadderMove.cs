using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class LadderMove : MonoBehaviour
{
    public GameObject upper;
    private Transform playerTrans;
    private Rigidbody2D playerRB;
    public float upSpeed = 10f;
    private Vector3 vMove;
    public GameObject marker;

    public bool canLadder = false;

    void Start()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            playerTrans = GameObject.FindWithTag("Player").GetComponent<Transform>();
            playerRB = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        vMove = new Vector3(0.0f, Input.GetAxis("Vertical"), 0.0f);
        if (canLadder == true)
        {
            playerTrans.position = playerTrans.position + vMove * upSpeed * Time.deltaTime;
        }
    }
	
	void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            upper.GetComponent<Collider2D>().enabled = false; 
            canLadder = true;
            playerRB.gravityScale = 0;
            // if game has jumping, add bool to disable it, and set true here
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            upper.GetComponent<Collider2D>().enabled = true;
            canLadder = false;
            playerRB.gravityScale = 1;
            // if game has jumping, add bool to disable it, and set false here
        }
    }

}