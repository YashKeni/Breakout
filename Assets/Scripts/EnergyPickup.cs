using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPickup : MonoBehaviour
{
    [SerializeField] int energyPickValue;

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            FindObjectOfType<Energy>().IncreaseCurrentEnergy(energyPickValue);
            Destroy(gameObject);
        }
    }
}
