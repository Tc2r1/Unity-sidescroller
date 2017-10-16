﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

	// Movement Variables
	public float maxSpeed;

	// Jumping Variables
	private bool grounded = false;
	private float groundCheckRadius = 0.2f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public float jumpHeight;

	private Rigidbody2D rigidbody;
	private Animator myAnim;
	private Vector3 theScale;
	private bool facingRight;

	// Use this for initialization
	void Start (){

		rigidbody = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();
		facingRight = true;

	}

	// Update is called once per frame
	void Update (){

		if (grounded && Input.GetAxis ("Jump") > 0){
			grounded = false;
			myAnim.SetBool ("isGrounded", grounded);
			rigidbody.AddForce (new Vector2 (0, jumpHeight));

		}
	}

	// Fixed update is called exactly at the same time
	void FixedUpdate (){

		// check if we are grounded, if no we are falling.
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, groundLayer);
		myAnim.SetBool ("isGrounded", grounded);

		myAnim.SetFloat ("verticalSpeed", rigidbody.velocity.y);


		float move = Input.GetAxis ("Horizontal");
		myAnim.SetFloat ("speed", Mathf.Abs (move));

		rigidbody.velocity = new Vector2 (
			move * maxSpeed,
			rigidbody.velocity.y);

		if (move > 0 && !facingRight){
			flip ();

		} else if (move < 0 && facingRight){
			flip ();

		}
	}

	void flip (){
		facingRight = !facingRight;
		theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}


}
