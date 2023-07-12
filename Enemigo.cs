using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public GameObject canvas; // El objeto Canvas que se activará al entrar en contacto con el jugador

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jugador"))
        {
            canvas.SetActive(true); // Activa el objeto Canvas
        }
    }
}
