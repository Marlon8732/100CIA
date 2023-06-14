using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isGrounded : MonoBehaviour
{
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float checkRadius = 0.2f;

    private bool EsSuelo;

    private void Update()
    {
        // Detectar si el personaje está tocando el suelo
        EsSuelo = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
    }

    public bool IsGrounded()
    {
        return EsSuelo;
    }
}