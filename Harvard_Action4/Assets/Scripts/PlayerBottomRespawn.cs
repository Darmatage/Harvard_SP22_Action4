using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerBottomRespawn : MonoBehaviour
{
    private GameHandler gameHandler;
    private Transform playerPos;
    public Transform pSpawn;
    public int damage = 100;


    void Start()
    {
        playerPos = GameObject.FindWithTag("Player").GetComponent<Transform>();
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
    }

    void Update()
    {
        if (playerPos != null)
        {
            if (transform.position.y >= playerPos.position.y)
            {
                //instantiate a particle effect
                gameHandler.playerLoseEssence(damage);
                Vector3 pSpn2 = new Vector3(pSpawn.position.x, pSpawn.position.y, playerPos.position.z);
                playerPos.position = pSpn2;
            }
        }
    }
}