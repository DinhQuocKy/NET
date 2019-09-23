using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FoodOrderApp.Models
{
    public partial class Foods
    {
        public Foods()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public int FoodPrice { get; set; }
        public string FoodImage { get; set; }
        [JsonIgnore]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
