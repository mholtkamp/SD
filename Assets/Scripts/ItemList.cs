using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemList : MonoBehaviour {

	public List<Item> possibleItems;
	public List<Item> currentItems;
	public int selectedItem;
	// Use this for initialization
	void Start () {
	  int selectedItem = 0;
	  possibleItems = new List<Item>();
	  possibleItems.Add(new Item("healthpotion"));
	  possibleItems.Add(new Item("goldherb"));
	  currentItems = new List<Item>();
	  currentItems.Add(new Item("healthpotion"));
	  //possibleItems.Add(new Item("Health Potion"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
