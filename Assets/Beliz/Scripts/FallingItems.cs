using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingItems : MonoBehaviour
{
    
    public List<GameObject> stone = new List<GameObject>();

    void OnTriggerEnter(Collider other){
        Player player = other.GetComponent<Player>();
        

        if (other.CompareTag("Player"))
        {
            foreach (var item in stone)
            {
                item.SetActive(true);
            }
            
            

        }
    }
}
