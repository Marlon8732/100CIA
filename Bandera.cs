using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bandera : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jugador"))
        {
            StartCoroutine(CambioEscena());
        }
        IEnumerator CambioEscena()
        {
            yield return new WaitForSeconds(2); // Pausa de tres segundos

            SceneManager.LoadScene("Inicio");
        }
    }
}
