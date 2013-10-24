using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour {
	startButtonScript start;
	exitButtonScript exit;
	titleScript title;
	int state ;
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
				state = 1;
			}
		}
		
	}
}
