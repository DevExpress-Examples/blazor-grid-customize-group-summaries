using System.ComponentModel.DataAnnotations;

namespace GroupSummaries.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        [Required]
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public DateTime SomeDate { get; set; }
        public string Group1 { get; set; }
        public string Group2 { get; set; }
        public bool Discontinued { get; set; }
    }
}