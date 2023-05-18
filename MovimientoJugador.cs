using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
      // Definir variables públicas para la velocidad y la fuerza del salto
public float speed = 5f;
public float jumpForce = 10f;

// Obtener los componentes necesarios del personaje
private Rigidbody2D rb2d;
private Animator anim;

// Detectar si el personaje está tocando el suelo
private bool isGrounded;
public Transform ControladorSuelo;
public float checkRadius;
public LayerMask QueEsSuelo;
// Detectar la dirección del movimiento
private bool facingRight = true;

// Obtener la referencia a la cámara
public Transform camTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
