using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	public float moveSpeed;
	public float spawnDelay = 1f;

	private int direction = 1;
	private float xmin;
	private float xmax;
	private float padding = 1f;

	public void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}

	void SpawnUntilFull()
	{
		Transform freePos = NextFreePosition();
		if (freePos) {
			GameObject enemy = Instantiate (enemyPrefab, freePos.position, Quaternion.identity) as GameObject;
			enemy.transform.SetParent (freePos);
		}
		Transform nextPos = NextFreePosition();
		if (nextPos) {
			Invoke("SpawnUntilFull", spawnDelay);
		}
	}

	// Use this for initialization
	void Start () {

		SpawnUntilFull ();

		padding = width / 2 + 1;
		SetFormationBoundaries ();
	}

	void SetFormationBoundaries()
	{
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, distance));
		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;
	}

	void MoveFormation()
	{
		transform.position += Vector3.left * moveSpeed * direction * Time.deltaTime;

		// clamp
		float newX = Mathf.Clamp (transform.position.x, xmin, xmax);

		// check if bounce and if so, flip
		if (transform.position.x != newX) {
			direction *= -1;
		}

		transform.position = new Vector3 (newX, transform.position.y, transform.position.z);
	}

	Transform NextFreePosition()
	{
		foreach (Transform childPositionGameObject in transform) 
		{
			if (childPositionGameObject.childCount == 0 )
			{
				return childPositionGameObject;
			}
		}
		return null;
	}

	bool AllMembersDead() 
	{
		foreach (Transform childPositionGameObject in transform) 
		{
			if (childPositionGameObject.childCount > 0 )
			{
				return false;
			}
		}
		return true;
	}

	// Update is called once per frame
	void Update () {
		MoveFormation ();

		if (AllMembersDead ()) 
		{
			Debug.Log ("All enemies dead!");
			SpawnUntilFull ();
		}
	}
}
