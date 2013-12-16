using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameLogik : MonoBehaviour
{
	public Map map;
	public Dictionary<Products, Reciepe> recipes;
	public HashSet<Team> teams;
	public GameLogik()
	{
		map = new Map();
		teams = new HashSet<Team>();
		recipes = new Dictionary<Products, Reciepe>();

		Reciepe r;
		r = new Reciepe();
		r.product = Products.Ironore;
		r.factory = Factories.IronMine;
		r.ingredents = new Dictionary<Products, int>();
		r.difficulty = 0;
		r.time = 1000;
		recipes.Add(r.product, r);

		r = new Reciepe();
		r.product = Products.Iron;
		r.factory = Factories.MetalFactory;
		r.ingredents = new Dictionary<Products, int>();
		r.ingredents.Add(Products.Ironore, 1);
		r.ingredents.Add(Products.Coal, 1);
		r.difficulty = 0;
		r.time = 1000;
		recipes.Add(r.product, r);

		r = new Reciepe();
		r.product = Products.Coal;
		r.factory = Factories.CoalMine;
		r.ingredents = new Dictionary<Products, int>();
		r.difficulty = 0;
		r.time = 1000;
		recipes.Add(r.product, r);

		r = new Reciepe();
		r.product = Products.CopperOre;
		r.factory = Factories.CopperMine;
		r.ingredents = new Dictionary<Products, int>();
		r.difficulty = 0;
		r.time = 1000;
		recipes.Add(r.product, r);

		r = new Reciepe();
		r.product = Products.Copper;
		r.factory = Factories.MetalFactory;
		r.ingredents = new Dictionary<Products, int>();
		r.ingredents.Add(Products.CopperOre, 1);
		r.ingredents.Add(Products.Coal, 1);
		r.difficulty = 0;
		r.time = 1000;
		recipes.Add(r.product, r);

		r = new Reciepe();
		r.product = Products.LeadOre;
		r.factory = Factories.LeadMine;
		r.ingredents = new Dictionary<Products, int>();
		r.difficulty = 0;
		r.time = 1000;
		recipes.Add(r.product, r);

		r = new Reciepe();
		r.product = Products.Lead;
		r.factory = Factories.MetalFactory;
		r.ingredents = new Dictionary<Products, int>();
		r.ingredents.Add(Products.LeadOre, 1);
		r.ingredents.Add(Products.Coal, 1);
		r.difficulty = 0;
		r.time = 1000;
		recipes.Add(r.product, r);

		r = new Reciepe();
		r.product = Products.Steel;
		r.factory = Factories.MetalFactory;
		r.ingredents = new Dictionary<Products, int>();
		r.ingredents.Add(Products.Iron, 1);
		r.ingredents.Add(Products.Coal, 2);
		r.difficulty = 0;
		r.time = 1000;
		recipes.Add(r.product, r);
	}

	// Use this for initialization
	void Start()
	{
		GameObject go1 = Instantiate(Resources.Load("Worker"), new Vector3(0f,0f,0f), Quaternion.identity) as GameObject;
		for (int x=0; x<map.x; x++)
		{
			GameObject go = Instantiate(Resources.Load("Block"), new Vector3(0.3333f*x,0f,0.3333f*(-1)), Quaternion.identity) as GameObject;
			go = Instantiate(Resources.Load("Block"), new Vector3(0.3333f*x,0f,0.3333f*map.z), Quaternion.identity) as GameObject;
		}
		for (int z=0; z<map.z; z++)
		{
			GameObject go = Instantiate(Resources.Load("Block"), new Vector3(0.3333f*(-1),0f,0.3333f*z), Quaternion.identity) as GameObject;
			go = Instantiate(Resources.Load("Block"), new Vector3(0.3333f*map.x,0f,0.3333f*z), Quaternion.identity) as GameObject;
		}
		for (int x=0; x<map.x; x++)
		{
			for (int y=0; y<map.y; y++)
			{
				for (int z=0; z<map.z; z++)
				{
					if (map.blocks[x, y, z].blocked)
					{
						GameObject go = Instantiate(Resources.Load("Block"), new Vector3(0.3333f*x,0.3333f*y,0.3333f*z), Quaternion.identity) as GameObject;
					}
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update()
	{
	}
}
