using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChargeActivationScript : MonoBehaviour {
	GameObject chara;
	charController charcon;
	lookAtMouse mouseLook;
	RaycastHit colCast;
	Collider[] newHits;
	List<Collider> prevHits;
	Vector3 dir;
	
	const float speed = 12f;
	const float collisionBuffer  = 0.001f;
	
	
	float duration;
	// Use this for initialization
	void Start () {
		chara = GameObject.Find ("Character");
		charcon = (charController) chara.GetComponent (typeof(charController));
		charcon.immobile = true;
		//charcon.invincible = true;
		charcon.silenced = true;
		mouseLook = chara.GetComponent(typeof(lookAtMouse)) as lookAtMouse;
		mouseLook.enabled = false;
		
		dir = chara.transform.forward;
		duration = 0.7f;
		prevHits = new List<Collider>();
		
		transform.position = chara.transform.position;
		transform.localEulerAngles = chara.transform.localEulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		duration -= Time.deltaTime;
		
		if(duration <= 0f)
		{
			charcon.immobile = false;
			//charcon.invincible = false;
			charcon.silenced = false;
			mouseLook.enabled = true;
			Destroy (gameObject);
		}
		else
		{
			charcon.immobile = true;
			//charcon.invincible = true;
			charcon.silenced = true;
			mouseLook.enabled = false;
			
			if(Physics.SphereCast(chara.transform.position,(chara.collider as SphereCollider).bounds.size.x/2,chara.transform.forward,out colCast,speed*Time.deltaTime))
			{
				transform.Translate (0f,0f,colCast.distance - collisionBuffer,Space.Self);
				chara.transform.position = transform.position;
				
			}
			else
			{
				transform.Translate(0f,0f,speed*Time.deltaTime,Space.Self);
				chara.transform.position = transform.position;
			}
			
			newHits = Physics.OverlapSphere(chara.transform.position,chara.collider.bounds.size.x/2);
			
			for(int i = 0; i < newHits.Length; i++)
			{
				if(newHits[i].CompareTag ("Enemy"))
				{
					if(!prevHits.Contains(newHits[i]))
					{
						(newHits[i].gameObject.GetComponent (typeof(Stats)) as Stats).health -= 75f;
						prevHits.Add(newHits[i]);
					}
				}
				
			}
		}
	}
}
