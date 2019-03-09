using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rigid;
    public float speed;
    public float xMin, xMax, zMin, zMax;
    public float tilt;

    public GameObject shot;
    public Transform shotSpawner;
    float nextFireTime, fireRate;
    

    void Start()
    {
        speed = 10;
        xMin = -6.11f;
        xMax = 6.07f;
        zMin = -4.12f;
        zMax = 14.09f;
        tilt = 5;
    }

    void Update()
    {
        if (Input.GetKeyDown("j") && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Instantiate(shot, shotSpawner.position, Quaternion.identity);
        }    
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigid.velocity = movement*speed;

        rigid.position = new Vector3(
            Mathf.Clamp(rigid.position.x,xMin,xMax),
            0.0f,
            Mathf.Clamp(rigid.position.z,zMin,zMax)
            );

        rigid.rotation = Quaternion.Euler(0.0f, 0.0f, rigid.position.x * -tilt);
    }
}
