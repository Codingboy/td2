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

	void aStar(Block src, Block dst)
	{
		List<Block> open = new List<Block>();
		List<Block> closed = new List<Block>();
		open.Add(src);
		src.f = 0f;
		while (!open.empty())
		{
			float minF = 42000f;
			int index = -1;
			for (int i=0; i<open.size(); i++)
			{
				float actualF = open.at(i).f;
				if (actualF < minF)
				{
					minF = actualF;
					index = i;
				}
			}
			Block q = open.pop(index);
			List<Block> successors = new List<Block>();
			//TODO http://web.mit.edu/eranki/www/tutorials/search/
		}
	}
}
