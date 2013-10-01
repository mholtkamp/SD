using UnityEngine;
using System.Collections;


public class charController : MonoBehaviour {
	

	private RaycastHit colCast;
	
	public float speed;
	public float collisionBuffer;
	Stats stats;
	
	
	// Use this for initialization
	void Start () {	
		stats = (Stats) (GetComponent(typeof(Stats)));
		speed = (float) (stats.speed/100f);
		collisionBuffer = 0.001f;
		colCast = new RaycastHit();
//		animation.Play("Take 001");
	}
	
	// Update is called once per frame
	void Update () {
		
		speed = (float) (stats.speed/100f);

		//Handle Input
		if(Input.GetKey(KeyCode.A))
		{
			if(Physics.SphereCast(transform.position,(collider as SphereCollider).bounds.size.x/2,Vector3.left,out colCast,speed*Time.deltaTime))
				transform.Translate (-colCast.distance + collisionBuffer,0f,0f,Space.World);
			else
				transform.Translate(-speed*Time.deltaTime,0f,0f,Space.World);

		}
		if(Input.GetKey(KeyCode.D))
		{
			if(Physics.SphereCast(transform.position,(collider as SphereCollider).bounds.size.x/2,Vector3.right,out colCast,speed*Time.deltaTime))
				transform.Translate (colCast.distance - collisionBuffer,0f,0f,Space.World);

			else
				transform.Translate(speed*Time.deltaTime,0f,0f,Space.World);

		}
		if(Input.GetKey(KeyCode.W))
		{
			if(Physics.SphereCast(transform.position,(collider as SphereCollider).bounds.size.z/2,Vector3.forward,out colCast,speed*Time.deltaTime))
				transform.Translate (0f,0f,colCast.distance - collisionBuffer,Space.World);
			else
				transform.Translate(0f,0f,speed*Time.deltaTime,Space.World);
		}
		if(Input.GetKey(KeyCode.S))
		{
			if(Physics.SphereCast(transform.position,(collider as SphereCollider).bounds.size.z/2,Vector3.back,out colCast,speed*Time.deltaTime))
				transform.Translate (0f,0f,-colCast.distance + collisionBuffer,Space.World);

			else
				transform.Translate(0f,0f,-speed*Time.deltaTime,Space.World);
		}
			
	}
}
