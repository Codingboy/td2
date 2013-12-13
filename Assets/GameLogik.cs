using UnityEngine;
using System.Collections;

public class GameLogik : MonoBehaviour
{
	Map map;
	List<Reciepe> recipes;
	List<Order> orders;
	List<Factory> factories;
	List<Worker> workers;
	public GameLogik()
	{
		map = new Map();
		recipes = new List<Recipe>();
		orders = new List<Order>();
		factories = new List<Factory>();
		workers = new List<Worker>();
	}

	// Use this for initialization
	void Start()
	{
	}
	
	// Update is called once per frame
	void Update()
	{
	}
}
