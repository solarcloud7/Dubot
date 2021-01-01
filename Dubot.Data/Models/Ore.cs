﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dubot.Data.Models
{
    public partial class Ore
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string OreName { get; set; }
        [Required]
        [StringLength(50)]
        public string PureName { get; set; }
        [Required]
        [StringLength(50)]
        public string Tier { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Weight { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Volume { get; set; }
    }
}