using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movimiento : MonoBehaviour
{
    //Atributos de la clase
         public float velocidadCorrer = 2;
         public float velocidadSaltar = 3;
         public int maxSaltos = 2;
         private int saltosRealizados = 0;
         Rigidbody2D rb2D;
         // Botones
         public Button btnleft, btnRight, salto;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();  
        rb2D.freezeRotation = true; // Evita que el objeto ruede      
    }
    public void irDerecha()
    {
        rb2D.velocity = new Vector2 (velocidadCorrer, rb2D.velocity.y);
    }
    public void irIzquierda()
    {
        rb2D.velocity = new Vector2 (-velocidadCorrer, rb2D.velocity.y);        
    }
    public void Saltar()
    {
        if (saltosRealizados < maxSaltos)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, velocidadSaltar);
            saltosRealizados++;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("suelo"))
        {
            saltosRealizados = 0;
        }
    }    
    // Update is called once per frame
    void Update()
    {
        
    }
}
