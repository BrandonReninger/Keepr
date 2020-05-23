using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Keepr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class VaultsController : ControllerBase
    {
        private readonly VaultsService _vs;

        public VaultsController(VaultsService vs)
        {
            _vs = vs;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Vault>> GetAll()
        {
            try
            {
                return Ok(_vs.GetAll());
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult<Vault> Create([FromBody] Vault newVault)
        {
            try
            {
                Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                newVault.UserId = user.Value;
                if (user == null)
                {
                    throw new Exception("C'mon man login!");
                }
                newVault.UserId = user.Value;
                return Ok(_vs.Create(newVault));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

    }
}