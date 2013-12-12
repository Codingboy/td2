using UnityEngine;
using System.Collections;

class Map
{
	public NodeTypes[,,] types;
	public GameObject[,,] objects;
	public bool[,,] blocked;
	public int x = 100;
	public int y = 100;
	public int z = 100;
	public Map()
	{
		types = new NodeTypes[x, y, z];
		for (int dx=0; dx<x; dx++)
		{
			for (int dz=0; dz<z; dz++)
			{
				types[dx,0,dz] = NodeTypes.block;
			}
		}
		objects = new GameObject[x, y, z];
		blocked = new bool[x, y, z];
	}

	Vector3 getIndex(Vector3 v)
	{
		return newVector(Math.Round(v.x/3), Math.Round(v.y/3), Math.Round(v.z/3));
	}

	void load()
	{

	}

	void save()
	{

	}
}

