﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dubot.Data.Models
{
    public partial class GuildMember
    {
        [Key]
        public int id { get; set; }
        public long GuildId { get; set; }
        public long UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [StringLength(50)]
        public string Nickname { get; set; }

        [ForeignKey(nameof(GuildId))]
        [InverseProperty("GuildMembers")]
        public virtual Guild Guild { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("GuildMembers")]
        public virtual User User { get; set; }
    }
}