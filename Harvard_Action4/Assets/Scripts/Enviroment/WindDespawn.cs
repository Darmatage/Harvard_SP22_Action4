using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindDespawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		StartCoroutine(DestroyThis());
    }
	
	IEnumerator DestroyThis(){
		yield return new WaitForSeconds(10f);
		Destroy(gameObject);
	}
}
