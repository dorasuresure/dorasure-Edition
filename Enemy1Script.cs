using UnityEngine;
using System.Collections;

public class Enemy1Script : MonoBehaviour {

	Rigidbody2D rigidbody2D;
	public int speed = -3;
	
	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		rigidbody2D.velocity = new Vector2 (speed, rigidbody2D.velocity.y);
	}
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Slash") {
			Destroy(gameObject);
		}
	}
}
