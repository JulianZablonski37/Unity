using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndRotat : MonoBehaviour
{
    public float force = 10.0f;
    public int directions = 0;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }


    void Update()
    {

        Vector3 a = new Vector3(0.0f, rb.position.y, 0.0f);
        Vector3 b = new Vector3(10.0f, rb.position.y, rb.position.z);
        Vector3 c = new Vector3(10.0f, rb.position.y, 10.0f);
        Vector3 d = new Vector3(0.0f, rb.position.y, 10.0f);
        var moveAmount = force * Time.deltaTime;
        if (rb.position.x >= 10.0f && directions==0)
        {
            directions = 1;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (rb.position.z >= 10.0f && directions == 1)
        {
            directions = 2;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (rb.position.x <= 0.0f  && directions == 2)
        {
            directions = 3;
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        else if (rb.position.z <= 0.0f  && directions == 3)
        {
            directions = 0;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (directions==0)
        {
            rb.position = Vector3.MoveTowards(rb.position, b, moveAmount);
        }
        else if (directions==1)
        {
            rb.position = Vector3.MoveTowards(rb.position, c, moveAmount);
        }
        else if (directions == 2)
        {
            rb.position = Vector3.MoveTowards(rb.position, d, moveAmount);
        }
        else if (directions == 3)
        {
            rb.position = Vector3.MoveTowards(rb.position, a, moveAmount);
        }
       
    }
}
