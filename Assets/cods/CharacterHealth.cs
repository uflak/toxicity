using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CharacterHealth : MonoBehaviour
{
    Animator Anim;

    //Health
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    //Enemy Spacing
    public bool enemyattack;
    public float enemytimer;

    public CharacterCod characterCod;

    public GameObject restart;

    public Text text;

    public bool gameOver;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    void Start()
    {
        Anim = GetComponent<Animator>();
        enemytimer = 1.5f;
    }

    void EnemyAttackSpacing()
    {
        if (enemyattack == false)
        {
            enemytimer -= Time.deltaTime;
        }

        if (enemytimer < 0)
        {
            enemytimer = 0f;
        }

        if (enemytimer == 0f)
        {
            enemyattack = true;
            enemytimer = 1.5f;
        }
    }

    public void CharacterDamage()
    {
        //if(Input.GetKeyDown(KeyCode.E))
        //{
        //    enemyattack = false;
        //}
    }

    //karakter damage alýyo
    public void TakeDamage(int damage)
    {
        //Anim.SetTrigger("ishurting");
        if (currentHealth <= 0 && enemyattack == true)
        {
            gameOver = true;
            FindFirstObjectByType<AudioManager>().Stop("font");
            FindFirstObjectByType<AudioManager>().Play("lose");
            text.text = "Game Over";
            Time.timeScale = 0;
            text.enabled = true;
            restart.SetActive(true);
        }
        if (enemyattack)
        {
            Anim.SetTrigger("isHurt");
            FindFirstObjectByType<AudioManager>().Play("churt");
            currentHealth -= damage;
            enemyattack = false;
        }
        healthBar.SetHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyAttackSpacing();
        CharacterDamage();

        //if(Input.GetKeyDown(KeyCode.Z))
        //{
        //    TakeDamage(20);
        //}
    }
}

