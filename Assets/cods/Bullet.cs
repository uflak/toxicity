using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    //private GameObject greenParticles;
    public float speed;
    private Rigidbody2D rb;

    public float life = 3;

    private void Awake()
    {
        Destroy(gameObject, life);
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
     
            Enemy enemy = collision.GetComponent<Enemy>();
            
            if (enemy != null && enemy.CompareTag("enemy"))
            {
                Debug.Log("vurdu");
                enemy.TakeDamage(40);
                Destroy(gameObject);
            }
            
    }

}
