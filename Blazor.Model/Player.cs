using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace Blazor.Model
{
    [Table("Player")]
    public class Player: PersistPoco
    {
        [Display(Name = "玩家名")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Name { get; set; }

        [Display(Name = "假删除")]
        public new bool IsValid { get; set; } = false;
    }
}
