using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using Blazor.Model;
using System.ComponentModel.DataAnnotations;

namespace Blazor.ViewModel.Play
{
    /// <summary>
    /// 用于包装Player数据，并提供UI所需的功能
    /// </summary>
    public class PlayerVM: BaseCRUDVM<Player>
    {
        public Guid Id { get; set; }

        // 玩家名
        [Display(Name = "玩家名")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Name { get; set; }

        // 假删除
        [Display(Name = "假删除")]
        public bool IsValid { get; set; } = false;

        /// <summary>
        /// 将Player对象映射到PlayerVM对象
        /// </summary>
        /// <param name="player"></param>
        public void LoadFromModel(Player player)
        {
            if (player != null)
            {
                Id = player.Id;
                Name = player.Name;
                IsValid = player.IsValid;
            }
        }

        /// <summary>
        /// 将PlayerVm对象映射到Player对象
        /// </summary>
        /// <param name="playervm"></param>
        /// <returns></returns>
        public Player SaveToModel(PlayerVM playervm)
        {
            return new Player
            {
                Id = playervm.Id,
                Name = playervm.Name,
                IsValid = playervm.IsValid
            };
        }
    }
}
