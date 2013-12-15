using UnityEngine;
using System.Collections;
using System;

public class Map
{
	public Block[,,] blocks;
	public int x = 10;
	public int y = 1;
	public int z = 10;
	public Map()
	{
		blocks = new Block[x, y, z];
		for (int xx=0; xx<x; xx++)
		{
			for (int yy=0; yy<y; yy++)
			{
				for (int zz=0; zz<z; zz++)
				{
					blocks[xx, yy, zz] = new Block();
					blocks[xx, yy, zz].id = zz*x+xx;
					blocks[xx, yy, zz].x = xx;
					blocks[xx, yy, zz].y = yy;
					blocks[xx, yy, zz].z = zz;
					blocks[xx, yy, zz].pos = new Vector3(xx*0.3333f, yy*0.3333f, zz*0.3333f);
				}
			}
		}
		blocks[2,0,2].blocked = true;
		blocks[8,0,9].blocked = true;
		blocks[8,0,8].blocked = true;
		blocks[9,0,6].blocked = true;
		blocks[8,0,6].blocked = true;
		blocks[7,0,6].blocked = true;
		blocks[6,0,6].blocked = true;
		blocks[6,0,9].blocked = true;
		blocks[6,0,7].blocked = true;
		blocks[4,0,8].blocked = true;
		blocks[4,0,7].blocked = true;
		blocks[5,0,5].blocked = true;
		blocks[2,0,2].blocked = true;
		blocks[1,0,3].blocked = true;
		blocks[4,0,0].blocked = true;
		blocks[4,0,2].blocked = true;
		blocks[4,0,3].blocked = true;
		//Instantiate(Resources.Load("Block"), new Vector3(0.3333f*dx,0f,0.3333f*dz), Quaternion.identity) as GameObject;
	}

	public Vector3 getIndex(Vector3 v)//v = pos
	{
		return new Vector3((float)Math.Round(v.x/3), (float)Math.Round(v.y/3), (float)Math.Round(v.z/3));
	}

	public Vector3 getPos(Vector3 v)//v = index
	{
		return new Vector3(v.x*3, v.y*3, v.z*3);
	}

	public bool onMap(int x, int y, int z)
	{
		return x<this.x && x>=0 && y<this.y && y>=0 && z<this.z && z>=0;
	}

	public void load()
	{

	}

	public void save()
	{

	}
}

