namespace GroupSummaries.Models
{
    public class OrderService
    {
        List<Order> orders;

        public void CreateOrders()
        {
            orders = new List<Order>();
            Random myRand = new Random();
            for (int i = 0; i < 10; i++)
            {
                Order newOrder = new Order();
                newOrder.OrderID = i;
                newOrder.ProductName = "Product " + i.ToString();
                newOrder.Price = myRand.Next(100, 500);
                newOrder.Quantity = myRand.Next(10, 50);
                newOrder.SomeDate = DateTime.Now.AddDays(i);
                newOrder.Group1 = "Parent Group " + (i % 2).ToString();
                newOrder.Group2 = "Child Group " + (i % 3).ToString();
                newOrder.Discontinued = Convert.ToBoolean(myRand.Next(0, 2));
                orders.Add(newOrder);
            }
        }

        public Task<List<Order>> GetOrdersAsync()
        {
            if (orders == null)
            {
                CreateOrders();
            }
            return Task.FromResult(orders);
        }
    }
}