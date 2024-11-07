using Microsoft.AspNetCore.Mvc;
using WalkingTec.Mvvm.Mvc;
using WalkingTec.Mvvm.Core;
using Blazor.ViewModel.Play;

namespace Blazor.Areas.Play.Controllers
{
    [AuthorizeJwt]
    [ApiController]
    [Route("api/PlayerInfo")]
    public class PlayerController:BaseController
    {
        [ActionDescription("Sys.Create")]
        [HttpPost("AddPlayer")]
        public IActionResult Add(PlayerVM vm)
        {

            if (ModelState.IsValid)
            {
                vm.DoAdd();

            }

            return Ok(vm.Entity);
        }
    }
}
