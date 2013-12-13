using UnityEngine;
using System.Collections;

public class Worker : MonoBehaviour
{
	public float speed;
	public int objectLimit;
	public List<Product> objects;
	public Worker()
	{
		speed = 0;//in meter per second
		objectLimit = 0;//number of objects worker can carry
		objects = new List<Product>();
	}

	// Use this for initialization
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
		if (dst != gameObject.transform.position)//need to go to another position
		{
			
		}
		else if (working)//already reached dst and working
		{

		}
		else//nothing to do
		{

		}
	}

	List<Block> calculatePath(Block src, Block dst, int depth)
	{
		
	}
}
