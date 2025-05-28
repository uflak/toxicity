using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
   
    public Transform enemyAttackPoint;
    public LayerMask playerLayers;

    public float enemyAttackRange = 0.5f;
    public int enemyAttackDamage = 20;

    Animator Anim;

    public void DamagePlayer()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(enemyAttackPoint.position, enemyAttackRange, playerLayers);

        foreach (Collider2D player in hitEnemies)
        {
            Debug.Log(player.tag);
            GameObject playerObject = GameObject.FindWithTag("Player");

            if(playerObject != null)
            {
                Anim = GetComponent<Animator>();
                Anim.SetTrigger("enemyattack");

                CharacterHealth characterHealth = playerObject.GetComponent<CharacterHealth>();
                if (characterHealth != null)
                {
                    characterHealth.TakeDamage(enemyAttackDamage);
                }
                else
                {
                    Debug.LogWarning("Oyuncu nesnesi saðlýk bileþenine sahip deðil: " + player.name);
                }
            }
        }

    }
    private void OnDrawGizmosSelected()
    {
        if (enemyAttackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(enemyAttackPoint.position, enemyAttackRange);
    }

}
