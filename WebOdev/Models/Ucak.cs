﻿using System.ComponentModel.DataAnnotations;

namespace WebOdev.Models
{
    public class Ucak
    {
        [Key]
        public int UcakId { get; set; }

        [Required(ErrorMessage = "Lütfen uçak adını giriniz.")]
        [Display(Name = "Uçak Adı")]
        public string UcakAdi { get; set; } = string.Empty;

        [Required(ErrorMessage = "Lütfen koltuk sayısını giriniz.")]
        [Display(Name = "Koltuk Sayısı")]
        public int KoltukSayisi { get; set; }

        [Required(ErrorMessage = "Lütfen fiyatı giriniz.")]
        [Display(Name = "Fiyat")]

        public double Fiyat { get; set; } 

        public int doluKoltukSayisi { get; set; } = 0;

    }
}
