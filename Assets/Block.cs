using UnityEngine;
using System.Collections;

public class Block
{
	public NodeTypes type;
	public GameObject obj;
	public bool blocked;
	public Vector3 index;
	public Block()
	{
		type = NodeTypes.none;
		obj = null;
		blocked = false;
		index = new Vector3();
	}
}
