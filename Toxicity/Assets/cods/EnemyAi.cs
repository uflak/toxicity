using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class EnemyAi : MonoBehaviour
{
    [SerializeField]
    private Transform Target;
    public float speed;
    public float stopDistance;
    

    

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent< Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyFollow();
    }
    

    void EnemyFollow()
    {
        if (Vector2.Distance(transform.position,Target.position)>stopDistance)
        {
            
            Vector2 targetPosition = new Vector2(Target.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }

 
}
