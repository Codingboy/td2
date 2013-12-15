using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Worker : MonoBehaviour
{
	public float speed;
	public int objectLimit;
	public List<Product> objects;
	public Stack<Block> path;
	Map map;
	GameLogik gl;
	Block next;
	public Order order;
	public WorkerMode mode;
	public Priority priority;
	public Worker()
	{
		speed = 0;//in meter per second
		objectLimit = 0;//number of objects worker can carry
		objects = new List<Product>();
	}

	void Awake()
	{
	}

	void move()
	{
		if (next != null)
		{
			float dist = 0.01f;
			while (dist > 0)
			{
				float pointDist = Vector3.Distance(next.pos, gameObject.transform.position);
				if (pointDist <= dist)
				{
					gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, next.pos, pointDist);
					dist -= pointDist;
					if (path.Count > 0)
					{
						next = path.Pop();
					}
					else
					{
						next = null;
						dist = 0;
						//TODO
					}
				}
				else
				{
					gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, next.pos, dist);
					dist = 0;
				}
			}
		}
	}

	// Use this for initialization
	void Start()
	{
		GameObject go = GameObject.Find("42");
		gl = (GameLogik)(go.GetComponent(typeof(GameLogik)));
		map = gl.map;
		moveTo(map.blocks[map.x-1, map.y-1, map.z-1]);
	}

	public void accept(Order order)
	{
		//TODO cancel actual order
		this.order = order;
		if (order.number > objectLimit)
		{
			Order o = new Order(order);
			//TODO other values
			//TODO enqueue
		}
	}

	public void handle()
	{
		if (mode == WorkerMode.GoToProducer)
		{

		}
		else if (mode == WorkerMode.WaitForRessources)
		{

		}
		else if (mode == WorkerMode.ProduceProduct)
		{
			
		}
		else if (mode == WorkerMode.ImproveProducts)
		{
			
		}
		else if (mode == WorkerMode.LoadProducts)
		{
			
		}
		else if (mode == WorkerMode.UnloadProducts)
		{
			
		}
		else if (mode == WorkerMode.Idle)
		{
			
		}
	}

	void moveTo(Block block)
	{
		Vector3 index = map.getIndex(block.pos);
		path = aStar(map.blocks[(int)(index.x), (int)(index.y), (int)(index.z)], block);
		if (path.Count > 0)
		{
			next = path.Pop();
		}
		else
		{
			next = null;
		}
	}
	
	// Update is called once per frame
	void Update()
	{
		move();
	}

	Stack<Block> aStar(Block src, Block dst)
	{
		HashSet<Block> open = new HashSet<Block>();
		HashSet<Block> closed = new HashSet<Block>();
		Dictionary<Block, Block> came_from = new Dictionary<Block, Block>();
		Dictionary<Block, float> g_score = new Dictionary<Block, float>();
		Dictionary<Block, float> f_score = new Dictionary<Block, float>();
		open.Add(src);
		g_score.Add(src, 0);
		f_score.Add(src, 0);
		while (open.Count != 0)
		{
			Block current = null;
			foreach (Block b in open)
			{
				if (current != null)
				{
					if (f_score[b] < f_score[current])
					{
						current = b;
					}
				}
				else
				{
					current = b;
				}
			}
			if (current == dst)
			{
				Stack<Block> s = new Stack<Block>();
				for (Block b=dst; b!=src; b=came_from[b])
				{
					s.Push(b);
				}
				return s;
			}
			open.Remove(current);
			closed.Add(current);
			HashSet<Block> neighbours = new HashSet<Block>();
			if (map.onMap(current.x+1, current.y, current.z))
			{
				if (!map.blocks[current.x+1, current.y, current.z].blocked || map.blocks[current.x+1, current.y, current.z]==dst)
				{
					neighbours.Add(map.blocks[current.x+1, current.y, current.z]);
				}
			}
			if (map.onMap(current.x-1, current.y, current.z))
			{
				if (!map.blocks[current.x-1, current.y, current.z].blocked || map.blocks[current.x-1, current.y, current.z]==dst)
				{
					neighbours.Add(map.blocks[current.x-1, current.y, current.z]);
				}
			}
			if (map.onMap(current.x, current.y, current.z+1))
			{
				if (!map.blocks[current.x, current.y, current.z+1].blocked || map.blocks[current.x, current.y, current.z+1]==dst)
				{
					neighbours.Add(map.blocks[current.x, current.y, current.z+1]);
				}
			}
			if (map.onMap(current.x, current.y, current.z-1))
			{
				if (!map.blocks[current.x, current.y, current.z-1].blocked || map.blocks[current.x, current.y, current.z-1]==dst)
				{
					neighbours.Add(map.blocks[current.x, current.y, current.z-1]);
				}
			}
			if (map.onMap(current.x-1, current.y, current.z-1))
			{
				if (!map.blocks[current.x-1, current.y, current.z-1].blocked || map.blocks[current.x-1, current.y, current.z-1]==dst)
				{
					if (!map.blocks[current.x, current.y, current.z-1].blocked && !map.blocks[current.x-1, current.y, current.z].blocked)
					{
						neighbours.Add(map.blocks[current.x-1, current.y, current.z-1]);
					}
				}
			}
			if (map.onMap(current.x-1, current.y, current.z+1))
			{
				if (!map.blocks[current.x-1, current.y, current.z+1].blocked || map.blocks[current.x-1, current.y, current.z+1]==dst)
				{
					if (!map.blocks[current.x, current.y, current.z+1].blocked && !map.blocks[current.x-1, current.y, current.z].blocked)
					{
						neighbours.Add(map.blocks[current.x-1, current.y, current.z+1]);
					}
				}
			}
			if (map.onMap(current.x+1, current.y, current.z-1))
			{
				if (!map.blocks[current.x+1, current.y, current.z-1].blocked || map.blocks[current.x+1, current.y, current.z-1]==dst)
				{
					if (!map.blocks[current.x, current.y, current.z-1].blocked && !map.blocks[current.x+1, current.y, current.z].blocked)
					{
						neighbours.Add(map.blocks[current.x+1, current.y, current.z-1]);
					}
				}
			}
			if (map.onMap(current.x+1, current.y, current.z+1))
			{
				if (!map.blocks[current.x+1, current.y, current.z+1].blocked || map.blocks[current.x+1, current.y, current.z+1]==dst)
				{
					if (!map.blocks[current.x, current.y, current.z+1].blocked && !map.blocks[current.x+1, current.y, current.z].blocked)
					{
						neighbours.Add(map.blocks[current.x+1, current.y, current.z+1]);
					}
				}
			}
			foreach (Block neighbour in neighbours)
			{
				float dist = 1;
				if (neighbour.x!=current.x && neighbour.z!=current.z)
				{
					dist = 1.4142f;
				}
				float tentative_g_score = g_score[current] + dist;
				int x = neighbour.x - dst.x;
				if (x < 0)
				{
					x *= -1;
				}
				int z = neighbour.z - dst.z;
				if (z < 0)
				{
					z *= -1;
				}
				float shortPath = Mathf.Pow(Mathf.Pow(x, 2) + Mathf.Pow(z, 2), 0.5f);
				float longPath = x+z;
				float heuristic = shortPath + (longPath-shortPath)/2;
				float tentative_f_score = tentative_g_score + heuristic;
				if (closed.Contains(neighbour) && tentative_f_score >= f_score[neighbour])
				{
					continue;
				}
				if (!open.Contains(neighbour) || tentative_f_score < f_score[neighbour])
				{
					came_from[neighbour] = current;
					g_score[neighbour] = tentative_g_score;
					f_score[neighbour] = tentative_f_score;
					if (!open.Contains(neighbour))
					{
						open.Add(neighbour);
					}
				}
			}
		}
		return new Stack<Block>();
		/*
		//pseudocode from http://web.mit.edu/eranki/www/tutorials/search/
		//initialisation
		List<Block> open = new List<Block>();
		List<Block> closed = new List<Block>();
		src.f = 0f;
		src.g = 0f;
		src.h = 0f;
		open.Add(src);
		bool end = false;
		dst._parent = null;
		while (open.Count > 0)
		{
			float minF = 42000f;
			int index = -1;
			for (int i=0; i<open.Count; i++)
			{
				if (open[i].f < minF)
				{
					minF = open[i].f;
					index = i;
				}
			}
			Block q = open[index];
			open.RemoveAt(index);
			List<Block> successors = new List<Block>();
			if (map.onMap((int)(q.x+1), 0, (int)(q.z)))
			{
				if (!map.blocks[(int)(q.x+1), 0, (int)(q.z)].blocked)
				{
					successors.Add(map.blocks[(int)(q.x+1), 0, (int)(q.z)]);
				}
			}
			if (map.onMap((int)(q.x-1), 0, (int)(q.z)))
			{
				if (!map.blocks[(int)(q.x-1), 0, (int)(q.z)].blocked)
				{
					successors.Add(map.blocks[(int)(q.x-1), 0, (int)(q.z)]);
				}
			}
			if (map.onMap((int)(q.x), 0, (int)(q.z+1)))
			{
				if (!map.blocks[(int)(q.x), 0, (int)(q.z+1)].blocked)
				{
					successors.Add(map.blocks[(int)(q.x), 0, (int)(q.z+1)]);
				}
			}
			if (map.onMap((int)(q.x), 0, (int)(q.z-1)))
			{
				if (!map.blocks[(int)(q.x), 0, (int)(q.z-1)].blocked)
				{
					successors.Add(map.blocks[(int)(q.x), 0, (int)(q.z-1)]);
				}
			}
			if (map.onMap((int)(q.x+1), 0, (int)(q.z+1)))
			{
				if (!map.blocks[(int)(q.x+1), 0, (int)(q.z+1)].blocked)
				{
					if (!map.blocks[(int)(q.x+1), 0, (int)(q.z)].blocked && !map.blocks[(int)(q.x), 0, (int)(q.z+1)].blocked)
					{
						successors.Add(map.blocks[(int)(q.x+1), 0, (int)(q.z+1)]);
					}
				}
			}
			if (map.onMap((int)(q.x-1), 0, (int)(q.z+1)))
			{
				if (!map.blocks[(int)(q.x-1), 0, (int)(q.z+1)].blocked)
				{
					if (!map.blocks[(int)(q.x-1), 0, (int)(q.z)].blocked && !map.blocks[(int)(q.x), 0, (int)(q.z+1)].blocked)
					{
						successors.Add(map.blocks[(int)(q.x-1), 0, (int)(q.z+1)]);
					}
				}
			}
			if (map.onMap((int)(q.x+1), 0, (int)(q.z-1)))
			{
				if (!map.blocks[(int)(q.x+1), 0, (int)(q.z-1)].blocked)
				{
					if (!map.blocks[(int)(q.x+1), 0, (int)(q.z)].blocked && !map.blocks[(int)(q.x), 0, (int)(q.z-1)].blocked)
					{
						successors.Add(map.blocks[(int)(q.x+1), 0, (int)(q.z-1)]);
					}
				}
			}
			if (map.onMap((int)(q.x-1), 0, (int)(q.z-1)))
			{
				if (!map.blocks[(int)(q.x-1), 0, (int)(q.z-1)].blocked)
				{
					if (!map.blocks[(int)(q.x-1), 0, (int)(q.z)].blocked && !map.blocks[(int)(q.x), 0, (int)(q.z-1)].blocked)
					{
						successors.Add(map.blocks[(int)(q.x-1), 0, (int)(q.z-1)]);
					}
				}
			}
			for (int i=0; i<successors.Count; i++)
			{
				if (successors[i] == dst)
				{
					Debug.Log("found path to dst");
					dst._parent = q;
					end = true;
					break;
				}
				if (successors[i].x!=q.x && successors[i].z!=q.z)
				{
					successors[i].g = q.g + 1.4142f;
				}
				else
				{
					successors[i].g = q.g + 1;
				}
				int x = (int)(successors[i].x-dst.x);
				if (x < 0)
				{
					x *= -1;
				}
				int z = (int)(successors[i].z-dst.z);
				if (z < 0)
				{
					z *= -1;
				}
				float shortPath = Mathf.Pow(Mathf.Pow(x, 2) + Mathf.Pow(z, 2), 0.5f);
				float longPath = x+z;
				successors[i].h = shortPath;// + (longPath-shortPath)/2;
				successors[i].f = successors[i].g + successors[i].h;
				bool skip = false;
				for (int j=0; j<open.Count; j++)
				{
					if (open[j] == successors[i])
					{
						if (open[j].f < successors[i].f)
						{
							skip = true;
							break;
						}
					}
				}
				if (skip)
				{
					continue;
				}
				for (int j=0; j<closed.Count; j++)
				{
					if (closed[j] == successors[i])
					{
						//if (closed[j].f < successors[i].f)
						{
							skip = true;
							break;
						}
					}
				}
				if (!skip)
				{
					open.Add(successors[i]);
					successors[i]._parent = q;
					Block succ = successors[i];
					string A = "x="+succ.x+" z="+succ.z+" := x="+succ._parent.x+" z="+succ._parent.z;
					string B = "";
					for (int k=0; k<open.Count; k++)
					{
						B += " x="+open[k].x+"_z="+open[k].z;
					}
					int sdfsd = 9;
				}
			}
			if (end)
			{
				break;
			}
			closed.Add(q);
		}
		Stack<Block> ret = new Stack<Block>();
		int count = 0;
		if (dst._parent != null)
		{
			for(Block b=dst; b!=src; b=b._parent)
			{
				ret.Push(b);
				Debug.Log ("x="+b.x+" z="+b.z);
				count++;
				if (count >= 100)break;
			}
		}
		for (int i=0; i<map.x; i++)
		{
			for (int j=0;j<map.z; j++)
			{
				if (map.blocks[i,0,j]._parent != null)
				{
					Debug.Log("x="+map.blocks[i,0,j].x+" z="+map.blocks[i,0,j].z+" px="+map.blocks[i,0,j]._parent.x+" pz="+map.blocks[i,0,j]._parent.z);
				}
			}
		}
		return ret;*/
	}
}
