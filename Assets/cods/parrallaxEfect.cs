using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parrallaxEfect : MonoBehaviour
{
        public float parallaxSpeed ; // H�z� ayarlamak i�in de�i�ken

        private float startPosX;
        private float length;

        private void Start()
        {
            startPosX = transform.position.x;
            length = GetComponent<SpriteRenderer>().bounds.size.x; // Sprite boyutunu al�r
        }

        private void Update()
        {
            float temp = (Camera.main.transform.position.x * (1 - parallaxSpeed));
            float dist = (Camera.main.transform.position.x * parallaxSpeed);

            transform.position = new Vector3(startPosX + dist, transform.position.y, transform.position.z);

            if (temp > startPosX + length)
            {
                startPosX += length;
            }
            else if (temp < startPosX - length)
            {
                startPosX -= length;
            }
        }
    }


