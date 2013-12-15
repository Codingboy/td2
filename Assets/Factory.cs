using System.Collections.Generic;

public class Factory : Product
{
	public List<Products> provides;
	public List<Order> orders;
	public Storage storage;
	public Factory()
	{
		provides = new List<Products>();
		orders = new List<Order>();
		storage = new Storage();
	}
}
