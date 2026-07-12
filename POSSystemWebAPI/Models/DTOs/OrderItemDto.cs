namespace POSSystemWebAPI.Models.DTOs
{

    public class OrderItemDto
    {
        public int ItemId { get; set; }              // 0 = new, >0 = update
        public int? ItemCategoryId { get; set; }
        public int? LocationId { get; set; }
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