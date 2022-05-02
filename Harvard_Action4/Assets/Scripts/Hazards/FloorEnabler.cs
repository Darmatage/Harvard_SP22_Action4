using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorEnabler : MonoBehaviour
{
    public GameObject upper;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            upper.GetComponent<BoxCollider2D>().enabled = true;
        
        }
    }
}
