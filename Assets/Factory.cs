public class Factory : Product
{
	public List<Products> provides;
	public Storage storage;
	public Factory()
	{
		priority = 0;//priority for resupply
		orders = new Dictionary<Products, int>();
		storage = new Storage();
	}
}
