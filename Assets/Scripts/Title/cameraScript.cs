using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour {
	startButtonScript start;
	exitButtonScript exit;
	titleScript title;
	int state ;
	
	//State 1 vars
	float xdisthalf;
	float xvel;
	float xacc;
	
	//State 2 vars
	float xrotdiff;
	float yrotdiff;
	
	// Use this for initialization
	void Start () {
		start = GameObject.Find ("Start").GetComponent (typeof(startButtonScript)) as startButtonScript;
		exit = GameObject.Find ("Exit").GetComponent (typeof(exitButtonScript)) as exitButtonScript;
		title = GameObject.Find ("Title").GetComponent (typeof(titleScript)) as titleScript;
		state = 0;
	}

	// Update is called once per frame
	void Update () {
		if(state == 0)
		{
			if((start.faded)&&(exit.faded)&&(title.faded))
			{
				Destroy(start.gameObject);
				Destroy(exit.gameObject);
				Destroy(title.gameObject);
				xdisthalf = (85.81f - transform.position.x)/2;
				xvel = 0f;
				xacc = 0.001f;
				state = 1;
			}
		}
		else if(state == 1)
		{
			StartCoroutine ("approachCastle");
			
			
		}
		else if(state == 2)
		{
			Vector3 newRot = transform.localEulerAngles;
			if((transform.localEulerAngles.x > 314f) || (transform.localEulerAngles.y > 44.7f))
			{
				if((transform.localEulerAngles.x > 314f))
					newRot.x -= xrotdiff*Time.deltaTime;
				if((transform.localEulerAngles.y > 44.7f))
					newRot.y -= yrotdiff*Time.deltaTime;
				
				if(newRot.x < 314f)
					newRot.x = 313.8f;
				if(newRot.y < 44.7f)
					newRot.y = 44.6f;
				
				transform.localEulerAngles = newRot;
			}
			else
			{
				
				state = 3;
			}
		}
		else if(state == 3)
		{
			
			
			
		}
		
		
		
		
	}
	
	IEnumerator approachCastle()
	{
		while(transform.position.x < 85.81f)
		{			
			if(transform.position.x < xdisthalf)
				xvel += xacc;
			else
				xvel -= xacc/2;
			
			Vector3 newPos = transform.position;
			newPos.x = transform.position.x + xvel*Time.deltaTime;
			transform.position = newPos;
			if(transform.position.x > 85.81f)
			{
				newPos.x = 85.82f;
				transform.position = newPos;
			}
			
			yield return 0;
				
		}
		
		xrotdiff = transform.localEulerAngles.x - 314f;
		yrotdiff = transform.localEulerAngles.y - 44.7f;
		state = 2;
	
		
	}
}
