using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public Rigidbody2D rb;

    public int health;
    private Animator anim;
    EnemyAi ai;
    public float life = 1;

    public void Awake()
    {
        health = 200;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ai = GetComponent<EnemyAi>();
        StartCoroutine(MyCoroutine());

    }

    public void TakeDamage(int damage)
    {
        FindFirstObjectByType<AudioManager>().Play("zhurt");
        StartCoroutine(MyCoroutine());
        health -= damage;
        anim.SetTrigger("enemyhurting");
        if (health <= 0)
        {
            if (anim != null)
            {
                FindFirstObjectByType<AudioManager>().Play("zdeath");
                GetComponent<Collider2D>().enabled = false;
                ai.speed = 0;
                rb.gravityScale = 0f;

                anim.SetTrigger("enemydeathing");
                          
            }
           
        }
    }
    void enemydestroyed()
    {
        Destroy(gameObject);
    }
    

    IEnumerator MyCoroutine()
    {
        ai.speed *= 0.0001f;
        yield return new WaitForSeconds(0.2f);
        ai.speed *=10000;

    }
}