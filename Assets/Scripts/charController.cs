using UnityEngine;
using System.Collections;

public class charController : MonoBehaviour {
	
	//Character Related
	public float speed;
	
	// Use this for initialization
	void Start () {	
		speed = 2f;
	}
	
	// Update is called once per frame
	void Update () {
		
		//Handle Input
		if(Input.GetKey(KeyCode.A))
			transform.Translate(-speed*Time.deltaTime,0f,0f);
		if(Input.GetKey(KeyCode.D))
			transform.Translate(speed*Time.deltaTime,0f,0f);
		if(Input.GetKey(KeyCode.W))
			transform.Translate(0f,0f,speed*Time.deltaTime);
		if(Input.GetKey(KeyCode.S))
			transform.Translate(0f,0f,-speed*Time.deltaTime);
			
	}
}
