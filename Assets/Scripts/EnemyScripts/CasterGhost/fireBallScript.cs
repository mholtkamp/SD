using UnityEngine;
using System.Collections;

public class fireBallScript : MonoBehaviour {
	
	public Vector3 dir;
	float speed;
	float damage;
	float lifetime;
	RaycastHit colCast;
	GameObject chara;
	// Use this for initialization
	void Start () {
		damage = 10f;
		speed = 3.5f;
		chara = GameObject.Find ("Character");
		dir = chara.transform.position - transform.position;
		dir.y = 0f;
		dir = dir/dir.magnitude;

		float angleOffset = Random.Range (-0.25f,0.25f);

		float newx,newz;
		newx = dir.x*Mathf.Cos (angleOffset) + dir.z*Mathf.Sin(angleOffset);
		newz = dir.x*Mathf.Sin (angleOffset)*(-1f) + dir.z*Mathf.Cos (angleOffset);
		dir.x = newx;
		dir.z = newz;

		lifetime = 4f;
	}
	
	// Update is called once per frame
	void Update () {
		lifetime -= Time.deltaTime;
		if(lifetime <= 0f)
			Destroy (gameObject);
		if(Physics.Raycast(transform.position,dir,out colCast,speed*Time.deltaTime))
		{
			if(colCast.collider.gameObject.name == "Character")
			{
				(colCast.collider.gameObject.GetComponent(typeof(Stats)) as Stats).health -= damage;
				Destroy (gameObject);
			}
			else if(colCast.collider.gameObject.CompareTag("Wall"))
				Destroy (gameObject);
			else
				transform.Translate(dir.x*speed*Time.deltaTime,dir.y*speed*Time.deltaTime,dir.z*speed*Time.deltaTime, Space.World);
		}
		else
			transform.Translate(dir.x*speed*Time.deltaTime,dir.y*speed*Time.deltaTime,dir.z*speed*Time.deltaTime, Space.World);
	}
	
	public void setDir(Vector3 newDir)
	{
		dir = newDir;
	}
	
	public void setSpeed(float speed)
	{
		this.speed = speed;
	}

	public void setDamage(float damage)
	{
		this.damage = damage;
	}
	
}
