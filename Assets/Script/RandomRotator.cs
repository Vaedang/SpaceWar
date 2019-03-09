using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    public Rigidbody rig;
    public float tumble;
    // Start is called before the first frame update
    void Start()
    {
        rig.angularVelocity = Random.insideUnitSphere * tumble;
    }
    
}
