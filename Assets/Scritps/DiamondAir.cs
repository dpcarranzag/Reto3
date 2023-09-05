using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiamondAir : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI diamondAirText;

    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.DiamondCollectedAir();
            diamondAirText.text = playerInventory.NumberofDiamondsAir.ToString();
            gameObject.SetActive(false);
            
            
        }
    }
}
