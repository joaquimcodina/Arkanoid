using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour {
	public float speed = 150.0f; //velocitat de racket

	//Utilitzarem FixedUpdate quan treballem amb fisiques
	void FixedUpdate () {
		
		//Moviment horitzontal (esquerra i dreta), amb les tecles
		float horizontalDirection = Input.GetAxisRaw("Horizontal");

		//Donar moviment a Racket (d'esquerra a dreta), depenen de la velocitat 
		//indicada en "speed"
		GetComponent<Rigidbody2D>().velocity = Vector2.right * horizontalDirection * speed;
	}
}
