using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DunGen : MonoBehaviour {

	const int MAP_WIDTH = 40;
	const int MAP_HEIGHT = 40;
	int[,] map;
	void Start () 
	{
		
		map = new int[MAP_WIDTH,MAP_HEIGHT];
		
		//Number of rooms
		int minRooms = (MAP_WIDTH * MAP_HEIGHT)/300;
		int maxRooms = (MAP_WIDTH * MAP_HEIGHT)/150;
		int numRooms = Random.Range (minRooms,maxRooms);
		print(numRooms);
		
		//Room sizes
		int widthRoot = (int) Mathf.Sqrt((float)MAP_WIDTH*2.0f);
		int heightRoot = (int) Mathf.Sqrt ((float) MAP_HEIGHT*2.0f);
		int minRoomWidth = (int) (MAP_WIDTH * 0.5f)/widthRoot;
		int maxRoomWidth = (int) (MAP_WIDTH * 2.0f)/widthRoot;
		int minRoomHeight = (int) (MAP_HEIGHT * 0.5f)/heightRoot;
		int maxRoomHeight = (int) (MAP_HEIGHT * 2.0f)/heightRoot;
		
		//Create Rooms
		List<Room> roomList = new List<Room>();
		
		bool ok = false;
		bool overlaps = false;
		for(int i = 0; i < numRooms; i++)
		{
			ok = false;
			while(!ok)
			{
				overlaps = false;
				Room candRoom = new Room();
				candRoom.x = Random.Range(0,MAP_WIDTH);
				candRoom.y = Random.Range(0,MAP_HEIGHT);
				candRoom.width = Random.Range(minRoomWidth,maxRoomWidth);
				candRoom.height = Random.Range(minRoomHeight,maxRoomHeight);
				
				//Room outside map?
				if(!Room.isInsideMap (candRoom,MAP_WIDTH,MAP_HEIGHT))
					continue;
				
				//Room overlapping other room?
				for(int j = 0; j < roomList.Count;j++)
				{
					if(Room.overlapsRoom(candRoom,roomList[j]))
					{
						overlaps = true;
						break;
					}
				}
				if(!overlaps)
				{
					ok = true;
					roomList.Add (candRoom);
				}
			}
		}
		
		for(int i =0; i < roomList.Count; i++)
		{
			GameObject newTile = (GameObject) Instantiate(Resources.Load ("Tile"));
			newTile.transform.localScale = new Vector3((float)roomList[i].width,0.01f,(float)roomList[i].height);
			newTile.transform.position = new Vector3((float)roomList[i].x + roomList[i].width/2,0f,(float)roomList[i].y + roomList[i].height/2);
			print (roomList[i].x + " " + roomList[i].y + " " + roomList[i].width + " " + roomList[i].height);
			
		}
		

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
