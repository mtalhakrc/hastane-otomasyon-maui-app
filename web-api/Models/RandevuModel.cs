using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace web_api.Models;

public class Randevu
{
    public class RandevuModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        [Required]
        [StringLength(100)]
        public string Isim { get; set; }

        [Required]
        public string DoctorID { get; set; }

        [ForeignKey("DoctorID")]
        public IdentityUser Doctor { get; set; }

        [Required]
        public string HastaID { get; set; }

        [ForeignKey("HastaID")]
        public IdentityUser Hasta { get; set; }

        [Required]
        public DateTime Tarih { get; set; }

        public string Not { get; set; }
    }
}