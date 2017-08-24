using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour {

    public float health = 200f;

    public GameObject laser;
    public float laserSpeed;
    public float firingRate;
    private float tempTime;

    // Update is called once per frame
    void Update()
    {
        tempTime += Time.deltaTime;
        if (tempTime > firingRate)
        {
            tempTime -= firingRate;
            Fire();
        }
    }


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

    void Fire()
    {
        Vector3 startPosition = transform.position + new Vector3(0f, -1f, 0f);
        GameObject laserObject = Instantiate(laser, startPosition, Quaternion.identity) as GameObject;
        laserObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, -laserSpeed);
    }
}
