using System;
using Blazor.Model;
using Blazor.ViewModel.Play;
using Microsoft.AspNetCore.Mvc;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Mvc;

namespace Blazor.Areas.Play.Controllers
{
    [Public]
    [ActionDescription("对玩家的相关操作")]
    public class PlayerController:BaseController
    {
        #region 获取
        [ActionDescription("获取玩家信息")]
        public ActionResult GetPlayerInfo(Guid id)
        {
            var vm = Wtm.CreateVM<PlayerVM>(id);
            return PartialView(vm);
        }
        #endregion

        #region 删除
        public ActionResult DeletePlayerInfo(Guid id)
        {
            var vm = Wtm.CreateVM<PlayerVM>(id);
            vm.DoDelete();
            if (!ModelState.IsValid)
            {
                return PartialView(vm);
            }
            else
            {
                return FFResult().CloseDialog().RefreshGrid();
            }
        }
        #endregion

        #region 修改
        public ActionResult EditPlayerInfo(Guid id)
        {
            var vm = Wtm.CreateVM<PlayerVM>(id);
            return PartialView(vm);
        }
        #endregion
    }
}
