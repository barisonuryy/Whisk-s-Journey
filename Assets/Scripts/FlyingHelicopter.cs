using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingHelicopter : MonoBehaviour
{
    public GameObject successPanel2;
    
    public GameObject player;
    public GameObject _camera;
    public float speed = 10f;
    public Transform destination;
    private bool hasReachedDestination = false;

    public Transform rotorBlades;
    public float rotorSpeed = 500f; 

    void Update()
    {
        if (hasReachedDestination)
        {
            if (transform.position.y < 36)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            transform.position = Vector3.MoveTowards(transform.position, destination.position, speed * Time.deltaTime);    
            Vector3 direction = (destination.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Euler(0f, -43f, 0f);


            if (rotorBlades != null)
            {
                rotorBlades.Rotate(Vector3.up, rotorSpeed * Time.deltaTime);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasReachedDestination = true;
            player.SetActive(false);
            _camera.SetActive(true);

            if (successPanel2 != null)
            {
                successPanel2.SetActive(true);
            }
        }
    }
}

