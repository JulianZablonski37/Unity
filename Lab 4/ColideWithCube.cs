using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColideWithCube : MonoBehaviour
{

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Obstacle")
        {
            Debug.Log("You cant go  through it");    
        }
    }

}
