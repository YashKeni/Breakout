using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    Player target;
    [SerializeField] float damage = 40f;
    [SerializeField] AudioClip attackSFX;
    [SerializeField] AudioSource audioSource;
    
    void Start()
    {
        target = FindObjectOfType<Player>();
        audioSource = GetComponent<AudioSource>();
    }

    public void AttackHitEvent()
    {
        if(target == null) return;
        target.TakeDamage(damage);
        target.GetComponent<DamageDisplay>().ShowDamage();
        audioSource.PlayOneShot(attackSFX, .5f);
    }
}
