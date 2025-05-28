using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharacterSwordAttack : MonoBehaviour
{
    [SerializeField]
    Animator anim;
    CharacterCod ccod;

    public Transform attackpoint;
    public LayerMask enemyLayers;

    public float attackRange= 0.5f;
    public int attackDamage = 40;

    private void Start()
    {
        anim = GetComponent<Animator>();
        ccod = GetComponent<CharacterCod>();
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            DamageEnemy();
            
        }
    }
    void DamageEnemy()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position, attackRange,enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            

            if (enemy != null && enemy.CompareTag("enemy"))
            {
                
                enemy.GetComponent<Enemy>().TakeDamage(20);
                
            }

            Debug.Log("zarar" + enemy.name);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackpoint== null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackpoint.position, attackRange);
    }

   
  
}
