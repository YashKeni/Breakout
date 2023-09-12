using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    [SerializeField] int keyValue;

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            FindObjectOfType<Key>().IncreaseCurrentKey(keyValue);
            Destroy(gameObject);
        }
    }
}
