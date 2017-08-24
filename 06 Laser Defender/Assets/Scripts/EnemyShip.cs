using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour {

    public float health = 200f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Projectile projectile = collision.gameObject.GetComponent<Projectile>();
        if (projectile != null)
        {
            health -= projectile.GetDamage();
            projectile.Hit();
            if (health <= 0f)
            {
                Destroy(gameObject);
            }
            print("Hit by projectile!");
            print("Projectile damage: " + projectile.GetDamage().ToString());
            print("Health: " + health);
        } else
        {
            print("Hit by something other!");
        }
    }
}
