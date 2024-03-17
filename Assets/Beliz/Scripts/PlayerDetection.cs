using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    void OnTriggerEnter(Collider other){

        if (other.CompareTag("Player"))
        {
            GetComponentInParent<Rigidbody>().isKinematic = false;
        }
    }
}
