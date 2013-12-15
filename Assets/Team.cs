using System.Collections.Generic;

public class Team
{
	public Dictionary<Priority, Queue<Order>> orders;
	public HashSet<Factory> factories;
	public Dictionary<Priority, HashSet<Worker>> workers;
	public Team()
	{
		orders = new Dictionary<Priority, Queue<Order>>();
		factories = new HashSet<Factory>();
		workers = new Dictionary<Priority, HashSet<Worker>>();
		workers.Add(Priority.Idle, new HashSet<Worker>());
		orders.Add(Priority.Idle, new Queue<Order>());
		workers.Add(Priority.VeryLow, new HashSet<Worker>());
		orders.Add(Priority.VeryLow, new Queue<Order>());
		workers.Add(Priority.Low, new HashSet<Worker>());
		orders.Add(Priority.Low, new Queue<Order>());
		workers.Add(Priority.Normal, new HashSet<Worker>());
		orders.Add(Priority.Normal, new Queue<Order>());
		workers.Add(Priority.High, new HashSet<Worker>());
		orders.Add(Priority.High, new Queue<Order>());
		workers.Add(Priority.VeryHigh, new HashSet<Worker>());
		orders.Add(Priority.VeryHigh, new Queue<Order>());
		workers.Add(Priority.ASAP, new HashSet<Worker>());
		orders.Add(Priority.ASAP, new Queue<Order>());
	}

	void handle()
	{
		foreach (Worker w in workers[Priority.Idle])
		{
			handle(w, Priority.Idle);
		}
		foreach (Worker w in workers[Priority.VeryLow])
		{
			handle(w, Priority.VeryLow);
		}
		foreach (Worker w in workers[Priority.Low])
		{
			handle(w, Priority.Low);
		}
		foreach (Worker w in workers[Priority.Normal])
		{
			handle(w, Priority.Normal);
		}
		foreach (Worker w in workers[Priority.High])
		{
			handle(w, Priority.High);
		}
		foreach (Worker w in workers[Priority.VeryHigh])
		{
			handle(w, Priority.VeryHigh);
		}
		foreach (Worker w in workers[Priority.ASAP])
		{
			handle(w, Priority.ASAP);
		}
	}

	void handle(Worker worker, Priority workerPriority)
	{
		if (workerPriority < Priority.ASAP)
		{
			Queue<Order> orderQueue = orders[Priority.ASAP];
			if (orderQueue.Count > 0)
			{
				Order order = orderQueue.Dequeue();
				worker.accept(order);
				return;
			}
		}
		if (workerPriority < Priority.VeryHigh)
		{
			Queue<Order> orderQueue = orders[Priority.VeryHigh];
			if (orderQueue.Count > 0)
			{
				Order order = orderQueue.Dequeue();
				worker.accept(order);
				return;
			}
		}
		if (workerPriority < Priority.High)
		{
			Queue<Order> orderQueue = orders[Priority.High];
			if (orderQueue.Count > 0)
			{
				Order order = orderQueue.Dequeue();
				worker.accept(order);
				return;
			}
		}
		if (workerPriority < Priority.Normal)
		{
			Queue<Order> orderQueue = orders[Priority.Normal];
			if (orderQueue.Count > 0)
			{
				Order order = orderQueue.Dequeue();
				worker.accept(order);
				return;
			}
		}
		if (workerPriority < Priority.Low)
		{
			Queue<Order> orderQueue = orders[Priority.Low];
			if (orderQueue.Count > 0)
			{
				Order order = orderQueue.Dequeue();
				worker.accept(order);
				return;
			}
		}
		if (workerPriority < Priority.VeryLow)
		{
			Queue<Order> orderQueue = orders[Priority.VeryLow];
			if (orderQueue.Count > 0)
			{
				Order order = orderQueue.Dequeue();
				worker.accept(order);
				return;
			}
		}
		if (workerPriority < Priority.Idle)
		{
			Queue<Order> orderQueue = orders[Priority.Idle];
			if (orderQueue.Count > 0)
			{
				Order order = orderQueue.Dequeue();
				worker.accept(order);
				return;
			}
		}
	}
}