using System.Text.Json;

namespace HWS_LINQ
{
    public class Order
    {
        public string CostumerName { get; set; }
        public int OrderNumber { get; set; }
        public int TotalPrice { get; set; }

        public Order(string costumerName, int orderNumber, int totalPrice)
        {
            CostumerName = costumerName;
            OrderNumber = orderNumber;
            TotalPrice = totalPrice;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

    }
}