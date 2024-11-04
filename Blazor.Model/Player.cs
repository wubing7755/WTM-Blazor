using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace Blazor.Model
{
    [Table("Player")]
    public class Player: PersistPoco
    {
        public Guid Id { get; set; } = new Guid();

        [Display(Name = "玩家名")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Name { get; set; }

        [Display(Name = "假删除")]
        public new bool IsValid { get; set; } = false;
    }
}
