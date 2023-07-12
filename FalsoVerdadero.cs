using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FalsoVerdadero : MonoBehaviour
{
   [SerializeField]
    private Image[] respuestas;
    [SerializeField]
    public GameObject canvas; // El objeto Canvas que se activará al entrar en contacto con el jugador
    public GameObject objetoADestruir; // Referencia al objeto que se destruirá

    public void ValidarPregunta(bool resp)
    {
        Time.timeScale = 0f; // Pausa el juego

        if (resp)
        {
            respuestas[0].gameObject.SetActive(true);
        }
        else
        {
            respuestas[1].gameObject.SetActive(true);
        }

        StartCoroutine(DesactivarCanvasYDestruirObjeto()); // Desactiva el canvas y destruye el objeto después de 3 segundos
    }

    private IEnumerator DesactivarCanvasYDestruirObjeto()
    {
        yield return new WaitForSecondsRealtime(3f); // Espera 3 segundos en tiempo real

        canvas.SetActive(false); // Desactiva el objeto Canvas

        if (objetoADestruir != null)
        {
            Destroy(objetoADestruir); // Destruye el objeto definido desde Unity
        }

        Time.timeScale = 1f; // Reanuda el juego
    }
}
