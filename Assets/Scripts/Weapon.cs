using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] float rateOfFire = 1f;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] TextMeshProUGUI ammoText;
    public bool allowFire = true;
    [SerializeField] AudioClip shootSFX;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject notEnoughAmmoText;
    Animator recoilAnimation;

    private void Start() 
    {
        audioSource = GetComponent<AudioSource>();
        notEnoughAmmoText.SetActive(false);
        recoilAnimation = GetComponent<Animator>();
    }

    void Update()
    {
        DisplayText();
        if (Input.GetButton("Fire1") && allowFire)
        {
            StartCoroutine(AutoFire());
            allowFire = false;
        }
    }

    private void DisplayText()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = ": " + currentAmmo.ToString();
    }

    IEnumerator AutoFire()
    {
        Shoot();
        yield return new WaitForSeconds(rateOfFire);
        allowFire = true;
    }

    public void Shoot()
    {
        if(ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            PlayShootSound();
            PlayMuzzleFlash();
            ProcessRayCast();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }
        else
        {
            StartCoroutine(ShowNoAmmoText());
            
        }
        
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void PlayShootSound()
    {
        audioSource.PlayOneShot(shootSFX, .5f);
        
    }

    private void ProcessRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, .1f);
    }

    IEnumerator ShowNoAmmoText()
    {
        notEnoughAmmoText.SetActive(true);
        yield return new WaitForSeconds(3f);
        notEnoughAmmoText.SetActive(false);
    }
}
