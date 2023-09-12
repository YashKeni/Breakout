using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] public int currentWeapon = 0;
    Animator switchAnimation;
    public bool changeWeapon;

    float delay = .5f;
    float timer;
    void Start()
    {
        SetWeaponActive();
        switchAnimation = GetComponent<Animator>();
        changeWeapon = false;
    }

    void Update()
    {
        int previousWeapon = currentWeapon;

        ProcessKeyInput();
        ProcessScrollWheel();

        if(previousWeapon != currentWeapon)
        {
            SetWeaponActive();
        }
    }

    private void ProcessKeyInput()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(Switching());
            currentWeapon = 0;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartCoroutine(Switching());
            currentWeapon = 1;
        }
    }

    private void ProcessScrollWheel()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if(currentWeapon >= transform.childCount - 1)
            {
                currentWeapon = 0;
            }
            else
            {
                currentWeapon++;
            }
            StartCoroutine(Switching());
        }
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if(currentWeapon <= 0)
            {
                currentWeapon = transform.childCount - 1;
            }
            else
            {
                currentWeapon--;
            }
            StartCoroutine(Switching());
        }
    }

    IEnumerator Switching()
    {
        ToEquip();
        FindObjectOfType<Weapon>().allowFire = false;
        yield return new WaitForSeconds(delay);
        ToIdle();
        FindObjectOfType<Weapon>().allowFire = true;
    }

    private void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach(Transform weapon in transform)
        {
            if(weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }

    public void ToEquip()
    {
        switchAnimation.SetTrigger("change");
    }
    public void ToIdle()
    {
        switchAnimation.SetTrigger("end");
    }

    
}
