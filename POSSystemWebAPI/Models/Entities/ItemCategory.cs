using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSSystemWebAPI.Models
{

    [Table("Item_Category")]
    public class ItemCategory
    {
        [Key]
        public int ItemCategoryId { get; set; }

        [MaxLength(50)] public string? Item { get; set; }
        [MaxLength(50)] public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        [MaxLength(50)] public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsActive { get; set; }
    }
}