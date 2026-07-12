using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS_System_Web_API.Models.Entities
{

    [Table("Location_Details")]
    [Index(nameof(LocationCode), IsUnique = true)]   // natural key for upsert
    public class LocationDetail
    {
        [Key]
        [Column("Location_Id")]
        public int LocationId { get; set; }

        [Column("Location_Code")]
        [MaxLength(50)]
        public string LocationCode { get; set; } = null!;

        [Column("Location_Name")]
        [MaxLength(50)]
        public string? LocationName { get; set; }
    }
}