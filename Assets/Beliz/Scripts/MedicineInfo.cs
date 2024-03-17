using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineInfo : MonoBehaviour
{
    public GameObject medicinePanel;

    void OnTriggerEnter(Collider other){
        Player player = other.GetComponent<Player>();

        if (other.CompareTag("Player"))
        {
            
            medicinePanel.SetActive(true);

            Invoke("ClosePanel", 3);
        }
    }

    private void ClosePanel(){
        Player player = GameObject.FindObjectOfType<Player>();

        if (player != null)
        {
            medicinePanel.SetActive(false);
        }
    }
}
