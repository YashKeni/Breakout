using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnergyDisplay : MonoBehaviour
{
    TextMeshProUGUI energyText;
    Energy energy;
    // Start is called before the first frame update
    void Start()
    {
        energyText = GetComponent<TextMeshProUGUI>();
        energy = FindObjectOfType<Energy>();
    }

    // Update is called once per frame
    void Update()
    {
        energyText.text = ": " + energy.GetCurrentEnergy().ToString();
    }
}
