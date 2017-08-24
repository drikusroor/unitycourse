using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float damage = 100f;

    private float timeBeforeDestroy = 3f;

    private void Start()
    {
        Destroy(gameObject, timeBeforeDestroy);
    }

    public float GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
