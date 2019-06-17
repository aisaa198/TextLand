using System.Collections.Generic;
using System.Web.Http;
using TextLand.BL.Models;
using TextLand.BL.Services.Interfaces;

namespace TextLand.Controllers
{
    public class AdminsController : ApiController
    {
        private readonly IAdminsService _adminsService;

        public AdminsController(IAdminsService adminsService)
        {
            _adminsService = adminsService;
        }

        [Route("api/admins/GetUndonePayoffs")]
        public List<PayoffDto> GetUndonePayoffs(int adminId)
        {
            return _adminsService.GetUndonePayoffs(adminId);
        }

        [HttpPut]
        [Route("api/admins/RealizePayoffs")]
        public List<PayoffDto> RealizePayoffs([FromUri] int adminId, [FromBody] int[] payoffsIds)
        {
            return _adminsService.RealizePayoffs(adminId, payoffsIds);
        }
    }
}
