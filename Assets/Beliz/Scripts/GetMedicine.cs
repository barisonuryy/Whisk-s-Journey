using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMedicine : MonoBehaviour
{
    public GameObject medicine;
    public GameObject successPanel;

    void OnTriggerEnter(Collider other){
        Player player = other.GetComponent<Player>();

        if (other.CompareTag("Player"))
        {
            medicine.SetActive(true);
            player.StopCountdown();
            successPanel.SetActive(true);

            Invoke("ClosePanel", 3);
        }
    }

    private void ClosePanel(){
        Player player = GameObject.FindObjectOfType<Player>();

        if (player != null)
        {
            successPanel.SetActive(false);
        }
    }
}
