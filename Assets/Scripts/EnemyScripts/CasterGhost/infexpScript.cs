using UnityEngine;
using System.Collections;

public class infexpScript : MonoBehaviour {
	
	float timer;
	const float MAX_TIME = 1f;
	// Use this for initialization
	void Start () {
		timer = MAX_TIME;
		Color newColor = renderer.material.color;
		newColor.a = 1f;
		renderer.material.color = newColor;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		
		Color newColor = renderer.material.color;
		newColor.a = timer/MAX_TIME;
		renderer.material.color = newColor;
		
		if(timer <= 0f)
			Destroy(gameObject);
		
	
	}
}
