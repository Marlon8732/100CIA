using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimientoJugador : MonoBehaviour
{
     // Atributos de la clase
    public float velocidadCorrer = 2;
    public float velocidadSaltar = 3;
    public int maxSaltos = 2;
    private int saltosRealizados = 0;
    private bool corriendo = false;
    private bool saltando = false;
    private Animator animator;
    private Rigidbody2D rb2D;
    //En este código, se ha agregado una variable cantidadMonedaspara llevar a cabo un registro de las monedas recolectadas. 
    private int cantidadMonedas = 0;
    //También se ha agregado un componente Textllamado contadorMonedasque debe ser asignado en el Inspector al objeto que muestra el contador.
    public Text contadorMonedas; // Referencia al objeto Text para mostrar el contador


    // Botones
    public Button btnLeft, btnRight, btnJump;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void IrDerecha()
    {
        rb2D.velocity = new Vector2(velocidadCorrer, rb2D.velocity.y);
        corriendo = true;
        animator.SetBool("Correr", true);
        animator.SetBool("Saludar", false);
        animator.SetBool("Saltar", false);
    }

    public void IrIzquierda()
    {
        rb2D.velocity = new Vector2(-velocidadCorrer, rb2D.velocity.y);
        corriendo = true;
        animator.SetBool("Correr", true);
        animator.SetBool("Saludar", false);
        animator.SetBool("Saltar", false);
    }

    public void Saltar()
    {
        if (saltosRealizados < maxSaltos)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, velocidadSaltar);
            saltosRealizados++;
            saltando = true;
            animator.SetBool("Saltar", true);
            animator.SetBool("Saludar", false);
            animator.SetBool("Correr", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("suelo"))
        {
            saltosRealizados = 0;
            saltando = false;
            animator.SetBool("Saltar", false);
            if (!corriendo)
            {
                animator.SetBool("Correr", false);
                animator.SetBool("Saludar", true);
            }
        }
    }
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Moneda"))
        {
            cantidadMonedas++;
            contadorMonedas.text = "Monedas: " + cantidadMonedas.ToString();
            //Destroy(collision.gameObject); // Destruir la moneda al recogerla
        }
    }
    //En el método OnTriggerEnter2D, se verifica si el objeto colisionado tiene la etiqueta "Moneda". En ese caso, se incrementa la variable cantidadMonedas, se actualiza el valor del Text contadorMonedasy se destruye la moneda colisionada.

    private void Update()
    {
        if (!corriendo && !saltando)
        {
            animator.SetBool("Saludar", true);
        }
    }
}
