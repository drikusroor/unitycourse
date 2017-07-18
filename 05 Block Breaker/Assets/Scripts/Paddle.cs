using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    public float movingSpeed = 10f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        float mousePosInBlocks = Mathf.Clamp( Input.mousePosition.x / Screen.width * 16 , 0.5f, 15.5f) ;
        Vector3 currentPos = this.transform.position;
        Vector3 newPos = new Vector3(mousePosInBlocks, currentPos.y, currentPos.z);

        this.transform.position = newPos;
    }
}
