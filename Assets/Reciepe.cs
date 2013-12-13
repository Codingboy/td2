public class Reciepe
{
	Dictionary ingredents;
	Products product;
	Factories factory;
	float difficulty;//100.0 = difficult
	int time;//in ms
	public Reciepe()
	{
		ingredents = new Dictionary<Products, int>();
	}
}
