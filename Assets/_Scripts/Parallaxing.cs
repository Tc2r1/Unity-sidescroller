﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour{

	// Parallax Controls
	public Transform[] backgrounds;
	public float smoothing;
	private float[] parallaxScales;

	private Transform cameraTransform;
	private Vector3 previousCameraPosition;

	// Use this for initialization
	void Start (){
		cameraTransform = Camera.main.transform;
		previousCameraPosition = cameraTransform.position;
		parallaxScales = new float[backgrounds.Length];
		for (int i = 0; i < parallaxScales.Length; i++){
			parallaxScales [i] = backgrounds [i].position.z * -1f;
		}
	}


	// Update is called once per frame
	void LateUpdate (){
		for (int i = 0; i < backgrounds.Length; i++){
			float parallax = (previousCameraPosition.x - cameraTransform.position.x) * (parallaxScales [i] / smoothing);
			float parallay = (previousCameraPosition.y - cameraTransform.position.y) * (parallaxScales [i] / smoothing); 

			float backgroundTargetPosX = backgrounds [i].position.x + parallax;
			float backgroundTargetPosY = backgrounds [i].position.y + parallay;

			backgrounds [i].position = new Vector3 (backgroundTargetPosX, backgrounds [i].position.y, backgrounds [i].position.z);
		}
		previousCameraPosition = cameraTransform.position;	
	}
}
