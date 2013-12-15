public class Order
{
	public Priority priority;
	public Products product;
	public int number;
	//public UFactory orderer;
	public Order()
	{
		priority = Priority.Normal;
		number = 0;
	}
	public Order(Order o)
	{
		this.priority = o.priority;
		this.product = o.product;
		this.number = o.number;
	}
}
