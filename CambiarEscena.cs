using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public void Cambiar (string escena)
    {
        SceneManager.LoadScene(escena);
    }
    public void Salir()
    {
        Application.Quit(); // Cierra el juego
    }
    
}
