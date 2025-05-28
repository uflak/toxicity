using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parrallaxEfect : MonoBehaviour
{
        public float parallaxSpeed ; // Hýzý ayarlamak için deðiþken

        private float startPosX;
        private float length;

        private void Start()
        {
            startPosX = transform.position.x;
            length = GetComponent<SpriteRenderer>().bounds.size.x; // Sprite boyutunu alýr
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


