using UnityEngine;
using System.Collections;

public class TridentGhostController : MonoBehaviour {
	Stats stats;
	// Use this for initialization
	void Start () {
		stats = (Stats) GetComponent(typeof(Stats));
	}
	
	// Update is called once per frame
	void Update () {
				stats.speed = 100;

	}
}
