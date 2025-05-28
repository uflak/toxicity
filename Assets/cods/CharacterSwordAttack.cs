using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSwordAttack : MonoBehaviour
{
    [SerializeField]
    Animator Anim;
    CharacterCod ccod;

    public Transform attackpoint;
    public LayerMask enemyLayers;

    public float attackRange= 0.5f;
    public int attackDamage = 20;

    public bool cut;
    public float cutTimer;

    private void Start()
    {
        ccod = GetComponent<CharacterCod>();
        Anim = GetComponent<Animator>();
        cutTimer = 0.5f;

    }

    private void Update()
    {
        if (!PauseMenu.ispaused && Keyboard.current.xKey.wasPressedThisFrame && cut)
        {
            FindFirstObjectByType<AudioManager>().Play("sattack");
            DamageEnemy();
            cut = false;
        }

        ReloadSpacing();
    }

    void ReloadSpacing()
    {
        if (cut == false)
        {
            cutTimer -= Time.deltaTime;
        }

        if (cutTimer < 0)
        {
            cutTimer = 0f;
        }

        if (cutTimer == 0f)
        {
            cut = true;
            cutTimer = 0.5f;
        }
    }
    void DamageEnemy()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position, attackRange,enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            

            if (enemy != null && enemy.CompareTag("enemy"))
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            }
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
