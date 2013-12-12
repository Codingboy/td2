using UnityEngine;
using System.Collections;

public class GameLogik : MonoBehaviour
{
	Map map;

	public GameLogik()
	{
		map = new Map();
	}

	// Use this for initialization
	void Start()
	{
		for (int x=0; x<map.x; x++)
		{
			for (int z=0; z<map.z; z++)
			{
				if (map.types[x,0,z] == NodeTypes.block)
				{
					GameObject go = Instantiate(Resources.Load("Block"), new Vector3(0.3333f*x,0f,0.3333f*z), Quaternion.identity) as GameObject;
					map.objects[x,0,z] = go;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update()
	{
	}
}
