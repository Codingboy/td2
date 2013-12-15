using UnityEngine;
using System.Collections;

public class Block
{
	public NodeTypes type;
	public GameObject obj;
	public Vector3 pos;
	public bool blocked;
	public int x, y, z;
	public int id;
	public Block()
	{
		type = NodeTypes.none;
		obj = null;
		blocked = false;
	}
}
