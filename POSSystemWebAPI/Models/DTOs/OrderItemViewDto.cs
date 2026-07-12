namespace POSSystemWebAPI.Models.DTOs
{

    public class OrderItemViewDto
    {
        public int ItemId { get; set; }
        public string? ItemName { get; set; }
        public string? LocationName { get; set; }
        public decimal? StandardCost { get; set; }
        public decimal? StandardPrice { get; set; }
        public decimal? Margin { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? FreeQuantity { get; set; }
        public decimal? Discount { get; set; }
        public decimal? TotalCost { get; set; }
        public decimal? TotalSelling { get; set; }
    }
}