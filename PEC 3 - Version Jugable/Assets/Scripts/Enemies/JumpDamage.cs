using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class JumpDamage : MonoBehaviour
{
    public Collider2D collider2D;

    public Animator animator;

    public SpriteRenderer spriteRenderer;

    public GameObject destroyParticle;

    public float jumpForce=2.5f;

    public int lifes=2;

    public AudioSource clip;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity=(Vector2.up*jumpForce);
            LooseLifeAndHit();
            CheckLife();
        }
    }
    public void LooseLifeAndHit()
    {
        lifes--;
        animator.Play("Hit");
    }
    public void CheckLife()
    {
        if (lifes==0)
        {
            destroyParticle.SetActive(true);
            clip.Play();
            spriteRenderer.enabled=false;
            Invoke("EnemyDie",0.2f);
        }
        
    }
      public void EnemyDie()
    {
        Destroy(gameObject);
    }

}
