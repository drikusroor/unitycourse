using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

    private LevelManager levelManager;

    private void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Trigger");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision!");
        levelManager.LoadLevel("Lose");
    }

}
