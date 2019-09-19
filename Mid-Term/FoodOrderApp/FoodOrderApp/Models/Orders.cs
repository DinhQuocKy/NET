using System;
using System.Collections.Generic;

namespace FoodOrderApp.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int OrderId { get; set; }
        public string CusName { get; set; }
        public string CusPhone { get; set; }
        public string CusAddress { get; set; }
        public int TotalPrice { get; set; }
        public DateTime OrderAt { get; set; }
        public bool? OrderStatus { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
