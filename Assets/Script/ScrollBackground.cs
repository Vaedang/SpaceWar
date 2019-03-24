using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeZ;
    GameObject obj;

    private Vector3 startPosition;

    void Awake()
    {
        obj = gameObject;
    }
    // Start is called before the first frame update
    void Start()
    {
        startPosition = obj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        obj.transform.position = startPosition + Vector3.forward * newPosition;
    }
}
