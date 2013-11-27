using UnityEngine;
using System.Collections;

public class lookAtMouse : MonoBehaviour {
	private Plane intersectionPlane; 
	private Ray cursorRay;
	private float intersectDistance;//distance from camera to point on plane where the cursor ray passes through
	private bool notParallel;
	private Vector3 onlyY;
	public bool enabled;
	// Use this for initialization
	void Start () {
		intersectionPlane = new Plane(Vector3.up, transform.position); //spawns at center of char so it only rotates around y axis
		intersectDistance = 0.0f;
		enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(enabled)
		{
			cursorRay = Camera.main.ScreenPointToRay(Input.mousePosition);//makes a ray
			notParallel = intersectionPlane.Raycast(cursorRay, out intersectDistance);//distance from camera to point on plane 
			//where the cursor ray passes through
			if(notParallel)
			{
				transform.LookAt(cursorRay.GetPoint(intersectDistance));
				onlyY = new Vector3(0,transform.rotation.eulerAngles.y,0);
				transform.localEulerAngles = onlyY;
			}
		}
	}
}
