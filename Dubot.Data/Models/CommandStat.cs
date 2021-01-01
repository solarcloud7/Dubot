﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dubot.Data.Models
{
    public partial class CommandStat
    {
        [Key]
        public int Id { get; set; }
        public int CommandId { get; set; }
        public long UserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }
        public string ErrorMessage { get; set; }

        [ForeignKey(nameof(CommandId))]
        [InverseProperty(nameof(BotCommand.CommandStats))]
        public virtual BotCommand Command { get; set; }
    }
}