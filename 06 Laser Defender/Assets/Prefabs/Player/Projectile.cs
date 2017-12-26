using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float damage = 100f;

    private float timeBeforeDestroy = 3f;

    public GameObject laserSmoke;

    private void Start()
    {
        Destroy(gameObject, timeBeforeDestroy);

        InvokeRepeating("EmitSmoke", .1f, .05f);
    }

    public float GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }

    void EmitSmoke()
    {
        Vector3 laserPosition = transform.position + new Vector3(0f, 0f, 5f);
        GameObject laserSmokeObject = Instantiate(laserSmoke, laserPosition, Quaternion.Euler(90, 0, 0)) as GameObject;
    }
}
