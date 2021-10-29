using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndBack : MonoBehaviour
{
    public float force = 10.0f;
    public bool direction = true;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }


    void Update()
    {
        Vector3 a = rb.position;
        Vector3 b = new Vector3(0.0f ,rb.position.y, rb.position.z );
        Vector3 c = new Vector3(10.0f, rb.position.y, rb.position.z);

        var moveAmount = force * Time.deltaTime;
        if(direction)
        {
            rb.position = Vector3.MoveTowards(rb.position, c, moveAmount);
        }
        else if(!direction)
        {
            rb.position = Vector3.MoveTowards(a, b, moveAmount);
        }
        if (rb.position.x >= 10.0f && direction)
        {
            direction = false;

        }
        else if(rb.position.x <=0.0f && !direction)
        {
            direction = true;
        }
    }
}
