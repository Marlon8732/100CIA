using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
  // Definir variables públicas para la velocidad y la fuerza del salto
public float speed = 5f;
public float jumpForce = 5f;
public int maxJumpCount = 2; // Número máximo de saltos permitidos
private int jumpCount = 0; // Contador de saltos realizados

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



void Start()
{
    // Obtener los componentes del personaje
    rb2d = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();

    
}

void FixedUpdate()
{
    // Detectar si el personaje está tocando el suelo
    isGrounded = Physics2D.OverlapCircle(ControladorSuelo.position, checkRadius, QueEsSuelo);

    // Obtener la entrada horizontal del jugador
    float horizontalInput = Input.GetAxis("Horizontal");

    // Mover el personaje en la dirección adecuada
    rb2d.velocity = new Vector2(horizontalInput * speed, rb2d.velocity.y);

    // Girar el personaje hacia la dirección del movimiento
    if (horizontalInput > 0 && !facingRight)
    {
        Flip();
    }
    else if (horizontalInput < 0 && facingRight)
    {
        Flip();
    }

    // Actualizar el estado de la animación
    anim.SetFloat("Speed", Mathf.Abs(horizontalInput));
    anim.SetBool("IsGrounded", isGrounded);

    
}

void Update()
{
    // Detectar si el jugador quiere saltar
    if (Input.GetButtonDown("Jump") && isGrounded)
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
    }
}

void Flip()
{
    // Cambiar la dirección del personaje
    facingRight = !facingRight;

    // Invertir la escala del personaje en el eje X
    Vector3 theScale = transform.localScale;
    theScale.x *= -1;
    transform.localScale = theScale;
}


}
