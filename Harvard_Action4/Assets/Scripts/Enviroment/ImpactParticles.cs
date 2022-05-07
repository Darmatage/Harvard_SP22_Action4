using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactParticles : MonoBehaviour
{

    public GameObject hitParticles;
    public Vector3 spwnPoint;

    void OnTriggerEnter2D(Collider2D other)
    {
        //if the impact has enough force
        if (other.tag == "Lava")
        {
            //get impact location
            spwnPoint = transform.position;
            //make particles
            GameObject particleSys = Instantiate(hitParticles, spwnPoint, other.transform.rotation);
            StartCoroutine(destroyParticles(particleSys));
        }
       
    }

    IEnumerator destroyParticles(GameObject pSys)
    {
        yield return new WaitForSeconds(4f);
        Destroy(pSys);
    }
}