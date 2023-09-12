using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    [SerializeField] public int energyAmount = 0;

    public int GetCurrentEnergy()
    {
        return energyAmount;
    }

    public void ReduceCurrentEnergy(int energySpent)
    {
        energyAmount = energyAmount - energySpent;
    }

    public void IncreaseCurrentEnergy(int energyPickValue)
    {
        energyAmount += energyPickValue;
    }
}
