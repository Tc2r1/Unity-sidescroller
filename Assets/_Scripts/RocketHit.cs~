using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketHit : MonoBehaviour{

	public float weaponDamage;
	public GameObject explosionEffect;
	ProjectileController myPC;

	// Use this for initialization
	void Awake (){
		myPC = GetComponentInParent<ProjectileController> ();

		
	}
	
	// Update is called once per frame
	void Update (){
		
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.layer == LayerMask.NameToLayer ("Shootable")){
			myPC.removeForce ();
			Instantiate (explosionEffect, transform.position, transform.rotation);
			Destroy (gameObject);

			if (other.tag == "Enemy"){
				EnemyHealth hurtEnemy = other.gameObject.GetComponent <EnemyHealth> ();
				if (hurtEnemy != null){
					hurtEnemy.addDamage (weaponDamage);
				}
			}
		}

			
	}

	void OnTriggerStay2D (Collider2D other){
		if (other.gameObject.layer == LayerMask.NameToLayer ("Shootable")){
			myPC.removeForce ();
			Instantiate (explosionEffect, transform.position, transform.rotation);
			Destroy (gameObject);

			if (other.tag == "Enemy"){
				EnemyHealth hurtEnemy = other.gameObject.GetComponent <EnemyHealth> ();
				if (hurtEnemy != null){
					hurtEnemy.addDamage (weaponDamage);
				}
			}
		}
		
	}
}
