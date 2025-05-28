using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnRate;

    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private bool canSpawn = true;

    public GameObject powerUp;

    public bool powerUpped;

    public float time;

    public CharacterSwordAttack Sword;

    public Text powerUpText;

    public CharacterHealth health;

    public HealthBar healthBar;

    public Enemy enemy;

    private void Start()
    {
        time = 3f;
        spawnRate = 7f;
        powerUpped = false;

        StartCoroutine(Spawner());
    }

    private void Update()
    {
        if (powerUpped)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
            }
            if (time < 0)
            {
                powerUp.SetActive(false);
                powerUpped = false;
                time = 3f;
            }
        }

    }

    private IEnumerator Spawner()
    {
        int enemies = 0;

        int dusmanSayisi = Random.Range(3, 11);

        int dalgaSayisi = 0;
        
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);

            Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            enemies++;

            /*zombileri her turda random sayýda spawnlat 10 olmasýn yani random sayýda gelsin*/

            if(enemies == dusmanSayisi)
            {
                dalgaSayisi++;

                enemies = 0;

                dusmanSayisi = Random.Range(3, 11) + dalgaSayisi * 3;

                health.currentHealth = 100;
                healthBar.SetHealth(health.currentHealth);

                Sword.attackDamage = 20 + dalgaSayisi * 5;

                spawnRate /= 1.1f;

                if(!powerUpped)
                {
                    powerUpText.text = dalgaSayisi + ". Düþman Dalgasýný Yendiðiniz Ýçin Hasarýnýz " + (dalgaSayisi * 5 + 20) + " Oldu";
                    powerUp.SetActive(true);
                    powerUpped = true;
                }
            }
        }
    }
}
