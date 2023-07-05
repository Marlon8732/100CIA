using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monedas : MonoBehaviour
{
    public Animator animator;
    public string ExplosionAnimationTrigger = "Explosion";
    public string jugadorTag = "Jugador";

    private bool hasCollided = false;
        //En este caso, se utiliza el método OnTriggerEnter2Den lugar de OnTriggerEnterpara detectar colisiones en el espacio 2D. El parametro collisiones un Collider2Den lugar de un Collider.
        
        //Este código utiliza el método OnTriggerEnterpara detectar colisiones con otros colisionadores. 
        //Cuando la moneda colisiona con un objeto que tiene la etiqueta "Jugador", 
        //se establece el disparador de animación "Explosion" en el componente Animator y 
        //se destruye el objeto después de que la animación haya terminado de reproducirse.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasCollided && collision.CompareTag(jugadorTag))
        {
            hasCollided = true;
            animator.SetTrigger(ExplosionAnimationTrigger);
            float animLength = animator.GetCurrentAnimatorStateInfo(0).length;
            StartCoroutine(DestroyAfterAnimation(animLength + 0f)); // Wait 3 seconds after animation finishes
        }
    }
        //En este código, se ha agregado la función DestroyAfterAnimationque utiliza una corrutina ( IEnumerator) para esperar durante un tiempo determinado antes de destruir el objeto. La corrutina DestroyAfterAnimationse llama después de que se ha activado la animación de explosión.
    private IEnumerator DestroyAfterAnimation(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
