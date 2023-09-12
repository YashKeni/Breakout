using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Energy energySlot;
    [SerializeField] Key keySlot;

    [SerializeField] float hitPoints = 100f;

    void Update()
    {
        
    }

    public void UseEnergy(int energySpent)
    {
        if(energySlot.GetCurrentEnergy() > 0)
        {
            energySlot.ReduceCurrentEnergy(energySpent);
        }   
    }
    public void UseKey(int keySpent)
    {
        if(keySlot.GetCurrentKeyValue() > 0)
        {
            keySlot.ReduceCurrentKey(keySpent);
        }   
    }

    public float TakeDamage(float damage)
    {
        hitPoints -= damage;
        if(hitPoints <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
        return hitPoints;
    }

    public float GetHealth()
    {
        return hitPoints;
    }

}
