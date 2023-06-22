using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    float horizontalMove = 0;
    float verticalMove = 0;

    public float runSpeedHorizontal = 3;
    public float runSpeedVertical = 3;
    public float runSpeed = 1;    
    Rigidbody2D rigidbody2D;
    public Joystick joystick;
    public float jumpForce = 5;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (joystick.Vertical >= 0.5F && isGrounded.IsGrounded)
        {
            jump();
            // Establecer el parámetro "Jump" en true para activar la animación de salto
            animator.SetBool("Jump", true);
        }
        else
        {
            // Establecer el parámetro "Jump" en false para desactivar la animación de salto
            animator.SetBool("Jump", false);
        }
       
        horizontalMove = joystick.Horizontal * runSpeedHorizontal;

        transform.position += new Vector3(horizontalMove, verticalMove, 0) * Time.deltaTime * runSpeed; 
        
        // Establecer el parámetro "Speed" en la magnitud de la velocidad horizontal para activar la animación de correr
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }

    public void jump()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }
}
