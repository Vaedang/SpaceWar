using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltMove : MonoBehaviour
{
    public Rigidbody rig;
    public float speed;
    void Start()
    {
        rig.velocity = transform.forward * speed;
    }

   
}
