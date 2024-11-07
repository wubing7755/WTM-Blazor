using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WalkingTec.Mvvm.Core;

namespace Blazor.Model
{
    [Table("Player")]
    [Comment("自定义玩家表")]
    public class Player: PersistPoco
    {
        [Display(Name = "玩家名")]
        [Required(ErrorMessage = "{0}是必填项")]
        [MaxLength(10)]
        public string Name { get; set; }

        [Display(Name = "假删除")]
        public new bool IsValid { get; set; }
    }
}
