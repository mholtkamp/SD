using UnityEngine;
using System.Collections;

public class BarrierActivationScript : MonoBehaviour {

	GameObject chara;
	Stats stats;
	charController charcon;
	
	float duration;
	float healthmin;
	
	void Start () {
		chara = GameObject.Find ("Character");
		stats = chara.GetComponent(typeof(Stats)) as Stats;
		charcon = chara.GetComponent(typeof(charController)) as charController;
		
		duration = 1.5f;
		healthmin = stats.health;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		duration -= Time.deltaTime;
		if(duration <= 0f)
		{
			charcon.invincible = false;	
			Destroy (gameObject);
		}
		else
		{
			charcon.invincible = true;
			if(stats.health < healthmin)
				stats.health = healthmin;
			else if(stats.health > healthmin)
				healthmin = stats.health;
		}
		
		transform.position = chara.transform.position;
	}
}
