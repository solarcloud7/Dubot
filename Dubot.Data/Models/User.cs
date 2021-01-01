﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dubot.Data.Models
{
    public partial class User
    {
        public User()
        {
            GuildMembers = new HashSet<GuildMember>();
        }

        [Key]
        public long Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastSeen { get; set; }
        [StringLength(50)]
        public string UserName { get; set; }

        [InverseProperty(nameof(GuildMember.User))]
        public virtual ICollection<GuildMember> GuildMembers { get; set; }
    }
}