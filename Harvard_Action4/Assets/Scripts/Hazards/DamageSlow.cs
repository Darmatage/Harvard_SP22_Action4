using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class DamageSlow : MonoBehaviour
{

    public double damage = 100;
    public float damageTime = 0.5f;
    private bool isDamaging = false;
    private float damageTimer = 0f;
    private GameHandler gameHandlerObj;

    void Start()
    {
        if (GameObject.FindWithTag("GameHandler") != null)
        {
            gameHandlerObj = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        }
    }

    void FixedUpdate()
    {
        if (isDamaging == true)
        {
            damageTimer += 2f;
            if (damageTimer >= damageTime)
            {
                gameHandlerObj.playerLoseEssence(damage);
                damageTimer = 0f;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isDamaging = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isDamaging = false;
        }
    }
}