using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour{

	public float fullHealth;
	public GameObject deathFX;
	public AudioClip playerHurt;
	private AudioSource playerAS;
	private float currentHealth;
	PlayerController playerController;


	// HUD VARIABLES
	public Slider healthSlider;
	public Image damageScreen;
	private bool damaged = false;
	private Color damagedColor = new Color (0.1f, 0.1f, 0.1f, .5f);
	private float damageScrenFade = 5f;

	// Use this for initialization
	void Start (){

		currentHealth = fullHealth;
		playerController = gameObject.GetComponent <PlayerController> ();
		playerAS = GetComponent<AudioSource> ();


		// HUD Init
		healthSlider.maxValue = fullHealth;
		healthSlider.value = fullHealth;

	}
	
	// Update is called once per frame
	void Update (){
		if (damaged){
			damageScreen.color = damagedColor;			
			damaged = false;
		} else{
			damageScreen.color = Color.Lerp (damageScreen.color, Color.clear, damageScrenFade * Time.deltaTime);
		}

	}

	public void addDamage (float damage){
		if (damage <= 0){
			return;
		}

		playerAS.clip = playerHurt;
		playerAS.Play ();
		//playerAS.PlayOneShot (playerHurt);


		currentHealth -= damage;
		healthSlider.value = currentHealth;
		damaged = true;

		if (currentHealth <= 0){
			makeDead ();
		}
	}

	public void makeDead (){
		Instantiate (deathFX, transform.position, transform.rotation);
		Destroy (gameObject);
	}


}
