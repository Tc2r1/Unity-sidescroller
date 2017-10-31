using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour{

	Animator enemyAnimator;
	// facing.
	public GameObject enemyGraphic;
	public bool canFlip = true;
	public bool facingRight = false;
	public float flipTime = 5f;
	float nextFlipChance = 0f;

	//attacking
	public float chargeTime;
	public float enemySpeed;
	float startChargeTime;
	bool charging;
	Rigidbody2D enemyRB;





	// Use this for initialization
	void Start (){
		enemyAnimator = GetComponentInChildren<Animator> ();
		enemyRB = GetComponent<Rigidbody2D> ();
				
	}
	
	// Update is called once per frame
	void Update (){

		if (Time.time > nextFlipChance){
			if (Random.Range (0, 1) >= 1){
				flipFacing ();
			}
			nextFlipChance = Time.time + flipTime;
		}		
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player"){

			// Facing Wrong Way Mob flips around!
			if (facingRight && other.transform.position.x < transform.position.x){
				flipFacing ();
			} else if (!facingRight && other.transform.position.x > transform.position.x){
				flipFacing ();
			}
			// no more flipping
			canFlip = false;
			// start charging
			charging = true;
			startChargeTime = Time.time + chargeTime;

		}
	}

	void OnTriggerStay2D (Collider2D other){
		if (other.tag == "Player"){
			if (startChargeTime < Time.time){
				// increase velocity in the direction we are facing.
				if (!facingRight){
					enemyRB.AddForce (new Vector2 (-1, 0) * enemySpeed);
				} else{
					enemyRB.AddForce (new Vector2 (1, 0) * enemySpeed);
				}
				enemyAnimator.SetBool ("isCharging", charging);

			}

		}

	}

	void OnTriggerExit2D (Collider2D other){
		if (other.tag == "Player"){

			// we can flip again.
			canFlip = true;
			charging = false;
			// stop moving. 
			enemyRB.velocity = new Vector2 (0, 0);

			// go back to idle.
			enemyAnimator.SetBool ("isCharging", charging);

		}

	}



	void flipFacing (){
		if (!canFlip)
			return;

		// flip the x
		float facingX = enemyGraphic.transform.localScale.x;
		facingX *= -1f;

		enemyGraphic.transform.localScale = new Vector3 (facingX, enemyGraphic.transform.localScale.y, enemyGraphic.transform.localScale.z);
	
		facingRight = !facingRight;
	}
}
