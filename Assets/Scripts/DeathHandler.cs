using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;

    void Start() 
    {
        gameOverCanvas.enabled = false;    
    }

    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        var firstPersonControllerCamera = GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        var mouseLook = firstPersonControllerCamera.m_MouseLook;
        mouseLook.SetCursorLock(false);
        firstPersonControllerCamera.enabled = false;
        FindObjectOfType<Weapon>().allowFire = false;
    }
}
