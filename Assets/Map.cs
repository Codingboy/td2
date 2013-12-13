using UnityEngine;
using System.Collections;

class Map
{
	public Block[,,] blocks;
	public int x = 100;
	public int y = 1;
	public int z = 100;
	public Map()
	{
		blocks = new Block[x, y, z];
		//Instantiate(Resources.Load("Block"), new Vector3(0.3333f*dx,0f,0.3333f*dz), Quaternion.identity) as GameObject;
	}

	Vector3 getIndex(Vector3 v)//v = pos
	{
		return new Vector(Math.Round(v.x/3), Math.Round(v.y/3), Math.Round(v.z/3));
	}

	Vector3 getPos(Vector3 v)//v = index
	{
		return new Vector(v.x*3, v.y*3, v.z*3);
	}

	void load()
	{

	}

	void save()
	{

	}
}

