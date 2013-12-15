using System.Collections.Generic;

public class Storage
{
	private Dictionary<Products, List<Product>> stock;
	public int size;
	public Storage()
	{
		stock = new Dictionary<Products, List<Product>>();
		size = 0;
	}
	void insert(Products product, List<Product> products)
	{
		if (!stock.ContainsKey(product))
		{
			List<Product> l = new List<Product>();
			for (int i=0; i<products.Count; i++)
			{
				l.Add(products[i]);
			}
			stock.Add(product, l);
		}
		else
		{
			for (int i=0; i<products.Count; i++)
			{
				stock[product].Add(products[i]);
			}
		}
	}
	bool canInsert(int number)
	{
		int n = 0;
		for (int i=0; i<stock.Count; i++)
		{
			n += stock.Values.Count;
		}
		return number+n <= size;
	}
	int count(Products product)
	{
		if (stock.ContainsKey(product))
		{
			return stock[product].Count;
		}
		else
		{
			return 0;
		}
	}
	List<Product> remove(Products product, int number)
	{
		List<Product> l = new List<Product>();
		for(int i=0; i<number; i++)
		{
			l.Add(stock[product][i]);
			stock[product].Remove(l[i]);
		}
		return l;
	}
}
