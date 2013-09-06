using UnityEngine;
using System.Collections;


public class charController : MonoBehaviour {
	

	private RaycastHit colCast;
	private Vector3 newPos;
	private bool movedLeft;
	private bool movedRight;
	private bool movedUp;
	private bool movedDown;
	
	public float speed;
	public float collisionBuffer;
	
	
	// Use this for initialization
	void Start () {	
		speed = 2f;
		movedLeft = false;
		movedRight = false;
		movedUp = false;
		movedDown = false;
		collisionBuffer = 0.04f;
		colCast = new RaycastHit();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		//Reset motion flags
		movedLeft = false;
		movedRight = false;
		movedUp = false;
		movedDown = false;
		
		//Handle Input
		if(Input.GetKey(KeyCode.A))
		{
			if(Physics.SphereCast(transform.position,(collider as SphereCollider).bounds.size.x/2,Vector3.left,out colCast,speed*Time.deltaTime))
			{
				newPos = transform.position;
				newPos.x = colCast.collider.bounds.max.x + (collider as SphereCollider).bounds.size.x/2;
				transform.position = newPos;
			}
			else
				transform.Translate(-speed*Time.deltaTime,0f,0f);

		}
		else if(Input.GetKey(KeyCode.D))
		{
			if(Physics.SphereCast(transform.position,(collider as SphereCollider).bounds.size.x/2,Vector3.right,out colCast,speed*Time.deltaTime))
			{
				newPos = transform.position;
				newPos.x = colCast.collider.bounds.min.x - (collider as SphereCollider).bounds.size.x/2;
				transform.position = newPos;
			}
			else
				transform.Translate(speed*Time.deltaTime,0f,0f);

		}
		if(Input.GetKey(KeyCode.W))
		{
			if(Physics.SphereCast(transform.position,(collider as SphereCollider).bounds.size.z/2,Vector3.forward,out colCast,speed*Time.deltaTime))
			{
				newPos = transform.position;
				newPos.z = colCast.collider.bounds.min.z - (collider as SphereCollider).bounds.size.z/2;
				transform.position = newPos;
			}
			else
				transform.Translate(0f,0f,speed*Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.S))
		{
			if(Physics.SphereCast(transform.position,(collider as SphereCollider).bounds.size.z/2,Vector3.back,out colCast,speed*Time.deltaTime))
			{
				newPos = transform.position;
				newPos.z = colCast.collider.bounds.max.z + (collider as SphereCollider).bounds.size.z/2;
				transform.position = newPos;
			}
			else
				transform.Translate(0f,0f,-speed*Time.deltaTime);
		}
			
	}
	
	/*
	void OnTriggerStay(Collider col)
	{
		if(col.gameObject.tag == "Wall")
		{
			if(movedUp)
			{
				Vector3 newPos = transform.position;
				newPos.z = col.bounds.min.z - transform.collider.bounds.size.z/2f - collisionBuffer;
				transform.position = newPos;
				return;
			}
			if(movedDown)
			{
				Vector3 newPos = transform.position;
				newPos.z = col.bounds.max.z + transform.collider.bounds.size.z/2f + collisionBuffer;
				transform.position = newPos;
				return;
			}

			if(movedLeft)
			{
				Vector3 newPos = transform.position;
				newPos.x = col.bounds.max.x + transform.collider.bounds.size.x/2f + collisionBuffer;
				transform.position = newPos;
				return;
			}
			if(movedRight)
			{
				Vector3 newPos = transform.position;
				newPos.x = col.bounds.min.x - transform.collider.bounds.size.x/2f - collisionBuffer;
				transform.position = newPos;
				return;
			}
		
		}
	}
	*/
}
