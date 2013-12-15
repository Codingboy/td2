using System.Collections.Generic;

public class Reciepe
{
	public Dictionary<Products, int> ingredents;
	public Products product;
	//public Factories factory;
	public float difficulty;//100.0 = difficult
	public int time;//in ms
	public Reciepe()
	{
		ingredents = new Dictionary<Products, int>();
	}
}
