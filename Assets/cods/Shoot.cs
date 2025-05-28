using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    public Animator anim;
    public Transform shootingPoint;
    public GameObject bulletPrefab;

    public static bool freeze;

    public bool fire;
    public float fireTimer;
    // Update is called once per frame

    private void Start()
    {
        anim= GetComponent<Animator>();
        fireTimer = 1.5f;
    }

    void Update()
    {
        if(!PauseMenu.ispaused && Keyboard.current.spaceKey.wasPressedThisFrame && fire)
        {
            anim.SetTrigger("isFire");
            FindFirstObjectByType<AudioManager>().Play("gun");
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            fire = false;
        }

        ReloadSpacing();

        if (!PauseMenu.ispaused && Keyboard.current.rKey.wasPressedThisFrame)
        {
            Reload();
        }
    }

    public void Reload()
    {
        if(fire)
        {
            fire = true;
        }
    }

    void ReloadSpacing()
    {
        if (fire == false)
        {
            fireTimer -= Time.deltaTime;
        }

        if (fireTimer < 0)
        {
            fireTimer = 0f;
        }

        if (fireTimer == 0f)
        {
            fire = true;
            fireTimer = 1.5f;
        }
    }
}
