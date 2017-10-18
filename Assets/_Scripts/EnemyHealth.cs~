using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour{
	public float enemyMaxHealth;
	private float currentHealth;

	// Use this for initialization
	void Start (){
		// init current health.
		currentHealth = enemyMaxHealth;


		
	}
	
	// Update is called once per frame
	void Update (){
		
	}

	public void addDamage (float damage){
		currentHealth -= damage;

		if (currentHealth <= 0){
			makeDead ();
		}
	}

	void makeDead (){
		Destroy (gameObject);
	}
}
