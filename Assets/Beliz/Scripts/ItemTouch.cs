using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ItemTouch : MonoBehaviour
{
    
    [SerializeField] GameObject[] health;
    private int heartsRemaining = 3;
    public GameObject gameOverPanel;

    void OnTriggerEnter(Collider other){
        Player player = other.GetComponent<Player>();

        if (other.CompareTag("Player"))
        {
            heartsRemaining--;
            health[heartsRemaining].gameObject.SetActive(false);

            if (heartsRemaining <= 0)
            {
                gameOverPanel.SetActive(true);
            }


        }
    }
}
