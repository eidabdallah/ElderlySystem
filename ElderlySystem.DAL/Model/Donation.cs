using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElderlySystem.DAL.Model
{
    public class Donation
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "اسم المتبرع مطلوب.")]
        [StringLength(100, ErrorMessage = "اسم المتبرع يجب ألا يتجاوز 100 حرف.")]
        public string DonorName { get; set; }

        [Required(ErrorMessage = "تاريخ التبرع مطلوب.")]
        public DateTime DonationDate { get; set; }
        public decimal? MonetaryAmount { get; set; }
        public string? Currency { get; set; }
        public string EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public ICollection<Good> Goods { get; set; } = new List<Good>();
    }
}
