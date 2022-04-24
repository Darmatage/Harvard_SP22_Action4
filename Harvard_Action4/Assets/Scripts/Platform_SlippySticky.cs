using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{

    private PlayerMove pMove;
    public bool isSlippery = false;
    public float slipperyMultiplier = 3f;
    public float stickyMultiplier = 0.2f;

    void Start()
    {
        pMove = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
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

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            pMove.playerMoveModify(0f, true);
            //Debug.Log("I am moving normally!");
        }
    }
}