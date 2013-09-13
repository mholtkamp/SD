using UnityEngine;
using System.Collections;

public class spellBarScript : MonoBehaviour {


	public float x,y,width,height;
	GUITexture[] spellTextures;
	
	void Start()
	{
		//Prepare the GUITexture PixelInset.
		transform.position = Vector3.zero;
		transform.localScale = Vector3.zero;
		x = 0.01f;
		y = 0.78f;
		width = 0.2404f;
		height = 0.20f;
		guiTexture.pixelInset =	new Rect(Screen.width*x,Screen.height*y,Screen.width*width,Screen.height*height);
		
		//Grab the initial spells from the SpellBar object.
		spellTextures = new GUITexture[3];
		spellTextures[0] = (GUITexture)(GameObject.Find ("Spell1")).GetComponent(typeof(GUITexture));
		spellTextures[0].texture = Resources.Load ("Speed") as Texture;
		spellTextures[1] = (GUITexture)(GameObject.Find ("Spell2")).GetComponent(typeof(GUITexture));
		spellTextures[1].texture = Resources.Load ("Speed") as Texture;
		spellTextures[2] = (GUITexture)(GameObject.Find ("Spell3")).GetComponent(typeof(GUITexture));
		spellTextures[2].texture = Resources.Load ("Speed") as Texture;
	}

}
