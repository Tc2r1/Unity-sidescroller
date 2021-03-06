﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour{

	public float maxHealth;
	private float currentHealth;
	public GameObject enemyDeathFX;
	public Slider healthSlider;
	public Image healthBarFill;
	public Color maxHealthColor = Color.green;
	public Color minHealthColor = Color.red;
	public bool drops;
	public GameObject theDrop;
	public AudioClip hurtSFX;
	public AudioClip deathSFX;



	void Awake (){
		healthSlider.gameObject.SetActive (false);
	}
	// Use this for initialization
	void Start (){
		// init current health.
		currentHealth = maxHealth;
		healthSlider.maxValue = currentHealth;
		healthSlider.value = currentHealth;

		// I dont want decimals, I want solid numbers like 2 or 20
		healthSlider.wholeNumbers = true;
	}
	
	// Update is called once per frame
	void Update (){
		
	}

	public void addDamage (float damage){
		currentHealth -= damage;

		if (!healthSlider.gameObject.activeSelf){
			healthSlider.gameObject.SetActive (true);
		}

		if (hurtSFX != null){
			AudioSource.PlayClipAtPoint (hurtSFX, transform.position);
		}
		healthSlider.value = currentHealth;
		healthBarFill.color = Color.Lerp (minHealthColor, maxHealthColor, currentHealth / maxHealth);

		if (currentHealth <= 0){
			makeDead ();
		}
	}

	void makeDead (){
		Destroy (gameObject);
		Instantiate (enemyDeathFX, transform.position, transform.rotation);
		if (deathSFX != null){
			AudioSource.PlayClipAtPoint (deathSFX, transform.position);
		}
		if (drops){
			Instantiate (theDrop, transform.position, transform.rotation);
		}
	}
}
