using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CameraFollow2DLERP : MonoBehaviour
{

    private GameObject target;
    public float camSpeed = 20.0f;
    public float vertical = 4;

    void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {

        Vector2 pos = Vector2.Lerp((Vector2)transform.position, (Vector2)target.transform.position, camSpeed * Time.fixedDeltaTime);
        transform.position = new Vector3(pos.x, pos.y + vertical, transform.position.z);
    }
}
