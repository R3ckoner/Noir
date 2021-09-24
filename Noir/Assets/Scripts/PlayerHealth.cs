using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth;
    public int curHealth;
    public int damage;

    // if player collides with bullet, subtract the damage of the bullet
    void OnCollisionEnter(Collision collision) {
         if (collision.gameObject.tag == "Bullet") {
         AddjustCurrentHealth(- damage);
         
         }
     }
    public void AddjustCurrentHealth(int adj) {
        curHealth += adj;
  
        if(curHealth < 0)
          curHealth = 0;
  
        if(curHealth > maxHealth)
          curHealth = maxHealth;
  
        if(maxHealth < 1)
          maxHealth = 1;
  
        if(curHealth < 10)
          Destroy (gameObject);
  
     }
 }
