using UnityEngine;
using System.Collections;

class Map
{
	public Block[,,] blocks;
	public int x = 100;
	public int y = 100;
	public int z = 100;
	public Map()
	{
		blocks = new Block[x, y, z];
		for (int dx=0; dx<x; dx++)
		{
			for (int dz=0; dz<z; dz++)
			{
				blocks[dx, 0, dz].type = NodeTypes.block;
				blocks[dx, 0, dz].index.x = dx;
				blocks[dx, 0, dz].index.y = 0;
				blocks[dx, 0, dz].index.z = dz;
				blocks[dx, 0, dz].obj = Instantiate(Resources.Load("Block"), new Vector3(0.3333f*dx,0f,0.3333f*dz), Quaternion.identity) as GameObject;
			}
		}
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

