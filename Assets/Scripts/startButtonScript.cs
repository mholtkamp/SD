using UnityEngine;
using System.Collections;

public class startButtonScript : MonoBehaviour {
	public float x,y,width,height;
	void Start()
	{
		transform.position = Vector3.zero;
		transform.localScale = Vector3.zero;
		x = 0.4f;
		y = 0.28f;
		width = 0.22f;
		height = 0.21f;
	}
	
	void Update() {

		guiTexture.pixelInset = new Rect(Screen.width*x,Screen.height*y,Screen.width*width,Screen.height*height);
	}
	
	// Update is called once per frame
	void OnMouseUp() {
		Application.LoadLevel("sc1");
	}
}
