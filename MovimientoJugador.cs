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

    private void Update()
    {
        if (!corriendo && !saltando)
        {
            animator.SetBool("Saludar", true);
        }
    }
}
