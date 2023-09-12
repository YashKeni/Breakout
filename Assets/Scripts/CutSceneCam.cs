using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneCam : MonoBehaviour
{
    public Canvas gameplayCanvas;
    public GameObject weaponModel;
    Weapon weapon;

    void Start()
    {
        weapon = FindObjectOfType<Weapon>();
    }

    public void DeactivateGUI()
    {
        gameplayCanvas.enabled = false;
        weapon.allowFire = false;
        weaponModel.SetActive(false);
    }

    public void ActivateGUI()
    {
        gameplayCanvas.enabled = true;
        weapon.allowFire = true;
        weaponModel.SetActive(true);
    }
}
