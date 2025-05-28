using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraS : MonoBehaviour
{
    public Transform targetObject; // Kameranýn takip edeceði hedef nesne
    public Vector3 offset = new Vector3(0f, 2f, -5f); // Kameranýn hedef nesneye olan ofseti
    public float smoothSpeed = 0.125f; // Kameranýn takip hýzý

    void LateUpdate()
    {
        if (targetObject == null)
            return; // Hedef nesne yoksa iþlem yapma

        Vector3 desiredPosition = targetObject.position + offset; // Hedef nesnenin pozisyonuna ofseti ekle
        desiredPosition.y = -0.55f; // Y eksenindeki pozisyonu sabit tut
        Quaternion desiredRotation = Quaternion.LookRotation(targetObject.position - desiredPosition, Vector3.up); // Hedef nesneye bakacak rotasyonu hesapla
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Düzgün bir hareket için pozisyonu yumuþat
        transform.rotation = Quaternion.Euler(0f, 0f, 0f); // Kameranýn rotasyonunu sabit tut (sadece y eksenindeki rotasyonu kullan)

    }
}
