using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public float speed = 100.0f; //velocitat de la pilota

	//Use this for initialization
	void Start () {
		
		// Li proporcionem moviment a la nostre pilota, enviant-la cap a dalt de l'escena
		// la seva velocitat depen del que hagim escrit
		GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
	}

	// L'objectiu es que depenen de la posicio de la pilota i la raqueta,
	// la pilota es moura per diferents llocs.
	float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth){
		// ascii art:
		//
		// 1   0.5	 0.5	1  <- x value
		// ================== <- racket
		
		return (ballPos.x - racketPos.x) / racketWidth;
	}

	void OnCollisionEnter2D(Collision2D col){
		// Hit the Racket? (la pilota ha impactat amb un objecte que es diu racket?)
		if (col.gameObject.name == "racket") {
			// Calculate hit Factor (calculem l'angle de tornada de la pilota)
			float x=hitFactor(transform.position,  //l'angle de tornada de la pilota
			col.transform.position,
			col.collider.bounds.size.x);

			// Calculate direction, set length to 1 (a partir de la posicio de la raqueta,
			// la pilota es moura cap a una direccio en conret)
			// la direccio de tornada de la pilota (sempre sera 1)
			Vector2 dir = new Vector2(x, 1).normalized;

			// Set Velocity with dir * speed the ball (a partir de la direccio obtinguda)
			GetComponent<Rigidbody2D>().velocity = dir * speed;
		}
	}
}

