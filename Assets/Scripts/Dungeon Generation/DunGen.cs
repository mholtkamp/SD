﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class DunGen : MonoBehaviour {

	const int MAP_WIDTH = 30;
	const int MAP_HEIGHT = 30;
	int[,] map;
	
	int minRooms;
	int maxRooms;
	int minRoomSize;
	int maxRoomSize;
	
	int enemyCount;
	int enemyMin;
	int enemyMax;
	
	enum Enemies {	TridentGhost,
					Beamo,
					Torpedo,
					CasterGhost};
	
	
	
	void Start () 
	{
		
		map = new int[MAP_WIDTH,MAP_HEIGHT];
		
		//Number of rooms
		//minRooms = (MAP_WIDTH * MAP_HEIGHT)/300;
		//maxRooms = (MAP_WIDTH * MAP_HEIGHT)/150;

		
		//Room sizes
		/*
		int widthRoot = (int) Mathf.Sqrt((float)MAP_WIDTH*2.0f);
		int heightRoot = (int) Mathf.Sqrt ((float) MAP_HEIGHT*2.0f);
		int minRoomWidth = (int) (MAP_WIDTH * 0.5f)/widthRoot;
		int maxRoomWidth = (int) (MAP_WIDTH * 2.0f)/widthRoot;
		int minRoomHeight = (int) (MAP_HEIGHT * 0.5f)/heightRoot;
		int maxRoomHeight = (int) (MAP_HEIGHT * 2.0f)/heightRoot;
		*/
		
		setGenParameters();
		int numRooms = Random.Range (minRooms,maxRooms);
		
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
				candRoom.width = Random.Range(minRoomSize,maxRoomSize);
				candRoom.height = Random.Range(minRoomSize,maxRoomSize);
				
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
					addRoomToMap(candRoom);
				}
			}
		}
		
		/*
		for(int i =0; i < roomList.Count; i++)
		{
			GameObject newTile = (GameObject) Instantiate(Resources.Load ("Tile"));
			newTile.transform.localScale = new Vector3((float)roomList[i].width,0.01f,(float)roomList[i].height);
			newTile.transform.position = new Vector3((float)roomList[i].x + roomList[i].width/2,0f,(float)roomList[i].y + roomList[i].height/2);
			print (roomList[i].x + " " + roomList[i].y + " " + roomList[i].width + " " + roomList[i].height);
			
		}
		*/
		int numConnections = numRooms;
		List<Room> connectedRooms = new List<Room>();
		
		
		for(int i = 0; i < numConnections; i++)
		{
			Room roomA = roomList[i];
			Room roomB = null;
			bool found = false;
			while(!found)
			{
				roomB = roomList[Random.Range (0,roomList.Count - 1)];
				if(roomB != roomA)
					found = true;
			}
			
			int aX = Random.Range (roomA.x,roomA.x + roomA.width);
			int aY = Random.Range (roomA.y,roomA.y + roomA.height);
			int bX = Random.Range (roomB.x,roomB.x + roomB.width);
			int bY = Random.Range (roomB.y,roomB.y + roomB.height);
			
			while((aX != bX) || (aY != bY))
			{
				if(aX != bX)
				{
					if(bX > aX)
						aX++;
					else
						aX--;
				}
				else
				{
					if(bY > aY)
						aY++;
					else
						aY--;
				}
				map[aX,aY] = 1;
			}
			
		}
		//outputMapFile ();
		createTiles();
		createWalls();
		spawnCharacter();
		spawnEnemies();
		instantiateHUD ();
		
		
		

	}
	
	void spawnCharacter()
	{
		int x,y;
		x = 0;
		y = 0;
		bool found = false;
		while(!found)
		{
			x = Random.Range(1,MAP_WIDTH);
			y = Random.Range (1,MAP_HEIGHT);
			if(map[x,y] == 1)
				found = true;
		}
		GameObject chara = (GameObject) Instantiate(Resources.Load ("Character"));
		chara.transform.position = new Vector3((float)x,0.3f,(float)y);
		chara.name = "Character";
	}
	
	void instantiateHUD()
	{
		(GameObject.Instantiate (Resources.Load ("SpellBarHUD"))).name = "SpellBarHUD";
		(GameObject.Instantiate (Resources.Load ("GUI"))).name = "GUI";
		(GameObject.Instantiate (Resources.Load ("ConjBar"))).name = "ConjBar";

	}
	
	void createTiles()
	{
		for(int i = 0; i < MAP_WIDTH; i++)
		{
			for(int j = 0; j < MAP_HEIGHT; j++)
			{
				if(map[i,j] == 1)
				{
					GameObject newTile = (GameObject) Instantiate(Resources.Load ("Tile"));
					newTile.transform.position = new Vector3((float)i,0,(float)j);
				}
			}
		}
	}
	
	void createWalls()
	{
		bool isWall = false;
		for(int i = -1; i <= MAP_WIDTH; i++)
		{
			for(int j = -1; j <= MAP_HEIGHT; j++)
			{
				if((i >= 0)&&(i < MAP_WIDTH)&&(j >= 0)&&(j < MAP_HEIGHT)&&(map[i,j] == 0))
					{
					isWall = false;
					if((j != -1)&&(j != MAP_HEIGHT))
					{
						if((i+1 >= 0) &&(i+1 < MAP_WIDTH))
						{
							if(map[i+1,j] == 1)
								isWall = true;
						}
						if((i-1 >= 0) &&(i-1 < MAP_WIDTH))
						{
							if(map[i-1,j] == 1)
								isWall = true;
						}
					}
					if((i != -1) &&(i != MAP_WIDTH))
					{
						if((j+1 >= 0) &&(j+1 < MAP_HEIGHT))
						{
							if(map[i,j+1] == 1)
								isWall = true;
						}
						if((j-1 >= 0) &&(j-1 < MAP_HEIGHT))
						{
							if(map[i,j-1] == 1)
								isWall = true;
						}
					}
					if(isWall)
					{
						GameObject newWall = (GameObject) Instantiate(Resources.Load ("Wall"));
						newWall.transform.position = new Vector3((float)i,0,(float)j);
					}
				}
				
			}
		}
	
	}
	
	
	void addRoomToMap(Room room)
	{
		for(int i = 0; i < room.width;i++)
		{
			for(int j = 0; j < room.height; j++)
			{
				map[room.x + i, room.y + j] = 1;
			}
		}
	}
	
	void outputMapFile()
	{
		string path = @"c:\users\Martin\Desktop\map.txt";
		File.WriteAllText(path, "");
		
		for(int i = MAP_WIDTH - 1; i >= 0; i--)
		{
			for(int j = 0; j < MAP_HEIGHT; j++)
			{
				File.AppendAllText(path,""+map[j,i] + " ");
			}
			File.AppendAllText (path,System.Environment.NewLine);
		}
	}
	
	private void setGenParameters()
	{
		if(Application.loadedLevelName.Equals ("lvl1"))
		{
			minRooms = 8;
			maxRooms = 14;
			minRoomSize = 4;
			maxRoomSize = 8;
			
			enemyCount = 12;
			enemyMin = 0;
			enemyMax = 3;
			
		}
	}
	
	private void spawnEnemies()
	{
		for(int i = 0; i < enemyCount; i++)
		{
			Enemies en = (Enemies) Random.Range (enemyMin,enemyMax+1);
			GameObject newEnemy = null;
			bool posFound = false;
			
			if(en == Enemies.TridentGhost)
				newEnemy = (GameObject) Instantiate (Resources.Load ("TridentGhost"));
			else if(en == Enemies.Beamo)
				newEnemy = (GameObject) Instantiate (Resources.Load ("beamo"));
			else if(en == Enemies.Torpedo)
				newEnemy = (GameObject) Instantiate (Resources.Load ("TorpedoParent"));
			else if(en == Enemies.CasterGhost)
				newEnemy = (GameObject) Instantiate (Resources.Load ("casterghost"));
			
			while(!posFound)
			{
				int xPos =	Random.Range (0,MAP_WIDTH);
				int yPos =  Random.Range (0,MAP_HEIGHT);
				if(map[xPos,yPos] == 1)
				{
					posFound = true;
					newEnemy.transform.position = new Vector3(xPos,0.3f,yPos);
				}
				
			}
			
		}
	}
	
	
	
}
