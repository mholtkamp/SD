﻿using UnityEngine;
using System.Collections;

public class titleScript : MonoBehaviour {

	public float x,y,width,height;
	startButtonScript startScript;
	public bool faded;
	void Start()
	{
		transform.position = Vector3.zero;
		transform.localScale = Vector3.zero;
		x = 0f;
		y = 0.65f;
		width = 0.82f;
		height = 0.3f;
		startScript = (GameObject.Find ("Start").GetComponent ("startButtonScript") as startButtonScript);
		
	}
	
	void Update() {

		guiTexture.pixelInset = new Rect(Screen.width*x,Screen.height*y,Screen.width*width,Screen.height*height);
		if(guiTexture.color.a == 0f)
			faded = true;
		if(startScript.started)
		{
			StartCoroutine ("fade");	
		}

		
		
	}
	
	IEnumerator fade()
	{
		for (float f = 0.5f; f >= 0; f -= 0.03f) 
		{
			Color c = guiTexture.color;
			c.a = f;
			guiTexture.color = c;
			yield return 0;
		}
		
		Color c2 = guiTexture.color;
		c2.a = 0f;
		guiTexture.color = c2;
	}
	
}
