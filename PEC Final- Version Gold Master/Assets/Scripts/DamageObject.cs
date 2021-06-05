using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageObject : MonoBehaviour
{

    public Collider2D collider2D;
 
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Debug.Log("Player Damaged");
        collision.transform.GetComponent<PlayerRespawn>().PlayerDamaged();

    }
   
}
