using POS_System_Web_API.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSSystemWebAPI.Models
{

    [Table("Order_Item")]
    public class OrderItem
    {
        [Key]
        [Column("Item_Id")]
        public int ItemId { get; set; }

        public int? ItemCategoryId { get; set; }
        public int? LocationId { get; set; }

        [Column(TypeName = "numeric(18,4)")] public decimal? StandardCost { get; set; }
        [Column(TypeName = "numeric(18,4)")] public decimal? StandardPrice { get; set; }
        [Column(TypeName = "numeric(18,4)")] public decimal? Margin { get; set; }
        [Column(TypeName = "numeric(18,4)")] public decimal? Quantity { get; set; }
        [Column(TypeName = "numeric(18,4)")] public decimal? FreeQuantity { get; set; }
        [Column(TypeName = "numeric(18,4)")] public decimal? Discount { get; set; }
        [Column(TypeName = "numeric(18,4)")] public decimal? TotalCost { get; set; }
        [Column(TypeName = "numeric(18,4)")] public decimal? TotalSelling { get; set; }

        [MaxLength(50)] public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        [MaxLength(50)] public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsActive { get; set; }

        // navigation — used for joins on GetAll
        [ForeignKey(nameof(ItemCategoryId))] public ItemCategory? ItemCategory { get; set; }
        [ForeignKey(nameof(LocationId))] public LocationDetail? Location { get; set; }
    }
}