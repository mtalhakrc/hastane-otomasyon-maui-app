using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace web_api.Models;

    public class RandevuModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [Required]
        [StringLength(100)]
        public string Isim { get; set; }

        public string? DoctorID { get; set; }

        [ForeignKey("DoctorID")]
        public IdentityUser Doctor { get; set; }

        public string? HastaID { get; set; }

        [ForeignKey("HastaID")]
        public IdentityUser Hasta { get; set; }

        [Required]
        public DateTime Tarih { get; set; }

        public string Not { get; set; }
    }
