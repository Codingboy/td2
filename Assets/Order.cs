public class Order
{
	public Priority priority;
	public int number;
	//public UFactory orderer;
	//public UFactory producer;
	public Reciepe reciepe;
	public Order()
	{
		priority = Priority.Normal;
		number = 0;
	}
	public Order(Order o)
	{
		this.priority = o.priority;
		this.number = o.number;
		this.reciepe = reciepe;
	}
}
