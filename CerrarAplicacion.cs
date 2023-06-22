using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CerrarAplicacion : MonoBehaviour
{
    void Start()
    {
        Button botonCerrar = GetComponent<Button>();
        botonCerrar.onClick.AddListener(Cerrar);
    }

    void Cerrar()
    {
        // Salir de la aplicación (solo funciona en builds)
        Application.Quit();
    }
}
