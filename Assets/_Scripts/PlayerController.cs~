using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour{

	// Movement Variables
	public float maxSpeed;

	// Jumping Variables
	private bool grounded = false;
	private float groundCheckRadius = 0.2f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public float jumpHeight;

	private Rigidbody2D myRigidbody;
	private Animator myAnim;
	private Vector3 theScale;
	private bool facingRight;

	// Projectile Firing
	public Transform barrelTip;
	public GameObject bullet;
	public float fireRate;
	private float nextFire;

	// Use this for initialization
	void Start (){

		myRigidbody = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();
		facingRight = true;

	}

	// Update is called once per frame
	void Update (){

		if (grounded && Input.GetAxis ("Jump") > 0){
			grounded = false;
			myAnim.SetBool ("isGrounded", grounded);
			myRigidbody.AddForce (new Vector2 (0, jumpHeight));

		}

		if (Input.GetAxisRaw ("Fire1") > 0){
			fireRocket ();
		}
	}

	void fireRocket (){
		// check if we can fire. 
		if (Time.time > nextFire){
			nextFire = Time.time + fireRate;

			// Check direction player is facing to fire projectile
			if (facingRight){
				Instantiate (bullet, barrelTip.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
			} else{
				Instantiate (bullet, barrelTip.position, Quaternion.Euler (new Vector3 (0, 0, 180f)));
			}
		}
	}

	// Fixed update is called exactly at the same time
	void FixedUpdate (){

		// check if we are grounded, if no we are falling.
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, groundLayer);
		myAnim.SetBool ("isGrounded", grounded);

		myAnim.SetFloat ("verticalSpeed", myRigidbody.velocity.y);


		float move = Input.GetAxis ("Horizontal");
		myAnim.SetFloat ("speed", Mathf.Abs (move));

		myRigidbody.velocity = new Vector2 (
			move * maxSpeed,
			myRigidbody.velocity.y);

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
