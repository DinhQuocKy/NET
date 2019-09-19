using System;
using System.Collections.Generic;

namespace FoodOrderApp.Models
{
    public partial class OrderDetails
    {
        public int DetailId { get; set; }
        public int OrderId { get; set; }
        public int FoodId { get; set; }
        public int Quantity { get; set; }

        public virtual Foods Food { get; set; }
        public virtual Orders Order { get; set; }
    }
}
