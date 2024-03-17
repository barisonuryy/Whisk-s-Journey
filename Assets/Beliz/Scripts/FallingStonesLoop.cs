using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStonesLoop : MonoBehaviour
{
    public List<GameObject> stones = new List<GameObject>();

    public float amplitude = 0.1f; 
    public float speed = 2.0f;
    private Vector3 initialPosition; 
    public float xAngle, yAngle, zAngle;
    
    void Start()
    {
        initialPosition = transform.position;
    }

    
    void Update()
    {
        float sinValue = Mathf.Sin(Time.time * speed);
        Vector3 offset = Vector3.up * sinValue * amplitude;

        transform.position = initialPosition + offset;
        transform.Rotate(xAngle, yAngle, zAngle);
    }

}
