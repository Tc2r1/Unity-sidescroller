using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Movement Variables

	public float maxSpeed;

	private Rigidbody2D rigidbody;
	Animator myAnim;
	Vector3 theScale;

	bool facingRight;
	 
	// Use this for initialization
	void Start () {

		rigidbody = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();
		facingRight = true;

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Fixed update is called exactly at the same time
	void FixedUpdate(){
		float move = Input.GetAxis ("Horizontal");
		myAnim.SetFloat("speed", Mathf.Ceil(move));

		rigidbody.velocity = new Vector2(move * maxSpeed, rigidbody.velocity.y);

		if (move > 0 && !facingRight){

			flip ();
		}else if (move < 0 && facingRight){

			flip ();
		}
	}

	void flip(){

		facingRight = !facingRight;
		theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}


}
